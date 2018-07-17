<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmReporteAsistenciaMensual.aspx.cs" Inherits="Sembrar.Tecnico.Reporte7" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style4 {
            height: 19px;
        }
        .auto-style5 {
            height: 19px;
            width: 296px;
        }
        .auto-style7 {
            height: 18px;
        }
        .auto-style8 {
            height: 31px;
            width: 77px;
        }
        .auto-style9 {
            text-align: center;
        }
        C:\Users\Administrator\Documents\SAEDI\Sembrar\Administrador\frmReporteAsistenciaMensual.aspx .auto-style10 {
            text-align: center;
            height: 31px;
        }
        .auto-style12 {
            height: 31px;
            width: 111px;
        }
        .auto-style13 {
            width: 111px;
        }
        .auto-style14 {
            width: 77px;
        }
        .auto-style15 {
            width: 77px;
            height: 19px;
        }
        .auto-style16 {
            width: 111px;
            height: 19px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style10">
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style5">
            </td>
            <td class="auto-style13">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style10"><strong>Reporte Asistencia Mensual</strong></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <!--td class="auto-style5">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" EnableParameterPrompt="False" />
            </td-->
            <td>
                <table style="width:100%;">
                    <tr>
                        <td>Año:</td>
                        <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Mes:</td>
                        <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="200px">
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
                        <td>Proceso:</td>
                        <td> <asp:DropDownList ID="ddlProceso" runat="server" Width="200px">
            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                <asp:Button ID="btnBuscar" runat="server" OnClick="Button1_Click" Text="Exportar PDF" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                <asp:Button ID="btnBuscar0" runat="server" OnClick="btnBuscar0_Click" Text="Exportar Excel" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style15"></td>
            <td class="auto-style5"></td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
