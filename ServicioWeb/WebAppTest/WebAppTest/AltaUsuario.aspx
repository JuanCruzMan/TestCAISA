<%@ Page Language="C#" MasterPageFile="~/TestMaster.Master" CodeBehind="AltaUsuario.aspx.cs" Inherits="WebAppTest.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css"/>
<script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript" >
        $(function () {
            $("#<%=TextBox8.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                yearRange: '1950:2018'
            });
        });
    </script>
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="XX-Large"></asp:Label>
    
    </div>
    <div>

    </div>
        <div>

    </div>
    <table style="width: 100%; height: 146px;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" AccessKey="*" TextMode="Password"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style1">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
             </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
             </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label8"  runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"  AutoPostBack="True" OnTextChanged="TextBox9_TextChanged" EnableViewState="False"  EnableTheming="False" ></asp:TextBox>
                
 
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server" OnTextChanged="TextBox9_TextChanged" ReadOnly="True"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox11" runat="server"  TextMode="Number" ></asp:TextBox>


            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server"></asp:Content>
