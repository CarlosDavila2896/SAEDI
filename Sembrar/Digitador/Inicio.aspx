<%@ Page Title="" Language="C#" MasterPageFile="~/Digitador/PrincipalDigitador.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Sembrar.Digitador.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="width:100%;">
    <tr>
        <td class="auto-style13" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;">
            &nbsp;</td>
        <td class="auto-style13" style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: large;" colspan="2">
            <asp:Label ID="lblMiPerfil" runat="server" CssClass="auto-style23" Text="Label" ViewStateMode="Disabled"></asp:Label>
        </td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style11">
            &nbsp;</td>
        <td class="auto-style11">
            <p style="box-sizing: border-box; margin: 0px 0px 20px; padding: 0px; border: 0px; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: inherit; font-size: 14px; line-height: 22.4px; font-family: Oxygen, sans-serif; vertical-align: baseline; color: rgb(96, 96, 96); letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
                La Fundación Sembrar es una organización ecuatoriana sin fines de lucro fundada en Quito en 1998. Su objetivo es encontrar soluciones a los problemas estructurales de la pobreza en el país impulsando ideas para el desarrollo.</p>
            <p style="box-sizing: border-box; margin: 0px 0px 20px; padding: 0px; border: 0px; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: inherit; font-size: 14px; line-height: 22.4px; font-family: Oxygen, sans-serif; vertical-align: baseline; color: rgb(96, 96, 96); letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
                La Fundación enfoca su trabajo en barrios urbano-marginales de la ciudad de Quito donde existe un alto índice de pobreza. En estos se llevan a cabo programas enfocados en educación, salud, habitabilidad básica y formación técnico-profesional, con el objetivo de ofrecer a las familias un apoyo integral que incluya todos los aspectos del ser humano. Actualmente Sembrar brinda su apoyo a 468 familias, trabajando con un total de 769 niños y jóvenes.</p>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style4"><span class="auto-style10"></td>
        <td>&nbsp;</td>
        <td></span></td>
    </tr>
    <tr>
        <td class="auto-style4">
            &nbsp;</td>
        <td class="auto-style4">
            <asp:LinkButton ID="lnbFundacionSembrar" runat="server" PostBackUrl="http://www.fundacionsembrar.ec/">Fundación Sembrar</asp:LinkButton>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
    
</asp:Content>
