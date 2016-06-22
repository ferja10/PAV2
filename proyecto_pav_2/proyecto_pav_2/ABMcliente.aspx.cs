using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Capa_de_presentacion
{
    public partial class ABMcliente : System.Web.UI.Page
    {
        enum boton
        {
            inicio, buscar, consultar, editar, agregar, eliminar
        }
        protected void Page_Load(object sender, EventArgs e)
        {   if (!Page.IsPostBack)
            {
                ViewState["gv_clientes"] = "nombre"; //guarda estado anterior en este caso de la primera carga
                ViewState["boton"] = "inicio";
                cargar_grilla();
                cargar_combo(ddl_tipoDocumento,"id_tipo_documento","nombre");
                ddl_tipoDocumento.Items.Insert(0,"Seleccione un tipo de Documento");

                cargar_combo(ddl_Localidad,"id_localidad", "nombre");
                ddl_Localidad.Items.Insert(0,"Seleccione una Localidad");
            }
        }
        private void cargar_grilla()
        {
            string orden = ViewState["gv_clientes"].ToString(); //recupera estado
            string boton = ViewState["boton"].ToString();

            if (boton == "inicio")
            {
                gv_clientes.DataSource =Capa_de_negocio.Gestor_Cliente.buscar_clientes();
                gv_clientes.DataBind();
            }
            else
            {
                if (boton == "buscar")
                {
                    gv_clientes.DataSource = Capa_de_negocio.Gestor_Cliente.buscar_por_nombre(txt_nombreCliente.Text, orden);
                    //gv_clientes.DataKeyNames = null;
                    gv_clientes.DataBind();
                 }
            } 
        }


        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            ViewState["boton"] = "buscar";
            cargar_grilla();
        }

      

        protected void gv_clientes_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["gv_clientes"] = e.SortExpression; //ordena por el titulo en el q hizo click
            ViewState["boton"] = "buscar";
            cargar_grilla();
        }

        protected void gv_clientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_clientes.PageIndex = e.NewPageIndex; //quiero mostrar en la pag donde hizo click

            cargar_grilla(); 
        }
        private void cargar_combo(DropDownList ddl, string valueField, string textField)
        {
            if (ddl.ID=="ddl_tipoDocumento")
            {
                ddl_tipoDocumento.DataSource = Capa_de_negocio.Gestor_TipoDocumento.obtener_TiposDocumento();
            }
            else
            {
                if (ddl.ID == "ddl_Localidad")
                {
                    ddl_Localidad.DataSource = Capa_de_negocio.Gestor_Localidad.obtener_TiposDocumento();
                }
            }
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataBind();
        }

        protected void btn_consultar_Click(object sender, EventArgs e)
        {
            pnl_Cliente.Visible=false;
            pnl_editar_Cliente.Visible = true;
            ViewState["boton"] = "consultar";
            habilitar();
            lbl_msj.Text = "";
            if (gv_clientes.SelectedRow != null) //Verificamos que haya seleccionado algo de la grilla 
            {       
                int id_cliente = (int)gv_clientes.SelectedValue;

                Capa_de_entidad.Usuario u = Capa_de_negocio.Gestor_Cliente.buscar_por_id(id_cliente);

                lbl_id_Cliente.Text = "" + u.cliente.id_cliente;
                lbl_nroIdCliente.Visible = true;
                lbl_id_Cliente.Visible = true;

                //completar_campos(c);
                    //,u);
                completar_campos(u);
                lbl_ambito.Text = "Consultando";
            }
          
          }

        private void completar_campos(Capa_de_entidad.Usuario u)
          {  
             ddl_tipoDocumento.SelectedValue=u.cliente.tipo_documento.id_tipo_documento.ToString();
             txt_nombre.Text=u.cliente.nombre;
             txt_apellido.Text=u.cliente.apellido;
             txt_numeroDocumento.Text=u.cliente.numero.ToString();
             txt_telefono.Text=u.cliente.telefono.ToString();
             txt_celular.Text=u.cliente.celular.ToString();
             txt_calle.Text=u.cliente.calle;
             txt_calleNumero.Text=u.cliente.numero.ToString();
             ddl_Localidad.SelectedValue=u.cliente.localidad.id_localidad.ToString();
             txt_mail.Text=u.cliente.mail.ToString();
             txt_fechaNacimiento.Text = u.cliente.fecha_nacimiento.ToString("dd/MM/yyyy");
             if (u.cliente.sexo.ToString() == "M")
             {
                 rbn_sexo.SelectedIndex = 0;
             }
             else
             {
                 rbn_sexo.SelectedIndex = 1;
             }
            
             txt_nombreUsuario.Text = u.nombre_usuario.ToString();
             txt_contraseña.Text = u.contraseña.ToString();
            }
             
        private void habilitar()
        {
            string boton = ViewState["boton"].ToString();
            if (boton == "editar" || boton == "agregar")
            {   
                txt_nombre.Enabled = true;
                txt_apellido.Enabled = true;
                ddl_tipoDocumento.Enabled = true;
                txt_numeroDocumento.Enabled = true;
                txt_telefono.Enabled = true;
                txt_celular.Enabled = true;
                txt_calle.Enabled = true;
                txt_calleNumero.Enabled = true;
                ddl_Localidad.Enabled = true;
                txt_mail.Enabled = true;
                txt_fechaNacimiento.Enabled = true;
                pnl_sexo.Enabled = true;
                rbn_sexo.Enabled = true; 
                txt_nombreUsuario.Enabled = true;
                txt_contraseña.Enabled = true;
                
            }
            else
            {
                txt_nombre.Enabled = false;
                txt_apellido.Enabled = false;
                ddl_tipoDocumento.Enabled = false;
                txt_numeroDocumento.Enabled = false;
                txt_telefono.Enabled = false;
                txt_celular.Enabled = false;
                txt_calle.Enabled = false;
                txt_calleNumero.Enabled = false;
                ddl_Localidad.Enabled = false;
                txt_mail.Enabled = false;
                txt_fechaNacimiento.Enabled = false;
                pnl_sexo.Enabled = false;
                rbn_sexo.Enabled = false;
                txt_nombreUsuario.Enabled = false;
                txt_contraseña.Enabled = false;
            }
        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {   pnl_Cliente.Visible = false;
            pnl_editar_Cliente.Visible = true;

            ViewState["boton"] = "editar";
            habilitar();
            lbl_msj.Text = "";
              if (gv_clientes.SelectedRow != null) //Verificamos que haya seleccionado algo de la grilla 
            {
               int id_cliente = (int)gv_clientes.SelectedValue;

                Capa_de_entidad.Usuario u = Capa_de_negocio.Gestor_Cliente.buscar_por_id(id_cliente);
               

                lbl_id_Cliente.Text = "" + u.cliente.id_cliente;
                lbl_nroIdCliente.Visible = true;
                lbl_id_Cliente.Visible = true;

                //completar_campos(c);
                completar_campos(u);
                    //,u);

                lbl_ambito.Text = "Editando";
            }
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            lbl_msj.Text = ""; 
            if (Page.IsValid)
            {
                pnl_Cliente.Visible = false;
                pnl_editar_Cliente.Visible = true;
                string boton = ViewState["boton"].ToString();
          
            if (boton == "agregar")
            {
                grabar();
                lbl_msj.Visible = true;
                lbl_msj.Text = "Cliente Agregado con exito";
                
            }
            else
              {
                if (boton == "editar")//|| boton == "eliminar")
                {
                    int id_cliente = int.Parse(lbl_id_Cliente.Text);
                    modificar_cliente(id_cliente);
                    lbl_msj.Visible = true;
                    lbl_msj.Text = "Cliente Modificado con exito";
                }
                else
                {
                    if (boton == "eliminar")
                    {
                        int id_cliente = int.Parse(lbl_id_Cliente.Text);
                        modificar_cliente(id_cliente);
                        lbl_msj.Visible = true;
                        lbl_msj.Text = "Cliente Eliminado con exito";   
                    }
                   
                }
                
              }
            ViewState["boton"] = "inicio";
            refrescar_campos();
            cargar_grilla();
            }
            
        }
           
        
        private void refrescar_campos()
        {
             lbl_id_Cliente.Text = "";     
             txt_nombre.Text="";
             txt_apellido.Text="";
             ddl_tipoDocumento.SelectedIndex=0;
             txt_numeroDocumento.Text="";
             txt_telefono.Text = ""; 
             txt_celular.Text="";
             txt_calle.Text="";
             txt_calleNumero.Text="";
             ddl_Localidad.SelectedIndex=0;
             txt_mail.Text="";
//             Lbl_Cliente.Visible=false;
             lbl_nroIdCliente.Visible=false;
             txt_nombreUsuario.Text = "";
             txt_contraseña.Text = "";
             txt_fechaNacimiento.Text = "";
         }

        private void grabar()
        {   string nombre = txt_nombre.Text;
            string apellido = txt_apellido.Text;
            int id_tipo_documento = ddl_tipoDocumento.SelectedIndex;
            int numero_documento = int.Parse(txt_numeroDocumento.Text);
            int telefono = int.Parse(txt_telefono.Text);
            string calle = txt_calle.Text;
            int numeroTelefono = int.Parse(txt_calleNumero.Text);
            int id_localidad = ddl_Localidad.SelectedIndex;
            string mail = txt_mail.Text;
            int celular = int.Parse(txt_celular.Text);
            DateTime fecha_nacimiento = DateTime.Parse(txt_fechaNacimiento.Text);
            string sexo = "";
            if (rbn_sexo.SelectedIndex==0)
            {
               sexo = "M";
            }
            else
            {
              sexo = "F";
            }
            string nombre_usuario = txt_nombreUsuario.Text;
            string contraseña = txt_contraseña.Text;

            Capa_de_entidad.Tipo_Documento td = new Capa_de_entidad.Tipo_Documento();
            Capa_de_entidad.Localidad l = new Capa_de_entidad.Localidad();
            td.id_tipo_documento = id_tipo_documento;
            l.id_localidad = id_localidad;
            Capa_de_entidad.Cliente c = new Capa_de_entidad.Cliente();
            Capa_de_entidad.Usuario u = new Capa_de_entidad.Usuario();
            u.nombre_usuario = nombre_usuario;
            u.contraseña = contraseña;
            u.cliente = c;
            u.cliente.tipo_documento = td;
            c.localidad = l;
            c.nombre = nombre;
            c.apellido = apellido;
            u.cliente.tipo_documento.id_tipo_documento = id_tipo_documento;
            c.numero_documento = numero_documento;
            c.telefono = telefono;
            c.celular = celular;
            c.calle = calle;
            c.numero = numeroTelefono;
            c.localidad.id_localidad = id_localidad;
            c.mail = mail;
            c.fecha_nacimiento = fecha_nacimiento;
            c.sexo = sexo;
            

            Capa_de_negocio.Gestor_Cliente.agregar_cliente(u);
            
        }
      protected void btn_cancelar_Click(object sender, EventArgs e)
           {
               pnl_Cliente.Visible = true;
               pnl_editar_Cliente.Visible = false;
               ViewState["boton"] = "cancelar";
               refrescar_campos();
               lbl_ambito.Text = "";
               cargar_grilla();
          }

        private void modificar_cliente(int id_cliente)
        {
          string boton = ViewState["boton"].ToString();
           Capa_de_entidad.Cliente c=new Capa_de_entidad.Cliente();
           Capa_de_entidad.Usuario u = new Capa_de_entidad.Usuario();
            if (boton == "editar") 
            {
                string nombre = txt_nombre.Text;
                string apellido = txt_apellido.Text;
                int id_tipo_documento = ddl_tipoDocumento.SelectedIndex;
                int numero_documento = int.Parse(txt_numeroDocumento.Text);
                int telefono = int.Parse(txt_telefono.Text);
                string calle = txt_calle.Text;
                int numeroTelefono = int.Parse(txt_calleNumero.Text);
                int id_localidad = ddl_Localidad.SelectedIndex;
                string mail = txt_mail.Text;
                int celular = int.Parse(txt_celular.Text); DateTime fecha_nacimiento = DateTime.Parse(txt_fechaNacimiento.Text);
                string sexo = "";
                if (rbn_sexo.SelectedIndex == 0)
                {
                    sexo = "M";
                }
                else
                {
                    sexo = "F";
                }
                string nombre_usuario = txt_nombreUsuario.Text;
                string contraseña = txt_contraseña.Text;

                
                u.nombre_usuario = nombre_usuario;
                u.contraseña = contraseña;
                u.cliente = c;
                Capa_de_entidad.Tipo_Documento td = new Capa_de_entidad.Tipo_Documento();
                Capa_de_entidad.Localidad l = new Capa_de_entidad.Localidad();
                td.id_tipo_documento = id_tipo_documento;
                l.id_localidad = id_localidad;
                u.cliente.tipo_documento = td;
                c.localidad = l;
                c.nombre = nombre;
                c.apellido = apellido;
                u.cliente.tipo_documento.id_tipo_documento = id_tipo_documento;
                c.numero_documento = numero_documento;
                c.telefono = telefono;
                c.celular = celular;
                c.calle = calle;
                c.numero = numeroTelefono;
                c.localidad.id_localidad = id_localidad;
                c.mail = mail;
                c.fecha_nacimiento = fecha_nacimiento;
                c.sexo = sexo;
                
                Capa_de_negocio.Gestor_Cliente.modificar_cliente(u,id_cliente);
              }
                 else
              {

                  Capa_de_negocio.Gestor_Cliente.eliminar_cliente(u, id_cliente);
             }
               
            }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            pnl_Cliente.Visible = false;
            pnl_editar_Cliente.Visible = true;
            lbl_msj.Text = "";
            ViewState["boton"] = "agregar";
            lbl_ambito.Text = "Agregando";
            habilitar();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            pnl_Cliente.Visible = false;
            pnl_editar_Cliente.Visible = true;

            ViewState["boton"] = "eliminar";
            habilitar();
            lbl_msj.Text = "";
            if (gv_clientes.SelectedRow != null) //Verificamos que haya seleccionado algo de la grilla 
            {
                int id_cliente = (int)gv_clientes.SelectedValue;

               Capa_de_entidad.Usuario u = Capa_de_negocio.Gestor_Cliente.buscar_por_id(id_cliente);
               
                lbl_id_Cliente.Text = "" + id_cliente;
                lbl_id_Cliente.Visible = true;
                lbl_nroIdCliente.Visible = true;

                //completar_campos(c);
                completar_campos(u);
                    //,u);

                lbl_ambito.Text = "Eliminando";
            }
            cargar_grilla();
        }

     
       

       

     

        
     }
      
  }
      
      
  

