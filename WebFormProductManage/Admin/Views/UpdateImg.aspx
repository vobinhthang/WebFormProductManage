<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateImg.aspx.cs" Inherits="WebFormProductManage.Admin.Views.UpdateImg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="active" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" >
        <div class="my-2">
            <asp:Label runat="server" Font-Size="38px" Font-Bold="true"  CssClass=" d-flex justify-content-center" ID="lbTitle" Text="Cập nhập ảnh sản phẩm"></asp:Label>
        </div> 
        <ol class="breadcrumb mb-3 p-3">
            <li class="breadcrumb-item"><a class="text-decoration-none" href="/admin/views/getalluser">Quay lại</a></li>
            <li class="breadcrumb-item active">Cập nhập ảnh sản phẩm</li>
        </ol>
    </div>
    <div  class="container-fluid px-5" style="width:700px">
       
        <form runat="server">
            <div class="form-group">
                <label class="fw-bold">ID</label>
                <asp:TextBox runat="server" ID="tbID" Enabled="false" CssClass="form-control "></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbimage" runat="server" class="fw-bold">Ảnh sản phẩm</asp:Label>
                 <asp:FileUpload CssClass="form-control" ID="fileImage" runat="server"  />
                
            </div>
            
            
            <asp:Button ID="btnSave" OnClick="btnSave_Click"  runat="server" CssClass="btn btn-success px-4 py-2 my-2" Text="Lưu"/>
        </form>
    </div>
</asp:Content>
