<%@ Page Title="Flash Quiz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuizPage.aspx.cs" Inherits="FlashWeb.QuizPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/><br/>
<div class="jumbotron">
  <h1>Flash Cards Online</h1>
  <h2><asp:Label ID="lblWelcome" runat="server" Text="Welcome to the Quiz..."></asp:Label>
  </h2>
</div>
    <h2>Pick an operation:
&nbsp;<asp:RadioButton ID="rbAdd" runat="server" Checked="True" GroupName="ops" Text="+" OnCheckedChanged="rbAdd_CheckedChanged" ToolTip="Addition" />
&nbsp;<asp:RadioButton ID="rbSubtract" runat="server" GroupName="ops" Text="-" OnCheckedChanged="rbAdd_CheckedChanged" ToolTip="Subtraction" />
&nbsp;<asp:RadioButton ID="rbMultiply" runat="server" GroupName="ops" Text="*" OnCheckedChanged="rbAdd_CheckedChanged" ToolTip="Multiplication" />
&nbsp;<asp:RadioButton ID="rbDivide" runat="server" GroupName="ops" Text="/" OnCheckedChanged="rbAdd_CheckedChanged" ToolTip="Division" />
&nbsp;<asp:Button ID="btnQuestion" runat="server" Text="Generate Question" OnClick="btnQuestion_Click" />
<br /><br /><asp:Label ID="lblQuestion" runat="server" Text="99 + 99 ="></asp:Label>
&nbsp;<asp:TextBox ID="txtAnswer" runat="server" Width="100px"></asp:TextBox>
&nbsp;<asp:Button ID="btnAnswer" runat="server" Text="Submit Answer" OnClick="btnAnswer_Click" />
&nbsp;<asp:Label ID="lblCorrect" runat="server" Text="Correct"></asp:Label>
&nbsp;</h2>
</asp:Content>
