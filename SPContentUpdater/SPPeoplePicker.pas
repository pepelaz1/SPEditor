unit SPPeoplePicker;

interface

uses 
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Buttons, StdCtrls, SearchUser, SPEditor_TLB;

type
  TSPPeoplePicker = class(TFrame)
    SpeedButton1: TSpeedButton;
    Edit1: TEdit;
    procedure SpeedButton1Click(Sender: TObject);
  private
    { Private declarations }
    FUserID: integer;
    FUserName: string;
    FSPEditor: TSPEditorCtrl;
    FSearchUserForm: TSearchUserForm;
  protected
    { Protected declarations }
  public
    { Public declarations }
    procedure SetData(AUserID: integer; AUserName: string);

    property SPEditorCtrl: TSPEditorCtrl read FSPEditor write FSPEditor;
    property UserName: string read FUserName;
    property UserID: integer read FUserID;


  published
    { Published declarations }
  end;

procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('Samples', [TSPPeoplePicker]);
end;
{$R *.dfm}

procedure TSPPeoplePicker.SpeedButton1Click(Sender: TObject);
begin
  FSearchUserForm := TSearchUserForm.Create(self);
  FSearchUserForm.SPEditorCtrl := SPEditorCtrl;
  FSearchUserForm.ShowModal;

  FUserID := FSearchUserForm.UserID;
  FUserName := FSearchUserForm.UserName;
  Edit1.Text := FUserName;
end;

procedure TSPPeoplePicker.SetData(AUserID: integer; AUserName: string);
begin
  FUserID := AUserID;
  FUserName := AUserName;
  Edit1.Text := FUserName;
end;

end.
