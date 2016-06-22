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
    }
}