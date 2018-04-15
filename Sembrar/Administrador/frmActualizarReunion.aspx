<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmActualizarReunion.aspx.cs" Inherits="Sembrar.Administrador.ActualizarReunion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 18px;
        }
        .auto-style2 {
            width: 135px;
        }
        .auto-style3 {
            width: 168px;
        }
        .auto-style4 {
            width: 135px;
            height: 18px;
        }
        .auto-style5 {
            width: 168px;
            height: 18px;
        }
        .auto-style6 {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">ACTUALIZAR REUNIÓN</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">Reunión:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlReunion" runat="server" AutoPostBack="True" Height="22px" OnSelectedIndexChanged="ddlReunion_SelectedIndexChanged" Width="221px">
                    <asp:ListItem>--Seleccionar Reunion--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style4">Tema</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtTema" runat="server" Width="222px"></asp:TextBox>
            </td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style2">Fecha</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtFecha" runat="server" Height="22px" TextMode="Date" Width="220px"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Hora</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtHora" runat="server" TextMode="Time" Width="220px"></asp:TextBox>
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar Reunion" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
