<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="Info_Paquete.aspx.cs" Inherits="Capa_de_presentacion.Info_Paquete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="nav-justified">
        <tr>
            <td>
                <asp:Panel ID="pnl_nombre_paquete" runat="server">
                    <div class="text-left">
                        <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: large" Text="Información del paquete"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lbl_nombre_paquete" runat="server" style="text-decoration: underline; font-weight: 700;" Text="Label"></asp:Label>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnl_contenido_paquete" runat="server">
                    <div class="text-center">
                        <br />
                        <strong>
                        <asp:Label ID="label2" runat="server" CssClass="auto-style1" Text="Destino: "></asp:Label>
                        <asp:Label ID="lbl_destino" runat="server" CssClass="auto-style1" Text="Label"></asp:Label>
                        </strong>
                        <br />
                        <asp:TextBox ID="txt_info_destino" runat="server" TextMode="MultiLine" Height="284px" Width="553px"></asp:TextBox>
                        <br />
                        <br />
                        <strong>
                        <asp:Label ID="Label3" runat="server" CssClass="auto-style1" Text="Alojamiento: "></asp:Label>
                        <asp:Label ID="lbl_alojamiento" runat="server" CssClass="auto-style1" Text="Label"></asp:Label>
                        </strong>
                        <br />
                        <asp:TextBox ID="txt_info_alojamiento" runat="server" TextMode="MultiLine" Height="292px" Width="554px"></asp:TextBox>
                        <br />
                        <br />
                        <strong>
                        <asp:Label ID="Label4" runat="server" CssClass="auto-style1" Text="Transporte: "></asp:Label>
                        <asp:Label ID="lbl_transporte" runat="server" CssClass="auto-style1" Text="Label"></asp:Label>
                        </strong>
                        <br />
                        <asp:TextBox ID="txt_info_transporte" runat="server" TextMode="MultiLine" Height="58px" Width="548px"></asp:TextBox>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnl_botones" runat="server">
                    <asp:Button ID="btn_aceptar" runat="server" Text="Aceptar" Width="78px" />
                    <asp:Button ID="btn_comprar" runat="server" Text="Comprar" />
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>
