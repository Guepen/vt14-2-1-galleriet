<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Galleriet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Style/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form" runat="server">
        <div id ="Content">
            <h1>Mitt Superläckra Galleri!</h1>
        <div>
            <asp:Label ID="UploadSuccess" runat="server" Text="Upladdningen lyckades!" Visible="false"></asp:Label>
            
            <asp:Image ID="ImageHolder" runat="server" Height="400" Width="500" Visible="false" />
            </div>

           <%-- Tumnagelbilderna --%>
            <div id="Thumbs">
             <asp:Repeater ID="Repeater1" runat="server" ItemType="System.String" SelectMethod="Repeater1_GetData">
                
                <ItemTemplate>
             
                        <asp:HyperLink ID="FileyperLink" runat="server"  

                            Text='<%#Item  %>' 
                            ImageUrl='<%#"Content/Images/Thumbnails/" + Item %>' 
                            NavigateUrl='<%#"?" + Item %>'>
                       
                        </asp:HyperLink>
                   
                </ItemTemplate>

            </asp:Repeater>
        </div>
    </div>
        
        <%-- Validering  --%>
        <div>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Välj en fil att ladda upp" 
               ControlToValidate="FileUpload" Text="*" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Bara filer av typerna JPG/JPEG/GIF/PNG" 
                Display="Dynamic" Text="*" ValidationExpression="^.+\.(([jJ][pP][eE]?[gG])|([gG][iI][fF])|([pP][nN][gG]))$" 
                ControlToValidate="FileUpload"></asp:RegularExpressionValidator>
        </div>

        <%-- Upladdningen av fil  --%>
    <div id="Upload">
        <asp:FileUpload ID="FileUpload" runat="server" />
        <asp:Button ID="ButtonUpload" runat="server" Text="Ladda Upp" OnClick="ButtonUpload_Click" />
    </div>

        <%-- Presentation av felmeddelanden --%>
        <div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
        </div>
    </form>
</body>
</html>
