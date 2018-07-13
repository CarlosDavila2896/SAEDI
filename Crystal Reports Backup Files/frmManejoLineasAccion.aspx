<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmManejoLineasAccion.aspx.cs" Inherits="Sembrar.Tecnico.frmManejoLineasAccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style4 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" __designer:mapid="18d">
        <tr __designer:mapid="18e">
            <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">Manejo de Líneas de Acción</td>
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
            <td __designer:mapid="1ac" class="auto-style1">
                <asp:GridView ID="gvLineasDeAccion" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="odsLineasDeAccion" DataKeyNames="IDLINEADEACCION" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar la línea de acción de la base de datos (Si la línea de accion alguna relación esto no será posible)?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                        <asp:BoundField DataField="IDLINEADEACCION" HeaderText="IDLINEADEACCION" SortExpression="IDLINEADEACCION" Visible="False" />
                        <asp:BoundField DataField="NOMBRELINEADEACCION" HeaderText="Nombre Línea de Acción" SortExpression="NOMBRELINEADEACCION" />
                        <asp:BoundField DataField="DESCRIPCIONLINEADEACCION" HeaderText="Descripción Línea de Acción" SortExpression="DESCRIPCIONLINEADEACCION" />
                        <asp:BoundField DataField="IDTIPOPERSONA" HeaderText="IDTIPOPERSONA" SortExpression="IDTIPOPERSONA" Visible="False" />
                        <asp:TemplateField HeaderText="Tipo de Personas">
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsTipoPersona" DataTextField="NOMBRETIPOPERSONA" DataValueField="IDTIPOPERSONA" SelectedValue='<%# Bind("IDTIPOPERSONA") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsTipoPersona" DataTextField="NOMBRETIPOPERSONA" DataValueField="IDTIPOPERSONA" Enabled="False" SelectedValue='<%# Bind("IDTIPOPERSONA") %>'>
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
            <td __designer:mapid="1ac">
                <asp:ObjectDataSource ID="odsLineasDeAccion" runat="server" DataObjectTypeName="CapaDatos.LINEADEACCION" DeleteMethod="D_eliminarLineaDeAccion" SelectMethod="D_consultarLineasDeAccion" TypeName="CapaDatos.clsDLineaAccion" UpdateMethod="D_editarLineasDeAccion" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="odsTipoPersona" runat="server" SelectMethod="D_consultarTipoPersona" TypeName="CapaDatos.clsDTipoPersona"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
