<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <br />
        Введите первую строку&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="35px" Width="371px"></asp:TextBox>
        <br />
        <br />
        <br />
        Введите вторую строку&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="35px" Width="371px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#006699" ForeColor="White" Height="42px" OnClick="Button1_Click" style="margin-left: 191px" Text="ПОСЧИТАТЬ" Width="190px" />
        <br />
        <br />
        <br />
        Количество символов равно :  
        <asp:TextBox ID="TextBox3" runat="server" BackColor="#CCCCCC" BorderStyle="None" Enabled="False" Height="44px" Width="43px" Font-Size="Large"></asp:TextBox>
        <br />
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
