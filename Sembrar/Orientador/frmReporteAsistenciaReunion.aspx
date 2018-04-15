<%@ Page Title="" Language="C#" MasterPageFile="~/Orientador/PrincipalOrientador.Master" AutoEventWireup="true" CodeBehind="frmReporteAsistenciaReunion.aspx.cs" Inherits="Sembrar.Orientador.frmReporteAsistenciaReunion" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="auto-style11" colspan="3"><strong>Actualizar Asistencia</strong></td>
        </tr>
        <tr>
            <td class="auto-style12">Fecha:</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlFecha" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlFecha_SelectedIndexChanged" Width="166px">
                    <asp:ListItem Selected="True" Value="0">--Select Fecha--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Tema:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br /></td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlTema" runat="server" AppendDataBoundItems="True" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" Height="16px" Width="166px">
                    <asp:ListItem Selected="True" Value="0">--Select Orientador--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style14">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
            </td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style4">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableParameterPrompt="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
