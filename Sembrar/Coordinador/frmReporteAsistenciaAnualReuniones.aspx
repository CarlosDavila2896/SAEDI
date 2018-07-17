<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador/PrincipalCoordiandor.Master" AutoEventWireup="true" CodeBehind="frmReporteAsistenciaAnualReuniones.aspx.cs" Inherits="Sembrar.Coordinador.frmReporteAsistenciaAnualReuniones" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        height: 18px;
    }
        .auto-style5 {
            width: 126px;
        }
        .auto-style6 {
            height: 18px;
            width: 126px;
        }
        .auto-style7 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style4"></td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style6">
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style7"><strong>Reporte Asistencia Anual Reuniones</strong></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Año:</td>
                    <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
            </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Proceso:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td> <asp:DropDownList ID="ddlProceso" runat="server" Width="200px">
            </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 29px" Text="Exportar PDF" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Exportar Excel" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
        <td class="auto-style4"></td>
    </tr>
    <tr>
        <td class="auto-style1"></td>
        <!--td class="auto-style1">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableParameterPrompt="False" OnInit="CrystalReportViewer1_Init" />
        </td-->
        <td class="auto-style5"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="stackedTabTitle"></td>
        <td class="auto-style5"></td>
        <td class="stackedTabTitle"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
