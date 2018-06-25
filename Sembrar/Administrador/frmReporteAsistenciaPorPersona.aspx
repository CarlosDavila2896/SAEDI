<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmReporteAsistenciaPorPersona.aspx.cs" Inherits="Sembrar.Administrador.frmReporteAsistenciaPorPersona" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        height: 16px;
    }
    .auto-style5 {
        width: 11px;
        height: 16px;
    }
    .auto-style6 {
        width: 11px;
        height: 20px;
    }
        .auto-style7 {
            height: 52px;
        }
        .auto-style8 {
            width: 11px;
            height: 52px;
        }
        .auto-style9 {
            height: 18px;
        }
        .auto-style10 {
            width: 11px;
            height: 18px;
        }
        .auto-style11 {
            text-align: center;
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9"></td>
        <td class="auto-style11"><strong>Reporte Asistencia por persona</strong></td>
        <td class="auto-style10"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;
            &nbsp;
        </td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <table style="width:100%;">
                <tr>
                    <td>Proceso:</td>
                    <td> <asp:DropDownList ID="ddlProceso" runat="server" Width="200px">
            </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Mes:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                <asp:DropDownList ID="ddlMes" runat="server" Width="200px">
                    <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Año:&nbsp;&nbsp;</td>
                    <td>
            <asp:DropDownList ID="ddlAnio" runat="server" Width="200px">
            </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Persona:</td>
                    <td>
            <asp:DropDownList ID="ddlPersona" runat="server" Width="200px">
            </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Exportar PDF" Height="29px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style9">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Exportar Excel" Height="29px" />
                    </td>
                    <td class="auto-style9"></td>
                </tr>
            </table>
                </td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6"></td>
        <td class="auto-style6">
            &nbsp;</td>
        <td class="auto-style6"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style7">
            &nbsp;</td>
        <td class="auto-style8"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <!--td>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableParameterPrompt="False" />
        </td-->
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style4"></td>
        <td class="auto-style5"></td>
    </tr>
    <tr>
        <td class="auto-style9"></td>
        <td class="auto-style9"></td>
        <td class="auto-style10"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
</table>
</asp:Content>
