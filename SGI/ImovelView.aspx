<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ImovelView.aspx.cs" Inherits="SGI.ImovelView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
 <div class="col-md-6 col-md-offset-3">
     <div class="panel panel-primary" style="margin-top:15px;">
         <div class="panel-heading">
              Cadastro de Imóveis
         </div>
        <div class="panel-body">

        <div style="margin-top:10px; margin-left:5px;" >
            <asp:Label ID="Label1" runat="server" Text="Tipo de Negócio: "></asp:Label>
            <asp:dropdownlist runat="server" id="tipoNegocio" CssClass="form-control" EnableViewState="true"/>
        </div>

        <div style="margin-top:10px; margin-left:5px;" >
             <asp:TextBox runat="server" id="desc" CssClass="form-control" placeholder="Descrição"/>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o campo Descrição" ControlToValidate="desc">*</asp:RequiredFieldValidator>
        </div>

        <div style="margin-top:10px; margin-left:5px;" >
             <asp:TextBox runat="server" id="valor" CssClass="form-control" placeholder="Valor"/>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Preencha o campo Valor" ControlToValidate="valor">*</asp:RequiredFieldValidator>
        </div>

        <div style="margin-top:10px; margin-left:5px;" >
             <asp:TextBox runat="server" id="endereco" CssClass="form-control" placeholder="Endereço"/>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o campo Endereço" ControlToValidate="endereco">*</asp:RequiredFieldValidator>
        </div>

        <div style="margin-top:10px; margin-left:5px;" >
            <asp:Label ID="Label2" runat="server" Text="Cliente: "></asp:Label>
            <asp:dropdownlist runat="server" id="ComboCliente" CssClass="form-control" placeholder="Cliente" EnableViewState="true"/>
        </div>

        <div style="margin-top:10px; margin-left:5px;" >
            <asp:Label ID="lbl" runat="server" Text="Negociado "></asp:Label>
            <asp:CheckBox runat="server" ID="status" placeholder="Vendido"/>
        </div>

        <div class="btn-group-sm" style="margin-top:15px; margin-left:5px;">
            <asp:Button CssClass="btn btn-success" runat="server" ID="cadastrar" Text="Cadastrar" OnClick="cadastrar_Click"/>
            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click"/>
            <asp:Button runat="server" ID="limpar" Text="Limpar" ValidationGroup="false" OnClick="limpar_Click"/>
        </div>

        <div style="margin-top:20px;">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Label ID="lblMensagem" runat="server" Text="" Visible="false"/>

        </div>

    </div>
    </div>
</div>
    <div class="col-md-6 col-md-offset-3">
            <div style="margin-top:20px;">
                <asp:Label ID="Label4" runat="server" Text="Lista de Imoveis" Visible="true" Font-Bold="True" />
             </div>
            <asp:GridView runat="server" ID="GridViewImoveis" OnSelectedIndexChanged="GridViewImovel_SelectedIndexChanged" OnRowCommand="GridViewEventos_RowCommand" DataKeyNames="Id" CellPadding="4" ForeColor="#333333" HeaderStyle-Width="100" RowStyle-Width="100" RowStyle-Wrap="True" Width="788px" PagerStyle-HorizontalAlign="Center" PagerStyle-VerticalAlign="Middle" EnableModelValidation="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>
                    <asp:ButtonField Text="Excluir" CommandName="excluir" ButtonType="Button" />
                    <asp:CommandField ButtonType="Button" SelectText="Editar" ShowSelectButton="True" />
                </Columns>


                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <%--<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />--%>

            </asp:GridView>
      </div>
</asp:Content>
