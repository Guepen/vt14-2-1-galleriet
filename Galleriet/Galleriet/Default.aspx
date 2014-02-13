<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="UploadSuccess" runat="server" Text="Upladdningen lyckades!" Visible="false"></asp:Label>
            <asp:Image ID="ImageHolder" runat="server" Height="500" Width="350" />

            <asp:Repeater ID="Repeater1" runat="server" ItemType="System.String" SelectMethod="Repeater1_GetData"  >
                
                <ItemTemplate>
             
                        <asp:HyperLink ID="FileyperLink" runat="server"  Text='<%#Item  %>' ImageUrl='<%#"Content/Images/Thumbnails/" + Item %>' NavigateUrl='<%#"?" + Item %>'>HyperLink
                            <asp:Image ID="Image1" runat="server" />
                        </asp:HyperLink>
                   
                </ItemTemplate>
            </asp:Repeater>
        </div>
        
        <%-- Validering  --%>
        <div>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Välj en fil att ladda upp" ControlToValidate="FileUpload"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Bara filer av typerna JPG/JPEG/GIF/PNG" ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([pP][nN][gG]))$" ControlToValidate="FileUpload"></asp:RegularExpressionValidator>
        </div>

        <%-- Upladdningen av fil  --%>
    <div>
        <asp:FileUpload ID="FileUpload" runat="server" />
        <asp:Button ID="ButtonUpload" runat="server" Text="Ladda Upp" OnClick="ButtonUpload_Click" />
    </div>
    </form>
</body>
</html>
