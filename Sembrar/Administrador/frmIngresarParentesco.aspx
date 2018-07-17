<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmIngresarParentesco.aspx.cs" Inherits="Sembrar.Administrador.IngresarParentesco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style8" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" colspan="3">Ingresar&nbsp; Parentesco</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Nombre Parentesco: (*)</td>
            <td class="auto-style8" style="text-align: left">
                <asp:TextBox ID="txtParentesco" runat="server" style="text-align: left" Width="223px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td>
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NOMBREPARENTEZCO" DataValueField="NOMBREPARENTEZCO" Height="129px" Rows="10" Width="50%"></asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SembrarConnectionString %>" SelectCommand="SELECT [NOMBREPARENTEZCO] FROM [PARENTEZCO]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
