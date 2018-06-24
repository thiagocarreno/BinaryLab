<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventViewer.aspx.cs" Inherits="EventViewer.EventViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblMsg" runat=server ></asp:Label>
    <asp:GridView ID="GrdVw_SystemLog" runat="server" CellPadding="4" ForeColor="#333333"
        GridLines="None" Font-Names="Arial" Font-Size="XX-Small" AutoGenerateColumns="true">
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </form>
</body>
</html>
