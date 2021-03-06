unit SPEditor_TLB;

// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// PASTLWTR : $Revision:   1.130  $
// File generated on 26.08.2014 22:48:03 from Type Library described below.

// ************************************************************************  //
// Type Lib: D:\Work\HoustonConsultant\spcontentupdater\SPEditor\Release\SPEditor.tlb (1)
// LIBID: {BCB6980E-E14E-4961-BAF8-8848F93C7A45}
// LCID: 0
// Helpfile: 
// DepndLst: 
//   (1) v2.0 stdole, (C:\Windows\SysWOW64\stdole2.tlb)
//   (2) v2.4 mscorlib, (C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.tlb)
//   (3) v2.4 System, (C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.tlb)
//   (4) v2.4 System_Windows_Forms, (C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.tlb)
//   (5) v4.0 StdVCL, (C:\WINDOWS\SysWOW64\stdvcl40.dll)
// Errors:
//   Hint: Member 'Library' of 'ISPEditorCtrl' changed to 'Library_'
//   Error creating palette bitmap of (TSPUserControl) : Server C:\WINDOWS\SysWow64\mscoree.dll contains no icons
//   Error creating palette bitmap of (TSPUserSearchForm) : Server C:\WINDOWS\SysWow64\mscoree.dll contains no icons
// ************************************************************************ //
// *************************************************************************//
// NOTE:                                                                      
// Items guarded by $IFDEF_LIVE_SERVER_AT_DESIGN_TIME are used by properties  
// which return objects that may need to be explicitly created via a function 
// call prior to any access via the property. These items have been disabled  
// in order to prevent accidental use from within the object inspector. You   
// may enable them by defining LIVE_SERVER_AT_DESIGN_TIME or by selectively   
// removing them from the $IFDEF blocks. However, such items must still be    
// programmatically created via a method of the appropriate CoClass before    
// they can be used.                                                          
{$TYPEDADDRESS OFF} // Unit must be compiled without type-checked pointers. 
{$WARN SYMBOL_PLATFORM OFF}
{$WRITEABLECONST ON}

interface

uses ActiveX, Classes, Graphics, mscorlib_TLB, OleCtrls, OleServer, StdVCL, 
System_TLB, System_Windows_Forms_TLB, Variants, Windows;
  

// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLASS_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
const
  // TypeLibrary Major and minor versions
  SPEditorMajorVersion = 1;
  SPEditorMinorVersion = 0;

  LIBID_SPEditor: TGUID = '{BCB6980E-E14E-4961-BAF8-8848F93C7A45}';

  IID__CBContentTypeItem: TGUID = '{58A2029F-0B78-372E-8614-434FA6148F92}';
  IID__LBUserData: TGUID = '{C47CD9C3-CF39-3418-AB12-4BA99E1677B1}';
  IID__SPUserControl: TGUID = '{ED17F5EE-9918-371E-AC68-D020919BEB90}';
  IID_ISPEditorCtrl: TGUID = '{58399E6E-12E3-41A9-835C-453CE8A28FB5}';
  CLASS_SPEditorCtrl: TGUID = '{0B5DE32F-04A1-45D0-9AD1-1AF095A76336}';
  IID__SPUserSearchForm: TGUID = '{900A856A-0CEC-39A4-A3FE-18AE7ED1EDE2}';
  CLASS_CBContentTypeItem: TGUID = '{617D5959-8DC1-30F0-B7C3-60C1F2001BA5}';
  CLASS_LBUserData: TGUID = '{7D3D84CE-0FE5-3973-82B4-F5E2F610D7F5}';
  CLASS_SPUserControl: TGUID = '{DD910193-DE65-3AF8-9E0C-DAA539E06CF0}';
  CLASS_SPUserSearchForm: TGUID = '{1FA7601C-0FF2-322A-BCFE-E073AB608CD7}';
type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  _CBContentTypeItem = interface;
  _CBContentTypeItemDisp = dispinterface;
  _LBUserData = interface;
  _LBUserDataDisp = dispinterface;
  _SPUserControl = interface;
  _SPUserControlDisp = dispinterface;
  ISPEditorCtrl = interface;
  ISPEditorCtrlDisp = dispinterface;
  _SPUserSearchForm = interface;
  _SPUserSearchFormDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  SPEditorCtrl = ISPEditorCtrl;
  CBContentTypeItem = _CBContentTypeItem;
  LBUserData = _LBUserData;
  SPUserControl = _SPUserControl;
  SPUserSearchForm = _SPUserSearchForm;


// *********************************************************************//
// Interface: _CBContentTypeItem
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {58A2029F-0B78-372E-8614-434FA6148F92}
// *********************************************************************//
  _CBContentTypeItem = interface(IDispatch)
    ['{58A2029F-0B78-372E-8614-434FA6148F92}']
  end;

// *********************************************************************//
// DispIntf:  _CBContentTypeItemDisp
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {58A2029F-0B78-372E-8614-434FA6148F92}
// *********************************************************************//
  _CBContentTypeItemDisp = dispinterface
    ['{58A2029F-0B78-372E-8614-434FA6148F92}']
  end;

// *********************************************************************//
// Interface: _LBUserData
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {C47CD9C3-CF39-3418-AB12-4BA99E1677B1}
// *********************************************************************//
  _LBUserData = interface(IDispatch)
    ['{C47CD9C3-CF39-3418-AB12-4BA99E1677B1}']
  end;

// *********************************************************************//
// DispIntf:  _LBUserDataDisp
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {C47CD9C3-CF39-3418-AB12-4BA99E1677B1}
// *********************************************************************//
  _LBUserDataDisp = dispinterface
    ['{C47CD9C3-CF39-3418-AB12-4BA99E1677B1}']
  end;

// *********************************************************************//
// Interface: _SPUserControl
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {ED17F5EE-9918-371E-AC68-D020919BEB90}
// *********************************************************************//
  _SPUserControl = interface(IDispatch)
    ['{ED17F5EE-9918-371E-AC68-D020919BEB90}']
  end;

// *********************************************************************//
// DispIntf:  _SPUserControlDisp
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {ED17F5EE-9918-371E-AC68-D020919BEB90}
// *********************************************************************//
  _SPUserControlDisp = dispinterface
    ['{ED17F5EE-9918-371E-AC68-D020919BEB90}']
  end;

// *********************************************************************//
// Interface: ISPEditorCtrl
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {58399E6E-12E3-41A9-835C-453CE8A28FB5}
// *********************************************************************//
  ISPEditorCtrl = interface(IDispatch)
    ['{58399E6E-12E3-41A9-835C-453CE8A28FB5}']
    function  Get_Visible: WordBool; safecall;
    procedure Set_Visible(pRetVal: WordBool); safecall;
    function  Get_Enabled: WordBool; safecall;
    procedure Set_Enabled(pRetVal: WordBool); safecall;
    function  Get_ForeColor: Integer; safecall;
    procedure Set_ForeColor(pRetVal: Integer); safecall;
    function  Get_BackColor: Integer; safecall;
    procedure Set_BackColor(pRetVal: Integer); safecall;
    function  Get_Website: WideString; safecall;
    procedure Set_Website(const pRetVal: WideString); safecall;
    function  Get_Username: WideString; safecall;
    procedure Set_Username(const pRetVal: WideString); safecall;
    function  Get_Password: WideString; safecall;
    procedure Set_Password(const pRetVal: WideString); safecall;
    function  Get_UseCurrentCredentials: WordBool; safecall;
    procedure Set_UseCurrentCredentials(pRetVal: WordBool); safecall;
    function  Get_Library_: WideString; safecall;
    procedure Set_Library_(const pRetVal: WideString); safecall;
    function  Get_Folder: WideString; safecall;
    procedure Set_Folder(const pRetVal: WideString); safecall;
    procedure LoadContentTypes; safecall;
    procedure SwitchContentType(i: Integer); safecall;
    function  GetContentTypesCount: Integer; safecall;
    function  GetContentTypeName(i: Integer): WideString; safecall;
    function  GetFieldInternalName(i: Integer): WideString; safecall;
    function  GetFieldTitle(i: Integer): WideString; safecall;
    function  GetFieldValue(i: Integer): WideString; safecall;
    procedure SetFieldValue(i: Integer; const value: WideString); safecall;
    function  GetFieldsCount: Integer; safecall;
    function  IsFieldHidden(i: Integer): WordBool; safecall;
    function  IsFieldReadOnly(i: Integer): WordBool; safecall;
    function  IsFieldRequired(i: Integer): WordBool; safecall;
    function  GetFieldDefaultValue(i: Integer): WideString; safecall;
    function  GetFieldTypeString(i: Integer): WideString; safecall;
    function  GetChoicesCount(i: Integer): Integer; safecall;
    function  GetChoice(i: Integer; j: Integer): WideString; safecall;
    function  GetLookupsCount(i: Integer): Integer; safecall;
    function  GetLookup(i: Integer; j: Integer): WideString; safecall;
    function  GetUserList(const part: WideString): Integer; safecall;
    function  GetUserId(i: Integer): Integer; safecall;
    function  GetUserName(i: Integer): WideString; safecall;
    procedure Commit(const document: WideString); safecall;
    property Visible: WordBool read Get_Visible;
    property Enabled: WordBool read Get_Enabled;
    property ForeColor: Integer read Get_ForeColor;
    property BackColor: Integer read Get_BackColor;
    property Website: WideString read Get_Website write Set_Website;
    property Username: WideString read Get_Username write Set_Username;
    property Password: WideString read Get_Password write Set_Password;
    property UseCurrentCredentials: WordBool read Get_UseCurrentCredentials;
    property Library_: WideString read Get_Library_ write Set_Library_;
    property Folder: WideString read Get_Folder write Set_Folder;
  end;

// *********************************************************************//
// DispIntf:  ISPEditorCtrlDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {58399E6E-12E3-41A9-835C-453CE8A28FB5}
// *********************************************************************//
  ISPEditorCtrlDisp = dispinterface
    ['{58399E6E-12E3-41A9-835C-453CE8A28FB5}']
    property Visible: WordBool readonly dispid 1610743808;
    property Enabled: WordBool readonly dispid 1610743810;
    property ForeColor: Integer readonly dispid 1610743812;
    property BackColor: Integer readonly dispid 1610743814;
    property Website: WideString readonly dispid 1610743816;
    property Username: WideString readonly dispid 1610743818;
    property Password: WideString readonly dispid 1610743820;
    property UseCurrentCredentials: WordBool readonly dispid 1610743822;
    property Library_: WideString readonly dispid 1610743824;
    property Folder: WideString readonly dispid 1610743826;
    procedure LoadContentTypes; dispid 1610743828;
    procedure SwitchContentType(i: Integer); dispid 1610743829;
    function  GetContentTypesCount: Integer; dispid 1610743830;
    function  GetContentTypeName(i: Integer): WideString; dispid 1610743831;
    function  GetFieldInternalName(i: Integer): WideString; dispid 1610743832;
    function  GetFieldTitle(i: Integer): WideString; dispid 1610743833;
    function  GetFieldValue(i: Integer): WideString; dispid 1610743834;
    procedure SetFieldValue(i: Integer; const value: WideString); dispid 1610743835;
    function  GetFieldsCount: Integer; dispid 1610743836;
    function  IsFieldHidden(i: Integer): WordBool; dispid 1610743837;
    function  IsFieldReadOnly(i: Integer): WordBool; dispid 1610743838;
    function  IsFieldRequired(i: Integer): WordBool; dispid 1610743839;
    function  GetFieldDefaultValue(i: Integer): WideString; dispid 1610743840;
    function  GetFieldTypeString(i: Integer): WideString; dispid 1610743841;
    function  GetChoicesCount(i: Integer): Integer; dispid 1610743842;
    function  GetChoice(i: Integer; j: Integer): WideString; dispid 1610743843;
    function  GetLookupsCount(i: Integer): Integer; dispid 1610743844;
    function  GetLookup(i: Integer; j: Integer): WideString; dispid 1610743845;
    function  GetUserList(const part: WideString): Integer; dispid 1610743846;
    function  GetUserId(i: Integer): Integer; dispid 1610743847;
    function  GetUserName(i: Integer): WideString; dispid 1610743848;
    procedure Commit(const document: WideString); dispid 1610743849;
  end;

// *********************************************************************//
// Interface: _SPUserSearchForm
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {900A856A-0CEC-39A4-A3FE-18AE7ED1EDE2}
// *********************************************************************//
  _SPUserSearchForm = interface(IDispatch)
    ['{900A856A-0CEC-39A4-A3FE-18AE7ED1EDE2}']
  end;

// *********************************************************************//
// DispIntf:  _SPUserSearchFormDisp
// Flags:     (4432) Hidden Dual OleAutomation Dispatchable
// GUID:      {900A856A-0CEC-39A4-A3FE-18AE7ED1EDE2}
// *********************************************************************//
  _SPUserSearchFormDisp = dispinterface
    ['{900A856A-0CEC-39A4-A3FE-18AE7ED1EDE2}']
  end;


// *********************************************************************//
// OLE Control Proxy class declaration
// Control Name     : TSPEditorCtrl
// Help String      : 
// Default Interface: ISPEditorCtrl
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
  TSPEditorCtrl = class(TOleControl)
  private
    FIntf: ISPEditorCtrl;
    function  GetControlInterface: ISPEditorCtrl;
  protected
    procedure CreateControl;
    procedure InitControlData; override;
  public
    procedure LoadContentTypes;
    procedure SwitchContentType(i: Integer);
    function  GetContentTypesCount: Integer;
    function  GetContentTypeName(i: Integer): WideString;
    function  GetFieldInternalName(i: Integer): WideString;
    function  GetFieldTitle(i: Integer): WideString;
    function  GetFieldValue(i: Integer): WideString;
    procedure SetFieldValue(i: Integer; const value: WideString);
    function  GetFieldsCount: Integer;
    function  IsFieldHidden(i: Integer): WordBool;
    function  IsFieldReadOnly(i: Integer): WordBool;
    function  IsFieldRequired(i: Integer): WordBool;
    function  GetFieldDefaultValue(i: Integer): WideString;
    function  GetFieldTypeString(i: Integer): WideString;
    function  GetChoicesCount(i: Integer): Integer;
    function  GetChoice(i: Integer; j: Integer): WideString;
    function  GetLookupsCount(i: Integer): Integer;
    function  GetLookup(i: Integer; j: Integer): WideString;
    function  GetUserList(const part: WideString): Integer;
    function  GetUserId(i: Integer): Integer;
    function  GetUserName(i: Integer): WideString;
    procedure Commit(const document: WideString);
    property  ControlInterface: ISPEditorCtrl read GetControlInterface;
    property  DefaultInterface: ISPEditorCtrl read GetControlInterface;
  published
    property Visible: WordBool index -1 read GetWordBoolProp write SetWordBoolProp stored False;
    property Enabled: WordBool index -1 read GetWordBoolProp write SetWordBoolProp stored False;
    property ForeColor: Integer index -1 read GetIntegerProp write SetIntegerProp stored False;
    property BackColor: Integer index -1 read GetIntegerProp write SetIntegerProp stored False;
    property Website: WideString index -1 read GetWideStringProp write SetWideStringProp stored False;
    property Username: WideString index -1 read GetWideStringProp write SetWideStringProp stored False;
    property Password: WideString index -1 read GetWideStringProp write SetWideStringProp stored False;
    property UseCurrentCredentials: WordBool index -1 read GetWordBoolProp write SetWordBoolProp stored False;
    property Library_: WideString index -1 read GetWideStringProp write SetWideStringProp stored False;
    property Folder: WideString index -1 read GetWideStringProp write SetWideStringProp stored False;
  end;

// *********************************************************************//
// The Class CoCBContentTypeItem provides a Create and CreateRemote method to          
// create instances of the default interface _CBContentTypeItem exposed by              
// the CoClass CBContentTypeItem. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoCBContentTypeItem = class
    class function Create: _CBContentTypeItem;
    class function CreateRemote(const MachineName: string): _CBContentTypeItem;
  end;

// *********************************************************************//
// The Class CoLBUserData provides a Create and CreateRemote method to          
// create instances of the default interface _LBUserData exposed by              
// the CoClass LBUserData. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoLBUserData = class
    class function Create: _LBUserData;
    class function CreateRemote(const MachineName: string): _LBUserData;
  end;

// *********************************************************************//
// The Class CoSPUserControl provides a Create and CreateRemote method to          
// create instances of the default interface _SPUserControl exposed by              
// the CoClass SPUserControl. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoSPUserControl = class
    class function Create: _SPUserControl;
    class function CreateRemote(const MachineName: string): _SPUserControl;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TSPUserControl
// Help String      : 
// Default Interface: _SPUserControl
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TSPUserControlProperties= class;
{$ENDIF}
  TSPUserControl = class(TOleServer)
  private
    FIntf:        _SPUserControl;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps:       TSPUserControlProperties;
    function      GetServerProperties: TSPUserControlProperties;
{$ENDIF}
    function      GetDefaultInterface: _SPUserControl;
  protected
    procedure InitServerData; override;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: _SPUserControl);
    procedure Disconnect; override;
    property  DefaultInterface: _SPUserControl read GetDefaultInterface;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TSPUserControlProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TSPUserControl
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TSPUserControlProperties = class(TPersistent)
  private
    FServer:    TSPUserControl;
    function    GetDefaultInterface: _SPUserControl;
    constructor Create(AServer: TSPUserControl);
  protected
  public
    property DefaultInterface: _SPUserControl read GetDefaultInterface;
  published
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoSPUserSearchForm provides a Create and CreateRemote method to          
// create instances of the default interface _SPUserSearchForm exposed by              
// the CoClass SPUserSearchForm. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoSPUserSearchForm = class
    class function Create: _SPUserSearchForm;
    class function CreateRemote(const MachineName: string): _SPUserSearchForm;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TSPUserSearchForm
// Help String      : 
// Default Interface: _SPUserSearchForm
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TSPUserSearchFormProperties= class;
{$ENDIF}
  TSPUserSearchForm = class(TOleServer)
  private
    FIntf:        _SPUserSearchForm;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps:       TSPUserSearchFormProperties;
    function      GetServerProperties: TSPUserSearchFormProperties;
{$ENDIF}
    function      GetDefaultInterface: _SPUserSearchForm;
  protected
    procedure InitServerData; override;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: _SPUserSearchForm);
    procedure Disconnect; override;
    property  DefaultInterface: _SPUserSearchForm read GetDefaultInterface;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TSPUserSearchFormProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TSPUserSearchForm
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TSPUserSearchFormProperties = class(TPersistent)
  private
    FServer:    TSPUserSearchForm;
    function    GetDefaultInterface: _SPUserSearchForm;
    constructor Create(AServer: TSPUserSearchForm);
  protected
  public
    property DefaultInterface: _SPUserSearchForm read GetDefaultInterface;
  published
  end;
{$ENDIF}


procedure Register;

resourcestring
  dtlServerPage = 'ActiveX';

implementation

uses ComObj;

procedure TSPEditorCtrl.InitControlData;
const
  CControlData: TControlData2 = (
    ClassID: '{0B5DE32F-04A1-45D0-9AD1-1AF095A76336}';
    EventIID: '';
    EventCount: 0;
    EventDispIDs: nil;
    LicenseKey: nil (*HR:$80004002*);
    Flags: $00000000;
    Version: 401);
begin
  ControlData := @CControlData;
end;

procedure TSPEditorCtrl.CreateControl;

  procedure DoCreate;
  begin
    FIntf := IUnknown(OleObject) as ISPEditorCtrl;
  end;

begin
  if FIntf = nil then DoCreate;
end;

function TSPEditorCtrl.GetControlInterface: ISPEditorCtrl;
begin
  CreateControl;
  Result := FIntf;
end;

procedure TSPEditorCtrl.LoadContentTypes;
begin
  DefaultInterface.LoadContentTypes;
end;

procedure TSPEditorCtrl.SwitchContentType(i: Integer);
begin
  DefaultInterface.SwitchContentType(i);
end;

function  TSPEditorCtrl.GetContentTypesCount: Integer;
begin
  Result := DefaultInterface.GetContentTypesCount;
end;

function  TSPEditorCtrl.GetContentTypeName(i: Integer): WideString;
begin
  Result := DefaultInterface.GetContentTypeName(i);
end;

function  TSPEditorCtrl.GetFieldInternalName(i: Integer): WideString;
begin
  Result := DefaultInterface.GetFieldInternalName(i);
end;

function  TSPEditorCtrl.GetFieldTitle(i: Integer): WideString;
begin
  Result := DefaultInterface.GetFieldTitle(i);
end;

function  TSPEditorCtrl.GetFieldValue(i: Integer): WideString;
begin
  Result := DefaultInterface.GetFieldValue(i);
end;

procedure TSPEditorCtrl.SetFieldValue(i: Integer; const value: WideString);
begin
  DefaultInterface.SetFieldValue(i, value);
end;

function  TSPEditorCtrl.GetFieldsCount: Integer;
begin
  Result := DefaultInterface.GetFieldsCount;
end;

function  TSPEditorCtrl.IsFieldHidden(i: Integer): WordBool;
begin
  Result := DefaultInterface.IsFieldHidden(i);
end;

function  TSPEditorCtrl.IsFieldReadOnly(i: Integer): WordBool;
begin
  Result := DefaultInterface.IsFieldReadOnly(i);
end;

function  TSPEditorCtrl.IsFieldRequired(i: Integer): WordBool;
begin
  Result := DefaultInterface.IsFieldRequired(i);
end;

function  TSPEditorCtrl.GetFieldDefaultValue(i: Integer): WideString;
begin
  Result := DefaultInterface.GetFieldDefaultValue(i);
end;

function  TSPEditorCtrl.GetFieldTypeString(i: Integer): WideString;
begin
  Result := DefaultInterface.GetFieldTypeString(i);
end;

function  TSPEditorCtrl.GetChoicesCount(i: Integer): Integer;
begin
  Result := DefaultInterface.GetChoicesCount(i);
end;

function  TSPEditorCtrl.GetChoice(i: Integer; j: Integer): WideString;
begin
  Result := DefaultInterface.GetChoice(i, j);
end;

function  TSPEditorCtrl.GetLookupsCount(i: Integer): Integer;
begin
  Result := DefaultInterface.GetLookupsCount(i);
end;

function  TSPEditorCtrl.GetLookup(i: Integer; j: Integer): WideString;
begin
  Result := DefaultInterface.GetLookup(i, j);
end;

function  TSPEditorCtrl.GetUserList(const part: WideString): Integer;
begin
  Result := DefaultInterface.GetUserList(part);
end;

function  TSPEditorCtrl.GetUserId(i: Integer): Integer;
begin
  Result := DefaultInterface.GetUserId(i);
end;

function  TSPEditorCtrl.GetUserName(i: Integer): WideString;
begin
  Result := DefaultInterface.GetUserName(i);
end;

procedure TSPEditorCtrl.Commit(const document: WideString);
begin
  DefaultInterface.Commit(document);
end;

class function CoCBContentTypeItem.Create: _CBContentTypeItem;
begin
  Result := CreateComObject(CLASS_CBContentTypeItem) as _CBContentTypeItem;
end;

class function CoCBContentTypeItem.CreateRemote(const MachineName: string): _CBContentTypeItem;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_CBContentTypeItem) as _CBContentTypeItem;
end;

class function CoLBUserData.Create: _LBUserData;
begin
  Result := CreateComObject(CLASS_LBUserData) as _LBUserData;
end;

class function CoLBUserData.CreateRemote(const MachineName: string): _LBUserData;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_LBUserData) as _LBUserData;
end;

class function CoSPUserControl.Create: _SPUserControl;
begin
  Result := CreateComObject(CLASS_SPUserControl) as _SPUserControl;
end;

class function CoSPUserControl.CreateRemote(const MachineName: string): _SPUserControl;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_SPUserControl) as _SPUserControl;
end;

procedure TSPUserControl.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{DD910193-DE65-3AF8-9E0C-DAA539E06CF0}';
    IntfIID:   '{ED17F5EE-9918-371E-AC68-D020919BEB90}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TSPUserControl.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as _SPUserControl;
  end;
end;

procedure TSPUserControl.ConnectTo(svrIntf: _SPUserControl);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TSPUserControl.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TSPUserControl.GetDefaultInterface: _SPUserControl;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call ''Connect'' or ''ConnectTo'' before this operation');
  Result := FIntf;
end;

constructor TSPUserControl.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TSPUserControlProperties.Create(Self);
{$ENDIF}
end;

destructor TSPUserControl.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TSPUserControl.GetServerProperties: TSPUserControlProperties;
begin
  Result := FProps;
end;
{$ENDIF}

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TSPUserControlProperties.Create(AServer: TSPUserControl);
begin
  inherited Create;
  FServer := AServer;
end;

function TSPUserControlProperties.GetDefaultInterface: _SPUserControl;
begin
  Result := FServer.DefaultInterface;
end;

{$ENDIF}

class function CoSPUserSearchForm.Create: _SPUserSearchForm;
begin
  Result := CreateComObject(CLASS_SPUserSearchForm) as _SPUserSearchForm;
end;

class function CoSPUserSearchForm.CreateRemote(const MachineName: string): _SPUserSearchForm;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_SPUserSearchForm) as _SPUserSearchForm;
end;

procedure TSPUserSearchForm.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{1FA7601C-0FF2-322A-BCFE-E073AB608CD7}';
    IntfIID:   '{900A856A-0CEC-39A4-A3FE-18AE7ED1EDE2}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TSPUserSearchForm.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as _SPUserSearchForm;
  end;
end;

procedure TSPUserSearchForm.ConnectTo(svrIntf: _SPUserSearchForm);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TSPUserSearchForm.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TSPUserSearchForm.GetDefaultInterface: _SPUserSearchForm;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call ''Connect'' or ''ConnectTo'' before this operation');
  Result := FIntf;
end;

constructor TSPUserSearchForm.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TSPUserSearchFormProperties.Create(Self);
{$ENDIF}
end;

destructor TSPUserSearchForm.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TSPUserSearchForm.GetServerProperties: TSPUserSearchFormProperties;
begin
  Result := FProps;
end;
{$ENDIF}

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TSPUserSearchFormProperties.Create(AServer: TSPUserSearchForm);
begin
  inherited Create;
  FServer := AServer;
end;

function TSPUserSearchFormProperties.GetDefaultInterface: _SPUserSearchForm;
begin
  Result := FServer.DefaultInterface;
end;

{$ENDIF}

procedure Register;
begin
  RegisterComponents('ActiveX',[TSPEditorCtrl]);
  RegisterComponents(dtlServerPage, [TSPUserControl, TSPUserSearchForm]);
end;

end.
