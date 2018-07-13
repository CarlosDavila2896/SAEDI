<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmManejoMatriculas.aspx.cs" Inherits="Sembrar.Tecnico.frmManejoMatriculas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        text-align: right;
    }
    .auto-style2 {
        text-align: center;
    }
    .auto-style4 {
        text-align: left;
    }
    .auto-style5 {
        margin-left: 0;
    }
    .auto-style6 {
        text-align: left;
        width: 339px;
    }
        .auto-style7 {
            height: 32px;
            text-align: center;
        }
        .auto-style8 {
            width: 100%;
            height: 723px;
        }
        .auto-style9 {
            width: 100%;
            height: 591px;
        }
        .auto-style10 {
            text-align: right;
            height: 51px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;" __designer:mapid="18d">
    <tr __designer:mapid="18e">
        <td class="auto-style14" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" __designer:mapid="18f">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Manejo de Matriculas</td>
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
        <td __designer:mapid="1ac">
            <table id="crearObjetivo" class="auto-style8">
                <tr>
                    <td class="auto-style2" colspan="2">Consultar un niño/joven a una linea de accion, proceso</td>
                </tr>
                <tr>
                    <td class="auto-style1">Línea de acción:</td>
                    <td>
                        <asp:DropDownList ID="ddlLineaAccion" runat="server" AutoPostBack="True" DataSourceID="odsLineaAccion" DataTextField="NOMBRELINEAACCION" DataValueField="IDLINEAACCION" OnSelectedIndexChanged="ddlLineaAccion_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsLineaAccion" runat="server" SelectMethod="D_consutarLineasDeAccionAsociadas" TypeName="CapaDatos.clsDLineaAccion"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:UpdatePanel ID="updParametros" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="auto-style9">
                                    <tr>
                                        <td class="auto-style1">Proceso:</td>
                                        <td class="auto-style6">
                                            <asp:DropDownList ID="ddlProceso" runat="server" AutoPostBack="True" CssClass="auto-style5" DataSourceID="odsProceso" DataTextField="NOMBREPROCESO" DataValueField="IDPROCESO" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged">
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
                                        <td class="auto-style1">Orientador</td>
                                        <td class="auto-style6">
                                            <asp:DropDownList ID="ddlOrientador" runat="server" AutoPostBack="True" DataSourceID="odsOrientador" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" OnSelectedIndexChanged="ddlOrientador_SelectedIndexChanged">
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
                                        <td class="auto-style1">Periodo:</td>
                                        <td class="auto-style6">
                                            <asp:DropDownList ID="ddlPeriodo" runat="server" AutoPostBack="True" DataSourceID="odsPeriodo" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged">
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
                                        <td class="auto-style2" colspan="3">Niños/Jovenes matriculados en dicha linea de acción</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10" colspan="3">
                                            <div class="auto-style2">
                                            </div>
                                            <asp:ObjectDataSource ID="odsMatriculas" runat="server" SelectMethod="D_consultarMatriculasFiltradas" TypeName="CapaDatos.clsDMatriculas">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlLineaAccion" Name="idLineaAccion" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlProceso" Name="idProceso" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlOrientador" Name="idOrientador" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlPeriodo" Name="idPeriodo" PropertyName="SelectedValue" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1" colspan="3">
                                            <asp:GridView ID="gvMatriculas" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="odsMatriculas" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="gvMatriculas_RowDataBound" Width="100%" OnSelectedIndexChanged="gvMatriculas_SelectedIndexChanged" DataKeyNames="IDMATRICULA">
                                                <Columns>
                                                    <asp:CommandField ShowSelectButton="True" SelectText="Eliminar"/>
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
                                        <td class="auto-style1" colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1" colspan="3">&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlLineaAccion" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlProceso" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlOrientador" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlPeriodo" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="gvMatriculas" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                </table>
        </td>
    </tr>
</table>
</asp:Content>
