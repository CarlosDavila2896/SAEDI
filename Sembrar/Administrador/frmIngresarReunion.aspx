<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmIngresarReunion.aspx.cs" Inherits="Sembrar.Administrador.CrearReunion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 266px;
        }
        .auto-style2 {
            height: 17px;
        }
        .auto-style3 {
            width: 268px;
            height: 17px;
        }
        .auto-style4 {
            width: 268px;
        }
        .auto-style5 {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style9">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">CREAR REUNIÓN</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>Linea de Acción:</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlLineaAccion" runat="server" OnSelectedIndexChanged="ddlLineaAccion_SelectedIndexChanged" Width="220px" AutoPostBack="True" style="height: 23px">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Proceso:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlProceso" runat="server" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged" Width="220px" AutoPostBack="True" style="height: 23px">
                </asp:DropDownList>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>Orientador:</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlOrientador" runat="server" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" OnSelectedIndexChanged="ddlOrientador_SelectedIndexChanged" AutoPostBack="True" Width="220px">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>Periodo:</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlPeriodo" runat="server" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" OnSelectedIndexChanged="ddlOrientador_SelectedIndexChanged" Width="220px">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>Fecha:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtFecha" runat="server" Height="22px" TextMode="Date" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>Hora Reunión:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtHora" runat="server" TextMode="Time" Width="220px"></asp:TextBox>
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>Tema</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtTema" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td>Tipo de asistentes:</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlTipoAsistentes" runat="server" DataTextField="NOMBREORIENTADOR" DataValueField="IDORIENTADOR" Width="220px">
                </asp:DropDownList>
            </td>
            <td class="auto-style7">
                <br />
            </td>
        </tr>
        <tr>
            <td>Observación:</td>
            <td class="auto-style4">
                <asp:TextBox ID="TxtObservacion" runat="server"  TextMode="MultiLine" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="AGREGAR REUNIÓN" Width="220px" />
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3"><strong>Reuniones</strong></td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="3">
                <asp:GridView ID="gvReuniones" runat="server" DataSourceID="odsReuniones" Width="100%">
                </asp:GridView>
                <asp:ObjectDataSource ID="odsReuniones" runat="server" SelectMethod="consultaDatosReuniones" TypeName="CapaDatos.clsDatosReunion">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlLineaAccion" Name="idLinea" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlProceso" Name="idProceso" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlOrientador" Name="idOrientador" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="ddlPeriodo" Name="idPeriodo" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
