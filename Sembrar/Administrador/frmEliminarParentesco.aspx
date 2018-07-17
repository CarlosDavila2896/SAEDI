<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmEliminarParentesco.aspx.cs" Inherits="Sembrar.Administrador.EliminarParentesco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="auto-style9" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" colspan="3">Eliminar Parentesco</td>
    </tr>
    <tr>
        <td class="auto-style8" style="text-align: left">Seleccionar Parentesco:</td>
        <td class="auto-style8" style="text-align: left">
            <asp:DropDownList ID="ddlParentesco" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOMBREPARENTEZCO" DataValueField="IDPARENTEZCO" Height="25px" Width="300px">
            </asp:DropDownList>
        </td>
        <td class="auto-style8"></td>
    </tr>
    <tr>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style14">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SembrarConnectionString %>" SelectCommand="SELECT * FROM [PARENTEZCO] ORDER BY [NOMBREPARENTEZCO]"></asp:SqlDataSource>
        </td>
        <td>
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
        </td>
    </tr>
    <tr>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style14">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
