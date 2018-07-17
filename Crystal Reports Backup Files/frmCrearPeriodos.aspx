<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmCrearPeriodos.aspx.cs" Inherits="Sembrar.Administrador.Crear_Periodos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style9" colspan="2"><h2>Crear Año lectivo</h2></td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Label ID="Label2" runat="server" Text="Nombre del Periodo:"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="txtNombrePeriodo" runat="server" Width="197px" ValidationGroup="Name"></asp:TextBox>
            </td>
            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombrePeriodo" Display="Dynamic" ErrorMessage="*" ValidationGroup="Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:CheckBox ID="chbFinPeriodo" runat="server" AutoPostBack="True" OnCheckedChanged="chbFinPeriodo_CheckedChanged" Text="¿Ingresar Limites para el Periodo?" />
            </td>
            <td class="auto-style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlLimites" runat="server" Visible="False">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style13">
                                <asp:Label ID="Label3" runat="server" Text="Inicio del Periodo:"></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtFechaInicio" runat="server" OnTextChanged="txtFechaFin_TextChanged" TextMode="Date" Width="184px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CompareValidator ID="cpvInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Fecha No Valida" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Ingrese la fecha de inicio del periodo">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style13">
                                <asp:Label ID="Label4" runat="server" Text="Fin del Periodo:"></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtFechaFin" runat="server" OnTextChanged="txtFechaFin_TextChanged" TextMode="Date" Width="184px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CompareValidator ID="cmvFin" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Fecha No Valida" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Ingrese fecha de Fin">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style14">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="vlsErrores" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">
                <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Crear" Width="80px" ValidationGroup="Name" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3">
                <asp:GridView ID="gvPeriodo" runat="server" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" DataSourceID="odsPeriodos" OnRowDataBound="gvPeriodo_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False" SelectedValue="<%# BIND('ESTADO') %>">
                                    <asp:ListItem Value="True">Activo</asp:ListItem>
                                    <asp:ListItem Value="False">Terminado</asp:ListItem>
                                </asp:DropDownList>
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
                <asp:ObjectDataSource ID="odsPeriodos" runat="server" SelectMethod="consultarAniosLectivos" TypeName="CapaDatos.clsDPeriodo"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
