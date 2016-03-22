<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label id="label2" runat="server" Text="Enter your name."></asp:Label>   
    </div>
        <div>
            <asp:TextBox id="textBox1" runat="server" OnTextChanged="textBox1_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="textBox1" errormessage="Please enter your name!" />
    <br/>
    <br/>
            <asp:Button id="Button1" runat="server" Text="SumbitNavigation" />     
        </div>
    </form>

</body>
</html>
