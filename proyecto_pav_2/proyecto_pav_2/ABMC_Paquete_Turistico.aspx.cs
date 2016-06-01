using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_de_presentacion
{
    public partial class ABMC_Paquete_Turistico : System.Web.UI.Page
    {
        enum boton
        {
            inicio,buscar,consultar,editar,agregar,eliminar
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["gv_paquete_turistico"] = "nombre_paquete"; //guarda estado anterior en este caso de la primera carga
                ViewState["boton"] = "inicio";

                cargar_grilla();

                cargar_combo(ddl_temporada, "id_temporada", "nombre");
                ddl_temporada.Items.Insert(0, "Seleccione una temporada");

                cargar_combo(ddl_destino,"id_destino","nombre");
                ddl_destino.Items.Insert(0,"Seleccione un destino");
                
                //cargar_combo(ddl_alojamiento, "id_alojamiento", "nombre");
                ddl_alojamiento.Items.Insert(0, "Seleccione un alojamiento");

                cargar_combo(ddl_pension, "id_pension", "descripcion");
                ddl_pension.Items.Insert(0, "Pension");

                cargar_combo(ddl_habitacion, "id_habitacion", "nombre");
                ddl_habitacion.Items.Insert(0,"Habitacion");

                cargar_combo(ddl_transporte, "id_transporte", "descripcion");
                ddl_transporte.Items.Insert(0, "Seleccione un transporte");
            }
        }

        private void cargar_grilla() 
        {
            string orden = ViewState["gv_paquete_turistico"].ToString(); //recupera estado
            string boton = ViewState["boton"].ToString();

            if (boton == "inicio")
            {
                gv_paquete_turistico.DataSource = Capa_de_negocio.Gestor_Paquete_Turistico.buscar_paquetes();
                gv_paquete_turistico.DataBind();    
            }
            else
            {
                if (boton == "buscar")
                {
                    gv_paquete_turistico.DataSource = Capa_de_negocio.Gestor_Paquete_Turistico.buscar_por_nombre(txt_nombre_paquete.Text, orden);
                    gv_paquete_turistico.DataBind(); 
                }
            }
        }

        private void cargar_combo(DropDownList ddl,string valueField,string textField) 
        {

            if (ddl.ID == "ddl_temporada")
            {
                ddl_temporada.DataSource = Capa_de_negocio.Gestor_Temporada.obtener_temporadas();
            }
            else
            {
                if (ddl.ID=="ddl_destino")
                {
                    ddl_destino.DataSource = Capa_de_negocio.Gestor_Destino.obtener_destinos();
                }
                else
                {
                    if (ddl.ID == "ddl_alojamiento")
                    {
                        ddl_alojamiento.DataSource = Capa_de_negocio.Gestor_Alojamento.obtener_alojamientos();
                    }
                    else
                    {
                        if (ddl.ID == "ddl_pension")
                        {
                            ddl_pension.DataSource = Capa_de_negocio.Gestor_Pension.obtener_pensiones();
                        }
                        else
                        {
                            if (ddl.ID == "ddl_habitacion")
                            {
                                ddl_habitacion.DataSource = Capa_de_negocio.Gestor_Habitacion.obtener_habitaciones();
                            }
                            else
                            {
                                if (ddl.ID == "ddl_transporte")
                                {
                                    ddl_transporte.DataSource = Capa_de_negocio.Gestor_Transporte.obtener_transportes();
                                }
                            }
                        }
                    }
                }
            }

            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataBind();
        }

        protected void gv_paquete_turistico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_paquete_turistico.PageIndex = e.NewPageIndex; //quiero mostrar en la pag donde hizo click
            cargar_grilla();
        }

        protected void gv_paquete_turistico_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["gv_paquete_turistico"] = e.SortExpression; //ordena por el titulo en el q hizo click
            ViewState["boton"] = "buscar";
            cargar_grilla();
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            ViewState["boton"] = "buscar";
            cargar_grilla();
        }

        protected void btn_consultar_Click(object sender, EventArgs e)
        {
            pnl_paquete_turistico.Visible = false;
            pnl_editar_paquete.Visible = true;
            ViewState["boton"] = "consultar";
            habilitar();

            if (gv_paquete_turistico.SelectedRow != null) //Verificamos que haya seleccionado algo de la grilla 
            {
                int id_paquete_turistico = (int)gv_paquete_turistico.SelectedValue;

                Capa_de_entidad.Paquete_Turistico p = (Capa_de_entidad.Paquete_Turistico) Capa_de_negocio.Gestor_Paquete_Turistico.buscar_por_id(id_paquete_turistico);

                lbl_id_paquete_turistico.Text = ""+p.id_paquete_turistico;

                lbl_nro_paquete_turistico.Visible = true;
                lbl_id_paquete_turistico.Visible = true;

                completar_campos(p);
                
                lbl_ambito.Text = "Consultando";
            }

        }

        protected void btn_editar_Click(object sender, EventArgs e)
        {
            pnl_paquete_turistico.Visible = false;
            pnl_editar_paquete.Visible = true;

            ViewState["boton"] = "editar";
            habilitar();

            if (gv_paquete_turistico.SelectedRow != null) //Verificamos que haya seleccionado algo de la grilla 
            {
                int id_paquete_turistico = (int)gv_paquete_turistico.SelectedValue;

                Capa_de_entidad.Paquete_Turistico p = (Capa_de_entidad.Paquete_Turistico)Capa_de_negocio.Gestor_Paquete_Turistico.buscar_por_id(id_paquete_turistico);

                lbl_id_paquete_turistico.Text = "" + p.id_paquete_turistico;

                lbl_nro_paquete_turistico.Visible = true;
                lbl_id_paquete_turistico.Visible = true;

                completar_campos(p);

                lbl_ambito.Text = "Editando";
            }

        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            pnl_paquete_turistico.Visible = false;
            pnl_editar_paquete.Visible = true;

            ViewState["boton"] = "agregar";
            lbl_ambito.Text = "Agregando";
            habilitar();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            pnl_paquete_turistico.Visible = false;
            pnl_editar_paquete.Visible = true;

            ViewState["boton"] = "eliminar";
            habilitar();

            if (gv_paquete_turistico.SelectedRow != null) //Verificamos que haya seleccionado algo de la grilla 
            {
                int id_paquete_turistico = (int)gv_paquete_turistico.SelectedValue;

                Capa_de_entidad.Paquete_Turistico p = (Capa_de_entidad.Paquete_Turistico)Capa_de_negocio.Gestor_Paquete_Turistico.buscar_por_id(id_paquete_turistico);

                lbl_id_paquete_turistico.Text = "" + p.id_paquete_turistico;

                lbl_nro_paquete_turistico.Visible = true;
                lbl_id_paquete_turistico.Visible = true;

                completar_campos(p);

                lbl_ambito.Text = "Eliminando";
            }
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                pnl_paquete_turistico.Visible = true;
                pnl_editar_paquete.Visible = false;

                string boton = ViewState["boton"].ToString();

                if (boton == "agregar")
                {
                    grabar();
                }
                else
                {
                    if (boton == "editar" || boton == "eliminar")
                    {
                        int id_paquete_turistico = int.Parse(lbl_id_paquete_turistico.Text);
                        modificar_paquete(id_paquete_turistico);
                    }
                }

                ViewState["boton"] = "aceptar";

                refrescar_campos();
            }
            
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            pnl_paquete_turistico.Visible = true;
            pnl_editar_paquete.Visible = false;

            ViewState["boton"] = "cancelar";
            refrescar_campos();
        }

        private void habilitar() 
        {
            string boton = ViewState["boton"].ToString();
            if (boton == "editar" || boton == "agregar")
            {
                ddl_temporada.Enabled = true;
                txt_nombre.Enabled = true;
                ddl_destino.Enabled = true;
                txt_fecha_inicio.Enabled = true;
                txt_fecha_finalizacion.Enabled = true;
                txt_cantidad_dias.Enabled = true;
                txt_cantidad_noches.Enabled = true;
                txt_descripcion_paquete.Enabled = true;
                ddl_alojamiento.Enabled = true;
                ddl_transporte.Enabled = true;
            }
            else
            {
                ddl_temporada.Enabled = false;
                txt_nombre.Enabled = false;
                ddl_destino.Enabled = false;
                txt_fecha_inicio.Enabled = false;
                txt_fecha_finalizacion.Enabled = false;
                txt_cantidad_dias.Enabled = false;
                txt_cantidad_noches.Enabled = false;
                txt_descripcion_paquete.Enabled = false;
                ddl_alojamiento.Enabled = false;
                ddl_transporte.Enabled = false;
            }
        }

        private void completar_campos(Capa_de_entidad.Paquete_Turistico p)
        {
            ddl_temporada.SelectedIndex = p.temporada.id_temporada;
            txt_nombre.Text = p.nombre_paquete;
            ddl_destino.SelectedIndex = p.destino.id_destino;
            txt_fecha_inicio.Text = p.fecha_inicio.ToString("dd/MM/yyyy");
            txt_fecha_finalizacion.Text = p.fecha_fin.ToString("dd/MM/yyyy");
            txt_cantidad_dias.Text = p.cantidad_dias.ToString();
            txt_cantidad_noches.Text = p.cantidad_noches.ToString();
            txt_descripcion_paquete.Text = p.descripcion;
            ddl_alojamiento.SelectedIndex = p.alojamiento.id_alojamiento;
            txt_descripcion_alojamiento.Text = p.alojamiento.descripcion;
            ddl_pension.SelectedIndex = p.alojamiento.pension.id_pension;
            ddl_habitacion.SelectedIndex = p.alojamiento.habitacion.id_habitacion;
            ddl_transporte.SelectedIndex = p.transporte.id_transporte;
            txt_descuento_menor.Text = "" + p.descuento_menor;
        }

        private void refrescar_campos() 
        {
            ddl_temporada.SelectedIndex = 0;
            txt_nombre.Text = "";
            ddl_destino.SelectedIndex = 0;
            txt_fecha_inicio.Text = "";
            txt_fecha_finalizacion.Text = "";
            txt_cantidad_dias.Text = "";
            txt_cantidad_noches.Text = "";
            txt_descripcion_paquete.Text = "";
            ddl_alojamiento.SelectedIndex = 0;
            txt_descripcion_alojamiento.Text = "";
            ddl_pension.SelectedIndex = 0;
            ddl_habitacion.SelectedIndex = 0;
            ddl_transporte.SelectedIndex = 0;
            txt_descuento_menor.Text = "";
            lbl_nro_paquete_turistico.Visible = false;
            lbl_id_paquete_turistico.Visible = false;
        }

        private void grabar() 
        {
            int id_temporada = ddl_temporada.SelectedIndex;
            string nombre_paquete = txt_nombre.Text;
            int id_destino = ddl_destino.SelectedIndex;
            DateTime fecha_desde = DateTime.Parse(txt_fecha_inicio.Text);
            DateTime fecha_hasta = DateTime.Parse(txt_fecha_finalizacion.Text);
            int cantidad_dias = int.Parse(txt_cantidad_dias.Text);
            int cantidad_noches = int.Parse(txt_cantidad_noches.Text);
            string descripcion_paquete = txt_descripcion_paquete.Text;
            int id_alojamiento = ddl_alojamiento.SelectedIndex;
            string descripcion_alojmiento = txt_descripcion_alojamiento.Text;
            int id_pension = ddl_pension.SelectedIndex;
            int id_habitacion = ddl_habitacion.SelectedIndex;
            int id_transporte = ddl_transporte.SelectedIndex;
            decimal descuento_menor;
            if (txt_descuento_menor.Text.Trim() !=  "")
            {
                descuento_menor = decimal.Parse(txt_descuento_menor.Text);    
            }
            else
            {
                descuento_menor = (decimal)0.0;
            }

            Capa_de_entidad.Paquete_Turistico p = new Capa_de_entidad.Paquete_Turistico();
            Capa_de_entidad.Temporada t = new Capa_de_entidad.Temporada();
            Capa_de_entidad.Destino d = new Capa_de_entidad.Destino();
            Capa_de_entidad.Alojamiento a = new Capa_de_entidad.Alojamiento();
            Capa_de_entidad.Pension pen = new Capa_de_entidad.Pension();
            Capa_de_entidad.Habitacion h = new Capa_de_entidad.Habitacion();
            Capa_de_entidad.Transporte tr = new Capa_de_entidad.Transporte();

            t.id_temporada = id_temporada;
            p.temporada = t;

            p.nombre_paquete = nombre_paquete;
            
            d.id_destino = id_destino;
            p.destino = d;

            p.fecha_inicio = fecha_desde;
            p.fecha_fin = fecha_hasta;
            p.cantidad_dias = cantidad_dias;
            p.cantidad_noches = cantidad_noches;
            p.descripcion = descripcion_paquete;

            a.id_alojamiento = id_alojamiento;
            a.descripcion = descripcion_alojmiento;
            pen.id_pension = id_pension;
            h.id_habitacion = id_habitacion;
            a.pension = pen;
            a.habitacion = h;
            p.alojamiento = a;

            tr.id_transporte = id_transporte;
            p.transporte = tr;

            p.descuento_menor = descuento_menor;

            Capa_de_negocio.Gestor_Paquete_Turistico.agregar_paquete(p);
        }

        private void modificar_paquete(int id_paquete) 
        {
            string boton = ViewState["boton"].ToString();
            Capa_de_entidad.Paquete_Turistico p = new Capa_de_entidad.Paquete_Turistico();

            if (boton == "editar")
            {
                int id_paquete_turistico = id_paquete;
                int id_temporada = ddl_temporada.SelectedIndex;
                string nombre_paquete = txt_nombre.Text;
                int id_destino = ddl_destino.SelectedIndex;
                DateTime fecha_desde = DateTime.Parse(txt_fecha_inicio.Text);
                DateTime fecha_hasta = DateTime.Parse(txt_fecha_finalizacion.Text);
                int cantidad_dias = int.Parse(txt_cantidad_dias.Text);
                int cantidad_noches = int.Parse(txt_cantidad_noches.Text);
                string descripcion_paquete = txt_descripcion_paquete.Text;
                int id_alojamiento = ddl_alojamiento.SelectedIndex;
                string descripcion_alojmiento = txt_descripcion_alojamiento.Text;
                int id_pension = ddl_pension.SelectedIndex;
                int id_habitacion = ddl_habitacion.SelectedIndex;
                int id_transporte = ddl_transporte.SelectedIndex;
                decimal descuento_menor = decimal.Parse(txt_descuento_menor.Text);

                Capa_de_entidad.Temporada t = new Capa_de_entidad.Temporada();
                Capa_de_entidad.Destino d = new Capa_de_entidad.Destino();
                Capa_de_entidad.Alojamiento a = new Capa_de_entidad.Alojamiento();
                Capa_de_entidad.Pension pen = new Capa_de_entidad.Pension();
                Capa_de_entidad.Habitacion h = new Capa_de_entidad.Habitacion();
                Capa_de_entidad.Transporte tr = new Capa_de_entidad.Transporte();

                t.id_temporada = id_temporada;
                p.temporada = t;

                p.id_paquete_turistico = id_paquete_turistico;
                p.nombre_paquete = nombre_paquete;

                d.id_destino = id_destino;
                p.destino = d;

                p.fecha_inicio = fecha_desde;
                p.fecha_fin = fecha_hasta;
                p.cantidad_dias = cantidad_dias;
                p.cantidad_noches = cantidad_noches;
                p.descripcion = descripcion_paquete;

                a.id_alojamiento = id_alojamiento;
                a.descripcion = descripcion_alojmiento;
                pen.id_pension = id_pension;
                h.id_habitacion = id_habitacion;
                a.pension = pen;
                a.habitacion = h;
                p.alojamiento = a;

                tr.id_transporte = id_transporte;
                p.transporte = tr;

                p.descuento_menor = descuento_menor;

                Capa_de_negocio.Gestor_Paquete_Turistico.modificar_paquete(p);
            }
            else
            {
                p.id_paquete_turistico = id_paquete;
                Capa_de_negocio.Gestor_Paquete_Turistico.eliminar_paquete(p);
            }
        }

        protected void validar_lista_temporada_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "0")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ddl_alojamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_alojamiento = ddl_alojamiento.SelectedIndex;

            if (id_alojamiento != 0)
            {
                Capa_de_entidad.Alojamiento a = Capa_de_negocio.Gestor_Alojamento.buscar_por_id(id_alojamiento);

                txt_descripcion_alojamiento.Text = a.descripcion;
                ddl_pension.SelectedIndex = a.pension.id_pension;
                ddl_habitacion.SelectedIndex = a.habitacion.id_habitacion;    
            }
            else
            {
                txt_descripcion_alojamiento.Text = "";
                ddl_pension.SelectedIndex = 0;
                ddl_habitacion.SelectedIndex = 0;
            }
        }

        protected void ddl_destino_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_destino = ddl_destino.SelectedIndex;

            //ddl_alojamiento.Items.Clear();

            if (id_destino != 0)
            {
                ddl_alojamiento.DataSource = Capa_de_negocio.Gestor_Alojamento.obtener_alojamientos(id_destino);
                ddl_alojamiento.DataValueField = "id_alojamiento";
                ddl_alojamiento.DataTextField = "nombre";
                ddl_alojamiento.DataBind();
                ddl_alojamiento.Items.Insert(0, "Seleccione un alojamiento");
                txt_descripcion_alojamiento.Text = "";
                ddl_pension.SelectedIndex = 0;
                ddl_habitacion.SelectedIndex = 0;

                ddl_transporte.DataSource = Capa_de_negocio.Gestor_Transporte.obtener_transportes(id_destino);
                ddl_transporte.DataValueField = "id_transporte";
                ddl_transporte.DataTextField = "descripcion";
                ddl_transporte.DataBind();
                ddl_transporte.Items.Insert(0, "Seleccione un transporte");
                
            }
            else
            {
                ddl_alojamiento.Items.Clear();
                ddl_alojamiento.Items.Insert(0, "Seleccione un alojamiento");
                txt_descripcion_alojamiento.Text = "";
                ddl_pension.SelectedIndex = 0;
                ddl_habitacion.SelectedIndex = 0;

                ddl_transporte.Items.Clear();
                ddl_transporte.Items.Insert(0, "Seleccione un transporte");
                
            }

        }

    }
}