<%@ Page Title="" Language="C#" MasterPageFile="~/ProductInfor.Master" AutoEventWireup="true" CodeBehind="ProductInfor.aspx.cs" Inherits="WebFormProductManage.ProductInfor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:Repeater runat="server" ID="rptProdcutInfor">
       <ItemTemplate>
            <div class="img__productInfo">
                <img class="img" src="<%# ResolveUrl(Convert.ToString(Eval("Thumbnail"))) %>" alt="" style="width:370px;height:370px">
            </div>
            <div class="product__information container container-fluid">
                <div class="productInfo__name " style="font-weight:500;font-size:30px"> <%#Eval("Name") %></div>
                <p class="productInfo__price">Giá bán: <span style="color: #fd475a; font-weight: bold;"><%#Eval("Price") %>đ</span> </p>
                <p class="trademark mb-1">Thương hiệu: <span class="text-info" href="apple.com"><%#Eval("ProducerName")%></span></p>
                <p class="status mb-4">Tình trạng: Còn hàng</p>
                <p class="description mb-4"><span style="font-weight: bold;"> Mô tả: </span><br> <%#Eval("Description")%></p>
                <p class="product__color mb-4">Màu sắc: <%#Eval("Color")%></p>

                <div class="btn__buyNow mb-4">
                    <p class="amount">Số lượng: <input  type="number" min="1" value="1" max="10"> </p>
                    <button class="btn btn-info mt-3 " style="height:50px;width:170px;font-size:16px;font-weight:bold" >Mua ngay</button>
                    <button class="btn btn-danger mt-3 mx-5" style="height:50px;width:170px;font-size:16px;font-weight:bold" >Thêm vào giỏ hàng</button>
                </div>

            </div>
       </ItemTemplate>
   </asp:Repeater>
</asp:Content>
