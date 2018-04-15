<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmManejoRespuestas.aspx.cs" Inherits="Sembrar.Administrador.frmManejoRespuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--Método para mostrar -->
    <script type="text/javascript">
        function mostrarTabla() {
            var tabla = document.getElementById('tblRelaciones');
            if (tabla.style.display == 'table') {
                tabla.style.display = 'none';
                tabla.style.width = '100%';
                var list1 = document.getElementById(<%= lstPreguntas.ClientID %>);
                list1.style.width = "100%";
            } else {
                tabla.style.display = 'table';
                tabla.style.width = '100%';
                var list1 = document.getElementById(<%= lstPreguntas.ClientID %>);
                list1.style.width = "100%";
            }
        }
    </script>

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
    <asp:ScriptManager ID="scmRelaciones" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <table style="width:100%;" __designer:mapid="18d">
    <tr __designer:mapid="18e">
        <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">Manejo de Respuestas</td>
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
        <td __designer:mapid="1ac" colspan="4">
            <table id="crearProceso" style="width: 100%;">
                <tr>
                    <td class="auto-style1" colspan="3">Crear nueva respuesta</td>
                </tr>
                <tr>
                    <td class="auto-style2">Texto de la respuesta:</td>
                    <td>
                        <asp:TextBox ID="txtNombreRespuesta" runat="server" Width="92%"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Puntaje de respuesta:</td>
                    <td>
                        <asp:TextBox ID="txtPuntaje" runat="server" TextMode="Number" Width="60%"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac">&nbsp;</td>
        <td __designer:mapid="1ad" style="text-align: right" colspan="2">&nbsp;</td>
        <td __designer:mapid="1ae">&nbsp;</td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="4" class="auto-style1">
            <asp:GridView ID="gvRespuestas" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="odsRespuestas" DataKeyNames="IDPOSIBLERESPUESTA" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="20" >
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar la respuesta de la base de datos (Si respuesta esta asociada a alguna pregunta, esto no será posible)?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                    <asp:BoundField DataField="IDPOSIBLERESPUESTA" HeaderText="IDPOSIBLERESPUESTA" SortExpression="IDPOSIBLERESPUESTA" Visible="False" />
                    <asp:BoundField DataField="TEXTOPOSIBLERESPUESTA" HeaderText="Texto Respuesta" SortExpression="TEXTOPOSIBLERESPUESTA" />
                    <asp:BoundField DataField="PUNTAJEPOSIBLERESPUESTA" HeaderText="Puntaje Respuesta" SortExpression="PUNTAJEPOSIBLERESPUESTA" />
                    <asp:CheckBoxField DataField="ESTADOPOSIBLERESPUESTA" HeaderText="ESTADOPOSIBLERESPUESTA" SortExpression="ESTADOPOSIBLERESPUESTA" Visible="False" />
                    <asp:TemplateField HeaderText="Estado Respuesta">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEstado" runat="server" SelectedValue='<%# Bind("ESTADOPOSIBLERESPUESTA") %>'>
                                <asp:ListItem Value="True">Activo</asp:ListItem>
                                <asp:ListItem Value="False">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlEstado" runat="server" Enabled="False" SelectedValue='<%# Bind("ESTADOPOSIBLERESPUESTA") %>'>
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
        <td __designer:mapid="1ac" colspan="4">
            <asp:ObjectDataSource ID="odsRespuestas" runat="server" DataObjectTypeName="CapaDatos.POSIBLERESPUESTA" DeleteMethod="D_eliminarPosibleRespuesta" SelectMethod="D_consultarPosiblesRespuestas" TypeName="CapaDatos.clsDPosibleRespuesta" UpdateMethod="D_editarPosibleRespuesta"></asp:ObjectDataSource>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="4">
            &nbsp;</td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="4" class="auto-style1">
            <input id="btnMostrar" type="button" value="Mostrar/Ocultar Relaciones Preguntas-Respuestas" onclick="mostrarTabla()" /></td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="4">
            <table id="tblRelaciones" style="width:100%; display:none;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">Seleccione una pregunta</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ListBox ID="lstPreguntas" runat="server" Width="90%" DataSourceID="odsPreguntas" DataTextField="NOMBREPREGUNTA" DataValueField="IDPREGUNTA" OnSelectedIndexChanged="lstPreguntas_SelectedIndexChanged" AutoPostBack="True" Rows="10"></asp:ListBox>
                        <asp:ObjectDataSource ID="odsPreguntas" runat="server" SelectMethod="D_consultarPreguntasCerradasActivasOrdenadas" TypeName="CapaDatos.clsDPregunta" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">Seleccione una respuesta</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ListBox ID="lstPosibleRespuesta" runat="server" Width="90%" Rows="10"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1">
                        <asp:Button ID="btnIngresarRelacion" runat="server" Text="Ingresar Relación" OnClick="btnIngresarRelacion_Click" CausesValidation="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:UpdatePanel ID="updRelaciones" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td class="auto-style1" colspan="3">Respuestas Asociadas a la Pregunta</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="auto-style1">
                                            <asp:GridView ID="gvRelacionPR" runat="server" Width="100%" OnSelectedIndexChanged="gvRelacionPR_SelectedIndexChanged" OnRowDataBound="gvRelacionPR_RowDataBound" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" PageSize="15">
                                                <Columns>
                                                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Eliminar" />
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
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lstPreguntas" EventName="SelectedIndexChanged" />          
                                <asp:AsyncPostBackTrigger ControlID="gvRelacionPR" EventName="SelectedIndexChanged" />  
                                <asp:AsyncPostBackTrigger ControlID="btnIngresarRelacion" EventName="Click" />                              
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="2">
            &nbsp;</td>
        <td __designer:mapid="1ac" colspan="2">
            &nbsp;</td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="4">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
