using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Capa_de_presentacion
{
    public partial class Informe_Reserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["grv_informe"] = "nombre_temporada"; //guarda estado anterior en este caso de la primera carga
                
                cargar_grilla();

                cargar_combo(ddl_temporada, Capa_de_negocio.Gestor_Temporada.obtener_temporadas(), "id_temporada", "nombre");
                ddl_temporada.Items.Insert(0, "Todas las temporadas");

                cargar_combo(ddl_nombre_paquete, Capa_de_negocio.Gestor_Paquete_Turistico.buscar_paquetes(), "id_paquete_turistico", "nombre_paquete");
                ddl_nombre_paquete.Items.Insert(0, "Todos los paquetes");
            }
        }

        private void cargar_combo(DropDownList ddl, DataTable dt, string valueField, string textField)
        {
            ddl.DataSource = dt;
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataBind();
        }

        private void cargar_grilla()
        {
            string orden = ViewState["grv_informe"].ToString(); //recupera estado

            grv_informe.DataSource = Capa_de_negocio.Gestor_Reserva.buscar_reservas();
            grv_informe.DataBind();
        }

        private void cargar_grilla(DataTable dt)
        {
            string orden = ViewState["grv_informe"].ToString(); //recupera estado

            grv_informe.DataSource = dt;
            grv_informe.DataBind();
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (chk_nombre_paquete.Checked)
            {
                if (txt_fecha_desde.Text != "" && txt_fecha_hasta.Text != "")
                {
                    validar_pagina();
                }
                else validar_pagina();
            }
            else
            {
                validar_pagina();
            }
        }

        private void validar_pagina() 
        {
            if (Page.IsValid)
            {
                if (!chk_temporada.Checked && !chk_rango_fecha.Checked && !chk_nombre_paquete.Checked)
                {
                    cargar_grilla();
                }
                else
                {
                    DateTime f_d,f_h;
                    string fecha_desde = "";
                    string fecha_hasta = "";
                    if(DateTime.TryParse(txt_fecha_desde.Text,out f_d)){fecha_desde=f_d.ToShortDateString();}
                    if(DateTime.TryParse(txt_fecha_hasta.Text,out f_h)){fecha_hasta=f_h.ToShortDateString();}

                    cargar_grilla(Capa_de_negocio.Gestor_Reserva.buscar_reservas(ddl_temporada.SelectedValue,fecha_desde,fecha_hasta,ddl_nombre_paquete.SelectedValue));
                }
            }
        }

        protected void btn_volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void chk_rango_fecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_rango_fecha.Checked)
            {
                txt_fecha_desde.Enabled = true;
                txt_fecha_hasta.Enabled = true;
            }
            else
            {
                txt_fecha_desde.Enabled = false;
                txt_fecha_desde.Text = "";
                txt_fecha_hasta.Enabled = false;
                txt_fecha_hasta.Text = "";
            }
        }

        protected void chk_temporada_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_temporada.Checked)
            {
                ddl_temporada.Enabled = true;
            }
            else
            {
                ddl_temporada.Enabled = false;
                ddl_temporada.SelectedIndex = 0;
            }
        }

        protected void chk_nombre_paquete_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_nombre_paquete.Checked)
            {
                ddl_nombre_paquete.Enabled = true;
            }
            else
            {
                ddl_nombre_paquete.Enabled = false;
                ddl_nombre_paquete.SelectedIndex = 0;
            }
        }
    }
}