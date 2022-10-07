<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormProductManage.Admin.Views.Login" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đăng nhập</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css">
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="/Assets/admin/css/login.css">
</head>
<body> 
        <div class="container">
            <div class="row justify-content-center">
                
                <div class="col-lg-5">
                    <div class="card shadow-lg border-0 rounded-lg mt-5">
                        <div class="card-header"><h3 style="color: rgb(23, 12, 69);" class="text-center font-weight-light my-4 font-weight-bold">ĐĂNG NHẬP</h3></div>
                        <div class="card-body">
                            <form runat="server">
                                <div class="form-input mb-3">
                                    <asp:TextBox runat="server" CssClass="input" ID="tbTaiKhoan" placeholder="Tài khoản"></asp:TextBox>
                                   <asp:Image runat="server" ImageUrl="~/Assets/img/logo_username.png" CssClass="logo_username"/>
                                </div>
                                <div class="form-input">
                                    <asp:TextBox TextMode="Password" runat="server" CssClass="input" ID="tbMatKhau" placeholder="Mật khẩu"></asp:TextBox>
                                     <asp:Image runat="server" ImageUrl="~/Assets/img/logo_pass.png" CssClass="logo_pass"/>
                                </div>
                                <div class="form-input mt-4">                                   
                                    <asp:Button runat="server" Text="Đăng nhập" CssClass="button"/>
                                </div>
                            </form>
                        </div>
                        <div class="card-footer text-center py-3">
                            <div ><a href="#">Chưa có tài khoản? Đăng ký!</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</body>
</html>
