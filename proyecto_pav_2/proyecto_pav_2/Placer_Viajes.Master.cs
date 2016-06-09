using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_de_presentacion
{
    public partial class Placer_Viajes : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Context.User.IsInRole("administrador"))
            {
                mnu_administracion_paquetes.Visible = true;
                mnu_informes.Visible = true;
            }
                
            else
            {
                mnu_administracion_paquetes.Visible = false;
                mnu_informes.Visible = false;
            } 
        }
    }
}