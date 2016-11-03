using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGI
{
    public partial class VendedorListView : System.Web.UI.Page
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

        protected void Salvar(object sender, EventArgs e)
        {
            Vendedor vend = new Vendedor();
            int id = int.Parse(lbId.Text);

            vend = sgiEntity.Vendedor.Where(x => x.Id == id).FirstOrDefault();

            vend.Nome = nome.Text;
            vend.Cpf = cpf.Text;
            vend.Email = email.Text;
            vend.senha = senha.Text;
            vend.login = login.Text;
            try
            {
                sgiEntity.ApplyPropertyChanges("Vendedor", vend);
                sgiEntity.SaveChanges();


                lblMensagem.Visible = true;
                lblMensagem.Text = "Alteração Realizada com Sucesso!";
                lblMensagem.CssClass = "alert alert-success";
                clear_form(this);
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void Limpar(object sender, EventArgs e)
        {
            clear_form(this);
        }

        protected void GridClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridVendedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alterar"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridVendedores.Rows[linha].Cells[0].Text);

                lbId.Text = GridVendedores.Rows[linha].Cells[0].Text;

                cpf.Text = GridVendedores.Rows[linha].Cells[3].Text;
                nome.Text = GridVendedores.Rows[linha].Cells[1].Text;
                email.Text = GridVendedores.Rows[linha].Cells[2].Text;
                login.Text = GridVendedores.Rows[linha].Cells[4].Text;
                senha.Text = GridVendedores.Rows[linha].Cells[5].Text;

                cpf.ReadOnly = false;
                nome.ReadOnly = false;
                email.ReadOnly = false;
                login.ReadOnly = false;
                senha.ReadOnly = false;
                confirmaSenha.ReadOnly = false;
            }
            else if (e.CommandName.Equals("Excluir"))
            {

                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridVendedores.Rows[linha].Cells[0].Text);

                //Inscricao ins = new Inscricao() { Id = id };

                var vend = sgiEntity.Vendedor.Where(x => x.Id == id).FirstOrDefault();
                sgiEntity.DeleteObject(vend);
                sgiEntity.SaveChanges();
                lblMensagem.Visible = true;
                lblMensagem.Text = "excluido com sucesso!";
                lblMensagem.CssClass = "alert alert-success";
                clear_form(this);
            }
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
            login.ReadOnly = true;
            senha.ReadOnly = true;
            Response.Redirect(Request.RawUrl);
        }
    }

}