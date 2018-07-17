<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmActualizarPeriodo.aspx.cs" Inherits="Sembrar.Tecnico.frmActualizarPeriodo" %>
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
        .auto-style7 {
            width: 95%;
        }
        .auto-style8 {
            width: 104%;
        }
        .auto-style9 {
            height: 18px;
        }
        .auto-style10 {
            height: 45px;
        }
        .auto-style11 {
            height: 45px;
            width: 222px;
        }
        .auto-style12 {
            width: 222px;
        }
        .auto-style13 {
            height: 18px;
            width: 222px;
        }
        .auto-style15 {
            width: 244px;
        }
        .auto-style17 {
            width: 237px;
        }
        .auto-style18 {
            height: 45px;
            width: 124px;
        }
        .auto-style19 {
            width: 124px;
        }
        .auto-style20 {
            width: 124px;
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style8">
        <tr>
            <td class="auto-style18"></td>
            <td class="auto-style11">ACTUALIZAR PERIODO</td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td class="auto-style19">Periodo</td>
            <td class="auto-style12">
                <asp:DropDownList ID="ddlPeriodo" runat="server" AutoPostBack="True" Height="24px" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="215px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">Nombre</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtNombre" runat="server" Width="208px"></asp:TextBox>
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" Width="207px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20">
                <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin"></asp:Label>
            </td>
            <td class="auto-style13">
                <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" Width="209px"></asp:TextBox>
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style12">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
