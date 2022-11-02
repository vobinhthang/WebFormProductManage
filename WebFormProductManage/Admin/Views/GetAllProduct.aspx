<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="GetAllProduct.aspx.cs" Inherits="WebFormProductManage.Admin.Views.GetAllProduct" %>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="active">
    <style>
        #product{
            color:#fd7e14;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
     <div  class="container-fluid px-4">
        <h1 class="m-4 text-center">Danh sách sản phẩm</h1>
        <ol class="breadcrumb mb-4 p-3">
            <li class="breadcrumb-item "><a class="text-decoration-none" href="/admin/views/">Trang chủ</a></li>
            <li class="breadcrumb-item active">Quản lý sản phẩm</li>
        </ol>
        <asp:Button ID="btnCreate" OnClick="btnCreate_Click" runat="server" CssClass="mr-4 mb-3 btn btn-success" Text="Thêm mới sản phẩm" /> 
   
        <div>
            <asp:DropDownList SelectMethod="ItemsInt" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" CssClass="form-select float-lg-start mb-3"  AutoPostBack="true"  Width="70px" runat="server" ID="ddlPageSize"></asp:DropDownList>
            <p class="float-lg-start pt-2 mx-2">Thông tin trên mỗi trang</p>
            <asp:Button OnClick="btSearch_Click" runat="server" ID="btSearch" CssClass="btn btn-secondary float-end" Text="Tìm"/>
            <asp:TextBox OnTextChanged="tbSearch_TextChanged" Width="200px" CssClass="form-control form-control float-end"  AutoPostBack="true"  placeholder="Tìm kiếm"  runat="server" ID="tbSearch"></asp:TextBox>
        </div>
        
        <asp:GridView runat="server"  CssClass="table" GridLines="None" ID="gvProduct"  EnableViewState="False" AutoGenerateColumns="False" DataKeyNames="ID"
                   OnRowDeleting="gvProduct_RowDeleting" OnRowDataBound="gvProduct_RowDataBound" OnRowEditing="gvProduct_RowEditing"
                    PageSize="5" AllowPaging="True" OnPageIndexChanging="gvProduct_PageIndexChanging">
            <Columns >   
                <asp:TemplateField  HeaderText="ID" >
                    
                    <ItemTemplate >  
                    <asp:Label runat="server" ID="lbID" Text='<%#:Eval("ID")%>' Visible="false"></asp:Label>
                      <%#Eval("ID")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Ảnh sản phẩm"  HeaderStyle-Width="250px">
                    <ItemTemplate>  
                            <a class="text-decoration-none" href="/admin/views/updateimg?id=<%#Eval("ID") %>">
                                <img src="<%# ResolveUrl(Convert.ToString(Eval("Thumbnail"))) %>" style="width:20%"/>
                            </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Tên sản phẩm" >
                    <ItemTemplate>  
                          <a class="text-decoration-none" href="/admin/views/createupdateproduct?id=<%#Eval("ID") %>"> <%#Eval("Name") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Nhà sản xuất">
                    <ItemTemplate>  
                          <%#Eval("ProducerName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Giá">
                    <ItemTemplate>  
                          <%#Eval("Price")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nổi bật">
                    <ItemTemplate>  
                          <%#Eval("Hot")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="true" DeleteText="Xóa"  ButtonType="Button" ControlStyle-CssClass="btn btn-danger"  />
                <asp:CommandField ShowEditButton="true" EditText="Sửa"  ButtonType="Button" ControlStyle-CssClass="btn btn-warning"  />
            
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4"/>
            
            <HeaderStyle CssClass=" thead-dark"/>
            <RowStyle CssClass="" />
      </asp:GridView>
    </div>
   </form>
</asp:Content>
