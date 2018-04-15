<%@ Page Title="" Language="C#" MasterPageFile="~/Orientador/PrincipalOrientador.Master" AutoEventWireup="true" CodeBehind="frmIngresarAsistencia.aspx.cs" Inherits="Sembrar.Orientador.CrearAsistencia"  EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style8 {
            height: 23px;
            width: 16px;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style9
        {
            width: 16px;
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
            <td class="auto-style7">
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label2" runat="server" Text="Reunión: "></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;<asp:DropDownList ID="ddlReunion" runat="server" AppendDataBoundItems="true" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" Height="16px" OnSelectedIndexChanged="ddlOrientador_SelectedIndexChanged" Width="180px">
                <asp:ListItem Value="0">--Seleccionar Reunión--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Buscar" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style14">
                <asp:Label ID="Label1" runat="server" Text="LISTA PARTICIPANTES"></asp:Label>
            </td>
            <td class="auto-style14"></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td>
                <asp:GridView ID="grvJovenes" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="100000" ShowFooter="True" ForeColor="Black" GridLines="Horizontal">
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td>
                <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrar" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
