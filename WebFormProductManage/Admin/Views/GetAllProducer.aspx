<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="GetAllProducer.aspx.cs" Inherits="WebFormProductManage.Admin.Views.GetAllProducer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="active" runat="server">
    <style>
        #producer{
            color:#fd7e14;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
     <div  class="container-fluid px-4">
        <h1 class="m-4 text-center">Danh sách nhà sản xuất</h1>
        <ol class="breadcrumb mb-4 p-3">
            <li class="breadcrumb-item "><a class="text-decoration-none" href="/admin/views/">Trang chủ</a></li>
            <li class="breadcrumb-item active">Quản lý nhà sản xuất</li>
        </ol>
        <asp:Button ID="btnCreate" OnClick="btnCreate_Click"  runat="server" CssClass="mr-4 mb-3 btn btn-success" Text="Thêm mới nhà sản xuất" /> 
        
        <asp:GridView runat="server"  CssClass="table" GridLines="None" ID="gvProducer"  EnableViewState="False" AutoGenerateColumns="False" DataKeyNames="ID"
                     OnRowDeleting="gvProducer_RowDeleting" OnRowDataBound="gvProducer_RowDataBound" OnRowEditing="gvProducer_RowEditing" >
            <Columns >   
                <asp:TemplateField  HeaderText="ID" >
                    
                    <ItemTemplate >  
                    <asp:Label runat="server" ID="lbID" Text='<%#:Eval("ID")%>' Visible="false"></asp:Label>
                      <%#Eval("ID")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Tên nhà sản xuất" >
                    <ItemTemplate>  
                          <a class="text-decoration-none" href="/admin/views/createupdateproducer?id=<%#Eval("ID") %>"> <%#Eval("Fullname") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:CommandField ShowDeleteButton="true" DeleteText="Xóa"  ButtonType="Button" ControlStyle-CssClass="btn btn-danger"  />
                <asp:CommandField ShowEditButton="true" EditText="Sửa"  ButtonType="Button" ControlStyle-CssClass="btn btn-warning"  />
            
            </Columns>
      
            <HeaderStyle CssClass=" thead-dark"/>
            
      </asp:GridView>
    </div>
   </form>
</asp:Content>
