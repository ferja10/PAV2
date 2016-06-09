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
                rpt_temporadas.DataSource = Capa_de_negocio.Gestor_Temporada.obtener_temporadas();
                rpt_temporadas.DataBind();
            }
        }
    }
}