<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmManejoPreguntas.aspx.cs" Inherits="Sembrar.Tecnico.frmManejoPreguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style4 {
            text-align: right;
        }
        .auto-style5 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" __designer:mapid="18d">
        <tr __designer:mapid="18e">
            <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">Manejo de Preguntas</td>
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
                        <td class="auto-style2">&nbsp;</td>
                        <td>
                            <asp:ObjectDataSource ID="odsTipoPregunta" runat="server" SelectMethod="consultaTipoPreguntas" TypeName="CapaDatos.clsDPregunta"></asp:ObjectDataSource>
                        </td>
            <td __designer:mapid="1ae">&nbsp;</td>
        </tr>
            <td __designer:mapid="1ac" class="auto-style4">Ingrese un texto:</td>
            <td __designer:mapid="1ad" class="auto-style5" colspan="2">
                <asp:TextBox ID="txtBuscar" runat="server" Width="243px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
            </td>
        </tr>
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac">&nbsp;</td>
            <td __designer:mapid="1ad" style="text-align: right">&nbsp;</td>
            <td __designer:mapid="1ae">&nbsp;</td>
        </tr>
        <tr __designer:mapid="1ab">
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac">&nbsp;</td>
            <td __designer:mapid="1ad" style="text-align: right">&nbsp;</td>
            <td __designer:mapid="1ae">&nbsp;</td>
        </tr>
        <tr __designer:mapid="1ab">
            <td __designer:mapid="1ac" colspan="3" class="auto-style1">
                <asp:GridView ID="gvPreguntas" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="odsPreguntas" DataKeyNames="IDPREGUNTA,IDTIPOPREGUNTA" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar la pregunta de la base de datos (Si pregunta pertenece a algun cuestionario/ficha, esto no será posible)?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                        <asp:BoundField DataField="IDPREGUNTA" HeaderText="IDPREGUNTA" SortExpression="IDPREGUNTA" Visible="False" />
                        <asp:BoundField DataField="IDTIPOPREGUNTA" HeaderText="IDTIPOPREGUNTA" SortExpression="IDTIPOPREGUNTA" Visible="False" />
                        <asp:BoundField DataField="NOMBREPREGUNTA" HeaderText="Texto de la pregunta" SortExpression="NOMBREPREGUNTA" />
                        <asp:CheckBoxField DataField="ESTADOPREGUNTA" HeaderText="ESTADOPREGUNTA" SortExpression="ESTADOPREGUNTA" Visible="False" />
                        <asp:TemplateField HeaderText="Tipo de pregunta">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="odsTipoPregunta" DataTextField="NOMBRETIPOPREGUNTA" DataValueField="IDTIPOPREGUNTA" Height="19px" SelectedValue='<%# Bind("IDTIPOPREGUNTA") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="odsTipoPregunta" DataTextField="NOMBRETIPOPREGUNTA" DataValueField="IDTIPOPREGUNTA" Enabled="False" SelectedValue='<%# Bind("IDTIPOPREGUNTA") %>'>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado de la pregunta">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEstado" runat="server" SelectedValue='<%# Bind("ESTADOPREGUNTA") %>'>
                                    <asp:ListItem Value="True">Activo</asp:ListItem>
                                    <asp:ListItem Value="False">Inactivo</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlEstado" runat="server" Enabled="False" SelectedValue='<%# Bind("ESTADOPREGUNTA") %>'>
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
                <asp:ObjectDataSource ID="odsPreguntas" runat="server" DataObjectTypeName="CapaDatos.PREGUNTA" DeleteMethod="D_eliminarPregunta" SelectMethod="D_consultarPreguntas" TypeName="CapaDatos.clsDPregunta" UpdateMethod="D_editarPreguntas">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtBuscar" Name="filtro" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
