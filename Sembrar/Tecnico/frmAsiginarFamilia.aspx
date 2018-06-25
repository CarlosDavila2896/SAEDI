<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmAsiginarFamilia.aspx.cs" Inherits="Sembrar.Tecnico.AsignarFamiliaIndividuos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 82px;
        }
    </style>
    <script type="text/javascript">
        function habilitarTextBox() {
            // Get the checkbox
            var checkBox = document.getElementById("ckhEditarNombre");
            // Get the output text
            var text = document.getElementById('<%=txtNombreFamlia.ClientID%>');

            // If the checkbox is checked, display the output text
            if (checkBox.checked == true) {
                text.disabled = false;
            } else {
                text.disabled = true;
            }
        }
        function habilitarAreaTextBox() {
            // Get the checkbox
            var checkBox = document.getElementById("ckhEditarDireccion");
            // Get the output text
            var text = document.getElementById('<%=txtDireccion.ClientID%>');

            // If the checkbox is checked, display the output text
            if (checkBox.checked == true) {
                text.disabled = false;
            } else {
                text.disabled = true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2"><h2>Asignar Individuos - Familia</h2></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label1" runat="server" Text="Seleccionar Familia"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlFamilia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFamilia_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style10"></td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style9">Nombre de la Familia:</td>
            <td class="auto-style10">
                <asp:TextBox ID="txtNombreFamlia" runat="server" Width="187px" Enabled="false"></asp:TextBox>
                <input id="ckhEditarNombre" name="Editar" type="checkbox" value="Editar" onclick="habilitarTextBox()"/>Editar</td>
            <td class="auto-style11">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label2" runat="server" Text="Seleccionar Individuo"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlIndividuos" runat="server" OnSelectedIndexChanged="ddlIndividuos_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style10">
                Buscar:
                <asp:TextBox ID="txtBusqueda" runat="server" AutoPostBack="True" OnTextChanged="txtBusqueda_TextChanged" Width="217px"></asp:TextBox>
            </td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label5" runat="server" Text="Seleccionar Parentesco Individuo"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlParentezco" runat="server" DataSourceID="odsParentezco" DataTextField="NOMBREPARENTEZCO" DataValueField="IDPARENTEZCO" AutoPostBack="True">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsParentezco" runat="server" SelectMethod="consultarParentezcos" TypeName="CapaDatos.clsDParentezco"></asp:ObjectDataSource>
            </td>
            <td>
                <strong>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                </strong>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label3" runat="server" Text="Miembros de la Familia Actual"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:GridView ID="gvFamilia" runat="server" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="gvFamilia_RowDataBound" OnRowDeleting="gvFamilia_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label4" runat="server" Text="Seleccionar Representante"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:DropDownList ID="ddlRepresentante" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">Observacion:<br />
                (Aquí ingrese los miembros adicionales<br />
                de la familia que no costen en el sistema)<br />
                Ej: 2 primos<br />
                1 tio<br />
                (Un miembro por línea)</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtObservacion" runat="server" Height="73px" TextMode="MultiLine" Width="228px"></asp:TextBox>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Total Miembros familia:</td>
            <td class="auto-style8">
                <asp:Label ID="lblMiembros" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">Dirección de la familia:</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtDireccion" runat="server" Height="60px" TextMode="MultiLine" Width="254px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <input id="ckhEditarDireccion" name="Editar0" type="checkbox" value="Editar" onclick="habilitarAreaTextBox()"/>Editar</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
            </td>
        </tr>
    </table>
</asp:Content>
