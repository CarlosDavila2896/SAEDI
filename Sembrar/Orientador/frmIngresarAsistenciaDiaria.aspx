<%@ Page Title="" Language="C#" MasterPageFile="~/Orientador/PrincipalOrientador.Master" AutoEventWireup="true" CodeBehind="frmIngresarAsistenciaDiaria.aspx.cs" Inherits="Sembrar.Orientador.CrearAsistenciaDiaria"  EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 11px;
        height: 49px;
    }
    .auto-style5 {
        height: 7px;
    }
    .auto-style6 {
        width: 11px;
        height: 7px;
    }
        .auto-style7 {
            text-align: left;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style9 {
            text-align: left;
            width: 11px;
        }
        .auto-style10 {
            width: 11px;
        }
        .auto-style11 {
            text-align: center;
            width: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="3"><strong>CREAR ASISTENCIA</strong></td>
        </tr>
        <tr>
            <td class="auto-style8">Fecha:</td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddlFecha" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">Linea de Acción:</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlLineaAccion" runat="server" OnSelectedIndexChanged="ddlLineaAccion_SelectedIndexChanged" Width="220px" AutoPostBack="True" style="height: 23px">
                </asp:DropDownList>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style1">Proceso:</td>
            <td class="auto-style10">
                <asp:DropDownList ID="ddlProceso" runat="server" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged" Width="220px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>Periodo:</td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddlPeriodo" runat="server" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="220px">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style11">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style10">
                <asp:Label ID="Label1" runat="server" Text="LISTA PARTICIPANTES"></asp:Label>
            </td>
            <td class="auto-style14"></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">
                <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrar" style="height: 29px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
