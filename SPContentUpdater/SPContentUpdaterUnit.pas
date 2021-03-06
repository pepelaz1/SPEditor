unit SPContentUpdaterUnit;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs, SPEditor_TLB,
  StdCtrls, ActiveX, SPItem;

type
  TContentTypeChangeEvent = procedure(Sender: TObject) of object;

  TSPContentUpdater = class(TFrame)
    lblContentTypes: TLabel;
    ComboBox1: TComboBox;
    ScrollBox1: TScrollBox;
    lblFields: TLabel;

    procedure ComboBox1Change(Sender: TObject);
  private
    { Private declarations }
    FOnContentTypeChange: TContentTypeChangeEvent;

    FContentTypeLabelText: string;
    FFieldsLabelText: string;

    FWebsite: WideString;
    FUsername: WideString;
    FPassword: WideString;
    FLib: WideString;

    FSPEditor: TSPEditorCtrl;
    FControls: TList;
    FSPItems: TList;
    FYOffset: integer;

    procedure SetContentType;
    procedure RemoveControls;
    procedure RebuildFields;
    function CreateSPItem(i: integer) : TSPItem;
    function GetContentTypeLabelText: string;
    procedure SetContentTypeLabelText(AValue: string);
    function GetFieldsLabelText: string;
    procedure SetFieldsLabelText(AValue: string);
  public
    { Public declarations }
    procedure LoadContentTypes;
    constructor Create(AOwner: TComponent);override;
    destructor Destroy; override;
    procedure Reset;
    function Validate: TStringList;
    procedure Save;
    procedure Commit(ADocument: string);
  published
    { Published declarations }
    property ContentTypeLabelText: string read GetContentTypeLabelText write SetContentTypeLabelText;
    property FieldsLabelText: string read GetFieldsLabelText write SetFieldsLabelText;

    property Website: WideString read FWebsite write FWebsite;
    property Username: WideString read FUsername write FUsername;
    property Password: WideString read FPassword write FPassword;
    property Lib: WideString read FLib write FLib;

     property OnContentTypeChange: TContentTypeChangeEvent read FOnContentTypeChange write FOnContentTypeChange;
  end;

procedure Register;

implementation

procedure Register;
begin
  RegisterComponents('Samples', [TSPContentUpdater]);
end;
{$R *.dfm}

constructor TSPContentUpdater.Create(AOwner: TComponent);
begin
 inherited Create(AOwner);
 FSPEditor := TSPEditorCtrl.Create(self);
 FControls := TList.Create;
 FSPItems := TList.Create;
 lblContentTypes.Caption := ContentTypeLabelText;
 lblFields.Caption := FieldsLabelText;
end;

destructor  TSPContentUpdater.Destroy;
begin
// RemoveControls;
 FSPEditor := nil;
 inherited;
end;

function TSPContentUpdater.GetContentTypeLabelText : string;
begin
  if FContentTypeLabelText <> '' then
    Result := FContentTypeLabelText
  else
    Result := 'Content types:';
end;

function TSPContentUpdater.GetFieldsLabelText : string;
begin
  if FFieldsLabelText <> '' then
    Result := FFieldsLabelText
  else
    Result := 'Fields:';
end;


procedure TSPContentUpdater.SetContentTypeLabelText(AValue: string);
begin
  FContentTypeLabelText := AValue;
  lblContentTypes.Caption := ContentTypeLabelText;
end;

procedure TSPContentUpdater.SetFieldsLabelText(AValue: string);
begin
  FFieldsLabelText := AValue;
  lblFields.Caption := FieldsLabelText;
end;


procedure TSPContentUpdater.Reset;
var i: integer;
    spi: TSPItem;
begin
 for i:=0 to FSPItems.Count-1 do
 begin
   spi := FSPItems[i];
   spi.Reset;
 end;
end;

function TSPContentUpdater.Validate: TStringList;
var r: TStringList;
    i: integer;
    spi: TSPItem;
    val: string;
begin
  r := TStringList.Create;
  for i := 0 to FSPItems.Count - 1 do
  begin
    spi := FSPItems[i];
    val := spi.TrySave();
    if (spi.Required = true) and (val = '') then
      r.Add(spi.Title);
  end;
  Result := r;
end;

procedure TSPContentUpdater.Save;
var i: integer;
    spi: TSPItem;
begin
 for i:=0 to FSPItems.Count-1 do
 begin
   spi := FSPItems[i];
   spi.Save;
 end;
end;

procedure  TSPContentUpdater.RemoveControls;
var ctrl: TControl;
    i: integer;
begin
 for i:=0 to FControls.Count-1 do
 begin
   ctrl := FControls[i];
   ctrl.Parent := nil;
   FreeAndNil(ctrl);
 end;
 FControls.Clear;
end;


procedure TSPContentUpdater.LoadContentTypes;
 var  i,cnt: integer;
      s: string;
begin
  with FSPEditor.DefaultInterface do
  begin
    Website := self.Website;
    Username := self.Username;
    Password := self.Password;
    Library_ := self.Lib;
    LoadContentTypes();

    ComboBox1.Clear;
    cnt := GetContentTypesCount();
    for i := 0 to cnt - 1 do
    begin
      s := GetContentTypeName(i);
      ComboBox1.Items.Add(s);
    end;
    ComboBox1.ItemIndex := 0;
    SetContentType;
  end;
end;

procedure TSPContentUpdater.ComboBox1Change(Sender: TObject);
begin
  SetContentType;
end;

procedure TSPContentUpdater.SetContentType;
begin
  try // TODO
    Screen.Cursor := crHourglass;
    FSPEditor.DefaultInterface.SwitchContentType(ComboBox1.ItemIndex);
    FYOffset := 5;
    RebuildFields;

    if Assigned(FOnContentTypeChange) then
     FOnContentTypeChange(Self);

  finally
    Screen.Cursor := crDefault;
  end;
end;

procedure  TSPContentUpdater.RebuildFields;
var lbl_a, lbl, ctrl: TControl;
    i: integer;
    internalName: string;
    spi: TSPItem;
    suff: string;
begin
  RemoveControls;

  FSPItems.Clear;
  ScrollBox1.AutoScroll := false;

  with FSPEditor.DefaultInterface do
  begin
    for i := 0 to GetFieldsCount-1 do
    begin
      internalName := GetFieldInternalName(i);
      if ( internalName <> 'ContentType') and (internalName <> 'FileLeafRef') and (IsFieldHidden(i) = false) and (IsFieldReadOnly(i) = false) then
      begin
         lbl_a := TLabel.Create(self);
         lbl_a.Parent := ScrollBox1;
         lbl_a.Left := 5;
         lbl_a.Top := FYOffset + 5;
         suff := ' ';
         if  IsFieldRequired(i) = true then
           suff := '*';
         (lbl_a as TLabel).Caption := suff;
         FControls.Add(lbl_a);


         lbl := TLabel.Create(self);
         lbl.Parent := ScrollBox1;
         (lbl as TLabel).Caption := GetFieldTitle(i);
         lbl.Left := 12;
         lbl.Top := FYOffset + 5;

         FControls.Add(lbl);

         spi := CreateSPItem(i);
         ctrl := spi.Ctrl;
         FControls.Add(ctrl);
         ctrl.Left := 110;
         ctrl.Top := FYOffset;
//         ctrl.Width := ScrollBox1.Width - 120;
         ctrl.Anchors := [akLeft, akRight,akTop];
         spi.AdjustWidth( ScrollBox1.Width  );

         FYOffset := FYOffset + ctrl.Height + 5;
      end;
    end;
     ScrollBox1.AutoScroll := true;
  end
end;

function TSPContentUpdater.CreateSPItem(i: integer) : TSPItem;
var spi: TSPItem;
    fieldType: WideString;
begin
 with FSPEditor.DefaultInterface do
 begin
   fieldType := GetFieldTypeString(i);
   if (fieldType = 'Text') then
      spi := TSPTextItem.Create
   else if (fieldType = 'DateTime') then
      spi := TSPDateTimeItem.Create
   else if (fieldType = 'Boolean') then
      spi := TSPBooleanItem.Create
   else if (fieldType = 'Note') then
      spi := TSPNoteItem.Create
   else if (fieldType = 'Number') then
      spi := TSPNumberItem.Create
   else if (fieldType = 'Currency') then
      spi := TSPCurrencyItem.Create
   else if (fieldType = 'Choice') then
      spi := TSPChoiceItem.Create
   else if (fieldType = 'Lookup') then
      spi := TSPLookupItem.Create
   else if (fieldType = 'User') then
      spi := TSPUserItem.Create
   else if (fieldType = 'URL') or (fieldType = 'Link') then
      spi := TSPUrlItem.Create;


   if Assigned(spi) then
   begin
     spi.Make(i, FSPEditor, ScrollBox1, GetFieldValue(i));
     FSPItems.Add(spi);
   end;
 end;
 Result := spi;
end;

procedure TSPContentUpdater.Commit(ADocument: string);
begin
   FSPEditor.Commit(ADocument);
end;

end.
