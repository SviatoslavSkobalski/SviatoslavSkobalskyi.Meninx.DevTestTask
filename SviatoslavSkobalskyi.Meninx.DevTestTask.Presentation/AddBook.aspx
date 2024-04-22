<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="SviatoslavSkobalskyi.Meninx.DevTestTask.Presentation.AddBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Edit Book<br />
        <br />
        Title<asp:TextBox ID="TB_Title" runat="server"></asp:TextBox>
        <br />
        Author<asp:TextBox ID="TB_Author" runat="server"></asp:TextBox>
        <br />
        ISBN<asp:TextBox ID="TB_ISBN" runat="server"></asp:TextBox>
        <br />
        Category Id
        <asp:TextBox ID="TB_CategoryId" runat="server"></asp:TextBox>
        <br />
        Publication Year<asp:TextBox ID="TB_PublicationYear" runat="server"></asp:TextBox>
        <br />
        Quantity<asp:TextBox ID="TB_Quantity" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Apply" runat="server" Text="Apply" OnClick="Apply_Click" />
        <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
    </div>
</form>
</body>
</html>
