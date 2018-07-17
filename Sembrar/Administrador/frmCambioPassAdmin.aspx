<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmCambioPassAdmin.aspx.cs" Inherits="Sembrar.Administrador.frmManejoPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
    .auto-style1 {
        width: 23px;
    }
    .auto-style3 {
            width: 628px;
        }
    .auto-style4 {
        width: 23px;
        height: 18px;
    }
    .auto-style5 {
        width: 24px;
        height: 18px;
    }
    .auto-style6 {
            width: 861px;
            height: 18px;
        }
    .auto-style7 {
        height: 18px;
    }
    .auto-style8 {
        width: 367px;
        height: 18px;
        text-align: center;
    }
        .auto-style9 {
            width: 2px;
        }
        .auto-style14 {
            height: 18px;
            width: 215px;
        }
        .auto-style15 {
            width: 5px;
        }
        .auto-style17 {
            width: 6px;
        }
        .auto-style20 {
            width: 109px;
        }
        .auto-style21 {
            width: 109px;
            height: 18px;
        }
        .auto-style22 {
            width: 861px;
            height: 18px;
            text-align: center;
        }
        auto-style70 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: large;
            color: #333333;
            text-align: left;
        }
        .auto-style23 {
            width: 861px;
            height: 50px;
        }
        .auto-style24 {
            width: 215px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td colspan="2">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style70">Generar Nueva Contraseña</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="vertical-align: top">
                            <hr />
                        </td>
                    </tr>
                </table>
            </td>
        <td class="auto-style24">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20">&nbsp;</td>
        <td class="auto-style23">
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoUsuario_SelectedIndexChanged" Width="100%">
                    <asp:ListItem Value="0">Seleccionar Rol</asp:ListItem>
                    <asp:ListItem Value="1">Administrador</asp:ListItem>
                    <asp:ListItem Value="2">Técnico</asp:ListItem>
                    <asp:ListItem Value="3">Coordinador</asp:ListItem>
                    <asp:ListItem Value="4">Digitador</asp:ListItem>
                    <asp:ListItem Value="5">Orientador</asp:ListItem>
                </asp:DropDownList>
            </td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style21"></td>
        <td class="auto-style6"></td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style21">&nbsp;</td>
        <td class="auto-style6">
                <asp:DropDownList ID="ddlUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" Width="100%">
                </asp:DropDownList>
            </td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style21">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style21">&nbsp;</td>
        <td class="auto-style22">
            <asp:Button ID="btnGenerarContraseña" runat="server" OnClick="btnGenerarContraseña_Click" Text="Cambiar Contraseña" />
        </td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style21">&nbsp;</td>
        <td class="auto-style22">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7" colspan="2">
            <asp:Panel ID="panelNuevaPass" runat="server" Width="501px">
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style5">
                            &nbsp;</td>
                        <td class="auto-style5">
                            <asp:Label ID="lblContrasenia" runat="server" Text="Nueva Contraseña:"></asp:Label>
                        </td>
                        <td class="auto-style8">
                            <asp:TextBox ID="txtContrasenia" runat="server" Enabled="False" Font-Size="Large" Height="50px" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">
                            <asp:Button ID="btnOtroUsuario" runat="server" Text="Otro Usuario" Width="60%" OnClick="btnOtroUsuario_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style21"></td>
        <td class="auto-style22"></td>
        <td class="auto-style14">&nbsp;</td>
    </tr>
</table>
</asp:Content>
