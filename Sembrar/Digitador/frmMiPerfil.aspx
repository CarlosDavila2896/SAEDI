<%@ Page Title="" Language="C#" MasterPageFile="~/Digitador/PrincipalDigitador.Master" AutoEventWireup="true" CodeBehind="frmMiPerfil.aspx.cs" Inherits="Sembrar.Digitador.frmMiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style type="text/css">
        .auto-style1 {
            height: 18px;
        }
        .auto-style2 {
            height: 18px;
            width: 248px;
        }
        .auto-style3 {
            height: 18px;
            width: 149px;
        }
        .auto-style4 {
            text-align: justify;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style70 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: large;
            color: #333333;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style6">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style5" colspan="3">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style70">Perfil del Usuarios</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="vertical-align: top">
                            <hr />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style5" colspan="3">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7" colspan="3">
    <table __designer:mapid="4c" style="width:100%;">
        <tr __designer:mapid="51">
            <td __designer:mapid="5a" class="auto-style4">&nbsp;</td>
            <td __designer:mapid="53" class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr __designer:mapid="51">
            <td __designer:mapid="5a" class="auto-style4">
    <table __designer:mapid="4c" style="width:100%;">
        <tr __designer:mapid="4d">
            <td __designer:mapid="59">&nbsp;</td>
            <td __designer:mapid="4f">
                <asp:TextBox ID="txtIdUsuario" runat="server" Enabled="False" Visible="False" Width="128px"></asp:TextBox>
            </td>
        </tr>
        <tr __designer:mapid="51">
            <td __designer:mapid="5a" class="auto-style5">Nombre:</td>
            <td __designer:mapid="53" class="auto-style4">
                <asp:TextBox ID="txtNombreUsuario" runat="server" MaxLength="50" Width="88%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfNombre" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="Actualizar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="55">
            <td __designer:mapid="5b" class="auto-style5">Apellido:</td>
            <td __designer:mapid="57">
                <asp:TextBox ID="txtApellidoUsuario" runat="server" MaxLength="50" Width="234px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfApellido" runat="server" ControlToValidate="txtApellidoUsuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="Actualizar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="5c">
            <td __designer:mapid="5e" class="auto-style5">Género</td>
            <td __designer:mapid="5f">
                <asp:DropDownList ID="ddlGeneroUsuario" runat="server" Height="19px" Width="56%">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="1">Femenino</asp:ListItem>
                    <asp:ListItem Value="2">Masculino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr __designer:mapid="61">
            <td __designer:mapid="63" class="auto-style5">&nbsp;</td>
            <td __designer:mapid="64">
                &nbsp;</td>
        </tr>
        <tr __designer:mapid="8c">
            <td __designer:mapid="8e" class="auto-style5">Nombre de Usuario:</td>
            <td __designer:mapid="8f" class="auto-style9">
                <asp:TextBox ID="txtUserName" runat="server" MaxLength="256" Width="146px" EnableTheming="True" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" ValidationGroup="Actualizar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="8c">
            <td __designer:mapid="8e" class="auto-style5">Correo:</td>
            <td __designer:mapid="8f" class="auto-style10">
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="256" TextMode="Email" Width="258px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" ValidationGroup="Actualizar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="8c">
            <td __designer:mapid="8e" class="auto-style10">&nbsp;</td>
            <td __designer:mapid="8f" class="auto-style10">&nbsp;</td>
        </tr>
        <tr __designer:mapid="91">
            <td __designer:mapid="93"></td>
            <td __designer:mapid="94">
                <asp:Button ID="btnActualizarUsuario" runat="server" Text="Actualizar" Width="247px" OnClick="btnActualizarUsuario_Click" ValidationGroup="Actualizar" />
            </td>
        </tr>
    </table>
            </td>
            <td __designer:mapid="53" class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr __designer:mapid="55">
            <td __designer:mapid="57">
                &nbsp;</td>
        </tr>
        </table>
            </td>
            <td class="auto-style6">
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:HyperLink ID="hlPass" runat="server" NavigateUrl="~/Digitador/frmCambioPass.aspx">¿Desea cambiar la contraseña?</asp:HyperLink>
            </td>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style5" colspan="3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style5" colspan="3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

