<%@ Page Title="" Language="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="ABMC_Paquete_Turistico.aspx.cs" Inherits="Capa_de_presentacion.ABMC_Paquete_Turistico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 99%;
            margin-right: 0px;
        }
        .auto-style3 {
            width: 309px;
            height: 26px;
            text-align: left;
        }
        .auto-style4 {
            height: 26px;
            text-align: left;
        }
        .auto-style9 {
            font-size: x-large;
        }
        .auto-style10 {
            width: 954px;
        }
        .auto-style11 {
            width: 954px;
            height: 738px;
        }
        .auto-style12 {
            width: 309px;
            text-align: left;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style10"><span class="auto-style9"><strong>Paquete Tutístico</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_ambito" runat="server" style="font-size: large; font-weight: 700"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:Panel ID="pnl_paquete_turistico" runat="server" Width="1261px" style="text-align: center">
                    <asp:Label ID="lbl_nombre_paquete_buscar" runat="server" Text="Nombre Paquete:"></asp:Label>
                    <asp:TextBox ID="txt_nombre_paquete" runat="server" style="margin-left: 28px" Width="397px" placeHolder="Nombre Paquete" MaxLength="100"></asp:TextBox>
                    <asp:Button ID="btn_buscar" runat="server" style="margin-left: 19px" Text="Buscar" OnClick="btn_buscar_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lbl_listado_paquetes" runat="server" Text="Listado de paquetes" style="text-decoration: underline; font-size: large; font-weight: 700;"></asp:Label>
                    <br />
                    <asp:GridView ID="gv_paquete_turistico" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" PageSize="7" AllowSorting="True" OnPageIndexChanging="gv_paquete_turistico_PageIndexChanging" OnSorting="gv_paquete_turistico_Sorting" DataKeyNames="id_paquete_turistico" CellSpacing="2" Width="1248px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Elegir" />
                            <asp:BoundField DataField="id_paquete_turistico" HeaderText="ID Paquete Turistico" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="nombre_paquete" HeaderText="Nombre Paquete" ReadOnly="True" SortExpression="nombre_paquete" />
                            <asp:BoundField DataField="destino" HeaderText="Destino" ReadOnly="True" SortExpression="destino" />
                            <asp:BoundField DataField="cantidad_dias" HeaderText="Cantidad Dias" ReadOnly="True" />
                            <asp:BoundField DataField="cantidad_noches" HeaderText="Cantidad Noches" ReadOnly="True" />
                            <asp:BoundField DataField="fecha_comienzo_funcionamiento" HeaderText="Fecha de inicio" ReadOnly="True" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="fecha_alta" HeaderText="Fecha Alta" ReadOnly="True" DataFormatString="{0:d}" />
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
            <td class="auto-style11">
             
                <asp:Panel ID="pnl_editar_paquete" runat="server" Visible="False" Width="1238px">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="ldl_datos_paquete" runat="server" style="text-decoration: underline; font-weight: 700" Text="Datos del Paquete Turístico"></asp:Label>
                                <br />
                                
                            </td>
                            <td class="text-left">
                                
                                <asp:Label ID="lbl_nro_paquete_turistico" runat="server" Text="N°" Visible="False"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Label ID="lbl_id_paquete_turistico" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lbl_temporada1" runat="server" Text="Temporada: "></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:DropDownList ID="ddl_temporada" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_temporada" runat="server" ErrorMessage="Debe seleccionar una temporada" InitialValue="Seleccione una temporada" ControlToValidate="ddl_temporada" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lbl_nombre_paquete_editar" runat="server" Text="Nombre Paquete: "></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:TextBox ID="txt_nombre" runat="server" MaxLength="100" placeHolder="Nombre Paquete" Width="532px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_nombre" runat="server" ErrorMessage="Debe ingresar un nombre" ControlToValidate="txt_nombre" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lbl_destino" runat="server" Text="Destino: "></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:DropDownList ID="ddl_destino" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_destino_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_destino" runat="server" ErrorMessage="Debe seleccionar un destino" ControlToValidate="ddl_destino" InitialValue="Seleccione un destino" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="Label1" runat="server" Text="Inicio de actividad:"></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:TextBox ID="txt_fecha_comienzo_funcionamiento" runat="server" CssClass="datepicker"></asp:TextBox>
                                <script type="text/javascript">
                                    $(document).ready(
                                        function () {

                                            $('.datepicker').datepicker({
                                                dateFormat: "dd/mm/yy",
                                                monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                                                dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"], minDate: "-0D", defaultDate: "+0D"
                                            });
                                        }
                                        );
                                </script>
                                <asp:RequiredFieldValidator ID="rfv_txt_fecha_comienzo_funcionamiento" runat="server" ErrorMessage="Debe seleccionar una fecha" ControlToValidate="txt_fecha_comienzo_funcionamiento" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lbl_cantidad_dias" runat="server" Text="Cantidad Dias: "></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:TextBox ID="txt_cantidad_dias" runat="server" MaxLength="2" placeHolder="N° de días" Width="530px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_cantidad_dias" runat="server" ErrorMessage="Debe ingresar cantidad de días" ControlToValidate="txt_cantidad_dias" CssClass="alert-danger"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_cantidad_dias" runat="server" ErrorMessage="ingrese sólo números" ControlToValidate="txt_cantidad_dias" ValidationExpression="^[1-9]$" CssClass="alert-danger"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lbl_cantidad_noches" runat="server" Text="Cantidad Noches: "></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:TextBox ID="txt_cantidad_noches" runat="server" MaxLength="2" placeHolder="N° de noches" Width="528px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_cantidad_noches" runat="server" ErrorMessage="Debe ingresar cantidad de noches" ControlToValidate="txt_cantidad_noches" CssClass="alert-danger"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvr_txt_cantidad_noches" runat="server" ErrorMessage="La cantidad de noches no puede ser mayor a la cantidad de días" ControlToValidate="txt_cantidad_noches" ControlToCompare="txt_cantidad_dias" Operator="LessThanEqual" Type="Integer" CssClass="alert-danger"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lbl_descripcion_paquete" runat="server" Text="Descripcion:"></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:TextBox ID="txt_descripcion_paquete" runat="server" Height="74px" MaxLength="8000" placeHolder="Descripción del paquete" TextMode="MultiLine" Width="757px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                &nbsp;</td>
                            <td class="auto-style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lbl_datos_alojamiento" runat="server" style="font-weight: 700; text-decoration: underline" Text="Datos del Alojamiento"></asp:Label>
                                <br />
                            </td>
                            <td class="text-left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_alojamiento0" runat="server" Text="Alojamiento: "></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                <asp:DropDownList ID="ddl_alojamiento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_alojamiento_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_alojamiento" runat="server" ErrorMessage="Debe seleccionar un alojamiento" ControlToValidate="ddl_alojamiento" InitialValue="Seleccione un alojamiento" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_descripcion_alojamiento" runat="server" Text="Descripción:"></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                
                                <asp:TextBox ID="txt_descripcion_alojamiento" runat="server" Height="74px" MaxLength="8000" placeHolder="Descripción del alojamiento" TextMode="MultiLine" Width="757px" Enabled="False"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_pension" runat="server" Text="Pension: "></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                
                                <asp:DropDownList ID="ddl_pension" runat="server" Enabled="False">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_habitacion" runat="server" Text="Habitación: "></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                
                                <asp:DropDownList ID="ddl_habitacion" runat="server" Enabled="False">
                                </asp:DropDownList>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                &nbsp;</td>
                            <td class="text-left">
                                
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_datos_transporte" runat="server" style="font-weight: 700; text-decoration: underline" Text="Datos del Transporte"></asp:Label>
                                <br />
                                
                            </td>
                            <td class="text-left">
                                
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_transporte" runat="server" Text="Transporte:"></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                <asp:DropDownList ID="ddl_transporte" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_transporte" runat="server" ErrorMessage="Debe seleccionar un transporte" ControlToValidate="ddl_transporte" InitialValue="Seleccione un transporte" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="Label2" runat="server" style="font-weight: 700; text-decoration: underline" Text="Excursiones"></asp:Label>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_monto_excurcion1" runat="server" Text="Monto excursiones: "></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                <asp:TextBox ID="txt_monto_excurciones" runat="server" MaxLength="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_monto_excurciones" runat="server" ErrorMessage="Debe ingresar el monto de las excursiones" ControlToValidate="txt_monto_excurciones" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                &nbsp;</td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_datos_descuento0" runat="server" style="font-weight: 700; text-decoration: underline" Text="Descuentos"></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                                <asp:Label ID="lbl_descuento" runat="server" Text="Descuento Menor:"></asp:Label>
                                
                            </td>
                            <td class="text-left">
                                
                                <asp:TextBox ID="txt_descuento_menor" runat="server" Enabled="False" MaxLength="2"></asp:TextBox>
                                <asp:CheckBox ID="chk_descuento_menor" runat="server" Text="Descuento" AutoPostBack="True" OnCheckedChanged="chk_descuento_menor_CheckedChanged" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                
                            </td>
                            <td class="text-left">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">
                                <asp:Panel ID="Panel1" runat="server" Width="1224px">
                                    <asp:Button ID="btn_aceptar" runat="server" OnClick="btn_aceptar_Click" Style="margin-left: 532px" Text="Aceptar" />
                                    <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" Style="margin-left: 15px" Text="Cancelar" Width="67px" CausesValidation="false" />
                                </asp:Panel>
                            </td>
        </tr>
        </table>
    </asp:Content>
