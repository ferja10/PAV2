using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_de_presentacion
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargar_temporadas();
                cargar_paquetes();

            }

        }

        private void cargar_temporadas() 
        {
            rpt_temporadas.DataSource = Capa_de_negocio.Gestor_Temporada.obtener_temporadas();
            rpt_temporadas.DataBind();
        }

        private void cargar_paquetes() 
        {
            int id_temporada = 0;
            if (Request.QueryString["id_temporada"] != null)
            {
                try
                {
                    id_temporada = Convert.ToInt32(Request.QueryString["id_temporada"]);

                }
                catch (Exception)
                {

                    id_temporada = 0;
                }
            }

            rpt_paquetes.DataSource = Capa_de_negocio.Gestor_Paquete_Turistico.obtener_lista(id_temporada);
            rpt_paquetes.DataBind();
        }

        protected void rpt_paquetes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id_paquete_turistico = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Ver")
            {
                visualizar_paquete(id_paquete_turistico);
            }
            else
            {
                agregar_paquete(id_paquete_turistico);
            }
        }

        private void visualizar_paquete(int id_paquete_turistico) 
        {
            Capa_de_entidad.Paquete_Turistico p = new Capa_de_entidad.Paquete_Turistico();

            p = Capa_de_negocio.Gestor_Paquete_Turistico.buscar_por_id(id_paquete_turistico);

            Session["Ver"] = p;

            Response.Redirect("Info_Paquete.aspx");
        }

        private void agregar_paquete(int id_paquete_turistico)
        {
            Capa_de_entidad.Paquete_Turistico p = new Capa_de_entidad.Paquete_Turistico();

            p = Capa_de_negocio.Gestor_Paquete_Turistico.buscar_por_id(id_paquete_turistico);

            Capa_de_entidad.Item_Paquete_turistico ipt = new Capa_de_entidad.Item_Paquete_turistico();

            ipt.paquete_turistico = p;

            List<Capa_de_entidad.Item_Paquete_turistico> lst = new List<Capa_de_entidad.Item_Paquete_turistico>();

            Boolean flag = true;

            ViewState["exito"] = "exito";

            if (Session["Reserva"] != null)
            {
                lst = (List<Capa_de_entidad.Item_Paquete_turistico>)Session["Reserva"];

                try
                {
                    foreach (var item in lst)
                    {

                        if (ipt.paquete_turistico.id_paquete_turistico == item.paquete_turistico.id_paquete_turistico)
                        {
                            flag = false;
                            
                            ViewState["exito"] = "fracaso";

                            if (ViewState["exito"].ToString().Equals("fracaso"))
                            {
                                string error = "Ya ha seleccionado este paquete anteriormente";

                                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + error + "');</script>");
                            }

                            break;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            if (flag)
            {
                lst.Add(ipt);

                Session["Reserva"] = lst;

                Response.Redirect("Reserva.aspx");
            }
        }

    }
}