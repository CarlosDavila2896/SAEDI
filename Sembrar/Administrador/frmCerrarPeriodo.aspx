<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmCerrarPeriodo.aspx.cs" Inherits="Sembrar.Administrador.frmCerrarPeriodo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2"><h2>Cerrar Año lectivo</h2></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label1" runat="server" Text="Selecionar Periodo:"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlPeriodo" runat="server" DataSourceID="odsPeriodo" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO" AutoPostBack="True" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsPeriodo" runat="server" SelectMethod="D_consultaPeriodosAniosLectivos" TypeName="CapaDatos.clsDPeriodo" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style8">Nombre:</td>
            <td class="auto-style8">
                <asp:Label ID="lblNombre" runat="server" Text="--"></asp:Label>
            </td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style4">Fecha Inicio: </td>
            <td class="auto-style8">
                <asp:Label ID="lblFechaInicio" runat="server" Text="--"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style4">Fecha Fin: </td>
            <td class="auto-style8">
                <asp:Label ID="lblFechaFin" runat="server" Text="--"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
