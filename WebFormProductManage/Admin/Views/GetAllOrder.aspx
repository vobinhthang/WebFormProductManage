<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="GetAllOrder.aspx.cs" Inherits="WebFormProductManage.Admin.Views.GetAllOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="active" runat="server">
    <style>
        #order{
            color:#fd7e14;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
     <div  class="container-fluid px-4">
        <h1 class="m-4 text-center">Danh sách hóa đơn</h1>
        <ol class="breadcrumb mb-4 p-3">
            <li class="breadcrumb-item "><a class="text-decoration-none" href="/admin/views/">Trang chủ</a></li>
            <li class="breadcrumb-item active">Quản lý hóa đơn</li>
        </ol>
        <asp:Button ID="btnCreate" OnClick="btnCreate_Click"  runat="server" CssClass="mr-4 mb-3 btn btn-success" Text="Thêm mới hóa đơn" /> 
        
        <asp:GridView runat="server"  CssClass="table" GridLines="None" ID="gvOrder"  EnableViewState="False" AutoGenerateColumns="False" DataKeyNames="ID"
                      OnRowDeleting="gvOrder_RowDeleting" OnRowDataBound="gvOrder_RowDataBound" OnRowEditing="gvOrder_RowEditing">
            <Columns >   
                <asp:TemplateField  HeaderText="ID" >
                    
                    <ItemTemplate >  
                    <asp:Label runat="server" ID="lbID" Text='<%#:Eval("ID")%>' Visible="false"></asp:Label>
                      <%#Eval("ID")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Tên khách hàng" >
                    <ItemTemplate>  
                         <%#Eval("FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Số điện thoại">
                    <ItemTemplate>  
                          <%#Eval("PhoneNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Địa chỉ giao">
                    <ItemTemplate>  
                          <%#Eval("Address")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Tổng tiền">
                    <ItemTemplate>  
                          <%#Eval("TotalMoney")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Ngày tạo">
                    <ItemTemplate>  
                          <%#Eval("OrderDate")%>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  >
                    <ItemTemplate>  
                          <a href="/admin/views/getallorderdetail?id=<%#Eval("ID") %>" class="btn btn-info" style="color:white">Chi tiết</a>
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
