<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClienteView.aspx.cs" Inherits="SGI.ClienteView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <div class="col-md-6 col-md-offset-3" >
            <div class="panel panel-primary" style="margin-top:15px;">
                <div class="panel-heading">
                    Cadastro de Clientes
                </div>
                <asp:Label ID="lblSucesso" runat="server" Visible="false"></asp:Label>
                <div class="panel-body">
                    <div style="margin-left:5px;margin-top:15px;">
                        <asp:TextBox runat="server" id="cpf" CssClass="form-control" placeholder="CPF" Width="587px"/>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Preencha o campo CPF" ControlToValidate="cpf">*</asp:RequiredFieldValidator>
                    </div>
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="nome" CssClass="form-control" placeholder="Nome" Width="587px"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o campo Nome" ControlToValidate="nome">*</asp:RequiredFieldValidator>
                    </div>                   

                    <div style="margin-left:5px;margin-top:15px;">
                        <asp:TextBox runat="server" id="email" CssClass="form-control" placeholder="E-mail" Width="587px"/>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o campo E-mail" ControlToValidate="email">*</asp:RequiredFieldValidator>
                    </div>
                     <div style="margin-left:5px;margin-top:15px;">
                        <asp:TextBox runat="server" id="telefone" CssClass="form-control" placeholder="Telefone" Width="587px"/>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Preencha o campo Telefone" ControlToValidate="telefone">*</asp:RequiredFieldValidator>
                    </div>                      

                    <div style="margin-left:5px;margin-top:15px;">
                        <asp:TextBox runat="server" id="endereco" CssClass="form-control" placeholder="Endereço" Width="587px"/>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencha o campo Endereco" ControlToValidate="endereco">*</asp:RequiredFieldValidator>
                    </div>       
                    
                     <div class="btn-group-sm" style="margin-top:15px; margin-left:5px;">
                        <asp:Button runat="server" ID="cadastrar" CssClass="btn btn-success" Text="Cadastrar" OnClick="Cadastrar"/>
                        <asp:Button runat="server" ID="limpar" CssClass="btn btn-danger" Text="Limpar" OnClick="Limpar" ValidationGroup="false"/>
                    </div>      
                          
                                        
                   <div style="margin-top:20px;">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        <asp:Label ID="lblMensagem" runat="server" Text="" Visible="false"/>
                    </div>

                    

                </div>
            </div>
        </div>
</asp:Content>
