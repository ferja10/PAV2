<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="Capa_de_presentacion.Reserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Su Reserva</h1>
    <asp:GridView ID="grv_reserva" runat="server" CssClass="table"></asp:GridView>
</asp:Content>
