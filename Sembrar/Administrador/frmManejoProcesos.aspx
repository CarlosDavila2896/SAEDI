<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmManejoProcesos.aspx.cs" Inherits="Sembrar.Administrador.frmManejoProcesos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--Método para mostrar -->
    <script type="text/javascript">
        function mostrarTabla() {
            var tabla = document.getElementById('tblAsignarRelaciones');
            if (tabla.style.display == 'table') {
                tabla.style.display = 'none';
                tabla.style.width = '100%';
            } else {
                tabla.style.display = 'table';
                tabla.style.width = '100%';
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
        .auto-style3 {
            height: 18px;
        }
        .auto-style4 {
            height: 18px;
            text-align: center;
        }
        .auto-style5 {
            width: 221px;
        }
        .auto-style6 {
            text-align: right;
            width: 221px;
        }
        .auto-style7 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" __designer:mapid="18d">
    <tr __designer:mapid="18e">
        <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">
            <asp:ScriptManager ID="scrRelaciones" runat="server">
            </asp:ScriptManager>
            Manejo de Procesos</td>
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
                    <td class="auto-style1" colspan="3">Crear nuevo Proceso</td>
                </tr>
                <tr>
                    <td class="auto-style2">Nombre del proceso:</td>
                    <td>
                        <asp:TextBox ID="txtNombreProceso" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo de proceso:&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlTipoProceso" runat="server" DataSourceID="odsTipoProceso" DataTextField="NOMBRETIPOPROCESO" DataValueField="IDTIPOPROCESO">
                        </asp:DropDownList>
                        <br />
                        <asp:ObjectDataSource ID="odsTipoProceso" runat="server" SelectMethod="obtenerTiposProceso" TypeName="CapaDatos.clsDTipoProceso"></asp:ObjectDataSource>
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
        <td __designer:mapid="1ad" style="text-align: right">&nbsp;</td>
        <td __designer:mapid="1ae">&nbsp;</td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style1">
            <asp:GridView ID="gvProcesos" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="IDPROCESO" DataSourceID="odsProcesos" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" >
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar el proceso de la base de datos (Si el proceso tiene asignado objetivos no será posible)?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                    <asp:BoundField DataField="IDPROCESO" HeaderText="IDPROCESO" SortExpression="IDPROCESO" Visible="False" />
                    <asp:BoundField DataField="NOMBREPROCESO" HeaderText="Nombre del Proceso" SortExpression="NOMBREPROCESO" />
                    <asp:CheckBoxField DataField="ESTADOPROCESO" HeaderText="ESTADOPROCESO" InsertVisible="False" SortExpression="ESTADOPROCESO" Visible="False" />
                    <asp:TemplateField HeaderText="Estado del Proceso">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEstado" runat="server" SelectedValue='<%# Bind("ESTADOPROCESO") %>'>
                                <asp:ListItem Value="True">Activo</asp:ListItem>
                                <asp:ListItem Value="False">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlEstado" runat="server" Enabled="False" SelectedValue='<%# Bind("ESTADOPROCESO") %>'>
                                <asp:ListItem Value="True">Activo</asp:ListItem>
                                <asp:ListItem Value="False">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="IDTIPOPROCESO" HeaderText="IDTIPOPROCESO" InsertVisible="False" SortExpression="IDTIPOPROCESO" Visible="False" />
                    <asp:TemplateField HeaderText="Tipo de Proceso">
                        <EditItemTemplate>
                                <asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="odsTipoProceso" DataTextField="NOMBRETIPOPROCESO" DataValueField="IDTIPOPROCESO" Height="19px" SelectedValue='<%# Bind("IDTIPOPROCESO") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="odsTipoProceso" DataTextField="NOMBRETIPOPROCESO" DataValueField="IDTIPOPROCESO" Enabled="False" SelectedValue='<%# Bind("IDTIPOPROCESO") %>'>
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
            <asp:ObjectDataSource ID="odsProcesos" runat="server" DataObjectTypeName="CapaDatos.PROCESO" DeleteMethod="D_eliminarProceso" SelectMethod="D_consultarProcesos" TypeName="CapaDatos.clsDProceso" UpdateMethod="D_editarProceso"></asp:ObjectDataSource>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style3">
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style4">
            <input id="btnMostrarRelaciones" type="button" value="Mostrar/Ocultar Asignacion de Procesos y Orientadores" onclick="mostrarTabla()"/></td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style3">
            &nbsp;</td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style3">
            <table id="tblAsignarRelaciones" style="width:100%; display:none;">
                <tr>
                    <td class="auto-style1" colspan="3">Relacionar lineas de acción, proceso, orientador y periodo</td>
                </tr>
                <tr>
                    <td class="auto-style7" colspan="3">Seleccione una linea de acción</td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="3">
                        <asp:ListBox ID="lstLineasAccion" runat="server" DataSourceID="odsLineasAccion" DataTextField="NOMBRELINEADEACCION" DataValueField="IDLINEADEACCION" Width="70%" AutoPostBack="True" OnSelectedIndexChanged="lstLineasAccion_SelectedIndexChanged" Rows="10"></asp:ListBox>
                        <asp:ObjectDataSource ID="odsLineasAccion" runat="server" SelectMethod="D_consultarLineasDeAccionActivasOrdenadas" TypeName="CapaDatos.clsDLineaAccion"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">Seleccione un proceso</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ListBox ID="lstProcesos" runat="server" DataSourceID="odsProcesosActivos" DataTextField="NOMBREPROCESO" DataValueField="IDPROCESO" Width="70%" AutoPostBack="True" OnSelectedIndexChanged="lstProcesos_SelectedIndexChanged" Rows="10"></asp:ListBox>
                        <asp:ObjectDataSource ID="odsProcesosActivos" runat="server" SelectMethod="D_consultarProcesosActivosOrdenadosPorTipo" TypeName="CapaDatos.clsDProceso" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="2" Name="idtipo" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">Seleccione un orientador</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ListBox ID="lstOrientador" runat="server" DataSourceID="odsOrientador" Width="70%" DataTextField="NOMBRE" DataValueField="ID_ORIENTADOR" AutoPostBack="True" OnSelectedIndexChanged="lstOrientador_SelectedIndexChanged" Rows="10"></asp:ListBox>
                        <asp:ObjectDataSource ID="odsOrientador" runat="server" SelectMethod="consultarOrientador" TypeName="CapaDatos.clsDatosOrientador"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">Seleccione un periodo</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ListBox ID="lstPeriodo" runat="server" DataSourceID="odsPeriodo" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO" Width="70%" Rows="10"></asp:ListBox>
                        <asp:ObjectDataSource ID="odsPeriodo" runat="server" SelectMethod="D_consultaPeriodosAniosLectivos" TypeName="CapaDatos.clsDPeriodo"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Observación:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtObservacion" runat="server" Height="55px" TextMode="MultiLine" Width="235px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="3">
                        <asp:Button ID="btnIngresarRelacion" runat="server" OnClick="btnIngresarRelacion_Click" Text="Ingresar Relación" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:UpdatePanel ID="updRelaciones" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gvRelaciones" runat="server" AutoGenerateColumns="False" DataKeyNames="IDLINEADEACCION,IDORIENTADOR,IDPROCESO,IDPERIODO" DataSourceID="odsRelaciones" Width="100%" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" PageSize="15">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Está seguro de eliminar la relación de la base de datos (Si la relación tiene alguna referencia, esto no será posible)?');"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="True"  ButtonType="Button"/>
                                        <asp:BoundField DataField="IDLINEADEACCION" HeaderText="IDLINEADEACCION" SortExpression="IDLINEADEACCION" Visible="False" />
                                        <asp:TemplateField HeaderText="Linea de Acción">
                                            <EditItemTemplate>
                                               <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="odsLineasAccion" DataTextField="NOMBRELINEADEACCION" DataValueField="IDLINEADEACCION" Enabled="False" SelectedValue='<%# Bind("IDLINEADEACCION") %>'>
                                                 </asp:DropDownList>
                                               </EditItemTemplate>
                                               <ItemTemplate>
                                                 <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="odsLineasAccion" DataTextField="NOMBRELINEADEACCION" DataValueField="IDLINEADEACCION" Enabled="False" SelectedValue='<%# Bind("IDLINEADEACCION") %>' Width="120px">
                                               </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IDORIENTADOR" HeaderText="IDORIENTADOR" SortExpression="IDORIENTADOR" Visible="False" />
                                        <asp:TemplateField HeaderText="Orientador">
                                            <EditItemTemplate>
                                               <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="odsOrientador" DataTextField="NOMBRE" DataValueField="ID_ORIENTADOR" Enabled="False" SelectedValue='<%# Bind("IDORIENTADOR") %>'>
                                                 </asp:DropDownList>
                                               </EditItemTemplate>
                                               <ItemTemplate>
                                                 <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="odsOrientador" DataTextField="NOMBRE" DataValueField="ID_ORIENTADOR" Enabled="False" SelectedValue='<%# Bind("IDORIENTADOR") %>' Width="100px">
                                               </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IDPROCESO" HeaderText="IDPROCESO" SortExpression="IDPROCESO" Visible="False" />
                                        <asp:TemplateField HeaderText="Proceso">
                                            <EditItemTemplate>
                                               <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="odsProcesosActivos" DataTextField="NOMBREPROCESO" DataValueField="IDPROCESO" Enabled="False" SelectedValue='<%# Bind("IDPROCESO") %>'>
                                                 </asp:DropDownList>
                                               </EditItemTemplate>
                                               <ItemTemplate>
                                                 <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="odsProcesosActivos" DataTextField="NOMBREPROCESO" DataValueField="IDPROCESO" Enabled="False" SelectedValue='<%# Bind("IDPROCESO") %>' Width="120px">
                                               </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IDPERIODO" HeaderText="IDPERIODO" SortExpression="IDPERIODO" Visible="False" />
                                        <asp:TemplateField HeaderText="Periodo">
                                            <EditItemTemplate>
                                               <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="odsTodosLosPeriodos" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO" Enabled="False" SelectedValue='<%# Bind("IDPERIODO") %>'>
                                                 </asp:DropDownList>
                                               </EditItemTemplate>
                                               <ItemTemplate>
                                                 <asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="odsTodosLosPeriodos" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO" Enabled="False" SelectedValue='<%# Bind("IDPERIODO") %>' Width="80px">
                                               </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OBSERVACION" HeaderText="OBSERVACION" SortExpression="OBSERVACION" />
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
                                <asp:ObjectDataSource ID="odsRelaciones" runat="server" DataObjectTypeName="CapaDatos.ORIENTADORACARGODEPROCESOENPERIODO" DeleteMethod="D_eliminarRelacionLA_PR_OR_PER" SelectMethod="D_consultarRelacionLA_PR_OR_PERFiltrada" TypeName="CapaDatos.clsDRelacionPR_LA_ORI" UpdateMethod="D_editarRelacionLA_PR_OR_PER">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lstLineasAccion" Name="idLineaAccion" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="lstProcesos" Name="idProceso" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="lstOrientador" Name="idOrientador" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lstLineasAccion" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="lstProcesos" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="lstOrientador" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="btnIngresarRelacion" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style3">
            <asp:ObjectDataSource ID="odsTodosLosPeriodos" runat="server" SelectMethod="consultaAniosLectivosCrudos" TypeName="CapaDatos.clsDPeriodo" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" colspan="3" class="auto-style3">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
