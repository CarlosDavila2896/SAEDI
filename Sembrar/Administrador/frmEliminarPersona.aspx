<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmEliminarPersona.aspx.cs" Inherits="Sembrar.Administrador.Eliminar_Persona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14" colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;">Eliminar Individuo</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3" style="vertical-align: top">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Seleccionar Individuo:</td>
            <td class="auto-style14" style="text-align: left">&nbsp;<asp:DropDownList ID="ddlIndividuo" runat="server" DataTextField="PERSONA" Width="290px" DataSourceID="dsPersona" DataValueField="IDPERSONA">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsPersona" runat="server" ConnectionString="<%$ ConnectionStrings:SembrarConnectionString %>" SelectCommand="SELECT IDPERSONA, PRIMERNOMBREPERSONA+' '+SEGUNDONOMBREPERSONA+' '+PRIMERAPELLIDOPERSONA+' '+SEGUNDOAPELLIDOPERSONA AS PERSONA FROM PERSONA p "></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td>
                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click1" Text="Eliminar" Width="153px" />
            </td>
        </tr>
    </table>
</asp:Content>
