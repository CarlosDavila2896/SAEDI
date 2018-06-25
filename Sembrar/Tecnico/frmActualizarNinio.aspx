<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalTecnico.Master" AutoEventWireup="true" CodeBehind="frmActualizarNinio.aspx.cs" Inherits="Sembrar.Tecnico.Actualizar_Niño" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14" colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;">Editar Niño</td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            <td class="auto-style7" colspan="3" style="vertical-align: top">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style9"></td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Seleccionar Individuo:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:DropDownList ID="ddlIndividuo" runat="server" Height="16px" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSeleccionar" runat="server" OnClick="btnSeleccionar_Click" Text="Seleccionar" Width="153px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="txtSAD" ErrorMessage="Este campo acepta números y letras" 
                    ValidationExpression="[0-9a-zA-Z]{0,7}$" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style4">Codigo SAD:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtSAD" runat="server" Columns="50" MaxLength="7" Width="290px"></asp:TextBox>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">                <%--This works for 1900 to 2099--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    ControlToValidate="txtAnioIngreso" ErrorMessage="Revise que el dato sea un año valido" 
                    ValidationExpression="^(19|20)\d{2}$" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Año Ingreso: (*)</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtAnioIngreso" runat="server" Columns="50" MaxLength="5" TextMode="Number" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RfAÑOIN" runat="server" ControlToValidate="txtAnioIngreso" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Ocupación:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:DropDownList ID="ddlAlimentacion2" runat="server" Width="290px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                    ControlToValidate="txtPrimerNombre" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Primer Nombre: (*)</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtPrimerNombre" runat="server" Columns="50" MaxLength="50" Width="290px"></asp:TextBox>
            </td>
            <td> <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" ControlToValidate="txtPrimerNombre" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8"><asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                    ControlToValidate="txtSegundoNombre" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Segundo Nombre:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtSegundoNombre" runat="server" Columns="50" MaxLength="50" Width="290px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"><asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                    ControlToValidate="txtPrimerApellido" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Primer Apellido: (*)</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtPrimerApellido" runat="server" Columns="50" MaxLength="50" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style14"><asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                    ControlToValidate="txtSegundoApellido" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Segundo Apellido:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtSegundoApellido" runat="server" Columns="50" MaxLength="50" Width="290px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Genero:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:DropDownList ID="ddlGenero" runat="server" Height="16px" Width="300px">
                    <asp:ListItem Value="True">Masculino</asp:ListItem>
                    <asp:ListItem Value="False">Femenino</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Fecha Nacimiento: (*)</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="10" TextMode="Date" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
                <br />
                <asp:CustomValidator ID="ctvFecha" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Fecha Nacimiento mayor que la actual o invalida" ForeColor="#CC3300" OnServerValidate="ctvFecha_ServerValidate" Display="Dynamic" Enabled="False"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Cedula:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtCedula" runat="server" Columns="50" MaxLength="10" Width="290px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Lugar de Nacimiento: (*)</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtLugarNacimiento" runat="server" Columns="50" Height="44px" MaxLength="50" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="rfvLugarNacimiento" runat="server" ControlToValidate="txtLugarNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7">023125018&nbsp; / 0967680357</td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Teléfono:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtTelefono" runat="server" Columns="50" MaxLength="11" Width="290px"></asp:TextBox>
                <asp:TextBox ID="txtTelefono0" runat="server" Columns="50" MaxLength="11" Width="290px"></asp:TextBox>
                <asp:TextBox ID="txtTelefono1" runat="server" Columns="50" MaxLength="11" Width="290px"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*El teléfono es un campo númerico con formato de 9 a 10 dígitos" ForeColor="#CC3300" SetFocusOnError="True" ValidationExpression="\d{9,10}"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Discapacidades:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtDiscapacidad" runat="server" Columns="50" Height="75px" MaxLength="200" Rows="4" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style9" style="text-align: left">Preguntas Generales</td>
            <td class="auto-style9" style="text-align: left">
                <asp:CheckBox ID="chbTrabaja" runat="server" Text="¿Trabaja el niño?" />
            </td>
            <td class="auto-style9">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">¿Cuanto tiempo trabaja?</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtTiempoTrabajo" runat="server" TextMode="Number" Width="290px"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                         ControlToValidate="txtTiempoTrabajo" ErrorMessage="Este campo acepta números positivos" 
                     ValidationExpression="^[0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator><br />
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style9" style="text-align: left">&nbsp;</td>
            <td class="auto-style9" style="text-align: left">
                <asp:CheckBox ID="chbVacunas" runat="server" Text="¿Tiene todas sus vacunas?" />
            </td>
            <td class="auto-style9">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"> <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                         ControlToValidate="txtAlimentacion" ErrorMessage="Este campo acepta números positivos" 
                     ValidationExpression="^[0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">¿Cuantas veces a la semana come carne?:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtAlimentacion" runat="server" Columns="50" MaxLength="5" TextMode="Number" Width="290px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style10" style="text-align: left">Sacramento del niño:</td>
            <td class="auto-style10" style="text-align: left">
                <asp:TextBox ID="txtSacramento" runat="server" Columns="50" Height="75px" MaxLength="200" Rows="4" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">Observaciones:</td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtObservacion" runat="server" Columns="50" Height="75px" MaxLength="1024" Rows="4" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td>
                <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" Width="153px" />
            </td>
        </tr>
    </table>
</asp:Content>
