unit SearchUser;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, SPEditor_TLB;

type
  TSearchUserForm = class(TForm)
    Label1: TLabel;
    Edit1: TEdit;
    SpeedButton1: TSpeedButton;
    ListBox1: TListBox;
    btnCancel: TButton;
    btnSave: TButton;
    procedure btnCancelClick(Sender: TObject);
    procedure btnSaveClick(Sender: TObject);
    procedure SpeedButton1Click(Sender: TObject);
    procedure ListBox1Click(Sender: TObject);
  private
    { Private declarations }
    FCount: integer;
    FUserID: integer;
    FUserName: string;
    FSPEditor: TSPEditorCtrl;

    procedure Save;
  public
    { Public declarations }
    property SPEditorCtrl: TSPEditorCtrl read FSPEditor write FSPEditor;
    property UserID: integer read FUserID;
    property UserName: string read FUserName;
  end;

var
  SearchUserForm: TSearchUserForm;

implementation

{$R *.dfm}

procedure TSearchUserForm.btnCancelClick(Sender: TObject);
begin
  Close;
end;

procedure TSearchUserForm.btnSaveClick(Sender: TObject);
begin
  Save;
end;

procedure TSearchUserForm.SpeedButton1Click(Sender: TObject);
var i: integer;
begin
   Screen.Cursor := crHourglass;
   FCount := FSPEditor.GetUserList(Edit1.Text);
   ListBox1.Clear;
   for i := 0 to FCount-1 do
   begin
    ListBox1.Items.AddObject(FSPEditor.GetUserName(i), TObject(FSPEditor.GetUserId(i)));
   end;
   Screen.Cursor := crDefault;
end;

procedure TSearchUserForm.ListBox1Click(Sender: TObject);
begin
  Save;
end;

procedure TSearchUserForm.Save;
begin
  if ( ListBox1.ItemIndex <> -1) then
  begin
   FUserName := ListBox1.Items[ListBox1.ItemIndex];
   FUserID := integer(ListBox1.Items.Objects[ListBox1.ItemIndex]);
  end;
  Close;
end;


end.
