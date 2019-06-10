<%@ Page Language="C#" MasterPageFile="~/TestMaster.Master" CodeBehind="RecuperarPass.aspx.cs" Inherits="WebAppTest.RecuperarPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div>
    
    </div>
         <div>
    
             <asp:Label ID="Label2" runat="server" Text="" Font-Size="XX-Large"></asp:Label>
    
    </div>
         <div>
    
    </div>
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Labelresultado" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server"></asp:Content>
