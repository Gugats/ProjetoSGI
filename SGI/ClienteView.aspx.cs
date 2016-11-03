using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGI
{
    public partial class ClienteView : System.Web.UI.Page
    {

        db_sgiEntities4 sgiEntity = new db_sgiEntities4();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.isLogado())
            {
            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Você não está logado no sistema!" + "');", true);
                Response.AddHeader("REFRESH", "1;URL=Login.aspx");
            }
        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            string cpf1 = cpf.Text;

            bool valida = sgiEntity.Cliente.Any(i => i.Cpf == cpf1);
            if (valida)
            {
                lblSucesso.Visible = true;
                lblSucesso.Text = "CPF já cadastrado no sistema!";
                lblSucesso.CssClass = "alert alert-danger";
            }
            else
            {
                Cliente cli = new Cliente();
                cli.Cpf = cpf.Text;
                cli.Nome = nome.Text;
                cli.Telefone = telefone.Text;
                cli.Email = email.Text;
                cli.Endereco = endereco.Text;
                sgiEntity.AddToCliente(cli);
                try
                {
                    sgiEntity.SaveChanges();


                    lblSucesso.Visible = true;
                    lblSucesso.Text = "Cadastro Realizado com Sucesso!";
                    lblSucesso.CssClass = "alert alert-success";
                    clear_form(this);
                }
                catch (Exception ex)
                {

                }
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