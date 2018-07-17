<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmRegistro.aspx.cs" Inherits="Sembrar.Administrador.frmRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style70 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: large;
            color: #333333;
        }

        .auto-style15 {
            width: 22px;
        }

        .auto-style17 {
            width: 608px;
        }

        .auto-style18 {
            width: 827px;
        }

        .auto-style20 {
            width: 827px;
            font-size: small;
            text-align: right;
        }

        .auto-style24 {
            width: 827px;
            font-size: small;
            text-align: right;
            height: 26px;
        }

        .auto-style25 {
            width: 608px;
            height: 26px;
        }

        .auto-style27 {
            font-size: x-large;
        }

        .auto-style29 {
            width: 1186px;
            font-size: small;
            text-align: right;
            height: 26px;
        }

        .auto-style31 {
            width: 581px;
        }

        .auto-style32 {
            height: 26px;
        }

        .auto-style33 {
            width: 827px;
            font-size: small;
            text-align: right;
            height: 34px;
        }

        .auto-style34 {
            width: 581px;
            height: 34px;
        }

        .auto-style35 {
            width: 1186px;
            font-size: small;
            text-align: right;
            height: 34px;
        }

        .auto-style36 {
            width: 608px;
            height: 34px;
        }

        .auto-style37 {
            font-size: small;
        }

        .auto-style38 {
            height: 26px;
            font-size: small;
        }

        .auto-style40 {
            width: 229px;
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

        .auto-style46 {
            height: 26px;
            width: 268px;
        }

        .auto-style47 {
            width: 268px;
        }

        .auto-style48 {
            width: 827px;
            font-size: small;
            text-align: right;
            height: 18px;
        }

        .auto-style49 {
            height: 18px;
        }
        .auto-style71 {
            text-align: center;
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style49" colspan="5">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style70">Registrar Nuevo Usuario</td>
                    </tr>
                    <tr>
                        <td class="auto-style7" style="vertical-align: top">
                            <hr />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style71" colspan="5">&nbsp;<asp:Label ID="lblRol" runat="server" Text="Rol del usuario: "></asp:Label>
                <asp:DropDownList ID="ddlROL" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlROL_SelectedIndexChanged" Width="221px">
                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                    <asp:ListItem Value="administrador">Administrador</asp:ListItem>
                    <asp:ListItem Value="coordinador">Coordinador</asp:ListItem>
                    <asp:ListItem Value="orientador">Orientador</asp:ListItem>
                    <asp:ListItem Value="tecnico">Técnico</asp:ListItem>
                    <asp:ListItem Value="digitador">Digitador</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style42" colspan="5">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style43">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td class="auto-style46">
                <asp:TextBox ID="txtUserNombre" runat="server" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired0" runat="server" ControlToValidate="txtUserNombre" ErrorMessage="Nombre Requerido" ToolTip="Nombre requerido" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style38">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td class="auto-style32">
                <asp:TextBox ID="txtUserApellido" runat="server" Width="220px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired1" runat="server" ControlToValidate="txtUserApellido" ErrorMessage="Apellido Requerido" ToolTip="Apellido requerido" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style32"></td>
        </tr>
        <tr>
            <td class="auto-style44">
                <asp:Label ID="lblGenero" runat="server" Text="Género:"></asp:Label>
            </td>
            <td class="auto-style47">
                <asp:DropDownList ID="ddlGeneroUsuario" runat="server" Height="16px" Width="225px">
                    <asp:ListItem Value="1">Femenino</asp:ListItem>
                    <asp:ListItem Value="2">Masculino</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style37">&nbsp;</td>
            <td>
                <asp:TextBox ID="txtUserM" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style41" colspan="5">
                <asp:CreateUserWizard ID="CreateUserWizard" runat="server" AnswerLabelText="Respuesta:" AnswerRequiredErrorMessage="Respuesta de seguridad requerida" CompleteSuccessText="Su cuenta ha sido creada exitosamente" ConfirmPasswordCompareErrorMessage="Las contraseñas no coinciden" ConfirmPasswordRequiredErrorMessage="Confirmación de contraseña requerida" DuplicateEmailErrorMessage="El e-mail ya ha sido ingresado. Por favor ingrese uno diferente" DuplicateUserNameErrorMessage="Ya existe este nombre de usuario" EmailRegularExpressionErrorMessage="Por favor ingrese un e-mail diferente." EmailRequiredErrorMessage="E-mail requerido" InvalidAnswerErrorMessage="Porfavor ingrese una respuesta diferente" InvalidEmailErrorMessage="Porfavor ingrese un e-mail correcto" InvalidPasswordErrorMessage="Minimo de caracteres en la contraseña: {6}. Se requiere mínimo un número {1}." InvalidQuestionErrorMessage="Porfavor ingrese otra pregunta" OnCreatedUser="CreateUserWizard_CreatedUser" PasswordRegularExpressionErrorMessage="Porfavor ingrese una contraseña diferente" PasswordRequiredErrorMessage="Contraseña requerida" QuestionLabelText="Pregunta de Seguridad:" QuestionRequiredErrorMessage="Pregunta de seguridad requerida" UnknownErrorMessage="Usuario no ha sido creado. Por favor intente de nuevo." UserNameLabelText="Nombre de Usuario:" UserNameRequiredErrorMessage="Nombre de usuario requerido" Visible="False" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" CancelDestinationPageUrl="~/Administrador/frmRegistro.aspx" ContinueDestinationPageUrl="~/Administrador/frmRegistro.aspx" DisableCreatedUser="True" FinishDestinationPageUrl="~/Administrador/frmRegistro.aspx" Width="100%" OnCreateUserError="CreateUserWizard_CreateUserError" OnCreatingUser="CreateUserWizard_CreatingUser">
                    <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                    <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <WizardSteps>
                        <asp:CreateUserWizardStep runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td class="auto-style33">Nombre de Usuario:</td>
                                        <td class="auto-style34">
                                            <asp:TextBox ID="UserName" runat="server" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style34">
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Nombre de usuario requerido" ToolTip="Nombre de usuario requerido" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style35">Email: </td>
                                        <td class="auto-style36">
                                            <asp:TextBox ID="Email" runat="server" TextMode="Email" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style36">
                                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail requerido" ToolTip="E-mail requerido" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style20">Contraseña:</td>
                                        <td class="auto-style31">
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style31">
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Contraseña requerida" ToolTip="Contraseña requerida" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="auto-style29">Repetir Contraseña:</td>
                                        <td class="auto-style17">
                                            <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="auto-style28" TextMode="Password" Width="190px" Height="20px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style17">
                                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirmación de contraseña requerida" ToolTip="Confirmación de contraseña requerida" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style24">&nbsp;</td>
                                        <td class="auto-style25" colspan="4">&nbsp;</td>
                                        <td class="auto-style25">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style48"></td>
                                        <td align="center" colspan="4" class="auto-style49">
                                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden" ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                        </td>
                                        <td align="center" class="auto-style49">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="color: Red;" class="auto-style18">&nbsp;</td>
                                        <td align="center" colspan="4" style="color: Red;">
                                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False" Text="Error al crear Usuario"></asp:Literal>
                                        </td>
                                        <td align="center" style="color: Red;">&nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td align="center" class="auto-style40">Usuario Creado</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style40">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="auto-style40">
                                            <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue" PostBackUrl="~/Administrador/frmRegistro.aspx" Text="Continuar" ValidationGroup="CreateUserWizard1" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                    <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                    <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                    <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                    <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
                    <StepStyle BorderWidth="0px" />
                </asp:CreateUserWizard>
            </td>
        </tr>
    </table>
</asp:Content>
