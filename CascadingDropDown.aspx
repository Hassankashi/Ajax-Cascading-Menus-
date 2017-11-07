<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CascadingDropDown.aspx.cs" Inherits="CascadingDropDown" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>CascadingDropDown</title>
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" ></ajaxToolkit:ToolkitScriptManager>
 
    <div>
    <asp:DropDownList ID="ddListCountry" runat="server" Width="170" />
        <br />
    <asp:DropDownList ID="ddListCity" runat="server" Width="170" /><br />
    <ajaxToolkit:CascadingDropDown ID="CascadingCountry" runat="server" TargetControlID="ddListCountry"
             Category="Country"  PromptText="Please select a Country"  LoadingText="[Loading Country...]"
            ServicePath="Cascading.asmx" ServiceMethod="GetCountries" ></ajaxToolkit:CascadingDropDown>
            
    <ajaxToolkit:CascadingDropDown ID="CascadingCity" runat="server" TargetControlID="ddListCity"
            Category="City" PromptText="Please select a City" LoadingText="[Loading City...]"
         servicePath="Cascading.asmx" ServiceMethod="GetCities" ParentControlID="ddListCountry" ></ajaxToolkit:CascadingDropDown>
         
    </div>
    </form>
</body>
</html>
