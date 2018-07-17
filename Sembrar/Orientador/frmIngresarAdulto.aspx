<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="C#" MasterPageFile="~/Orientador/PrincipalOrientador.Master" AutoEventWireup="true" CodeBehind="frmIngresarAdulto.aspx.cs" Inherits="Sembrar.Orientador.Ingresar_Adulto"  EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style type="text/css">
        .auto-style4 {
            color: #333333;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14" colspan="2"><h2 class="auto-style4">Agregar Adulto</h2></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7" colspan="3" style="vertical-align: top">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Ocupación:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:DropDownList ID="ddlAlimentacion2" runat="server" Width="290px" CssClass="MiCheck">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Nombre:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
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
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Nombre:</p></td>
            <td class="auto-style14" style="text-align: left">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="txtSegundoNombre" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtSegundoNombre" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Apellido:</p></td>
            <td class="auto-style14" style="text-align: left">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
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
            <td class="auto-style14">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Apellido:</p></td>
            <td class="auto-style14" style="text-align: left">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                ControlToValidate="txtSegundoApellido" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtSegundoApellido" runat="server" Columns="50" MaxLength="50" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Género:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:DropDownList ID="ddlGenero" runat="server" Height="16px" Width="300px" CssClass="MiCheck">
                    <asp:ListItem Value="TRUE">Masculino</asp:ListItem>
                    <asp:ListItem Value="FALSE">Femenino</asp:ListItem>
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
            <td class="auto-style12" style="text-align: left"><p>Fecha Nacimiento:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="10" Width="290px" TextMode="Date" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="ctvFecha" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Fecha Nacimiento mayor que la actual o invalida" ForeColor="#CC3300" OnServerValidate="ctvFecha_ServerValidate" Display="Dynamic"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style20" style="text-align: left"><p>Cédula:</p></td>
            <td class="auto-style21" style="text-align: left">
                <asp:TextBox ID="txtCedula" runat="server" Columns="50" MaxLength="10" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td class="auto-style21">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style15"></td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Teléfono:</p></td>
            <td class="auto-style19" style="text-align: left">
                Formato:022222222&nbsp;&nbsp; /&nbsp;&nbsp; 0912345678<br />
                <asp:TextBox ID="txtTelefono" runat="server" Columns="50" MaxLength="10" Width="290px" CssClass="MiCheck"></asp:TextBox>
                <asp:TextBox ID="txtTelefono0" runat="server" Columns="50" MaxLength="10" Width="290px" CssClass="MiCheck"></asp:TextBox>
                <asp:TextBox ID="txtTelefono1" runat="server" Columns="50" MaxLength="10" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*El teléfono es un campo númerico con formato de 9 a 10 dígitos" ForeColor="#CC3300" SetFocusOnError="True" ValidationExpression="\d{9,10}" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Lugar de Nacimiento:
            <td class="auto-style14" style="text-align: left">
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                    ControlToValidate="txtLugarNacimiento" ErrorMessage="Este campo acepta solo letras" 
                    ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtLugarNacimiento" runat="server" Columns="50" Height="44px" MaxLength="50" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvLugarNacimiento" runat="server" ControlToValidate="txtLugarNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left">
                <asp:Label ID="lblEstudia" runat="server" Text="¿Donde Estudia?:" CssClass="MiCheck"></asp:Label>
            </td>

            <td class="auto-style14" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator100" runat="server"
                 ControlToValidate="txtDondeEstudia" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+">
                 </asp:RegularExpressionValidator>
                <asp:TextBox ID="txtDondeEstudia" runat="server" Columns="50" Height="56px" MaxLength="150" Rows="4" TextMode="MultiLine" Width="290px" CssClass="MiCheck"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Nivel Educación:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlNivel" runat="server">
                    <asp:ListItem>Sin Estudios</asp:ListItem>
                    <asp:ListItem>Basica</asp:ListItem>
                    <asp:ListItem>Bachiller</asp:ListItem>
                    <asp:ListItem>Técnico</asp:ListItem>
                    <asp:ListItem>Superior</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Observaciones:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator101" runat="server"
                 ControlToValidate="txtObservacion" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" Display="Dynamic"></asp:RegularExpressionValidator>
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
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" Width="153px" CssClass="MiBrn" />
            </td>
        </tr>
    </table>
</asp:Content>