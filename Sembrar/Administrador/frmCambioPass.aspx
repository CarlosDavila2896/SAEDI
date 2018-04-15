<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmCambioPass.aspx.cs" Inherits="Sembrar.Administrador.frmCambioPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6">Cambiar Contraseña</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtId" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtPass" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">Contraseña anterior:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtPassA" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfPass" runat="server" ControlToValidate="txtPassA" ErrorMessage="*" ForeColor="Red" ValidationGroup="Cambiar"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1">Contraseña nueva:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtPassNueva" runat="server" TextMode="Password" Width="134px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfPass0" runat="server" ControlToValidate="txtPassNueva" ErrorMessage="*" ForeColor="Red" ValidationGroup="Cambiar"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">Repetir contraseña nueva:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtRPassNueva" runat="server" TextMode="Password" Height="20px" Width="132px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfPass1" runat="server" ControlToValidate="txtRPassNueva" ErrorMessage="*" ForeColor="Red" ValidationGroup="Cambiar"></asp:RequiredFieldValidator>
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6">
                <asp:CompareValidator ID="cvPassIguales" runat="server" ControlToCompare="txtPassNueva" ControlToValidate="txtRPassNueva" ErrorMessage="Contraseñas no coinciden" ForeColor="Red" ValidationGroup="Cambiar">Contraseñas no coinciden</asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6">
                <asp:Button ID="btnCambiar" runat="server" OnClick="btnCambiar_Click" Text="Cambiar Contraseña" Width="209px" ValidationGroup="Cambiar" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
