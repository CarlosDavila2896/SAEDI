<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmManejoObjetivos.aspx.cs" Inherits="Sembrar.Tecnico.frmManejoObjetivos" %>
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
        <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">Manejo de Objetivos</td>
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
            
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac">&nbsp;</td>
        <td __designer:mapid="1ad" style="text-align: right">&nbsp;</td>
        <td __designer:mapid="1ae">&nbsp;</td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style1">
            <asp:GridView ID="gvObjetivos" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="odsObjetivos" DataKeyNames="IDOBJETIVO" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar el objetivo de la base de datos (Si el objetivo tiene asignado indicadores no será posible)?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                    <asp:BoundField DataField="IDOBJETIVO" HeaderText="IDOBJETIVO" SortExpression="IDOBJETIVO" Visible="False" ApplyFormatInEditMode="True" />
                    <asp:BoundField DataField="NOMBREOBJETIVO" HeaderText="Nombre del Objetivo" SortExpression="NOMBREOBJETIVO" />
                    <asp:CheckBoxField DataField="ESTADOOBJETIVO" HeaderText="ESTADOOBJETIVO" InsertVisible="False" SortExpression="ESTADOOBJETIVO" Visible="False" />
                    <asp:TemplateField HeaderText="Estado del Objetivo">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEstado" runat="server" SelectedValue='<%# Bind("ESTADOOBJETIVO") %>'>
                                <asp:ListItem Value="True">Activo</asp:ListItem>
                                <asp:ListItem Value="False">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlEstado" runat="server" Enabled="False" SelectedValue='<%# Bind("ESTADOOBJETIVO") %>'>
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
            <asp:ObjectDataSource ID="odsObjetivos" runat="server" DataObjectTypeName="CapaDatos.OBJETIVO" DeleteMethod="D_eliminarObjetivos" SelectMethod="D_consultarObjetivos" TypeName="CapaDatos.clsDObjetivo" UpdateMethod="D_editarObjetivo"></asp:ObjectDataSource>
        </td>
    </tr>
</table>
</asp:Content>
