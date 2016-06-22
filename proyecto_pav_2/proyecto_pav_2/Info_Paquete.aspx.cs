using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_de_presentacion
{
    public partial class Info_Paquete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Capa_de_entidad.Paquete_Turistico p = new Capa_de_entidad.Paquete_Turistico();
            p = (Capa_de_entidad.Paquete_Turistico)Session["Ver"];
            completar_campos(p);
        }

        private void completar_campos(Capa_de_entidad.Paquete_Turistico p) 
        {
            lbl_nombre_paquete.Text = p.nombre_paquete;
            lbl_destino.Text = p.destino.nombre;
            txt_info_destino.Text = "Datos del lugar: " + p.destino.descripcion + "\nContenido del paquete: " + p.descripcion;
            lbl_alojamiento.Text = p.alojamiento.nombre;
            txt_info_alojamiento.Text = "Servicios: " + p.alojamiento.descripcion + "\nTipo de habitación: " + p.alojamiento.habitacion.nombre + "\nPensión: " + p.alojamiento.pension.nombre;
            lbl_transporte.Text = p.transporte.empresa.razon_social;
            txt_info_transporte.Text = "Datos del servicio de transporte " + p.transporte.nombre + ". " + p.transporte.descripcion;
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}