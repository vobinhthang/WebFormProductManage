<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="GetAllRole.aspx.cs" Inherits="WebFormProductManage.Admin.Views.GetAllRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="active" runat="server">
       <style>
        #role{
            color:#fd7e14;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
     <div  class="container-fluid px-4">
        <h1 class="m-4 text-center">Danh sách chức vụ người dùng</h1>
        <ol class="breadcrumb mb-4 p-3">
            <li class="breadcrumb-item "><a class="text-decoration-none" href="/admin/views/">Trang chủ</a></li>
            <li class="breadcrumb-item active">Quản lý chức vụ người dùng</li>
        </ol>
        <asp:Button ID="btnCreate" OnClick="btnCreate_Click"  runat="server" CssClass="mr-4 mb-3 btn btn-success" Text="Thêm mới chức vụ" /> 
        
        <asp:GridView runat="server"  CssClass="table" GridLines="None" ID="gvRole"  EnableViewState="False" AutoGenerateColumns="False" DataKeyNames="ID"
                      OnRowDeleting="gvRole_RowDeleting" OnRowDataBound="gvRole_RowDataBound" OnRowEditing="gvRole_RowEditing">
            <Columns >   
                <asp:TemplateField  HeaderText="ID" >
                    
                    <ItemTemplate >  
                    <asp:Label runat="server" ID="lbID" Text='<%#:Eval("ID")%>' Visible="false"></asp:Label>
                      <%#Eval("ID")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Tên chức vụ" >
                    <ItemTemplate>  
                          <a class="text-decoration-none" href="/admin/views/createupdaterole?id=<%#Eval("ID") %>"> <%#Eval("Name") %></a>
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
