using System;
using System.Windows.Forms;
using System.Data;

namespace DateTimePicker
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
    private DataTable _table;
    private DataSet _set;

    private System.Windows.Forms.DataGrid _dataGrid;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private ProjectMentor.Windows.Controls.NullableDateTimePicker _dtp;
    private System.Windows.Forms.CheckBox _chkShowUpDown;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

      _set = new DataSet();

      _table = _set.Tables.Add("Table");

      _table.Columns.Add("DateTimeColumn", typeof(DateTime));
      _table.Columns[0].AllowDBNull = true;

      _table.Rows.Add(new object[]{DateTime.Now});
      _table.Rows.Add(new object[]{DBNull.Value});

      _dataGrid.DataSource = _set;
      _dataGrid.DataMember = "Table";

      _dtp.DataBindings.Add("Value", _set, "Table.DateTimeColumn");

      _dtp.Focus();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this._dataGrid = new System.Windows.Forms.DataGrid();
      this._dtp = new ProjectMentor.Windows.Controls.NullableDateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this._chkShowUpDown = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this._dataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // _dataGrid
      // 
      this._dataGrid.AllowNavigation = false;
      this._dataGrid.CaptionVisible = false;
      this._dataGrid.ColumnHeadersVisible = false;
      this._dataGrid.DataMember = "";
      this._dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this._dataGrid.Location = new System.Drawing.Point(8, 128);
      this._dataGrid.Name = "_dataGrid";
      this._dataGrid.Size = new System.Drawing.Size(208, 80);
      this._dataGrid.TabIndex = 0;
      // 
      // _dtp
      // 
      this._dtp.Location = new System.Drawing.Point(8, 96);
      this._dtp.Name = "_dtp";
      this._dtp.NullValue = "<Select Date>";
      this._dtp.Size = new System.Drawing.Size(208, 20);
      this._dtp.TabIndex = 1;
      this._dtp.Value = new System.DateTime(2005, 4, 14, 18, 1, 59, 609);
      this._dtp.ValueChanged += new System.EventHandler(this._dtp_ValueChanged);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(8, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(264, 32);
      this.label1.TabIndex = 2;
      this.label1.Text = "NullableDateTimePicker and DataGrid are bound to the same data source.";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(8, 56);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(256, 32);
      this.label2.TabIndex = 3;
      this.label2.Text = "Press DELETE while NullableDateTimePicker has the focus to enter null value.";
      // 
      // _chkShowUpDown
      // 
      this._chkShowUpDown.Location = new System.Drawing.Point(8, 216);
      this._chkShowUpDown.Name = "_chkShowUpDown";
      this._chkShowUpDown.Size = new System.Drawing.Size(160, 24);
      this._chkShowUpDown.TabIndex = 4;
      this._chkShowUpDown.Text = "ShowUpDown";
      this._chkShowUpDown.CheckedChanged += new System.EventHandler(this._chkShowUpDown_CheckedChanged);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(292, 251);
      this.Controls.Add(this._chkShowUpDown);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._dtp);
      this.Controls.Add(this._dataGrid);
      this.Name = "Form1";
      this.Text = "Nullable DateTimePicker Demo";
      ((System.ComponentModel.ISupportInitialize)(this._dataGrid)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
      Application.EnableVisualStyles();
      Application.DoEvents();
			Application.Run(new Form1());
		}

    private void _chkShowUpDown_CheckedChanged(object sender, System.EventArgs e)
    {
      _dtp.ShowUpDown = _chkShowUpDown.Checked;
    }

    private void _dtp_ValueChanged(object sender, System.EventArgs e)
    {
      this.Focus();
      _dtp.Focus();
    }
	}
}
