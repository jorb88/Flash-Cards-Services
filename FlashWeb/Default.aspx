<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FlashWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <div class="jumbotron">
        <h1>Flash Cards Online</h1>
        <h2>Please enter your secret student code: <asp:TextBox ID="txtStudentCode" runat="server"></asp:TextBox> 
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </h2>
        If you do not have a secret student code you can use one of the test accounts shown on the About page.<br />
            </div></asp:Content>
