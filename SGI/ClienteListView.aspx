<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClienteListView.aspx.cs" Inherits="SGI.ClienteListView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <div>

        <asp:GridView ID="GridClientes" runat="server" OnRowCommand="GridClientes_RowCommand"  AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" DataSourceID="SqlDataSource1" EnableModelValidation="True" GridLines="Vertical" OnSelectedIndexChanged="GridClientes_SelectedIndexChanged" Width="882px" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone" SortExpression="Telefone" />
                <asp:BoundField DataField="Cpf" HeaderText="Cpf" SortExpression="Cpf" />
                <asp:BoundField DataField="Endereco" HeaderText="Endereco" SortExpression="Endereco" />
                <asp:ButtonField ButtonType="Image" HeaderText="Excluir" ImageUrl="~/Imagens/delete_icon.png" Text="Button" CommandName="Excluir" >
                <ControlStyle Height="20px" Width="20px" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" HeaderText="Alterar" ImageUrl="~/Imagens/alterar.png" Text="Button" CommandName="Alterar" >
                <ControlStyle Height="20px" Width="20px" />
                </asp:ButtonField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        </asp:GridView><br /> <br />

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Cliente] ORDER BY [Id]"></asp:SqlDataSource>

    </div>
     <div>
          <asp:Label ID="lblMensagem" runat="server" Visible="false"></asp:Label>
    </div> 
    <div>

        <div class="panel-body">
            <asp:Label ID="lbId" runat="server" Visible="false"></asp:Label>
            <div style="margin-left:5px;margin-top:15px;">
                <asp:TextBox runat="server" id="cpf" CssClass="form-control" placeholder="CPF" ReadOnly="true" Width="587px"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Preencha o campo CPF" ControlToValidate="cpf">*</asp:RequiredFieldValidator>
            </div>
            <div style="margin-top:10px; margin-left:5px;" >
                <asp:TextBox runat="server" id="nome" CssClass="form-control" ReadOnly="true" placeholder="Nome" Width="587px"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o campo Nome" ControlToValidate="nome">*</asp:RequiredFieldValidator>
            </div>
            <div style="margin-left:5px;margin-top:15px;">
                <asp:TextBox runat="server" id="email" CssClass="form-control" ReadOnly="true" placeholder="E-mail" Width="587px"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ReadOnly="true" ErrorMessage="Preencha o campo E-mail" ControlToValidate="email">*</asp:RequiredFieldValidator>
            </div>
            <div style="margin-left:5px;margin-top:15px;">
                <asp:TextBox runat="server" id="telefone" CssClass="form-control" ReadOnly="true" placeholder="Telefone" Width="587px"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Preencha o campo Telefone" ControlToValidate="telefone">*</asp:RequiredFieldValidator>
            </div>
            <div style="margin-left:5px;margin-top:15px;">
                <asp:TextBox runat="server" id="endereco" CssClass="form-control" ReadOnly="true" placeholder="Endereço" Width="587px"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencha o campo Endereco" ControlToValidate="endereco">*</asp:RequiredFieldValidator>
            </div>
            <div class="btn-group-sm" style="margin-top:15px; margin-left:5px;">
                <asp:Button runat="server" ID="alterar" CssClass="btn btn-primary" Text="Salvar Alterações" OnClick="Salvar"/>
                <asp:Button runat="server" ID="limpar" CssClass="btn btn-danger" Text="Cancelar" OnClick="Limpar" ValidationGroup="false" Height="32px"/>
            </div>
        </div>

    </div>
</asp:Content>
