<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VendedorView.aspx.cs" Inherits="SGI.VendedorView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <div class="col-md-6 col-md-offset-3" >
            <div class="panel panel-primary" style="margin-top:15px;">
                <div class="panel-heading">
                    Cadastrar Vendedor
                </div>
                    <asp:Label ID="lblSucesso" runat="server" Visible="false"/>
                <div class="panel-body">
                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="txtNome" CssClass="form-control" placeholder="Nome"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o campo Nome" ControlToValidate="txtnome">*</asp:RequiredFieldValidator>
                    </div>                    

                    <div style="margin-left:5px;margin-top:15px;">
                        <asp:TextBox runat="server" id="txtEmail" CssClass="form-control" placeholder="E-mail"/>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o campo E-mail" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Informe um E-mail válido" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </div>

                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="txtCpf" CssClass="form-control" placeholder="CPF"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Preencha o campo CPF" ControlToValidate="txtCpf">*</asp:RequiredFieldValidator>
                    </div>

                     <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="login" CssClass="form-control" placeholder="Login"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencha o campo Login" ControlToValidate="login">*</asp:RequiredFieldValidator>
                    </div>

                     <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="senha" CssClass="form-control" TextMode="Password" placeholder="Senha"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Preencha o campo Senha" ControlToValidate="senha">*</asp:RequiredFieldValidator>
                    </div>

                    <div style="margin-top:10px; margin-left:5px;" >
                        <asp:TextBox runat="server" id="confirmaSenha" CssClass="form-control" TextMode="Password" placeholder="Confirmar Senha"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Preencha o campo Confirmar Senha" ControlToValidate="confirmaSenha">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="comparacao" runat="server" ErrorMessage="As senhas devem ser iguais" ControlToValidate="senha" ControlToCompare="confirmaSenha">*</asp:CompareValidator>
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
