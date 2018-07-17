<%@ Page Title="" Language="C#" MasterPageFile="~/Orientador/PrincipalOrientador.Master" AutoEventWireup="true" CodeBehind="frmIngresarJoven.aspx.cs" Inherits="Sembrar.Orientador.Ingresar_Joven"  EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            color: #333333;
        }
       .auto-style5 {
           height: 16px;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td colspan="2"><h2 class="auto-style4">Agregar Joven</h2></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3" style="vertical-align: top">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style18"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>&nbsp;</p>
                <p>Código SAD:</p></td>
            <td class="auto-style13" style="text-align: left">
                Prefijo PRO - QUI - OYE seguido de 4 numeros<br />
                <asp:TextBox ID="txtSAD" runat="server" Columns="50" MaxLength="7" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
            <asp:RegularExpressionValidator ID="revSAD" runat="server" ControlToValidate="txtSAD" ErrorMessage="* Formato Incorrecto" ForeColor="#CC3300" ValidationExpression="(QUI|PRO|OYE)\d{4}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style18"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Año Ingreso:</p></td>
            <td class="auto-style13" style="text-align: left">
                <%--This works for 1900 to 2099--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    ControlToValidate="txtAnioIngreso" ErrorMessage="Revise que el dato sea un año valido" 
                    ValidationExpression="^(19|20)\d{2}$">
                </asp:RegularExpressionValidator>
                <asp:TextBox ID="txtAnioIngreso" runat="server" Columns="50" MaxLength="5" TextMode="Number" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RfAÑOIN" runat="server" ControlToValidate="txtAnioIngreso" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style18"></td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Ocupación:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:DropDownList ID="ddlAlimentacion2" runat="server" Width="290px" CssClass="MiCheck">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Nombre:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                    ControlToValidate="txtPrimerNombre" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtPrimerNombre" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" ControlToValidate="txtPrimerNombre" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style15"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Nombre:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                    ControlToValidate="txtSegundoNombre" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtSegundoNombre" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Apellido:</p></td>
            <td class="auto-style19" style="text-align: left">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                    ControlToValidate="txtPrimerApellido" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtPrimerApellido" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Apellido:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                    ControlToValidate="txtSegundoApellido" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtSegundoApellido" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Género:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:DropDownList ID="ddlGenero" runat="server" Height="16px" Width="300px" CssClass="MiCheck">
                    <asp:ListItem Value="TRUE">Masculino</asp:ListItem>
                    <asp:ListItem Value="FALSE">Femenino</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Fecha Nacimiento:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="10" TextMode="Date" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                  <br />
                <asp:CustomValidator ID="ctvFecha" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Fecha Nacimiento mayor que la actual o invalida" ForeColor="#CC3300" OnServerValidate="ctvFecha_ServerValidate" Display="Dynamic"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Cédula:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtCedula" runat="server" Columns="50" MaxLength="10" Width="154px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">
                <p>Teléfono:</p></td>
            <td class="auto-style19" style="text-align: left">
                Formato:&nbsp; 022222222&nbsp;&nbsp; /&nbsp;&nbsp; 0912345678<br />
                <asp:TextBox ID="txtTelefono" runat="server" Columns="50" MaxLength="10" Width="160px" CssClass="MiCheck" ValidationGroup="Telefono"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtTelefono0" runat="server" Columns="50" MaxLength="10" Width="160px" CssClass="numeros" ValidationGroup="Telefono"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtTelefono1" runat="server" Columns="50" MaxLength="10" Width="160px" CssClass="numeros" ValidationGroup="Telefono"></asp:TextBox>
                <br />
                <br />
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*El teléfono es un campo númerico con formato de 9 a 10 dígitos" ForeColor="#CC3300" SetFocusOnError="True" ValidationExpression="\d{9,10}" ValidationGroup="Telefono"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Lugar de Nacimiento:</p></td>
            <td class="auto-style19" style="text-align: left">
                <asp:TextBox ID="txtLugarNacimiento" runat="server" Columns="50" Height="44px" MaxLength="50" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvLugarNacimiento" runat="server" ControlToValidate="txtLugarNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
    <tr>
        <td class="auto-style8"></td>
        <td class="auto-style8"></td>
        <td class="auto-style8"></td>
    </tr>
    <tr>
        <td class="auto-style12"><p>Observaciones:</p></td>
        <td class="auto-style14" style="text-align: left">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator101" runat="server"
                 ControlToValidate="txtObservacion" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+">
                 </asp:RegularExpressionValidator>
            <asp:TextBox ID="txtObservacion" runat="server" Columns="50" Height="75px" MaxLength="1024" Rows="4" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
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
            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" Width="153px" />
        </td>
    </tr>
</table>
</asp:Content>

