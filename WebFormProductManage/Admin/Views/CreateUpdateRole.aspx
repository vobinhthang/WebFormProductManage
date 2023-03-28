<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="CreateUpdateRole.aspx.cs" Inherits="WebFormProductManage.Admin.Views.CreateUpdateRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="active" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" >
        <div class="my-2">
            <asp:Label runat="server" Font-Size="38px" Font-Bold="true"  CssClass=" d-flex justify-content-center" ID="lbTitle" Text="Thêm mới vai trò"></asp:Label>
        </div> 
        <ol class="breadcrumb mb-3 p-3">
            <li class="breadcrumb-item"><a class="text-decoration-none" href="/admin/views/getallorder">Quay lại</a></li>
            <li class="breadcrumb-item active">Tạo mới vai trò</li>
        </ol>
    </div>
    <div  class="container-fluid px-5" style="width:700px">
       
        <form runat="server">
            
            <div class="form-group">
                <label class="fw-bold" >Tên vai trò</label>
                 <asp:TextBox runat="server" ID="tbName" CssClass="form-control "></asp:TextBox>
            </div> 
           
           
            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-success px-4 py-2 mt-3" Text="Thêm"/>
        </form>
    </div>
</asp:Content>
