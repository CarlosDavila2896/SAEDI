<%@ Page Title="" Language="C#" MasterPageFile="~/Orientador/PrincipalOrientador.Master" AutoEventWireup="true" CodeBehind="frmActualizarAsistenciaDiaria.aspx.cs" Inherits="Sembrar.Orientador.ActualizarAsistenciaDiaria"  EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 11px;
        height: 49px;
    }
    .auto-style5 {
        height: 23px;
    }
    .auto-style6 {
        width: 11px;
        height: 23px;
    }
    .auto-style7 {
        height: 48px;
    }
    .auto-style8 {
        width: 11px;
        height: 48px;
    }
    .auto-style9 {
        height: 45px;
    }
    .auto-style10 {
        width: 11px;
        height: 29px;
    }
    .auto-style11 {
        height: 29px;
    }
    .auto-style14 {
        height: 49px;
    }
        .auto-style18 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="3">Actualizar Asistencia</td>
        </tr>
        <tr>
            <td class="auto-style8">Fecha:</td>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlFecha" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style11">Linea de Acción:</td>
            <td class="auto-style10">
                <asp:DropDownList ID="ddlLineaAccion" runat="server" OnSelectedIndexChanged="ddlLineaAccion_SelectedIndexChanged" Width="220px" AutoPostBack="True" style="height: 23px">
                </asp:DropDownList>
            </td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td class="auto-style6">Proceso:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlProceso" runat="server" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged" Width="220px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td>Periodo:</td>
            <td class="auto-style18">
                <asp:DropDownList ID="ddlPeriodo" runat="server" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="220px">
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style14">
                <asp:Label ID="Label1" runat="server" Text="LISTA PARTICIPANTES"></asp:Label>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td>
                <asp:GridView ID="grvJovenes" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" PageSize="100000" ShowFooter="True" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField HeaderText="Asistencia">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAsistencia" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOMBRETIPOASISTENCIA" DataValueField="IDTIPOASISTENCIA">
                                    <asp:ListItem Selected="True">Presente</asp:ListItem>
                                    <asp:ListItem>Ausente</asp:ListItem>
                                    <asp:ListItem>Justificado</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" SelectCommand="SELECT * FROM [TIPOASISTENCIA]"></asp:SqlDataSource>
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td>
                <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrar" />
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
