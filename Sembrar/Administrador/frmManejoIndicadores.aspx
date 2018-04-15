<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmManejoIndicadores.aspx.cs" Inherits="Sembrar.Administrador.frmManejoIndicadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" __designer:mapid="18d">
        <tr __designer:mapid="18e">
            <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">Manejo de Indicadores</td>
            <td __designer:mapid="190">&nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="auto-style7" style="vertical-align: top">
                <hr /></td>
        </tr>
    </table>
    <table style="width:100%;" __designer:mapid="192">
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac" colspan="3">
                <table id="crearProceso" style="width: 100%;">
                    <tr>
                        <td class="auto-style1" colspan="3">Crear nuevo Indicador</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Nombre del indicador:</td>
                        <td>
                            <asp:TextBox ID="txtNombreIndicador" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac">&nbsp;</td>
            <td __designer:mapid="1ad" style="text-align: right">&nbsp;</td>
            <td __designer:mapid="1ae">&nbsp;</td>
        </tr>
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac" colspan="3" class="auto-style1">
                <asp:GridView ID="gvIndicadores" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="odsIndicadores" DataKeyNames="IDINDICADOR" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" >
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar el indicador de la base de datos (Si el indicador tiene asignado preguntas no será posible)?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                        <asp:BoundField DataField="IDINDICADOR" HeaderText="IDINDICADOR" SortExpression="IDINDICADOR" Visible="False" />
                        <asp:BoundField DataField="NOMBREINDICADOR" HeaderText="Nombre del Indicador" SortExpression="NOMBREINDICADOR" />
                        <asp:CheckBoxField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" Visible="False" />
                        <asp:TemplateField HeaderText="Estado del Indicador">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEstado" runat="server" SelectedValue='<%# Bind("ESTADO") %>'>
                                    <asp:ListItem Value="True">Activo</asp:ListItem>
                                    <asp:ListItem Value="False">Inactivo</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlEstado" runat="server" Enabled="False" SelectedValue='<%# Bind("ESTADO") %>'>
                                    <asp:ListItem Value="True">Activo</asp:ListItem>
                                    <asp:ListItem Value="False">Inactivo</asp:ListItem>
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
            </td>
        </tr>
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac" colspan="3">
                <asp:ObjectDataSource ID="odsIndicadores" runat="server" DataObjectTypeName="CapaDatos.INDICADOR" DeleteMethod="D_eliminarIndicador" SelectMethod="D_consultarIndicadores" TypeName="CapaDatos.clsDIndicador" UpdateMethod="D_editarIndicador"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
