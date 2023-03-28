<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Views/Admin.Master" AutoEventWireup="true" CodeBehind="GetAllOrderDetail.aspx.cs" Inherits="WebFormProductManage.Admin.Views.GetAllOrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="active" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <div class="container container-fluid">
            <h1 class="m-4 text-center">Chi tiết hóa đơn: mã <asp:Label runat="server" ID="lbMa" Text="abc"></asp:Label></h1>
        <ol class="breadcrumb mb-4 p-3">
            <li class="breadcrumb-item "><a class="text-decoration-none" href="/admin/views/">Trang chủ</a></li>
            <li class="breadcrumb-item active">Chi tiết hóa đơn</li>
        </ol>
             <asp:Button ID="btnCreate" OnClick="btnCreate_Click"  runat="server" CssClass="mr-4 mb-3 btn btn-success" Text="Thêm mới" /> 
        
         <asp:GridView runat="server"  CssClass="table" GridLines="None" ID="gvOrderDetail"  EnableViewState="False" AutoGenerateColumns="False" DataKeyNames="ID"
                OnRowDeleting="gvOrderDetail_RowDeleting" OnRowDataBound="gvOrderDetail_RowDataBound" OnRowEditing="gvOrderDetail_RowEditing"    
             >
            <Columns >   
                <asp:TemplateField  HeaderText="STT" >
                    
                    <ItemTemplate >  
                    <asp:Label runat="server" ID="lbID" Text='<%#:Eval("ID")%>' Visible="false"></asp:Label>
                       <%#Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Ảnh"  HeaderStyle-Width="100px" >
                    <ItemTemplate>  
                        <img src="<%# ResolveUrl(Convert.ToString(Eval("Thumbnail"))) %>" style="width:40%"/>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField  HeaderText="Tên sản phẩm" >
                    <ItemTemplate>  
                         <%#Eval("Name") %>
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
                <asp:TemplateField  HeaderText="Địa chỉ giao hàng">
                    <ItemTemplate>  
                          <%#Eval("Address")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Số lượng ">
                    <ItemTemplate>  
                          <%#Eval("Amount")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Giá">
                    <ItemTemplate>  
                          <%#Eval("Price")%>
                        
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
