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

        }
    }
}