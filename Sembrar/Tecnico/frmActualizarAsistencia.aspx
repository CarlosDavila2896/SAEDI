<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmActualizarAsistencia.aspx.cs" Inherits="Sembrar.Tecnico.ActualizarAsistencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
    </style>
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
                <br />
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlTema" runat="server" AppendDataBoundItems="True" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" Height="16px" OnSelectedIndexChanged="ddlOrientador2_SelectedIndexChanged" Width="166px">
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
            <td class="auto-style8"></td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style4">
                <asp:GridView ID="grvAsistencia2" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="100000" ShowFooter="True" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <asp:TemplateField HeaderText="Asistencia">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAsistencia" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOMBRETIPOASISTENCIA" DataValueField="IDTIPOASISTENCIA">
                                    <asp:ListItem Selected="True">Presente</asp:ListItem>
                                    <asp:ListItem>Ausente</asp:ListItem>
                                    <asp:ListItem>Justificado</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" SelectCommand="SELECT * FROM [TIPOASISTENCIA]"></asp:SqlDataSource>
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
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
