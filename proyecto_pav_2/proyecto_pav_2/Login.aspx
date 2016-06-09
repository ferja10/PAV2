<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Capa_de_presentacion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" Height="163px" Width="316px">
    </asp:Login>
</asp:Content>
