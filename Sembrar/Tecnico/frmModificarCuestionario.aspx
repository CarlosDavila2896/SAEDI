<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmModificarCuestionario.aspx.cs" Inherits="Sembrar.Administrador.frmModificarCuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" __designer:mapid="18d">
    <tr __designer:mapid="18e">
        <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">
            <asp:ScriptManager ID="scrCuestionario" runat="server">
            </asp:ScriptManager>
            Resolución de Fichas/Cuestionarios</td>
        <td __designer:mapid="190">&nbsp;</td>
    </tr>
</table>
<table style="width:100%;">
    <tr>
        <td class="auto-style7" style="vertical-align: top">
            <hr /></td>
    </tr>
</table>
<table __designer:mapid="192" class="auto-style4">
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" class="auto-style6">
            <table id="crearObjetivo" class="auto-style4">
                <tr>
                    <td class="auto-style3" colspan="2">Seleccionar el proceso y el individuo para resolver el cuestionario</td>
                </tr>
                <tr>
                    <td class="auto-style2">Línea de acción:</td>
                    <td>
                        <div class="auto-style3">
                        <asp:DropDownList ID="ddlLineaAccion" runat="server" AutoPostBack="True" DataSourceID="odsLineaAccion" DataTextField="NOMBRELINEAACCION" DataValueField="IDLINEAACCION" OnSelectedIndexChanged="ddlLineaAccion_SelectedIndexChanged" Width="70%">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsLineaAccion" runat="server" SelectMethod="D_consutarLineasDeAccionAsociadas" TypeName="CapaDatos.clsDLineaAccion"></asp:ObjectDataSource>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:UpdatePanel ID="updParametros" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="auto-style4">
                                    <tr>
                                        <td class="auto-style2">Proceso:</td>
                                        <td class="auto-style3">
                                            <asp:DropDownList ID="ddlProceso" runat="server" AutoPostBack="True" CssClass="auto-style5" DataSourceID="odsProceso" DataTextField="NOMBREPROCESO" DataValueField="IDPROCESO" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged" Height="19px" Width="70%">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsProceso" runat="server" SelectMethod="D_consutarProcesosActivosAsociados" TypeName="CapaDatos.clsDProceso">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlLineaAccion" Name="idLineaAccion" PropertyName="SelectedValue" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">Orientador</td>
                                        <td class="auto-style3">
                                            <asp:DropDownList ID="ddlOrientador" runat="server" AutoPostBack="True" DataSourceID="odsOrientador" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" OnSelectedIndexChanged="ddlOrientador_SelectedIndexChanged" Width="70%">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsOrientador" runat="server" SelectMethod="D_consutarOrientadoresActivosAsociados" TypeName="CapaDatos.clsDatosOrientador">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlLineaAccion" Name="idLineaAccion" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlProceso" Name="idProceso" PropertyName="SelectedValue" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">Periodo:</td>
                                        <td class="auto-style3">
                                            <asp:DropDownList ID="ddlPeriodo" runat="server" AutoPostBack="True" DataSourceID="odsPeriodo" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="70%">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsPeriodo" runat="server" SelectMethod="D_consutarPeriodosActivosAsociados" TypeName="CapaDatos.clsDPeriodo">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlLineaAccion" Name="idLineaAccion" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlProceso" Name="idProceso" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlOrientador" Name="idOrientador" PropertyName="SelectedValue" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">Individuo</td>
                                        <td class="auto-style4" colspan="2">
                                            <asp:ListBox ID="lstIndividuos" runat="server" Width="100%" DataSourceID="odsIndividuos" DataTextField="NOMBRE" DataValueField="IDPERSONA" Rows="10"></asp:ListBox>
                                            <asp:ObjectDataSource ID="odsIndividuos" runat="server" SelectMethod="D_consultaIndividuosPorLineaDeAccionOrientador" TypeName="CapaDatos.clsDatosPersona" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlLineaAccion" Name="idLineaAccion" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlOrientador" Name="idOrientador" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlProceso" Name="idProceso" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlPeriodo" Name="idPeriodo" PropertyName="SelectedValue" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlLineaAccion" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlProceso" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlOrientador" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlPeriodo" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">
                                                <asp:Button ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar" />
                                        </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">
                                            <asp:Panel ID="pnlCuestionario" runat="server" ClientIDMode="Static" Height="100%" ViewStateMode="Enabled" Width="320px">
                                            </asp:Panel>
                    </td>
                </tr>
                

                </table>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" class="auto-style6">
                                                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Modificar" Visible="False" OnClientClick="return confirm('¿Está seguro de guardar estas respuestas (Las anteriores respuestas serán eliminadas de la base de datos)?');" />
                                                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar Respuestas" OnClientClick="return confirm('¿Está seguro de eliminar estas respuestas (Las respuestas serán eliminadas de la base de datos y ya no se reflejarán en los reportes)?');" Visible="False"/>
                                                <br />
                                                <asp:Label ID="lblModificacion" runat="server" Font-Bold="True" ForeColor="Black" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
    <table style="width:100%;">

    </table>
</asp:Content>
