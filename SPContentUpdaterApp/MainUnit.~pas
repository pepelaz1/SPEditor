unit MainUnit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, OleCtrls, (*Prisoner_TLB,*) StdCtrls(*, CSActiveX_TLB*), SPEditor_TLB,
   ExtCtrls, SPContentUpdaterUnit, WinSkinData, Buttons;

type
  TMainForm = class(TForm)
    Label1: TLabel;
    WebsiteEdit: TEdit;
    UsernameLabel: TLabel;
    UsernameEdit: TEdit;
    PasswordLabel: TLabel;
    PasswordEdit: TEdit;
    Label4: TLabel;
    LibraryEdit: TEdit;
    Button2: TButton;
    Button5: TButton;
    Label6: TLabel;
    DocumentEdit: TEdit;
    UseCurrCheckBox: TCheckBox;
    Button3: TButton;
    Button4: TButton;
    SkinData1: TSkinData;
    SPContentUpdater1: TSPContentUpdater;
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure UseCurrCheckBoxClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure SPContentUpdater1ContentTypeChange(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
    procedure UpdateCredControls;
  public
    { Public declarations }
  end;

var
  MainForm: TMainForm;

implementation

{$R *.dfm}

procedure TMainForm.Button2Click(Sender: TObject);
begin
  try
    Screen.Cursor := crHourglass;
    with SPContentUpdater1 do
    begin
       Website := WebsiteEdit.Text;
       Username := UsernameEdit.Text;
       Password := PasswordEdit.Text;
       Lib := LibraryEdit.Text;

       LoadContentTypes;
    end;

    (*with SPEditorCtrl1.DefaultInterface do
    begin
     // BackColor := RGB(255,0,0);
     // ForeColor := RGB(0,0,255);
      Website := WebsiteEdit.Text;
      Username := UsernameEdit.Text;
      Password := PasswordEdit.Text;
      Library_ := LibraryEdit.Text;

      LoadContentTypes;
    end; *)
   finally
    Screen.Cursor := crDefault;
   end;
end;

procedure TMainForm.Button1Click(Sender: TObject);
var r: TStringList;
    i: integer;
    msg: string;
begin
   try
    Screen.Cursor := crHourglass;
    r := SPContentUpdater1.Validate;
    if (r.Count <> 0) then
    begin
       msg := 'Following required fields are not filled: ';
       for i := 0 to r.Count-1 do
       begin
         msg := msg + r[i];
         if ( i < r.Count-1 ) then
           msg := msg + ', ';
       end;
       ShowMessage (msg);
    end
    else
      SPContentUpdater1.Save;
   finally
    Screen.Cursor := crDefault;
   end;
end;

procedure TMainForm.UseCurrCheckBoxClick(Sender: TObject);
begin
   UpdateCredControls;
end;

procedure TMainForm.FormCreate(Sender: TObject);
begin
  UpdateCredControls;

  SetWindowLong(Button2.Handle, GWL_STYLE,  GetWindowLong(Button2.Handle, GWL_STYLE) or BS_MULTILINE);
end;

procedure TMainForm.UpdateCredControls;
begin
  UsernameEdit.Enabled := not UseCurrCheckBox.Checked;
  UsernameLabel.Enabled := not UseCurrCheckBox.Checked;
  PasswordEdit.Enabled := not UseCurrCheckBox.Checked;
  PasswordLabel.Enabled := not UseCurrCheckBox.Checked;

 // SPEditorCtrl1.DefaultInterface.UseCurrentCredentials :=  UseCurrCheckBox.Checked ;
end;

procedure TMainForm.Button5Click(Sender: TObject);
begin
   try
    Screen.Cursor := crHourglass;
    SPContentUpdater1.Commit(DocumentEdit.Text);
   finally
    Screen.Cursor := crDefault;
   end;
end;


procedure TMainForm.SPContentUpdater1ContentTypeChange(Sender: TObject);
begin
  SkinData1.UpdateSkinControl(self);
//  SPContentUpdater1.Refresh;
  SPContentUpdater1.Hide;
  SPContentUpdater1.Show;
end;

procedure TMainForm.Button3Click(Sender: TObject);
begin
   try
    Screen.Cursor := crHourglass;
    SPContentUpdater1.Reset;
   finally
    Screen.Cursor := crDefault;
   end;
end;

end.
