using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGI
{
    public partial class Login : System.Web.UI.Page
    {
        db_sgiEntities4 de = new db_sgiEntities4();

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void AcessarLogin(object sender, EventArgs e)
        {
            Vendedor v = de.Vendedor.Where(x => x.login.Equals(usuario.Text) && x.senha.Equals(senha.Text)).FirstOrDefault();
            if (v != null)
            {
                Session["idVendedor"] = v.Id;
                Response.Write("<sript>window.alert('Logado com sucesso!')</script>");
                Response.Redirect("Default.aspx");
            }
            else
            {
                alerta.Text = "Usuário ou senha inválidos";
                alerta.Visible = true;

            }
        }

        public static Boolean isLogado()
        {   
            return  HttpContext.Current.Session["idVendedor"] != null;
        }
    }
}