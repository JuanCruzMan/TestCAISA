<%@ Page Language="C#" MasterPageFile="~/TestMaster.Master" CodeBehind="Loguin.aspx.cs" Inherits="WebAppTest.Loguin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server"> </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
   
        <div><asp:Label ID="Label3" runat="server" Text="" Font-Size="XX-Large"></asp:Label></div>
    <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="" OnClick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="" OnClick="Button4_Click" style="height: 26px" />
                </td>
                <td>
                    <asp:Label ID="Labelresultado" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="" OnClick="Button3_Click" />
                </td>
            </tr>
        </table>
</asp:Content>
 <asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server" ></asp:Content>
