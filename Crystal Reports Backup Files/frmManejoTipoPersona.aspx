<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmManejoTipoPersona.aspx.cs" Inherits="Sembrar.Tecnico.frmManejoTipoPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style4 {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" __designer:mapid="18d">
        <tr __designer:mapid="18e">
            <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">Manejo de Tipo Persona</td>
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
            <td __designer:mapid="1ac" class="auto-style4"></td>
            <td __designer:mapid="1ad" style="text-align: right" class="auto-style4"></td>
            <td __designer:mapid="1ae" class="auto-style4"></td>
        </tr>
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac" colspan="3" class="auto-style1">
                <asp:GridView ID="gvTiposPersona" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="IDTIPOPERSONA" DataSourceID="odsTiposPersona" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar el tipo de persona de la base de datos (Si el tipo de persona tiene asignado una linea de acción no será posible)?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                        <asp:BoundField DataField="IDTIPOPERSONA" HeaderText="IDTIPOPERSONA" SortExpression="IDTIPOPERSONA" Visible="False" />
                        <asp:BoundField DataField="NOMBRETIPOPERSONA" HeaderText="Nombre de Tipo de Persona" SortExpression="NOMBRETIPOPERSONA" />
                        <asp:BoundField DataField="EDADMINIMA" HeaderText="Edad Minima" SortExpression="EDADMINIMA" />
                        <asp:BoundField DataField="EDADMAXIMA" HeaderText="Edad Maxima" SortExpression="EDADMAXIMA" />
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
                <asp:ObjectDataSource ID="odsTiposPersona" runat="server" DataObjectTypeName="CapaDatos.TIPOPERSONA" DeleteMethod="D_eliminarTiposPersonas" SelectMethod="D_consultarTipoPersona" TypeName="CapaDatos.clsDTipoPersona" UpdateMethod="D_editarTipoPersona"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
