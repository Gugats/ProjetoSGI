using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGI
{
    public partial class ClienteListView : System.Web.UI.Page
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

        protected void GridClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void GridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if(e.CommandName.Equals("Alterar"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridClientes.Rows[linha].Cells[0].Text);
                lbId.Text = GridClientes.Rows[linha].Cells[0].Text;

            
                cpf.Text = GridClientes.Rows[linha].Cells[4].Text;
                nome.Text = GridClientes.Rows[linha].Cells[1].Text;
                email.Text = GridClientes.Rows[linha].Cells[2].Text;
                telefone.Text = GridClientes.Rows[linha].Cells[3].Text;
                endereco.Text = GridClientes.Rows[linha].Cells[5].Text;
                
                cpf.ReadOnly = false;
                nome.ReadOnly = false;
                email.ReadOnly = false;
                telefone.ReadOnly = false;
                endereco.ReadOnly = false;
                
            }else if(e.CommandName.Equals("Excluir")){
                string messageBoxText = "Do you want to save changes?";
                string caption = "Word Processor";
               

                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridClientes.Rows[linha].Cells[0].Text);

                //Inscricao ins = new Inscricao() { Id = id };

                var cli = sgiEntity.Cliente.Where(x => x.Id == id).FirstOrDefault();
                sgiEntity.DeleteObject(cli);
                sgiEntity.SaveChanges();
                lblMensagem.Visible = true;
                lblMensagem.Text = "excluido com sucesso!";
                lblMensagem.CssClass = "alert alert-success";
                Response.Redirect(Request.RawUrl);

            }
        }

        protected void Salvar(object sender, EventArgs e)
        {

                Cliente cli = new Cliente();
                int id = int.Parse(lbId.Text);

                cli = sgiEntity.Cliente.Where(x => x.Id == id).FirstOrDefault();

                cli.Nome = nome.Text;
                cli.Cpf = cpf.Text;
                cli.Telefone = telefone.Text;
                cli.Email = email.Text;
                cli.Endereco = endereco.Text;

                try
                {
                    sgiEntity.ApplyPropertyChanges("Cliente", cli);
                    sgiEntity.SaveChanges();


                    lblMensagem.Visible = true;
                    lblMensagem.Text = "Alteração Realizada com Sucesso!";
                    lblMensagem.CssClass = "alert alert-success";
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {

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

                if (ctrl.HasControls())
                    clear_form(ctrl);
            }

            cpf.ReadOnly = true;
            nome.ReadOnly = true;
            email.ReadOnly = true;
            telefone.ReadOnly = true;
            endereco.ReadOnly = true;

        }
    }
}