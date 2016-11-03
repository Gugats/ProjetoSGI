using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGI
{
    public partial class ImovelView : System.Web.UI.Page
    {
        db_sgiEntities4 sgiEntity = new db_sgiEntities4();
        int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.isLogado())
            {
                if (!IsPostBack)
                {
                    carregarComboCliente();
                    carregarComboTipoNegocio();
                    listarImoveis();
                }
            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Você não está logado no sistema!" + "');", true);
                Response.AddHeader("REFRESH", "1;URL=Login.aspx");
            }
        }

        private void listarImoveis()
        {
            var dados = sgiEntity.Imovel.Select(x => new
            {
                x.Id,
                x.Cliente.Nome,
                x.Descricao,
                x.Tipo_Negocio,
                x.Valor,
                x.Negociado,
                x.Endereco
            });
            GridViewImoveis.DataSource = dados;
            GridViewImoveis.DataBind();
        }

        protected void cadastrar_Click(object sender, EventArgs e)
        {
            Imovel imovel = new Imovel();

            imovel.Valor = float.Parse(valor.Text);
            imovel.Endereco = endereco.Text;
            imovel.Descricao = desc.Text;
            imovel.Tipo_Negocio = tipoNegocio.SelectedValue;
            if (status.Checked)
            {
                imovel.Negociado = "Sim";
            }
            else
            {
                imovel.Negociado = "Não";
            }

            id = Int32.Parse(ComboCliente.SelectedItem.Value);
            var cliente = sgiEntity.Cliente.Where(x => x.Id == id).FirstOrDefault();
            imovel.Cliente = cliente;

            sgiEntity.AddToImovel(imovel);
            sgiEntity.SaveChanges();
            lblMensagem.Visible = true;
            lblMensagem.Text = "Imovel cadastrado com Sucesso!";
            lblMensagem.CssClass = "alert alert-success";
            clear_form(this);
            listarImoveis();
        }

        public void carregarComboCliente()
        {
            var dados = sgiEntity.Cliente.Select(x => new
            {
                x.Id,
                x.Nome
            }
            ).OrderByDescending(y => y.Id);

            ComboCliente.DataSource = dados;
            ComboCliente.DataTextField = "Nome";
            ComboCliente.DataValueField = "Id";
            ComboCliente.DataBind();
        }

        public void carregarComboTipoNegocio()
        {
            String venda = "Venda";
            String locar = "Aluguel";
            tipoNegocio.Items.Add(venda);
            tipoNegocio.Items.Add(locar);
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

        }

        protected void GridViewEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("excluir"))
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewImoveis.Rows[linha].Cells[2].Text);

                //Inscricao ins = new Inscricao() { Id = id };

                var imo = sgiEntity.Imovel.Where(x => x.Id == id).FirstOrDefault();
                sgiEntity.DeleteObject(imo);
                sgiEntity.SaveChanges();
                listarImoveis();
            }
        }

        protected void GridViewImovel_SelectedIndexChanged(object sender, EventArgs e)
        {
            valor.Text = GridViewImoveis.SelectedRow.Cells[6].Text;
            if (GridViewImoveis.SelectedRow.Cells[7].Text.Equals("Sim"))
            {
                status.Checked = true;
            }
            else
            {
                status.Checked = false;
            }
            tipoNegocio.SelectedValue = GridViewImoveis.SelectedRow.Cells[5].Text;
            endereco.Text = GridViewImoveis.SelectedRow.Cells[8].Text;
            desc.Text = GridViewImoveis.SelectedRow.Cells[4].Text;

            string value = GridViewImoveis.SelectedRow.Cells[3].Text;
            //int idCli = (int)GridViewImoveis.SelectedValue;
            ComboCliente.SelectedIndex = ComboCliente.Items.IndexOf(ComboCliente.Items.FindByText(value));

        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = (int)GridViewImoveis.SelectedValue;
            Imovel imovel = new Imovel();

            imovel = sgiEntity.Imovel.Where(x => x.Id == id).FirstOrDefault();
            imovel.Endereco = endereco.Text;
            imovel.Valor = float.Parse(valor.Text);
            imovel.Descricao = desc.Text;
            imovel.Tipo_Negocio = tipoNegocio.SelectedValue;
            if (status.Checked)
            {
                imovel.Negociado = "Sim";
            }
            else
            {
                imovel.Negociado = "Não";
            }

            id = Int32.Parse(ComboCliente.SelectedItem.Value);
            var cliente = sgiEntity.Cliente.Where(x => x.Id == id).FirstOrDefault();
            imovel.Cliente = cliente;

            sgiEntity.ApplyPropertyChanges("Imovel", imovel);

            sgiEntity.SaveChanges();

            lblMensagem.Visible = true;
            lblMensagem.Text = "Imovel salvo com Sucesso!";
            lblMensagem.CssClass = "alert alert-success";
            clear_form(this);
            listarImoveis();
        }

        protected void limpar_Click(object sender, EventArgs e)
        {
            clear_form(this);
        }
    }
}