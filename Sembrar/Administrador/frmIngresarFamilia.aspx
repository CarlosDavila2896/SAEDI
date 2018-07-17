<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/PrincipalAdministrador.Master" AutoEventWireup="true" CodeBehind="frmIngresarFamilia.aspx.cs" Inherits="Sembrar.Administrador.CrearFamilia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 66px;
        }
        .auto-style6 {
            height: 97px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            height: 58px;
        }
        .auto-style9 {
            height: 54px;
        }
        .auto-style11 {
            height: 58px;
            width: 119px;
        }
        .auto-style12 {
            width: 119px;
        }
        .auto-style13 {
            height: 97px;
            width: 119px;
        }
        .auto-style15 {
            height: 26px;
            width: 214px;
        }
        .auto-style16 {
            height: 26px;
            width: 119px;
        }
        .auto-style17 {
            height: 58px;
            width: 243px;
        }
        .auto-style18 {
            width: 510px;
        }
        .auto-style19 {
            height: 97px;
            width: 510px;
        }
        .auto-style20 {
            height: 26px;
            width: 510px;
        }
        .auto-style21 {
            height: 58px;
            width: 510px;
        }
        .auto-style22 {
            width: 510px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style11">
    <asp:Label ID="Label1" runat="server" Text="Ingrese Familia"></asp:Label>
                : (*)</td>
            <td class="auto-style21">
<asp:TextBox ID="txtNombre" runat="server" style="margin-left: 15px" MaxLength="50" Width="90%" Height="35%"></asp:TextBox>
                </td>
            <td class="auto-style8">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style18">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">Dirección: (*)</td>
            <td class="auto-style19">
                <asp:TextBox ID="txtDireccion" runat="server" MaxLength="300" style="margin-left: 15px" TextMode="MultiLine" Height="80%" Width="90%"></asp:TextBox>
            </td>
            <td class="auto-style6">
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</td>
            <td class="auto-style22">
<asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" style="height: 29px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">Familias Ingresadas:</td>
            <td class="auto-style18">
                <asp:GridView ID="gvFamilias" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="odsFamilias" ForeColor="Black" Width="500px" GridLines="Horizontal" AllowPaging="True">
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
            <td>
                <asp:ObjectDataSource ID="odsFamilias" runat="server" SelectMethod="consultaInfoFamilia" TypeName="CapaDatos.clsDFamilia" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style16"></td>
            <td class="auto-style20"></td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
