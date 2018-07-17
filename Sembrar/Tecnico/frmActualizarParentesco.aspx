<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmActualizarParentesco.aspx.cs" Inherits="Sembrar.Tecnico.ActualizarParentesco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style16" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" colspan="3">Actualizar Parentesco</td>
        </tr>
        <tr>
            <td class="auto-style15">Seleccionar Parentesco:</td>
            <td class="auto-style9" style="text-align: left">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SembrarConnectionString %>" SelectCommand="SELECT * FROM [PARENTEZCO] ORDER BY [NOMBREPARENTEZCO]"></asp:SqlDataSource>
                <asp:DropDownList ID="ddlParentesco" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NOMBREPARENTEZCO" DataValueField="IDPARENTEZCO" OnSelectedIndexChanged="ddlParentesco_SelectedIndexChanged" Height="100%" Width="90%">
                </asp:DropDownList>
            </td>
            <td class="auto-style9" style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">Nombre de Parentesco:</td>
            <td class="auto-style10">
                <asp:TextBox ID="txtNombreParentesco" runat="server" Width="165px" Enabled="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>
                <asp:Button ID="btnActualizar" runat="server" Enabled="False" OnClick="btnActualizar_Click" Text="Actualizar" />
            </td>
        </tr>
    </table>
</asp:Content>
