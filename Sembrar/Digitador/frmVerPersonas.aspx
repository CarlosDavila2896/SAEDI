<%@ Page Title="" Language="C#" MasterPageFile="~/Digitador/PrincipalDigitador.Master" AutoEventWireup="true" CodeBehind="frmVerPersonas.aspx.cs" Inherits="Sembrar.Digitador.Ver_Induviduo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style4 {
            height: 105px;
        }
        .auto-style5 {
            height: 18px;
        }
        .auto-style6 {
            font-size: medium;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14" colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;">
                Ver Individuos </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3" style="vertical-align: top">
                <hr />
            </td>
        </tr>
        <tr>
            <td>Filtrar por tipo de individuo:</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:LinkButton ID="lbtTodos" runat="server" OnClick="lbtTodos_Click">Todos</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtAdultos" runat="server" OnClick="lbtAdultos_Click">Adultos</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtJovenes" runat="server" OnClick="lbtJovenes_Click">Jóvenes</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtNinios" runat="server" OnClick="lbtNinios_Click">Niños</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="3">Filtrar por nombre o Codigo SAD(Solo aplica para niños y jovenes):<br />
&nbsp;<asp:TextBox ID="txtNombre" runat="server" AutoPostBack="True" Width="367px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Height="24px" OnClick="btnBuscar_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlCodigos" runat="server">
                    Filtrar por Codigo:<br />
                    <asp:LinkButton ID="lbtPRO" runat="server" OnClick="lbtPRO_Click">PRO</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtQUI" runat="server" OnClick="lbtQUI_Click">QUI</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbtOYE" runat="server" OnClick="lbtOYE_Click">OYE</asp:LinkButton>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="3">
                        <asp:GridView ID="gvIndividuos" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="odsIndividuos" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="gvIndividuos_RowDataBound" OnSelectedIndexChanged="gvIndividuos_SelectedIndexChanged" Width="100%" DataKeyNames="ID">
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Ver/Editar"/>
                                <asp:TemplateField HeaderText="Género">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False" SelectedValue='<%# Bind("GENERO") %>'>
                                            <asp:ListItem Value="True">Masculino</asp:ListItem>
                                            <asp:ListItem Value="False">Femenino</asp:ListItem>
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
                        <asp:ObjectDataSource ID="odsIndividuos" runat="server" SelectMethod="consultarInfoIndividuos" TypeName="CapaDatos.clsDatosPersona"></asp:ObjectDataSource>
                        <br />
                        <span class="auto-style6"><strong>TOTAL DE INDIVIDUOS:</strong></span>
                        <asp:Label ID="lblCantidad" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style16">
                &nbsp;</td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style13" colspan="3">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
