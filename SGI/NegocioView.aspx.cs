using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGI
{
    public partial class NegocioView : System.Web.UI.Page
    {
        db_sgiEntities4 de = new db_sgiEntities4();
        Negocio n = new Negocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.isLogado())
            {
                alerta.Text = "";
                if (!Page.IsPostBack)
                {
                    Dictionary<string, string> options = new Dictionary<string, string>();
                    options.Add("0", "Selecione um tipo de negócio");
                    options.Add("1", "Aluga-se");
                    options.Add("2", "Vende-se");
                    options.Add("3", "Todos");

                    comboTipo.DataSource = options;
                    comboTipo.DataTextField = "value";
                    comboTipo.DataValueField = "key";
                    comboTipo.DataBind();

                    Tab1.Enabled = true;
                    Tab2.Enabled = false;
                    MainView.ActiveViewIndex = 0;
                    btnSalvar.Enabled = false;

                    carregarTabela();
                }
            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Você não está logado no sistema!" + "');", true);
                Response.AddHeader("REFRESH", "1;URL=Login.aspx");
            }

        }

        public void carregarTabela()
        {
            var lista = de.Imovel.Select(x => new { x.Id, x.Descricao, x.Valor, x.Tipo_Negocio, x.Endereco }).OrderBy(y => y.Id);
            GridViewImovel.DataSource = lista;
            GridViewImovel.DataBind();
            GridViewImovel.UseAccessibleHeader = true;
            GridViewImovel.HeaderRow.TableSection = TableRowSection.TableHeader;

            var listaCliente = de.Cliente.Select(x => new { x.Id, x.Nome, x.Telefone }).OrderBy(y => y.Id);
            GridCliente.DataSource = listaCliente;
            GridCliente.DataBind();
            GridCliente.UseAccessibleHeader = true;
            GridCliente.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void comboTipo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (comboTipo.SelectedValue == "1")
            {
                var lista = de.Imovel.Select(x => new { x.Id, x.Descricao, x.Valor, x.Tipo_Negocio, x.Endereco }).Where(x => x.Tipo_Negocio.Equals("Aluguel")).OrderBy(y => y.Id);
                GridViewImovel.DataSource = lista;
                GridViewImovel.DataBind();
                GridViewImovel.UseAccessibleHeader = true;
                GridViewImovel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else if (comboTipo.SelectedValue == "2")
            {
                var lista = de.Imovel.Select(x => new { x.Id, x.Descricao, x.Valor, x.Tipo_Negocio, x.Endereco }).Where(x => x.Tipo_Negocio.Equals("Venda")).OrderBy(y => y.Id);
                GridViewImovel.DataSource = lista;
                GridViewImovel.DataBind();
                GridViewImovel.UseAccessibleHeader = true;
                GridViewImovel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else if (comboTipo.SelectedValue == "3")
            {
                var lista = de.Imovel.Select(x => new { x.Id, x.Descricao, x.Valor, x.Tipo_Negocio, x.Endereco }).OrderBy(y => y.Id);
                GridViewImovel.DataSource = lista;
                GridViewImovel.DataBind();
                GridViewImovel.UseAccessibleHeader = true;
                GridViewImovel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            MainView.ActiveViewIndex = 0;
            Tab2.Enabled = false;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            MainView.ActiveViewIndex = 1;
        }

       

        protected void GridViewImovel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "escolher")
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridViewImovel.Rows[linha].Cells[1].Text);
                n.Imovel = de.Imovel.Where(x => x.Id == id).FirstOrDefault();
                MainView.ActiveViewIndex = 1;
                Tab2.Enabled = true;
                lblImovel.Text = GridViewImovel.Rows[linha].Cells[1].Text;
            }
        }

        protected void GridCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "escolher")
            {
                int linha = int.Parse((string)e.CommandArgument);
                int id = int.Parse(GridCliente.Rows[linha].Cells[1].Text);
                n.Cliente = de.Cliente.Where(x => x.Id == id).FirstOrDefault();
                //MainView.ActiveViewIndex = 2;
                lblCliente.Text = GridCliente.Rows[linha].Cells[1].Text;
                btnSalvar.Enabled = true;

            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(lblCliente.Text);
            n.Cliente = de.Cliente.Where(x => x.Id == idCliente).FirstOrDefault();
            //int idVendedor = int.Parse(lblVendedor.Text);
            //n.Vendedor = de.Vendedor.Where(x => x.Id == idVendedor).FirstOrDefault();
            int idImovel = int.Parse(lblImovel.Text);
            n.Imovel = de.Imovel.Where(x => x.Id == idImovel).FirstOrDefault();
            n.Data_Evento = DateTime.Now;
            int id = int.Parse(Session["idVendedor"].ToString());
            n.Vendedor = de.Vendedor.Where(x => x.Id == id).FirstOrDefault();
            de.AddToNegocio(n);
            de.SaveChanges();

            Tab2.Enabled = false;
            btnSalvar.Enabled = false;
            MainView.ActiveViewIndex = 0;

            alerta.Text = "Negócio cadastrado com sucesso!";
            alerta.Visible = true;
        }
    }
}