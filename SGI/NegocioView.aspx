<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NegocioView.aspx.cs" Inherits="SGI.NegocioView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <div class="page-header">
        <h1>Área de Venda</h1>
    </div>   
    <div>
        <div>
            <asp:Button Text="Imóvel" ID="Tab1" CssClass="btn btn-primary" runat="server"
              OnClick="Tab1_Click" />
          <asp:Button Text="Cliente" ID="Tab2" CssClass="btn btn-primary" runat="server"
              OnClick="Tab2_Click" />
            <asp:MultiView runat="server" ID="MainView">
                <asp:View runat="server" ID="ViewImovel">
                    <div class="span12" style="border: 1px groove">
                        
                        <asp:DropDownList runat="server" ID="comboTipo" CssClass="form-control" EnableViewState="true" Width="20%" OnSelectedIndexChanged="comboTipo_SelectedIndexChanged1" AutoPostBack="true">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:GridView OnRowCommand="GridViewImovel_RowCommand" ID="GridViewImovel" runat="server" DataKeyNames="id" CssClass="table table-hover table-striped" EnableModelValidation="True">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="Escolher" CommandName="escolher">
                                <ControlStyle CssClass="btn btn-primary" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="ViewCliente">
                    <div class ="span12" style="border: 1px groove">
                    <asp:GridView OnRowCommand="GridCliente_RowCommand" ID="GridCliente" runat="server" DataKeyNames="id" CssClass="table table-hover table-striped" EnableModelValidation="True">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="Escolher" CommandName="escolher">
                                <ControlStyle CssClass="btn btn-primary" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                        </div>
                </asp:View>
            </asp:MultiView>

        </div>
        <div>
            <asp:Button runat="server" ID="btnSalvar" CssClass="btn btn-success" Text="Salvar" OnClick="btnSalvar_Click" />
            <br />
            <br />
            <br />
            <asp:Label CssClass="alert alert-success" runat="server" ID="alerta" Visible="false"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label runat="server" ID="lblVendedor" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="lblCliente" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="lblImovel" Visible="false"></asp:Label>
        </div>
       
    </div>
</asp:Content>
