<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sembrar.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style9 {
            height: 26px;
            }
        .auto-style7 {
            width: 13px;
        }
    .auto-style10 {
        font-weight: normal;
    }
    .auto-style11 {
        height: 26px;
        font-weight: normal;
    }
    .auto-style14 {
        height: 26px;
        font-weight: normal;
    }
    .auto-style15 {
        text-align: justify;
    }
    .auto-style16 {
        text-align: right;
    }
    .auto-style17 {
        font-size: medium;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <table style="width:100%;">
    <tr>
        <td class="auto-style9" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" colspan="2">&nbsp;</td>
        <td class="auto-style4"></td>
    </tr>
    <tr>
        <td class="auto-style9" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large; vertical-align: top;" colspan="3">
            <hr />
        </td>
    </tr>
    <tr>
        <td class="auto-style14" colspan="2">
            <p style="box-sizing: border-box; margin: 0px 0px 20px; padding: 0px; border: 0px; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: inherit; font-size: 14px; line-height: 22.4px; font-family: Oxygen, sans-serif; vertical-align: baseline; color: rgb(96, 96, 96); letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);" class="auto-style15">
                La Fundación Sembrar es una organización ecuatoriana sin fines de lucro fundada en Quito en 1998. Su objetivo es encontrar soluciones a los problemas estructurales de la pobreza en el país impulsando ideas para el desarrollo.</p>
            <p style="box-sizing: border-box; margin: 0px 0px 20px; padding: 0px; border: 0px; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: inherit; font-size: 14px; line-height: 22.4px; font-family: Oxygen, sans-serif; vertical-align: baseline; color: rgb(96, 96, 96); letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);" class="auto-style15">
                La Fundación enfoca su trabajo en barrios urbano-marginales de la ciudad de Quito donde existe un alto índice de pobreza. En estos se llevan a cabo programas enfocados en educación, salud, habitabilidad básica y formación técnico-profesional, con el objetivo de ofrecer a las familias un apoyo integral que incluya todos los aspectos del ser humano. Actualmente Sembrar brinda su apoyo a 468 familias, trabajando con un total de 769 niños y jóvenes.</p>
        </td>
        <td class="auto-style9"></td>
    </tr>
    <tr>
        <td class="auto-style4"><span class="auto-style10"></td>
        <td class="auto-style7">&nbsp;</td>
        <td></span></td>
    </tr>
    <tr>
        <td class="auto-style16">
            <asp:LinkButton ID="lnbFundacionSembrar" runat="server" PostBackUrl="http://www.fundacionsembrar.ec/" CssClass="auto-style17">Fundación Sembrar</asp:LinkButton>
        </td>
        <td class="auto-style7">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
