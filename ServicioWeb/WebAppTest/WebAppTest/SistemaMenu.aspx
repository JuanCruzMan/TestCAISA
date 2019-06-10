<%@ Page Language="C#" MasterPageFile="~/TestMaster.Master" CodeBehind="SistemaMenu.aspx.cs" Inherits="WebAppTest.SistemaMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server"></asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
        <div><ul>
            
             
            
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Width="182px" />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" Width="182px" />
            <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" Width="182px" />
        </ul></div>
        
    
    </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox1" runat="server" Width="425px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server"></asp:Content>

