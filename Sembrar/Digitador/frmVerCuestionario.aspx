<%@ Page Title="" Language="C#" MasterPageFile="~/Digitador/PrincipalDigitador.Master" AutoEventWireup="true" CodeBehind="frmVerCuestionario.aspx.cs" Inherits="Sembrar.Digitador.frmVerCuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 18px;
            height: 50px;
        }
        .auto-style5 {
            width: 22px;
            height: 50px;
        }
    </style>
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
                    <td class="auto-style3">Seleccionar el proceso y el individuo para resolver el cuestionario</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:UpdatePanel ID="updParametros" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="auto-style4">
                                    <tr>
                                        <td class="auto-style5">Proceso:</td>
                                        <td class="auto-style3">
                                            <asp:DropDownList ID="ddlProceso" runat="server" CssClass="auto-style5" DataSourceID="odsProceso" DataTextField="NOMBREPROCESO" DataValueField="IDPROCESO" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged" Height="19px" Width="70%">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsProceso" runat="server" SelectMethod="D_consultarProcesosActivosOrdenadosPorTipo" TypeName="CapaDatos.clsDProceso" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="1" Name="idtipo" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style5">Orientador</td>
                                        <td class="auto-style3">
                                            <asp:DropDownList ID="ddlOrientador" runat="server" DataSourceID="odsOrientador" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" OnSelectedIndexChanged="ddlOrientador_SelectedIndexChanged" Width="70%">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsOrientador" runat="server" SelectMethod="D_consultarOrientadoresNombresCompletos" TypeName="CapaDatos.clsDOrientador">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style5">Periodo:</td>
                                        <td class="auto-style3">
                                            <asp:DropDownList ID="ddlPeriodo" runat="server" DataSourceID="odsPeriodo" DataTextField="NOMBREPERIODO" DataValueField="IDPERIODO" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="70%">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsPeriodo" runat="server" SelectMethod="consultarPeriodoActivo" TypeName="CapaDatos.clsDPeriodo">
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style5">Individuo</td>
                                        <td class="auto-style4" colspan="2">
                                            <asp:ListBox ID="lstIndividuos" runat="server" Width="100%" DataSourceID="odsIndividuos" DataTextField="NOMBRES" DataValueField="ID" Rows="10"></asp:ListBox>
                                            <asp:ObjectDataSource ID="odsIndividuos" runat="server" SelectMethod="D_consultaIndividuosPorLineaDeAccionOrientador" TypeName="CapaDatos.clsDatosPersona" OldValuesParameterFormatString="original_{0}">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                                                <asp:Button ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar" />
                                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                                            <asp:Panel ID="pnlCuestionario" runat="server" ClientIDMode="Static" Height="100%" ViewStateMode="Enabled" Width="320px">
                                            </asp:Panel>
                    </td>
                </tr>
                

                </table>
        </td>
    </tr>
    <tr __designer:mapid="1ab">
        <td __designer:mapid="1ac" class="auto-style6">
                                                <br />
        </td>
    </tr>
</table>
    <table style="width:100%;">

    </table>
</asp:Content>
