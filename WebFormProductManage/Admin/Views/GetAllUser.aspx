<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="GetAllUser.aspx.cs" Inherits="WebFormProductManage.Admin.Views.GetAllUser" %>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="active">
    <style>
        #user{
            color:#fd7e14;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--get all user--%>
   <form runat="server">
     <div  class="container-fluid px-4">
        <h1 class="m-4 text-center">Danh sách người dùng</h1>
        <ol class="breadcrumb mb-4 p-3">
            <li class="breadcrumb-item "><a class="text-decoration-none" href="/admin/views/">Trang chủ</a></li>
            <li class="breadcrumb-item active">Quản lý người dùng</li>
        </ol>
        <asp:Button ID="btnCreate" OnClick="btnCreate_Click"  runat="server" CssClass="mr-4 mb-3 btn btn-success" Text="Thêm mới người dùng" /> 
        
        <asp:GridView runat="server"  CssClass="table" GridLines="None" ID="gvUser"  EnableViewState="False" AutoGenerateColumns="False" DataKeyNames="ID"
                      OnRowDeleting="gvUser_RowDeleting" OnRowDataBound="gvUser_RowDataBound" OnRowEditing="gvUser_RowEditing">
            <Columns >   
                <asp:TemplateField  HeaderText="ID" >
                    
                    <ItemTemplate >  
                    <asp:Label runat="server" ID="lbID" Text='<%#:Eval("ID")%>' Visible="false"></asp:Label>
                      <%#Eval("ID")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Tài khoản" >
                    <ItemTemplate>  
                          <a class="text-decoration-none" href="/admin/views/createupdate?id=<%#Eval("ID") %>"> <%#Eval("Username") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Mật khẩu">
                    <ItemTemplate>  
                          <%#Eval("Password")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Họ và tên">
                    <ItemTemplate>  
                          <%#Eval("FullName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Vai trò">
                    <ItemTemplate>  
                          <%#Eval("RoleName")%>
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
