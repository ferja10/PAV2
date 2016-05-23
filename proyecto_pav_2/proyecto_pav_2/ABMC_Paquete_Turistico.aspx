<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="ABMC_Paquete_Turistico.aspx.cs" Inherits="proyecto_pav_2.ABMC_Paquete_Turistico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 309px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style8 {
            width: 309px;
        }
        .auto-style9 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td><span class="auto-style9"><strong>Paquete Tutístico</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_ambito" runat="server" style="font-size: large; font-weight: 700"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnl_paquete_turistico" runat="server">
                    <asp:Label ID="lbl_nombre_paquete_buscar" runat="server" Text="Nombre Paquete:"></asp:Label>
                    <asp:TextBox ID="txt_nombre_paquete" runat="server" style="margin-left: 28px" Width="397px" placeHolder="Nombre Paquete" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btn_buscar" runat="server" style="margin-left: 19px" Text="Buscar" OnClick="btn_buscar_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lbl_listado_paquetes" runat="server" Text="Listado de paquetes" style="text-decoration: underline; font-size: large; font-weight: 700;"></asp:Label>
                    <br />
                    <asp:GridView ID="gv_paquete_turistico" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" PageSize="7" AllowSorting="True" OnPageIndexChanging="gv_paquete_turistico_PageIndexChanging" OnSorting="gv_paquete_turistico_Sorting" DataKeyNames="id_paquete_turistico" CellSpacing="2">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Elegir" />
                            <asp:BoundField DataField="id_paquete_turistico" HeaderText="ID Paquete Turistico" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="nombre_paquete" HeaderText="Nombre Paquete" ReadOnly="True" SortExpression="nombre_paquete" />
                            <asp:BoundField DataField="destino" HeaderText="Destino" ReadOnly="True" SortExpression="destino" />
                            <asp:BoundField DataField="cantidad_dias" HeaderText="Cantidad Dias" ReadOnly="True" />
                            <asp:BoundField DataField="cantidad_noches" HeaderText="Cantidad Noches" ReadOnly="True" />
                            <asp:BoundField DataField="fecha_desde" HeaderText="Fecha de inicio" ReadOnly="True" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="fecha_hasta" HeaderText="Fecha de finalizacion" ReadOnly="True" DataFormatString="{0:d}" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btn_consultar" runat="server" Text="Consultar" OnClick="btn_consultar_Click" />
                    <asp:Button ID="btn_editar" runat="server" Text="Editar" OnClick="btn_editar_Click" />
                    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClick="btn_agregar_Click" />
                    <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" OnClick="btn_eliminar_Click" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
             
                <asp:Panel ID="pnl_editar_paquete" runat="server" Visible="False">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="ldl_datos_paquete" runat="server" style="text-decoration: underline; font-weight: 700" Text="Datos del Paquete Turístico"></asp:Label>
                                <br />
                                
                            </td>
                            <td>
                                
                                <asp:Label ID="lbl_nro_paquete_turistico" runat="server" Text="N°" Visible="False"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Label ID="lbl_id_paquete_turistico" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_temporada1" runat="server" Text="Temporada: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_temporada" runat="server" Enabled="False"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_temporada" runat="server" ErrorMessage="Debe seleccionar una temporada" ControlToValidate="ddl_temporada" InitialValue="Seleccione una temporada" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_nombre_paquete_editar" runat="server" Text="Nombre Paquete: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_nombre" runat="server" MaxLength="100" placeHolder="Nombre Paquete" Width="532px" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_nombre" runat="server" ErrorMessage="Debe Ingresar un Nombre para el Paquete" ControlToValidate="txt_nombre" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_destino" runat="server" Text="Destino: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_destino" runat="server" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddl_destino_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_destino" runat="server" ErrorMessage="Debe Seleccionar un destino" ControlToValidate="ddl_destino" InitialValue="Seleccione un destino" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_fecha_inicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_fecha_inicio" runat="server" MaxLength="10" placeHolder="dd/mm/aaaa" Width="531px" Enabled="False"></asp:TextBox>
                                <asp:CompareValidator ID="cv_txt_fecha_inicio" runat="server" ErrorMessage="Debe ingresar una fecha válida" ControlToValidate="txt_fecha_inicio" Operator="DataTypeCheck" Type="Date" Display="Dynamic"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="rfv_txt_fecha_inicio" runat="server" ErrorMessage="Debe ingresar una fecha" ControlToValidate="txt_fecha_inicio" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_fecha_finalizacion" runat="server" Text="Fecha Finalizacion: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_fecha_finalizacion" runat="server" MaxLength="10" placeHolder="dd/mm/aaaa" Width="531px" Enabled="False"></asp:TextBox>
                                <asp:CompareValidator ID="cv_txt_fecha_finalizacion" runat="server" ErrorMessage="Debe ingresar una fecha válida" ControlToValidate="txt_fecha_finalizacion" Operator="DataTypeCheck" Type="Date" Display="Dynamic"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="rfv_txt_fecha_finalizacion" runat="server" ErrorMessage="Debe ingresar una fecha" ControlToValidate="txt_fecha_finalizacion" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_cantidad_dias" runat="server" Text="Cantidad Dias: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_cantidad_dias" runat="server" MaxLength="2" placeHolder="N° de días" Width="530px" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_cantidad_dias" runat="server" ErrorMessage="Debe ingresar la cantidad de dias" ControlToValidate="txt_cantidad_dias" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_cantidad_noches" runat="server" Text="Cantidad Noches: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_cantidad_noches" runat="server" MaxLength="2" placeHolder="N° de noches" Width="528px" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_cantidad_noches" runat="server" ErrorMessage="Debe ingresar la cantidad de noches" ControlToValidate="txt_cantidad_noches" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_descripcion_paquete" runat="server" Text="Descripcion:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_descripcion_paquete" runat="server" Height="74px" MaxLength="8000" placeHolder="Descripción del paquete" TextMode="MultiLine" Width="757px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                &nbsp;</td>
                            <td class="auto-style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="lbl_datos_alojamiento" runat="server" style="font-weight: 700; text-decoration: underline" Text="Datos del Alojamiento"></asp:Label>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_alojamiento0" runat="server" Text="Alojamiento: "></asp:Label>
                                
                            </td>
                            <td>
                                
                                <asp:DropDownList ID="ddl_alojamiento" runat="server" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddl_alojamiento_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_alojamiento" runat="server" ErrorMessage="Debe Seleccionar un alojamiento" ControlToValidate="ddl_alojamiento" InitialValue="Seleccione un alojamiento" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_descripcion_alojamiento" runat="server" Text="Descripción:"></asp:Label>
                                
                            </td>
                            <td>
                                
                                <asp:TextBox ID="txt_descripcion_alojamiento" runat="server" Height="74px" MaxLength="8000" placeHolder="Descripción del alojamiento" TextMode="MultiLine" Width="757px" Enabled="False"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_pension" runat="server" Text="Pension: "></asp:Label>
                                
                            </td>
                            <td>
                                
                                <asp:DropDownList ID="ddl_pension" runat="server" Enabled="False">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_habitacion" runat="server" Text="Habitación: "></asp:Label>
                                
                            </td>
                            <td>
                                
                                <asp:DropDownList ID="ddl_habitacion" runat="server" Enabled="False">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                &nbsp;</td>
                            <td>
                                
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_datos_transporte" runat="server" style="font-weight: 700; text-decoration: underline" Text="Datos del Transporte"></asp:Label>
                                <br />
                                
                            </td>
                            <td>
                                
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_transporte" runat="server" Text="Transporte:"></asp:Label>
                                
                            </td>
                            <td>
                                
                                <asp:DropDownList ID="ddl_transporte" runat="server" Enabled="False"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_transporte" runat="server" ErrorMessage="Seleccione un transporte" ControlToValidate="ddl_transporte" InitialValue="Seleccione un transporte" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_datos_descuento" runat="server" Text="Descuentos" style="font-weight: 700; text-decoration: underline"></asp:Label>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                                <asp:Label ID="lbl_descuento_menor" runat="server" Text="Dto. Menor de 12: "></asp:Label>
                                
                            </td>
                            <td>
                                
                                <asp:TextBox ID="txt_descuento_menor" runat="server" MaxLength="2"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                
                            </td>
                            <td>
                                
                                <asp:Button ID="btn_aceptar0" runat="server" OnClick="btn_aceptar_Click" style="margin-left: 608px" Text="Aceptar" />
                                <asp:Button ID="btn_cancelar0" runat="server" OnClick="btn_cancelar_Click" style="margin-left: 20px" Text="Cancelar" Width="67px" />
                                
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
             
            </td>
        </tr>
    </table>
</asp:Content>
