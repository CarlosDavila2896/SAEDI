<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmRegistro.aspx.cs" Inherits="Sembrar.Administrador.frmRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style15 {
            width: 22px;
        }
        .auto-style17 {
            width: 608px;
        }
        .auto-style32 {
            height: 26px;
        }
        .auto-style37 {
            font-size: small;
        }
        .auto-style38 {
            height: 26px;
            font-size: small;
        }
        .auto-style41 {
            width: 22px;
            text-align: center;
        }
        .auto-style42 {
            text-align: center;
        }
        .auto-style43 {
            height: 26px;
            font-size: small;
            text-align: right;
        }
        .auto-style44 {
            font-size: small;
            text-align: right;
        }
        .auto-style45 {
            font-size: large;
        }
        .auto-style46 {
            height: 26px;
            width: 268px;
        }
        .auto-style47 {
            width: 268px;
        }
        .auto-style48 {
            background-color: #FFFFFF;
        }
        .auto-style49 {
            background-color: #FEFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style14" colspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style42" colspan="5">
                <asp:Label ID="lblRol" runat="server" Text="Elegir Rol a ingresar:&nbsp;&nbsp;"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlROL" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlROL_SelectedIndexChanged" Width="221px">
                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="administrador">Administrador</asp:ListItem>
                    <asp:ListItem Value="coordinador">Coordinador</asp:ListItem>
                    <asp:ListItem Value="tecnico">Técnico</asp:ListItem>
<asp:ListItem Value="digitador">Digitador</asp:ListItem>
                    <asp:ListItem Value="orientador">TécnicoOrientador</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style42" colspan="5">
                <asp:Label ID="lblTitulo" runat="server" CssClass="auto-style45" Text="Registrar Nuevo Usuario"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style43">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td class="auto-style46">
                <asp:TextBox ID="txtUserNombre" runat="server" Width="220px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired0" runat="server" ControlToValidate="txtUserNombre" ErrorMessage="Nombre Requerido" ToolTip="Nombre requerido" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style38">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td class="auto-style32">
                <asp:TextBox ID="txtUserApellido" runat="server" Width="220px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired1" runat="server" ControlToValidate="txtUserApellido" ErrorMessage="Apellido Requerido" ToolTip="Apellido requerido" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style32">
            </td>
        </tr>
        <tr>
            <td class="auto-style44">
                <asp:Label ID="lblGenero" runat="server" Text="Sexo:"></asp:Label>
            </td>
            <td class="auto-style47">
                <asp:DropDownList ID="ddlGeneroUsuario" runat="server" Height="16px" Width="225px">
                    <asp:ListItem Value="1">Femenino</asp:ListItem>
                    <asp:ListItem Value="2">Masculino</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style37">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtUserM" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style44">
                &nbsp;</td>
            <td class="auto-style47">
                &nbsp;</td>
            <td class="auto-style37">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style41" colspan="5">
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser" Width="629px" CssClass="auto-style48" Visible="False">
                    <WizardSteps>
                        <asp:CreateUserWizardStep runat="server" >
                            <ContentTemplate>
                                <table style="font-family:Verdana;font-size:100%;width:629px;">
                                    <tr>
                                        <td align="right" class="auto-style48">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Correo electrónico:</asp:Label>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="El correo electrónico es obligatorio." ToolTip="El correo electrónico es obligatorio." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style48">&nbsp;</td>
                                        <td class="auto-style48">&nbsp;</td>
                                        <td></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style48">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirmar contraseña:</asp:Label>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirmar contraseña es obligatorio." ToolTip="Confirmar contraseña es obligatorio." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style48">&nbsp;</td>
                                        <td class="auto-style48" colspan="2">
                                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                        </td>
                                        <td class="auto-style48">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style48">
                                            <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question" Visible="False">Pregunta de seguridad:</asp:Label>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:TextBox ID="Question" runat="server" Visible="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="La pregunta de seguridad es obligatoria." ToolTip="La pregunta de seguridad es obligatoria." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style48">
                                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                            <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer" Visible="False">Respuesta de seguridad:</asp:Label>
                                            <asp:TextBox ID="Answer" runat="server" Visible="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="La respuesta de seguridad es obligatoria." ToolTip="La respuesta de seguridad es obligatoria." ValidationGroup="CreateUserWizard1" Visible="False">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style48">&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep runat="server" >
                            <ContentTemplate>
                                <table class="auto-style49" style="font-family:Verdana;font-size:100%;width:629px;">
                                    <tr>
                                        <td>La cuenta se ha creado correctamente.</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue" Font-Names="Verdana" ForeColor="#284775" OnClick="ContinueButton_Click" Text="Continuar" ValidationGroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
            </td>
        </tr>
        <tr>
            <td class="auto-style41" colspan="5">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
