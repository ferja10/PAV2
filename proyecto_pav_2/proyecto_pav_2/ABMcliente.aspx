<%@ Page  Title="C#" MasterPageFile="~/Placer_Viajes.Master" AutoEventWireup="true" CodeBehind="ABMcliente.aspx.cs" Inherits="Capa_de_presentacion.ABMcliente"   %>
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
        .auto-style9 {
            font-size: x-large;
        }
        .auto-style13 {
            width: 152px;
            height: 26px;
            text-align: left;
        }
        .auto-style15 {
            width: 372px;
            height: 26px;
            text-align: left;
        }
        .auto-style16 {
            width: 293px;
            height: 26px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Panel ID="pnl_Ambito" runat="server">
                    <br />
                   <span class="auto-style9"><strong>Clientes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></span>

                     &nbsp;<asp:Label ID="lbl_ambito" runat="server" style="font-size: large; font-weight: 700"></asp:Label>
                </asp:Panel>
            </td> 
        </tr>
        <tr>
            <td >
                <asp:Panel ID="pnl_Cliente" runat="server">
                    <asp:Label class="auto-style13" ID="lbl_nombreCliente" runat="server" Text="Nombre Cliente"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox class="auto-style13" ID="txt_nombreCliente" runat="server" Width="386px"></asp:TextBox>
                    &nbsp;
                    <asp:Button class="auto-style13" ID="btn_buscar" runat="server" OnClick="btn_buscar_Click" Text="Buscar" />
                    <br />
                    <br />
                    <asp:Label ID="lbl_listadoCliente0" runat="server" Font-Underline="True" Text="Listado de Clientes"></asp:Label>
                    <br />
                    <asp:GridView  ID="gv_clientes" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnPageIndexChanging="gv_clientes_PageIndexChanging" OnSorting="gv_clientes_Sorting" DataKeyNames="id_cliente" PageSize="7">
                        <Columns>
                            <asp:CommandField ButtonType="Button" FooterText="Elegir" SelectText="Elegir" ShowSelectButton="True" />
                            <asp:BoundField DataField="id_cliente" HeaderText="id_cliente" Visible="False" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
                            <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                            <asp:BoundField DataField="Tipo Documento" HeaderText="Tipo Documento" />
                            <asp:BoundField DataField="numero_documento" HeaderText="Numero Documento" />
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="celular" HeaderText="Celular" />
                            <asp:BoundField DataField="calle" HeaderText="Calle" />
                            <asp:BoundField DataField="numero" HeaderText="Numero" />
                            <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                            <asp:BoundField DataField="mail" HeaderText="Mail" />
                            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                            <asp:BoundField DataField="Usuario" HeaderText="Nombre Usuario " />
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
                    <br />
                    <asp:Button ID="btn_consultar" runat="server" Text="Consultar" OnClick="btn_consultar_Click"/>
                    <asp:Button ID="btn_editar" runat="server" OnClick="btn_editar_Click" Text="Editar"/>
                    
                    <asp:Button ID="btn_agregar" runat="server" OnClick="btn_agregar_Click" Text="Agregar"/>
                    <asp:Button ID="btn_eliminar" runat="server" Text="Eliminar" OnClick="btn_eliminar_Click"/>
                    <br />
                    <br />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnl_editar_Cliente" runat="server" Visible="False">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="lbl_datosClientes" runat="server" Text="Datos del Cliente" style="font-size: large; font-weight: 700"></asp:Label>
                            </td>
                            <td >
                                <asp:Label ID="lbl_nroIdCliente" runat="server" Text="Nro" Visible="False" style="font-size: large; font-weight: 700"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label class="auto-style13" ID="lbl_id_Cliente" runat="server" Visible="False" style="font-size: large; font-weight: 700"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbl_msj" runat="server" Text="Label" style="font-size: large; font-weight: 700" Enabled="False" ForeColor="Green" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_apellido" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_apellido" runat="server" ErrorMessage="Debe ingresar el apellido" ControlToValidate="txt_apellido" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_nombre" runat="server" MaxLength="50"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rfv_txt_nombre" runat="server" ErrorMessage="Debe ingresar el nombre" ControlToValidate="txt_apellido" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">Tipo Documento</td>
                            <td class="auto-style3">
                                <asp:DropDownList ID="ddl_tipoDocumento" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv_ddl_tipoDocumento" runat="server" ErrorMessage="Debe Seleccionar un Tipo de Documento" ControlToValidate="ddl_tipoDocumento" InitialValue="Seleccione un tipo de Documento" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label4" runat="server" Text="Numero Documento"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_numeroDocumento" runat="server" MaxLength="8"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_numeroDocumento" runat="server" ErrorMessage="Debe ingresar el numero de Documento" ControlToValidate="txt_numeroDocumento" Display="Dynamic"></asp:RequiredFieldValidator>
                           <asp:CompareValidator ID="cv_txt_numeroDocumento" runat="server" ErrorMessage="Debe ingresar un nro" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txt_numeroDocumento"></asp:CompareValidator>
                          </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_telefono" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_telefono" runat="server" ErrorMessage="Debe ingresar el nro de telefono" ControlToValidate="txt_telefono" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cv_txt_telefono" runat="server" ErrorMessage="Debe ingresar un nro" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txt_telefono"></asp:CompareValidator>
                         
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label6" runat="server" Text="Celular"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_celular" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_celular" runat="server" ErrorMessage="Debe ingresar el nro de celular" ControlToValidate="txt_celular" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cv_txt_celular" runat="server" ErrorMessage="Debe ingresar un nro" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txt_celular"></asp:CompareValidator>
                          
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label7" runat="server" Text="Calle"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_calle" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_calle" runat="server" ErrorMessage="Debe la calle" ControlToValidate="txt_calle" Display="Dynamic"></asp:RequiredFieldValidator>
 
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label8" runat="server" Text="Numero"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_calleNumero" runat="server" MaxLength="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_numeroCalle" runat="server" ErrorMessage="Debe completar el nro de la calle" ControlToValidate="txt_calleNumero" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cv_txt_calleNumero" runat="server" ErrorMessage="Debe ingresar un nro" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txt_calleNumero"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label9" runat="server" Text="Localidad"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:DropDownList ID="ddl_Localidad" runat="server">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="rfv_localidad" runat="server" ErrorMessage="Seleccione una Localidad" ControlToValidate="ddl_localidad" InitialValue="Seleccione una Localidad" Display="Dynamic"></asp:RequiredFieldValidator>
                           
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label10" runat="server" Text="Mail"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_mail" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_mail" runat="server" ErrorMessage="Debe coompletar el mail" ControlToValidate="txt_mail"  Display="Dynamic"></asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="rev_txt_mail" runat="server" ErrorMessage="Formato Incorrecto de Mail" ControlToValidate="txt_mail" ValidationExpression="\w+@\w+\.\w+"  Display="Dynamic"></asp:RegularExpressionValidator>
                            
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label11" runat="server" Text="Fecha Nacimiento"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_fechaNacimiento" runat="server" CssClass="datepicker" ></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="rfv_txt_fechaNacimiento" runat="server" ErrorMessage="Debe elegir una fecha" ControlToValidate="txt_fechaNacimiento"  Display="Dynamic"></asp:RequiredFieldValidator>
                                 <script type="text/javascript">
                                    $(document).ready(
                                        function () {

                                            $('.datepicker').datepicker({
                                                dateFormat: "dd/mm/yy",
                                                monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                                                dayNamesMax: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"], maxDate: "-0D", defaultDate: "+0D"
                                            });
                                        }
                                        );
                                </script>
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="Label12" runat="server" Text="Sexo"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                <asp:Panel ID="pnl_sexo" runat="server">
                                    
                                    <asp:RadioButtonList ID="rbn_sexo" runat="server">
                                        <asp:ListItem>Masculino</asp:ListItem>
                                        <asp:ListItem>Femenino</asp:ListItem>
                                    </asp:RadioButtonList>
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">Nombre Usuario</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_nombreUsuario" runat="server" MaxLength="50"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="rfv_txt_nombre_usuario" runat="server" ErrorMessage="Debe Completar el nombre de Usuario" ControlToValidate="txt_nombreUsuario"></asp:RequiredFieldValidator>
                            </td>
                              

                        </tr>
                        <tr><td class="auto-style16">Contraseña</td>
                            <td class="auto-style3">
                                <asp:TextBox ID="txt_contraseña" runat="server" MaxLength="8"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_txt_contraseña" runat="server" ErrorMessage="debe completar la contraseña" ControlToValidate="txt_contraseña"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">&nbsp;</td>
                            <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_aceptar" runat="server" Text="Aceptar" OnClick="btn_aceptar_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" CausesValidation="false" />
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
