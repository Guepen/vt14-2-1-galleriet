<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <ul class="files">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="FileyperLink" runat="server" NavigateUrl="">HyperLink</asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        
        <%-- Validering  --%>
        <div>
           
        </div>

        <%-- Upladdningen av fil  --%>
    <div>
        <asp:FileUpload ID="FileUpload" runat="server" />
        <asp:Button ID="ButtonUpload" runat="server" Text="Ladda Upp" OnClick="ButtonUpload_Click" />
    </div>
    </form>
</body>
</html>
