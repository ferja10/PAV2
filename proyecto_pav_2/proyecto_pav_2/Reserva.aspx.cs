using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_de_presentacion
{
    public partial class Reserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grv_reserva.DataSource = (List<Capa_de_entidad.Item_Paquete_turistico>)Session["Reserva"];
                grv_reserva.DataBind();
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btn_reservar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (grv_reserva.Rows.Count == 0)
                {
                    string error = "No hay paquetes para reservar";

                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                }
                else
                {
                    Capa_de_negocio.Gestor_Reserva.reservar(listar_detalles(),Session["nombre_usuario"].ToString(),DateTime.Now);

                    Response.Redirect("Inicio.aspx");
                }
            }
        }

        private List<Capa_de_entidad.Detalle_Reserva> listar_detalles() 
        {
            List<Capa_de_entidad.Detalle_Reserva> lst = new List<Capa_de_entidad.Detalle_Reserva>();
            List<Capa_de_entidad.Item_Paquete_turistico>lipt = (List<Capa_de_entidad.Item_Paquete_turistico>)Session["Reserva"];
            int i=0;
            foreach (GridViewRow dtgItem in this.grv_reserva.Rows)
            {
               Capa_de_entidad.Detalle_Reserva det = new Capa_de_entidad.Detalle_Reserva();
               i++;
               TextBox cant_may = ((TextBox)grv_reserva.Rows[dtgItem.RowIndex].FindControl("txt_cantidad_mayores"));
               TextBox cant_men = ((TextBox)grv_reserva.Rows[dtgItem.RowIndex].FindControl("txt_cantidad_menores"));
               det.cantidad_mayor = int.Parse(cant_may.Text);
               det.cantidad_menor = int.Parse(cant_men.Text);
               det.item = i;
               det.item_paquete_turistico = lipt.ElementAt(i - 1);
               lst.Add(det);
            }

            return lst;
        }

        protected void grv_reserva_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = grv_reserva.SelectedIndex;
            List<Capa_de_entidad.Item_Paquete_turistico> lst = (List<Capa_de_entidad.Item_Paquete_turistico>)Session["Reserva"];

            if (id >= 0)
            {
                lst.RemoveAt(id);
                grv_reserva.DataSource = lst;
                grv_reserva.DataBind();
            }
            else
            {
                string error = "No ha seleccionado ningun paquete";

                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
            }
        }
    }
}