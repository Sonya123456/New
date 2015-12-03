<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SmartHouse.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart House</title>
    <link href="App_Themes/css/index.css" rel="stylesheet" />
</head>
<body>
     <div class="nav">
        <p>Welcome to your Smart House</p>
      </div>
     <div class="sider"> 
         <input type="button" value="Switch On All Devices" class="navButton" onserverclick="SwitchOnAll_Click" runat="server"/>
         <input type="button" value="Switch Off All Devices" class="navButton" onserverclick="SwitchOffAll_Click" runat="server"/>
        <input type="button" value="Delete All Devices" class="navButton" onserverclick="DeleteAll_Click" runat="server"/>
    </div>
    <form id="form1" runat="server">
    <div>
       
    <asp:Button ID="AddLamp" runat="server" Text="Add Lamp" OnClick="AddDevice_Click" CssClass="button" />
    <asp:Button ID="AddFridge" runat="server" Text="Add Fridge" OnClick="AddDevice_Click" CssClass="button"/>
    <asp:Button ID="AddTv" runat="server" Text="Add TV" OnClick="AddDevice_Click" CssClass="button"/>
    <asp:Button ID="AddShower" runat="server" Text="Add Shower" OnClick="AddDevice_Click" CssClass="button"/>
    <asp:Button ID="AddHoover" runat="server" Text="Add Hoover" OnClick="AddDevice_Click" CssClass="button"/>
        <br />
        <br/>
    <asp:Label ID="Label1" runat="server" Text="Enter device's name" />
    <asp:TextBox ID="DeviceName" runat="server" Text="" />
    <asp:Label ID="WrongName" runat="server" Text="" CssClass="wrong"/>
      
        <br/>
        <br/>
      
    </div>

        <div id="divDevices" runat="server">
           <asp:PlaceHolder ID ="PlaceHolder1" runat="server"></asp:PlaceHolder>
           
        </div>
        <div id="black" class="black" runat="server"></div>
    </form>
    
</body>
</html>

