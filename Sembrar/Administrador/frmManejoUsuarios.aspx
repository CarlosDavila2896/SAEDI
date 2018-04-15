<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmManejoUsuarios.aspx.cs" Inherits="Sembrar.Administrador.frmManejoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style70">Manejo de Usuarios</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="vertical-align: top">
                            <hr />
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoUsuario_SelectedIndexChanged" Width="100%" Height="38px">
                    <asp:ListItem Value="0">Seleccionar Rol</asp:ListItem>
                    <asp:ListItem Value="1">Administrador</asp:ListItem>
                    <asp:ListItem Value="2">Técnico</asp:ListItem>
                    <asp:ListItem Value="3">Coordinador</asp:ListItem>
                    <asp:ListItem Value="4">Orientador</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" Width="100%">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
    <table __designer:mapid="4c" style="width:100%;">
        <tr __designer:mapid="4d">
            <td __designer:mapid="59">&nbsp;</td>
            <td __designer:mapid="4f">
                <asp:TextBox ID="txtIdUsuario" runat="server" Enabled="False" Visible="False" Width="128px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td __designer:mapid="8e" class="auto-style2">Nombre de Usuario:</td>
            <td __designer:mapid="8f" class="auto-style3">
                <asp:TextBox ID="txtUserName" runat="server" MaxLength="256" Width="152px" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" ValidationGroup="Actualizar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="51">
            <td __designer:mapid="5a" class="auto-style2">Nombre:</td>
            <td __designer:mapid="53" class="auto-style3">
                <asp:TextBox ID="txtNombreUsuario" runat="server" MaxLength="50" Width="73%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfNombre" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="Actualizar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="55">
            <td __designer:mapid="5b" class="auto-style1">Apellido:</td>
            <td __designer:mapid="57">
                <asp:TextBox ID="txtApellidoUsuario" runat="server" MaxLength="50" Width="199px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfApellido" runat="server" ControlToValidate="txtApellidoUsuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="Actualizar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="5c">
            <td __designer:mapid="5e" class="auto-style1">Género</td>
            <td __designer:mapid="5f">
                <asp:DropDownList ID="ddlGeneroUsuario" runat="server" Height="19px" Width="56%">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="1">Femenino</asp:ListItem>
                    <asp:ListItem Value="2">Masculino</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr __designer:mapid="61">
            <td __designer:mapid="63" class="auto-style1">Estado Usuario:</td>
            <td __designer:mapid="64">
                <asp:DropDownList ID="ddlEstado" runat="server" Height="19px" Width="169px">
                    <asp:ListItem Value="True">Activo</asp:ListItem>
                    <asp:ListItem Value="False">Inactivo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr __designer:mapid="8c">
            <td __designer:mapid="8e" class="auto-style1">Correo:</td>
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td __designer:mapid="80">&nbsp;</td>
            <td __designer:mapid="88">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td __designer:mapid="84">&nbsp;</td>
            <td __designer:mapid="89">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
