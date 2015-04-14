#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
using System.Security.Permissions;
using Microsoft.SharePoint.Client;
using System.Net;
using System.Security.Principal;
using System.Globalization;
#endregion


namespace SPEditor
{
    #region Interfaces

    /// <summary>
    /// ISPEditorCtrl describes the COM interface of the coclass 
    /// </summary>
    [Guid("58399E6E-12E3-41A9-835C-453CE8A28FB5")]
    public interface ISPEditorCtrl
    {
        #region Properties

        bool Visible { get; set; }          // Typical control property
        bool Enabled { get; set; }          // Typical control property
        int ForeColor { get; set; }         // Typical control property
        int BackColor { get; set; }         // Typical control property
  
        String Website { get; set; }   // SharePoint Website
        String Username { get; set; }   // Username and password
        String Password { get; set; }
        bool UseCurrentCredentials { get; set; } 

        String Library { get; set; }    // Library on SharePoint Site
        String Folder { get; set; }     // Folder in library
        #endregion

        #region Methods

        void LoadContentTypes();            // Loading content types for specified library/folder
        void SwitchContentType(int i);
        int GetContentTypesCount();
        string GetContentTypeName(int i);

        string GetFieldInternalName(int i);
        string GetFieldTitle(int i);
        string GetFieldValue(int i);
        void SetFieldValue(int i, string value);
        int GetFieldsCount();
        bool IsFieldHidden(int i);
        bool IsFieldReadOnly(int i);
        bool IsFieldRequired(int i);
        string GetFieldDefaultValue(int i);
        string GetFieldTypeString(int i);

        // Choice
        int GetChoicesCount(int i);
        string GetChoice(int i, int j);

        // Lookup
        int GetLookupsCount(int i);
        string GetLookup(int i, int j);

        // People picker
        int GetUserList(string part);
        int GetUserId(int i);
        string GetUserName(int i);

        //void Save();
        //void Reset();
        void Commit(String document);                      // Commit metadate to server
 
        #endregion
    }

    /// <summary>
    /// ISPEditorCtrlEvents describes the events the coclass can sink
    /// </summary>
    //[Guid("C3E9D49B-F8D2-459A-8C47-F693014ECB5C")]
    //[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    //// The public interface describing the events of the control
    //public interface ISPEditorCtrlEvents
    //{
    //    #region Events

    //    // Must explicitly define DISPID for each event, otherwise, the 
    //    // callback address cannot be found when the event is fired.
    //    [DispId(1)]
    //    void Click();
    //    [DispId(2)]
    //    void FloatPropertyChanging(float NewValue, ref bool Cancel);

    //    #endregion
    //}

    #endregion

    [ClassInterface(ClassInterfaceType.None)]
   // [ComSourceInterfaces(typeof(ISPEditorCtrlEvents))]
    [Guid("0B5DE32F-04A1-45D0-9AD1-1AF095A76336")]
    public partial class SPEditorCtrl : UserControl, ISPEditorCtrl
    {
        #region ActiveX Control Registration

        // These routines perform the additional COM registration needed by 
        // ActiveX controls

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComRegisterFunction()]
        public static void Register(Type t)
        {
            try
            {
                ActiveXCtrlHelper.RegasmRegisterControl(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the error
                throw;  // Re-throw the exception
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComUnregisterFunction()]
        public static void Unregister(Type t)
        {
            try
            {
                ActiveXCtrlHelper.RegasmUnregisterControl(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the error
                throw; // Re-throw the exception
            }
        }

        #endregion

        #region Private variables
        private SPFormGenerator _frmGen;
        private Dictionary<String,SPMetadataHolder> _metadata;
      //  private Dictionary<String, String> _fieldsForUpdate;
        #endregion

        #region Initialization

        public SPEditorCtrl()
        {
            InitializeComponent();

            // For the Click event that is re-defined.
          //  base.Click += new EventHandler(SPEditor_Click);

            // These functions are used to handle Tab-stops for the ActiveX 
            // control (including its child controls) when the control is 
            // hosted in a container.
            LostFocus += new EventHandler(SPEditor_LostFocus);
            ControlAdded += new ControlEventHandler(SPEditor_ControlAdded);

            // Raise custom Load event
            OnCreateControl();

            _frmGen = new SPFormGenerator();
            _frmGen.Container = pnlForm;

            _metadata = new Dictionary<String, SPMetadataHolder>();

         //   _fieldsForUpdate = new Dictionary<String, String>();
        }

        // This event will hook up the necessary handlers
        void SPEditor_ControlAdded(object sender, ControlEventArgs e)
        {
            // Register tab handler and focus-related event handlers for 
            // the control and its child controls.
            ActiveXCtrlHelper.WireUpHandlers(e.Control, ValidationHandler);
        }

        // Ensures that the Validating and Validated events fire properly
        internal void ValidationHandler(object sender, System.EventArgs e)
        {
            if (this.ContainsFocus) return;

            this.OnLeave(e); // Raise Leave event

            if (this.CausesValidation)
            {
                CancelEventArgs validationArgs = new CancelEventArgs();
                this.OnValidating(validationArgs);

                if (validationArgs.Cancel && this.ActiveControl != null)
                    this.ActiveControl.Focus();
                else
                    this.OnValidated(e); // Raise Validated event
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_SETFOCUS = 0x7;
            const int WM_PARENTNOTIFY = 0x210;
            const int WM_DESTROY = 0x2;
            const int WM_LBUTTONDOWN = 0x201;
            const int WM_RBUTTONDOWN = 0x204;
         //   const int WM_KEYDOWN = 0x0100;

            if (m.Msg == WM_SETFOCUS)
            {
                // Raise Enter event
                this.OnEnter(System.EventArgs.Empty);
            }
            else if (m.Msg == WM_PARENTNOTIFY && (
                m.WParam.ToInt32() == WM_LBUTTONDOWN ||
                m.WParam.ToInt32() == WM_RBUTTONDOWN))
            {
                if (!this.ContainsFocus)
                {
                    // Raise Enter event
                    this.OnEnter(System.EventArgs.Empty);
                }
            }
            else if (m.Msg == WM_DESTROY &&
                !this.IsDisposed && !this.Disposing)
            {
                // Used to ensure the cleanup of the control
                this.Dispose();
            }

            base.WndProc(ref m);
        }

        // Ensures that tabbing across the container and the .NET controls
        // works as expected
        void SPEditor_LostFocus(object sender, EventArgs e)
        {
            ActiveXCtrlHelper.HandleFocus(this);
        }
        #endregion

        #region Properties

        public new int ForeColor
        {
            get { return ActiveXCtrlHelper.GetOleColorFromColor(base.ForeColor); }
            set { base.ForeColor = ActiveXCtrlHelper.GetColorFromOleColor(value); }
        }

        public new int BackColor
        {
            get { return ActiveXCtrlHelper.GetOleColorFromColor(base.BackColor); }
            set { base.BackColor = ActiveXCtrlHelper.GetColorFromOleColor(value); }
        }

     //   private float fField = 0;

        /// <summary>
        /// A custom property with both get and set accessor methods.
        /// </summary>
        public String Website { get; set; }   
        public String Username { get; set; }   
        public String Password { get; set; }
        public bool UseCurrentCredentials { get; set; }
        public String Library { get; set; }    
        public String Folder { get; set; }

        private FieldCollection _fieldCol;
        private ContentType _currentContentType;

        #endregion

        #region Public methods

       
        public void LoadContentTypes()
        {
           // Username = "bvv2";
           // Password = "byjgkfytnzyby";
          //  Library = "TestLib";
           // Website = "http://tstshp02";

            //MessageBox.Show("Website = " + Website + " Username = " + Username + " Password = " + Password);

            CBContentTypeItem[] result = null;
            using (ClientContext ctx = new ClientContext(Website))
            {
                NetworkCredential userCredentials = UseCurrentCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(Username, Password);
                ctx.Credentials = userCredentials;


               // string[] parts = Library.Split("/".ToCharArray());

                Web web = ctx.Web; 
                List list = web.Lists.GetByTitle(Library);
               // List list = web.Lists.GetByTitle(parts[0]);
                
                ContentTypeCollection contentTypeColl = list.ContentTypes;
                ctx.Load(contentTypeColl);
                ctx.ExecuteQuery();

               // MessageBox.Show("Website = " + Website + " Username = " + Username + " Password = " + Password);

                result = new CBContentTypeItem[contentTypeColl.Count];
                cmbContentTypes.Items.Clear();
                foreach (ContentType contentType in contentTypeColl)
                {
                    var o = new CBContentTypeItem(contentType);
                   // if (parts.Length > 1)
                   // {
                        if (!string.IsNullOrEmpty(contentType.DocumentTemplate) && contentType.Group != "Special Content Types")
                        {
                            cmbContentTypes.Items.Add(o);
                        }
                   // }
                   // else
                   //    cmbContentTypes.Items.Add(o);
                }
            }
            cmbContentTypes.SelectedIndex = 0;

          //  cmbContentTypes.Focus();
          //  btnReset.Focus();
          //  cmbContentTypes.Focus();
           // btnReset.Focus();
        }

        public int GetContentTypesCount()
        {
            return cmbContentTypes.Items.Count;
        }

        public string GetContentTypeName(int i)
        {
            ContentType ct = ((CBContentTypeItem)cmbContentTypes.Items[i]).ContentType;
            return ct.Name;
        }

        public void SwitchContentType(int i)
        {
            ContentType ct = ((CBContentTypeItem)cmbContentTypes.Items[i]).ContentType;
            _currentContentType = ct;
            LoadContentType(ct);
        }

        public string GetFieldInternalName(int i)
        {
            return _fieldCol[i].InternalName;
        }

        public string GetFieldTitle(int i)
        {
            return _fieldCol[i].Title;
        }

        public string GetFieldValue(int i)
        {
            SPContentItem ci = _metadata[Library].ContentItems[_currentContentType.Id.ToString()];
            SPItem item = ci.Items[_fieldCol[i].InternalName];
            return item.Value;
        }

        public void SetFieldValue(int i, string value)
        {
            SPContentItem ci = _metadata[Library].ContentItems[_currentContentType.Id.ToString()];
            SPItem item = ci.Items[_fieldCol[i].InternalName];
            item.Value = value;
        }

        public int GetFieldsCount()
        {
            return _fieldCol.Count;
        }

        public bool IsFieldHidden(int i)
        {
            return _fieldCol[i].Hidden;
        }

        public bool IsFieldReadOnly(int i)
        {
            return _fieldCol[i].ReadOnlyField;
        }

        public bool IsFieldRequired(int i)
        {
            return _fieldCol[i].Required;
        }

        public string GetFieldDefaultValue(int i)
        {
            return _fieldCol[i].DefaultValue;
        }


        public string GetFieldTypeString(int i)
        {
            return _fieldCol[i].TypeAsString;
        }

        public int GetChoicesCount(int i)
        {
            FieldChoice fc = _fieldCol[i] as FieldChoice;
            return fc.Choices.Length;
        }

        public string GetChoice(int i, int j)
        {
            FieldChoice fc = _fieldCol[i] as FieldChoice;
            return fc.Choices[j];
        }

        public int GetLookupsCount(int i)
        {
            SPContentItem ci = _metadata[Library].ContentItems[_currentContentType.Id.ToString()];
            SPLookupItem item = ci.Items[_fieldCol[i].InternalName] as SPLookupItem;
            return item.GetLookupsCount();
       
        }

        public string GetLookup(int i, int j)
        {
            SPContentItem ci = _metadata[Library].ContentItems[_currentContentType.Id.ToString()];
            SPLookupItem item = ci.Items[_fieldCol[i].InternalName] as SPLookupItem;
            return item.GetLookup(j);
        }

        private List<LBUserData> _users = new List<LBUserData>();

        public int GetUserList(string part)
        {
            if (part == null)
                part = "";
            _users.Clear();
            using (ClientContext ctx = new ClientContext(Website))
            {

                NetworkCredential userCredentials = UseCurrentCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(Username, Password);
                ctx.Credentials = userCredentials;

                GroupCollection groupCollection = ctx.Web.SiteGroups;
                ctx.Load
                    (groupCollection,
                     groups => groups.Include(
                     group => group.Users));
                ctx.ExecuteQuery();

                foreach (Group group in groupCollection)
                {
                    UserCollection userCollection = group.Users;
                    foreach (User user in userCollection)
                    {
                        if (user.Title.Contains(part))
                        {
                            LBUserData lbd = new LBUserData(user.Id, user.Title);
                            _users.Add(lbd);
                        }
                    }
                }
            }
            return _users.Count;
        }

        public int GetUserId(int i)
        {
            return _users[i].ID;
        }

        public string GetUserName(int i)
        {
            return _users[i].Value;
        }

        public void Commit(String document)
        {
            Uri uri = new Uri(document);
            
            using (ClientContext ctx = new ClientContext(Website))
            {
                NetworkCredential userCredentials = UseCurrentCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(Username, Password);
                ctx.Credentials = userCredentials;

                //<Value Type='Text'>" + uri.Segments[uri.Segments.Length-1] +@"</Value>
   
                string path = "";
                for ( int i = 0; i < uri.Segments.Length - 1; i++)
                    path += uri.Segments[i];

                List lst = ctx.Web.Lists.GetByTitle(Library);
                CamlQuery camlQuery = new CamlQuery();
                camlQuery.FolderServerRelativeUrl = path;
                camlQuery.ViewXml =
                    @"<View>
                        <Query>
                          <Where>
                            <Eq>
                              <FieldRef Name='FileLeafRef'/>
                              
                               <Value Type='Text'>" + uri.Segments[uri.Segments.Length - 1] + @"</Value>
                            </Eq>
                          </Where>
                          <RowLimit>1</RowLimit>
                        </Query>
                      </View>";

                ctx.Load(lst);

                ListItemCollection itemsCol = lst.GetItems(camlQuery);
                ctx.Load(itemsCol);

                ctx.ExecuteQuery();

                foreach (ListItem item in itemsCol)
                {
                    List<String> fields = new List<String>();
                    foreach (KeyValuePair<String, Object> fv in item.FieldValues)
                        fields.Add(fv.Key);

                    SPContentItem ci = _metadata[Library].ContentItems[item.FieldValues["ContentTypeId"].ToString()];
                    foreach (String fld in fields)
                    {
                        if (ci.Items.ContainsKey(fld))
                            ci.Items[fld].SetValue(item);
                   }
                   item.Update();

                   try
                   {
                       User u = item.File.CheckedOutByUser;
                       ctx.Load(u);
                       ctx.ExecuteQuery();

                       String login = u.LoginName;
                       item.File.CheckIn("", CheckinType.MinorCheckIn);
                   }
                   catch (Exception)
                   {
                   }
                }
                ctx.ExecuteQuery(); // important, commit changes to the server
            }
        }

        #endregion

        #region Private methods
        
        private void LoadContentType(ContentType contentType)
        {
            using (ClientContext clientContext = new ClientContext(Website))
            {
                Web web = clientContext.Web;
                NetworkCredential userCredentials = new NetworkCredential(Username, Password);
                clientContext.Credentials = userCredentials;

                //string[] parts = Library.Split("/".ToCharArray());

                String id = contentType.Id.ToString();
                ContentType cntType = web.Lists.GetByTitle(Library).ContentTypes.GetById(contentType.Id.ToString());
                _fieldCol = cntType.Fields;
                clientContext.Load(_fieldCol);
                clientContext.ExecuteQuery();

                SPMetadataHolder mdh = null;
                if (!_metadata.ContainsKey(Library))
                {
                     mdh = new SPMetadataHolder();
                    _metadata[Library] = mdh;
                }
                mdh = _metadata[Library];

                SPContentItem ci = null;
                if (!mdh.ContentItems.ContainsKey(contentType.Id.ToString()))
                {
                    ci = new SPContentItem();
                    mdh.ContentItems[contentType.Id.ToString()] = ci;
                }
                ci = mdh.ContentItems[contentType.Id.ToString()];

                _frmGen.Website = Website;
                _frmGen.Username = Username;
                _frmGen.Password = Password;
                _frmGen.UseCurrentCredentials = UseCurrentCredentials;
                _frmGen.Generate(_fieldCol, ci);

                //lbFields.Items.Clear();
                //foreach (Field field in fieldColl)
                //    lbFields.Items.Add("Title:" + field.Title + "; Type:" + field.TypeAsString + "; Requried:" +field.Required.ToString());
            }
        }

        //public void Save()
        //{
        //    SPContentItem ci = _metadata[Library].ContentItems[_currentContentType.Id.ToString()];
        //    if (_frmGen.Validate(ci))
        //        _frmGen.Save(ci);
        //}

        //public void Reset()
        //{
        //    _metadata.Clear();
        //    LoadContentType(_currentContentType);
        //}

        private void SaveMetadata()
        {
            ContentType ct = (cmbContentTypes.SelectedItem as CBContentTypeItem).ContentType;
            SPContentItem ci = _metadata[Library].ContentItems[ct.Id.ToString()];
            if (_frmGen.Validate(ci))
                _frmGen.Save(ci);
        }

        private void ClearMetadata()
        {
            _metadata.Clear();
            LoadContentType((cmbContentTypes.SelectedItem as CBContentTypeItem).ContentType);
        }
        #endregion

        #region Events

        // This section shows the examples of exposing a control's events.
        // Typically, you just need to
        // 1) Declare the event as you want it.
        // 2) Raise the event in the appropriate control event.

      //  [ComVisible(false)]
      //  public delegate void ClickEventHandler();
       // public new event ClickEventHandler Click = null;
      //  void SPEditor_Click(object sender, EventArgs e)
      ////  {
     //       if (null != Click) Click(); // Raise the new Click event.
      //  }

     //   [ComVisible(false)]
      //  public delegate void FloatPropertyChangingEventHandler(float NewValue, ref bool Cancel);
     //   public event FloatPropertyChangingEventHandler FloatPropertyChanging = null;

        #endregion
        
        #region Message handlers
        private void cmbContentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContentType((cmbContentTypes.SelectedItem as CBContentTypeItem).ContentType);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMetadata();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearMetadata();
        }
        #endregion

  
    }

} 
