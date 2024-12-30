<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MyWebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="Styles/TemPlate.css"/>
    <link rel="stylesheet" type="text/css" href="Styles/FA_THEMES.css"/>
    <style>
    body {
        background-image: url('Image/nuoitom.jpg');
        background-repeat: no-repeat;
        background-size: cover;
    }
    
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <header class="w3-container w3-center w3-padding-32"> 
        <h1><b>Hệ thống giám sát điều khiển tưới cây và nuôi cá trong nhà kính thông minh</b></h1>
        </header>
        <div class="container">  
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
 
            <label>Username:</label>
            <input type="text" id="txtUsername" runat="server" />
          
            <label>Password:</label>
            <input type="password" id="txtPassword" runat="server" />
 
            <button id="btnLogin" runat="server" onserverclick="btnLogin_Click">Login</button> 
            <button id="btnRegister" runat="server" onserverclick="btnRegister_Click">Register</button>
        </div>
    </form>
</body>
</html>
