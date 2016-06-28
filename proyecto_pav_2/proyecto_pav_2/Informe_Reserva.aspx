<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="Informe_Reserva.aspx.cs" Inherits="Capa_de_presentacion.Informe_Reserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 150px;
            height: 25px;
            text-align: center;
        }
        .auto-style3 {
            height: 25px;
            text-align: left;
        }
        .auto-style4 {
            width: 150px;
            text-align: center;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="slide-image">
        <tr>
            <td>
                <table class="slide-image">
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="lbl_temporada" runat="server" Text="Temporada:"></asp:Label>
                        </td>
                        <td class="text-left">
                            <asp:DropDownList ID="ddl_temporada" runat="server" Height="16px" Width="295px" Enabled="False">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chk_temporada" runat="server" AutoPostBack="True" OnCheckedChanged="chk_temporada_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lbl_fecha_desde" runat="server" Text="Fecha Reserva Desde:"></asp:Label>
                        </td>
                        <td class="auto-style3">&nbsp;
                            &nbsp;<asp:TextBox ID="txt_fecha_desde" runat="server" CssClass="datepicker" Enabled="False"></asp:TextBox>
                            <asp:CompareValidator ID="cmp_txt_fecha_desde" runat="server" ErrorMessage="Ingrese una fecha válida" ControlToValidate="txt_fecha_desde" Type="Date" Operator="DataTypeCheck"></asp:CompareValidator>
                            <asp:CheckBox ID="chk_rango_fecha" runat="server" AutoPostBack="True" OnCheckedChanged="chk_rango_fecha_CheckedChanged" />
                        &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lbl_advertencia" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lbl_fecha_hasta" runat="server" Text="Fecha Reserva Hasta:"></asp:Label>
                        </td>
                        <td class="auto-style3">&nbsp;
                            &nbsp;<asp:TextBox ID="txt_fecha_hasta" runat="server" CssClass="datepicker" Enabled="False"></asp:TextBox>
                            <asp:CompareValidator ID="cmp_txt_fecha_hasta" runat="server" ErrorMessage="Ingrese una fecha válida" ControlToValidate="txt_fecha_hasta" Type="Date" Operator="DataTypeCheck"></asp:CompareValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="La fecha hasta no puede ser inferior a la fecha desde" ControlToValidate="txt_fecha_hasta" ControlToCompare="txt_fecha_desde" Operator="GreaterThanEqual"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="lbl_nombre_paquete" runat="server" Text="Nombre Paquete:"></asp:Label>
                        </td>
                        <td class="text-left">
                            <asp:DropDownList ID="ddl_nombre_paquete" runat="server" Height="16px" Width="295px" Enabled="False">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chk_nombre_paquete" runat="server" AutoPostBack="True" OnCheckedChanged="chk_nombre_paquete_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            
                        </td>
                        <td class="text-left">
                            <asp:Button ID="btn_buscar" runat="server" Text="Buscar" OnClick="btn_buscar_Click" CausesValidation="true" />
                            <asp:Label ID="lbl_aclaracion" runat="server" Text="(*) si no se selecciona ningún campo se buscan todos los registros"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="text-left">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="grv_informe" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1136px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="Temporada" DataField="nombre_temporada" />
                            <asp:BoundField HeaderText="Nombre Paquete" DataField="nombre_paquete" />
                            <asp:BoundField HeaderText="Destino" DataField="nombre_destino" />
                            <asp:BoundField HeaderText="Cantidad de Veces Reservado" DataField="cantidad_reservada" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="text-left">
                <asp:Button ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>

</asp:Content>
