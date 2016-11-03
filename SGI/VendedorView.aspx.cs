using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGI
{
    public partial class VendedorView : System.Web.UI.Page
    {
        db_sgiEntities4 sgiEntity = new db_sgiEntities4();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Login.isLogado())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Você não está logado no sistema!" + "');", true);
                Response.AddHeader("REFRESH", "1;URL=Login.aspx");
            
            }

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            Vendedor vend = new Vendedor();

            vend.Nome = txtNome.Text;
            vend.Cpf = txtCpf.Text;
            vend.Email = txtEmail.Text;
            vend.login = login.Text;
            vend.senha = senha.Text;

            sgiEntity.AddToVendedor(vend);
            try
            {
                sgiEntity.SaveChanges();

                lblSucesso.Visible = true;
                lblSucesso.Text = "Cadastro Realizado com Sucesso!";
                lblSucesso.CssClass = "alert alert-success";
                // clear_form(this);
            }
            catch (Exception ex)
            {
                lblSucesso.Visible = true;
                lblSucesso.Text = ex.Message;
            }
        }

        protected void Limpar(object sender, EventArgs e)
        {
            clear_form(this);
        }

        public void clear_form(Control controle)
        {

            foreach (Control ctrl in controle.Controls)
            {
                //Limpa todos os campos TextBox
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
                if (ctrl.GetType() == typeof(Label))
                {
                    ((Label)(ctrl)).Text = String.Empty;
                }

                if (ctrl.HasControls())
                    clear_form(ctrl);
            }

            lblSucesso.Visible = false;

        }
    }
}