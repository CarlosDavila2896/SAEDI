<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmCerrarPeriodo.aspx.cs" Inherits="Sembrar.Administrador.frmCerrarPeriodo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2"><h2>Cerrar Año lectivo</h2></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label1" runat="server" Text="Selecionar Periodo:"></asp:Label>
            </td>
            <td class="auto-style10">
                <asp:DropDownList ID="ddlPeriodo" runat="server" DataSourceID="odsPeriodo" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsPeriodo" runat="server" SelectMethod="D_consultaPeriodosAniosLectivos" TypeName="CapaDatos.clsDPeriodo" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
            </td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td>
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
            </td>
        </tr>
        </table>
</asp:Content>
