<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteConfirmation.aspx.cs" Inherits="SviatoslavSkobalskyi.Meninx.DevTestTask.Presentation.DeleteConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="ConfirmButton" runat="server" Text="Delete" OnClick="ConfirmButton_Click" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
    </form>
</body>
</html>
