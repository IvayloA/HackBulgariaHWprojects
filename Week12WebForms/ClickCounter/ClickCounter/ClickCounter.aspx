<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClickCounter.aspx.cs" Inherits="WebApplication2.ClickCounter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <asp:Label ID="label2" runat="server"></asp:Label>
    </div>
        <div>
        <asp:Button ID="button1" Text="Click" runat="server" OnClick="button1_Click" />
            <asp:Label ID="label3" runat="server"><%: Session["Click"] %></asp:Label>
            <asp:Label ID="label1" runat="server"><%: Application["Click"] %></asp:Label>
        </div>
    </form>
</body>
</html>
