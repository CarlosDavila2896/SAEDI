<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmActualizarAdulto.aspx.cs" Inherits="Sembrar.Tecnico.Actualizar_Adulto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 20px;
        }
        .auto-style5 {
            height: 80px;
        }
        .auto-style6 {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="2"><h2>Editar Adulto</h2></td>
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
            <td class="auto-style10" style="text-align: left"><p>Seleccionar Individuo:</p></td>
            <td class="auto-style10" style="text-align: left">
                <asp:DropDownList ID="ddlIndividuo" runat="server" Height="16px" Width="300px" OnSelectedIndexChanged="ddlIndividuo_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="auto-style10">
                <asp:Button ID="btnSeleccionar" runat="server" OnClick="btnSeleccionar_Click" Text="Seleccionar" Width="153px" CssClass="MiBrn" />
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
                <asp:DropDownList ID="ddlAlimentacion2" runat="server" Width="290px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="txtPrimerNombre" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Nombre: (*)</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtPrimerNombre" runat="server" Columns="50" MaxLength="50" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" ControlToValidate="txtPrimerNombre" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8"><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="txtSegundoNombre" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Nombre:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtSegundoNombre" runat="server" Columns="50" MaxLength="50" Width="290px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8"><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                ControlToValidate="txtPrimerApellido" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Primer Apellido: (*)</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtPrimerApellido" runat="server" Columns="50" MaxLength="50" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" ControlToValidate="txtPrimerApellido" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style14"><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                ControlToValidate="txtSegundoApellido" ErrorMessage="Este campo acepta solo letras" 
                ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+" ForeColor="Red"></asp:RegularExpressionValidator></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Segundo Apellido:</p></td>
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
            <td class="auto-style12" style="text-align: left"><p>Genero:</p></td>
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
            <td class="auto-style12" style="text-align: left"><p>Fecha Nacimiento: (*)</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="10" TextMode="Date" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Cedula:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtCedula" runat="server" Columns="50" MaxLength="10" Width="290px"></asp:TextBox>
            </td>
            <td class="auto-style20">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Lugar de Nacimiento: (*)</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtLugarNacimiento" runat="server" Columns="50" Height="44px" MaxLength="50" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="rfvLugarNacimiento" runat="server" ControlToValidate="txtLugarNacimiento" ErrorMessage="*Campo Requerido" ForeColor="#CC3300" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7">023330196&nbsp; / 0967680357</td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Teléfono:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtTelefono" runat="server" Columns="50" MaxLength="11" Width="290px"></asp:TextBox>
                <asp:TextBox ID="txtTelefono0" runat="server" Columns="50" MaxLength="11" Width="290px"></asp:TextBox>
                <asp:TextBox ID="txtTelefono1" runat="server" Columns="50" MaxLength="11" Width="290px"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*El teléfono es un campo númerico de máximo 10 dígitos" ForeColor="#CC3300" SetFocusOnError="True" ValidationExpression="\d{7,11}"></asp:RegularExpressionValidator><br />
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8"></td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">Nivel Educación:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlNivel" runat="server">
                    <asp:ListItem>Sin Estudios</asp:ListItem>
                    <asp:ListItem>Basica</asp:ListItem>
                    <asp:ListItem>Bachiller</asp:ListItem>
                    <asp:ListItem>Técnico</asp:ListItem>
                    <asp:ListItem>Superior</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>¿Donde Estudia?:</p></td>
            <td class="auto-style14" style="text-align: left">
                <asp:TextBox ID="txtDondeEstudia" runat="server" Columns="50" Height="75px" MaxLength="150" Rows="4" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style12" style="text-align: left"><p>Observaciones:</p></td>
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
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Actualizar" Width="153px" CssClass="MiBrn" />
            </td>
        </tr>
    </table>
</asp:Content>
