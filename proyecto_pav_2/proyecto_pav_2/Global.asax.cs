using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Capa_de_presentacion
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/js/jquery.js",
                DebugPath = "~/js/jquery.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                //Establezco los roles del usuario
                var id = HttpContext.Current.User.Identity;
                HttpContext.Current.User =
                    new System.Security.Principal.GenericPrincipal
                        (id, Capa_de_negocio.Gestor_Usuario.obtener_roles(id.Name));
            }
        }

    }
}