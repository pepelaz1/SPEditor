unit SPItem;

interface

uses
  Controls, StdCtrls, ComCtrls,  SPEditor_TLB, SysUtils, Classes, SPPeoplePicker,DateUtils, Windows;

type

  TSPItem = class
  private
    FFieldNumber: integer;
    FRequired: boolean;
    FValue: string;
    FTitle: string;
    FControl: TControl;
    FSPEditor: TSPEditorCtrl;
  protected
    procedure CheckDefaultValue;virtual;
  public
    property Required: boolean read FRequired write FRequired;
    property Value: string read FValue;
    property Title: string read FTitle;
    property Ctrl: TControl read FControl;
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);virtual;
    procedure Save;virtual;abstract;
    function TrySave: string;virtual;abstract;
    procedure Reset;virtual;abstract;
    procedure AdjustWidth(AParentWidth: integer);virtual;
  end;

  TSPTextItem = class(TSPItem)
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPDateTimeItem = class(TSPItem)
  private
    FFormat: string;
    procedure DateTimePickerChange(Sender: TObject);
    function ConvertToDate(AValue:string): TDateTime;
    function ConvertToDateSP(AValue:string): TDateTime;
  protected
    procedure CheckDefaultValue;override;
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPBooleanItem = class(TSPItem)
  protected
    procedure CheckDefaultValue;override;
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPNoteItem = class(TSPItem)
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPNumberItem = class(TSPItem)
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPCurrencyItem = class(TSPItem)
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPChoiceItem = class(TSPItem)
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPLookupItem = class(TSPItem)
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPUserItem = class(TSPItem)
  private
    FUserID: integer;
    FUserName: string;
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

  TSPUrlItem = class(TSPItem)
  public
    procedure Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);override;
    procedure Save;override;
    function TrySave: string;override;
    procedure Reset;override;
  end;

implementation
	
procedure Split(Delimiter: Char; Str: string; ListOfStrings: TStrings) ;
begin
   ListOfStrings.Clear;
   ListOfStrings.Delimiter     := Delimiter;
   ListOfStrings.DelimitedText := Str;
end;

// TSPItem
procedure TSPItem.Make (AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
    FSPEditor := ASPEditor;
    FFieldNumber := AFieldNumber;
    FControl.Parent := AParent;
    FValue := AValue;

    CheckDefaultValue();

    if FValue = '' then
       FValue := FSPEditor.GetFieldDefaultValue(AFieldNumber);

    FRequired := FSPEditor.IsFieldRequired(AFieldNumber);
    FTitle := FSPEditor.GetFieldTitle(AFieldNumber);
end;

procedure TSPItem.AdjustWidth(AParentWidth: integer);
begin
  Ctrl.Width := AParentWidth - 130;
end;


procedure TSPItem.CheckDefaultValue;
begin
 if FValue = '' then
     FValue := FSPEditor.GetFieldDefaultValue(FFieldNumber);
end;


// TSPTextItem
procedure TSPTextItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
  FControl := TEdit.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TEdit).Text := FValue;
end;

function TSPTextItem.TrySave: string;
begin
  Result := (FControl as TEdit).Text;
end;

procedure TSPTextItem.Save;
begin
  FValue := (FControl as TEdit).Text;
  FSPEditor.SetFieldValue(FFieldNumber, FValue);
end;

procedure TSPTextItem.Reset;
begin
  FValue := '';
  (FControl as TEdit).Text := FValue;
  Save;
end;

// TSPDateTimeItem
procedure TSPDateTimeItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
  FControl := TDateTimePicker.Create(AParent);
  FFormat := 'MM/dd/yyyy hh:mm';
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TDateTimePicker).OnChange := DateTimePickerChange;
  if (FValue = '') then
    (FControl as TDateTimePicker).Format := ' '
  else
  begin
    (FControl as TDateTimePicker).Format := FFormat;
    (FControl as TDateTimePicker).DateTime := ConvertToDate(FValue);
  end;
end;

function TSPDateTimeItem.ConvertToDate(AValue:string): TDateTime;
var dt: TDateTime;
begin
    dt := EncodeDateTime(StrToInt(Copy(AValue,7,4))
       , StrToInt(Copy(AValue,1,2))
       , StrToInt(Copy(AValue,4,2))
       , StrToInt(Copy(AValue,12,2))
       , StrToInt(Copy(AValue,15,2))
       , 0, 0);
    Result := dt;
end;

function TSPDateTimeItem.ConvertToDateSP(AValue:string): TDateTime;
var dt: TDateTime;
begin
    dt := EncodeDateTime(StrToInt(Copy(AValue,1,4))
       , StrToInt(Copy(AValue,6,2))
       , StrToInt(Copy(AValue,9,2))
       , StrToInt(Copy(AValue,12,2))
       , StrToInt(Copy(AValue,15,2))
       , 0, 0);
    Result := dt;
end;

function TSPDateTimeItem.TrySave: string;
var
  val: string;
begin
  if (FControl as TDateTimePicker).Format = ' ' then
    val := ''
  else
  begin
   val := FormatDateTime(FFormat , (FControl as TDateTimePicker).DateTime );
   val := StringReplace(val,'.','/',[rfReplaceAll]);
  end;
  Result := val;
end;

procedure  TSPDateTimeItem.Save;
begin
  if ((FControl as TDateTimePicker).Format <> ' ') then
  begin
   // fs := TFormatSettings.Create('en-US');
    FValue := FormatDateTime(FFormat , (FControl as TDateTimePicker).DateTime );
    FValue := StringReplace(FValue,'.','/',[rfReplaceAll]);
    FSPEditor.SetFieldValue(FFieldNumber,FValue);
  end;
end;

procedure TSPDateTimeItem.Reset;
begin
  FValue := '';
 (FControl as TDateTimePicker).Format := ' ';
  Save;
end;


procedure TSPDateTimeItem.DateTimePickerChange(Sender: TObject);
var tdp: TDateTimePicker;
begin
 tdp := (Sender as TDateTimePicker);
 if (tdp.Date = 0) then
    tdp.Format := ' '
 else
    tdp.Format := FFormat;
end;

procedure TSPDateTimeItem.CheckDefaultValue;
var s: string;
    dt: TDateTime;
begin
 if FValue = '' then
 begin
     s := FSPEditor.GetFieldDefaultValue(FFieldNumber);
     if s <> '' then
     begin
      if s = '[today]' then
      begin
       dt := Now;
       FValue := FormatDateTime(FFormat, dt);
       FValue := StringReplace(FValue,'.','/',[rfReplaceAll]);
      end
      else begin
        dt := ConvertToDateSP(s);
        FValue := FormatDateTime(FFormat, dt);
        FValue := StringReplace(FValue,'.','/',[rfReplaceAll]);
      end;
    end;
 end;
end;


// TSPBooleanItem
procedure TSPBooleanItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
  FControl := TCheckBox.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  if (LowerCase(FValue) = 'true') then
    (FControl as TCheckBox).Checked := true
  else
    (FControl as TCheckBox).Checked := false;
end;

function TSPBooleanItem.TrySave: string;
var val: string;
begin
   if ((FControl as TCheckBox).Checked = true ) then
      val := 'true'
   else
      val := 'false';
  Result := val;
end;

procedure TSPBooleanItem.Save;
begin
   if ((FControl as TCheckBox).Checked = true ) then
      FValue := 'true'
   else
      FValue := 'false';
  FSPEditor.SetFieldValue(FFieldNumber,FValue);
end;

procedure TSPBooleanItem.Reset;
begin
  FValue := 'false';
 (FControl as TCheckBox).Checked := false;
  Save;
end;


procedure TSPBooleanItem.CheckDefaultValue;
var s: string;
begin
 if FValue = '' then
 begin
     s := FSPEditor.GetFieldDefaultValue(FFieldNumber);
     if s = '1' then
        FValue := 'true'
     else
        FValue := 'false';
 end;
end;


// TSPNotetem
procedure TSPNoteItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
  FControl := TMemo.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  FControl.Height := 50;
  (FControl as TMemo).Text := FValue;
end;

function TSPNoteItem.TrySave: string;
begin
  Result := (FControl as TMemo).Text;
end;

procedure TSPNoteItem.Save;
begin
  FValue := (FControl as TMemo).Text;
  FSPEditor.SetFieldValue(FFieldNumber, FValue);
end;

procedure TSPNoteItem.Reset;
begin
  FValue := '';
 (FControl as TMemo).Text := '';
  Save;
end;


// TSPNumberItem
procedure TSPNumberItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
  FControl := TEdit.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TEdit).Text := FValue;
end;

function TSPNumberItem.TrySave: string;
begin
  Result := (FControl as TEdit).Text;
end;

procedure TSPNumberItem.Save;
begin
  FValue := (FControl as TEdit).Text;
  FSPEditor.SetFieldValue(FFieldNumber,FValue);
end;

procedure TSPNumberItem.Reset;
begin
  FValue := '';
 (FControl as TEdit).Text := '';
  Save;
end;


// TSPCurrencyItem
procedure TSPCurrencyItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
  FControl := TEdit.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TEdit).Text := FValue;
end;

function TSPCurrencyItem.TrySave: string;
begin
  Result := (FControl as TEdit).Text;
end;

procedure TSPCurrencyItem.Save;
begin
  FValue := (FControl as TEdit).Text;
  FSPEditor.SetFieldValue(FFieldNumber, FValue);
end;

procedure TSPCurrencyItem.Reset;
begin
  FValue := '';
 (FControl as TEdit).Text := '';
  Save;
end;

// TSPChoiceItem
procedure TSPChoiceItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
var i, cnt: integer;
begin
  FControl := TComboBox.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TComboBox).Style := csDropDownList;
  cnt := FSPEditor.GetChoicesCount(AFieldNumber);
  for i := 0 to cnt-1 do
  begin
     (FControl as TComboBox).Items.Add(FSPEditor.GetChoice(AFieldNumber,i));
  end;
  (FControl as TComboBox).ItemIndex := (FControl as TComboBox).Items.IndexOf(FValue);
end;

function TSPChoiceItem.TrySave: string;
begin
  Result := (FControl as TComboBox).Text;
end;

procedure TSPChoiceItem.Save;
begin
  FValue := (FControl as TComboBox).Text;
  FSPEditor.SetFieldValue(FFieldNumber, FValue);
end;

procedure TSPChoiceItem.Reset;
begin
  FValue := '';
 (FControl as TComboBox).Text := '';
  Save;
end;


// TSPLookupItem
procedure TSPLookupItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
var i, cnt, val: integer;
    s: string;
    arr: TStringList;
begin
  FControl := TComboBox.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TComboBox).Style := csDropDownList;
  cnt := FSPEditor.GetLookupsCount(AFieldNumber);
  arr := TStringList.Create;
  for i := 0 to cnt-1 do
  begin
      s := FSPEditor.GetLookup(AFieldNumber,i);
      s := StringReplace(s,' ','__', [rfReplaceAll]);
      Split(';',s,arr);
      arr[1] := StringReplace(arr[1],'__',' ', [rfReplaceAll]);
      val := StrToInt(arr[0]);
      (FControl as TComboBox).Items.AddObject(arr[1],TObject(val));
  end;
  if (FValue <> '') then
  begin
    val := StrToInt(FValue);
    (FControl as TComboBox).ItemIndex := (FControl as TComboBox).Items.IndexOfObject(TObject(val));
  end;
end;

function TSPLookupItem.TrySave: string;
begin
  Result := (FControl as TComboBox).Text;
end;

procedure TSPLookupItem.Save;
var obj: TObject;
    i: integer ;
begin
  if ((FControl as TComboBox).ItemIndex <> -1 ) then
  begin
    obj := (FControl as TComboBox).Items.Objects[(FControl as TComboBox).ItemIndex];
    i := Integer(obj);
    FValue := IntToStr(i);
    FSPEditor.SetFieldValue(FFieldNumber, FValue);
  end;
end;

procedure TSPLookupItem.Reset;
begin
  FValue := '';
 (FControl as TComboBox).Text := FValue;
  Save;
end;


// TSPUserItem
procedure TSPUserItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
var
    arr: TStringList;
begin
  FControl := TSPPeoplePicker.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TSPPeoplePicker).SPEditorCtrl := ASPEditor;
  if (FValue <> '') then
  begin
    arr := TStringList.Create;
    Split(';',FValue,arr);
    FUserID := StrToInt(arr[0]);
    if arr.Count > 1 then
       FUserName := arr[1]
    else
       FUserName := '';
    (FControl as TSPPeoplePicker).SetData(FUserID,FUserName);
  end;
end;

function TSPUserItem.TrySave: string;
var val: string;
begin
  val := '';
  if ( (FControl as TSPPeoplePicker).UserID <> 0) then
    val := IntToStr((FControl as TSPPeoplePicker).UserID)+';'+(FControl as TSPPeoplePicker).UserName;
  Result := val;
end;


procedure TSPUserItem.Save;
begin
  FUserID :=(FControl as TSPPeoplePicker).UserID;
  FUserName :=(FControl as TSPPeoplePicker).UserName;
  FValue := IntToStr(FUserID)+';'+FUserName;
  FSPEditor.SetFieldValue(FFieldNumber,FValue);
end;

procedure TSPUserItem.Reset;
begin
 //(FControl as TEdit).Text := '';
  FUserID := 0;
  FUserName := '';
  FValue := IntToStr(FUserID)+';'+FUserName;
  FSPEditor.SetFieldValue(FFieldNumber,FValue);
  (FControl as TSPPeoplePicker).SetData(FUserID,FUserName);
end;


// TSPUrlItem
procedure TSPUrlItem.Make(AFieldNumber: integer; ASPEditor: TSPEditorCtrl; AParent: TWinControl; AValue: string);
begin
  FControl := TEdit.Create(AParent);
  inherited Make(AFieldNumber,ASPEditor,AParent,AValue);
  (FControl as TEdit).Text := FValue;
end;

function TSPUrlItem.TrySave: string;
begin
  Result := (FControl as TEdit).Text;
end;

procedure TSPUrlItem.Save;
begin
  FValue := (FControl as TEdit).Text;
  FSPEditor.SetFieldValue(FFieldNumber, FValue);
end;

procedure TSPUrlItem.Reset;
begin
  FValue := '';
 (FControl as TEdit).Text := FValue;
  Save;
end;


end.
