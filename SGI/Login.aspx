<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SGI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/bootstrap.css" rel="stylesheet" media="screen" type="text/css" />

    <script type="text/javascript" src="Content/js/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="Content/js/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">

            <div class="col-md-6 col-md-offset-3" id="loginbox" style="margin-top:45px;" >    
                                
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Área de Autenticação</div>
                    </div>     

                    <div class="panel-body" style="padding-top:30px" >    
                                       
                        <div class="form-horizontal" id="loginform" runat="server">    
                                             
                            
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Login vazio!" ControlToValidate="usuario">*</asp:RequiredFieldValidator>  
                            <div class="input-group" style="margin-bottom: 25px" >
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-user"></i>
                                </span>
                                <asp:TextBox CssClass="form-control" id="usuario" placeholder="Usuário"  runat="server"/>                                        
                            </div>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Senha vazia!" ControlToValidate="senha">*</asp:RequiredFieldValidator>
                            <div class="input-group" style="margin-bottom: 25px" >
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-lock"></i>
                                </span>
                                <asp:TextBox CssClass="form-control" id="senha" TextMode="Password"  placeholder="Senha" runat="server" />
                            </div>
                            
        
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox id="remember" type="checkbox" name="remember" value="" runat="server"  /> Lembrar Minha Senha
                                </label>
                            </div>

                            <div class="form-group" style="margin-top:10px" >
                                <!-- Button -->
                                <div class="col-sm-12 controls">
                                    <asp:Button runat="server" ID="acessar" CssClass="btn btn-success"  OnClick="AcessarLogin" Text="Acessar"/>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                    <asp:Label runat="server" class="alert alert-danger" ID="alerta" Visible="false" Text="" style="margin-left:100px;"></asp:Label>
                                </div>
                            </div>

                        </div>   
                          
                    </div>    
                                     
                </div>  

            </div>

        </div>
    </div>
    </form>
</body>
</html>
