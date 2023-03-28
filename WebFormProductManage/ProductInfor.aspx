<%@ Page Title="" Language="C#" MasterPageFile="~/ProductInfor.Master" AutoEventWireup="true" CodeBehind="ProductInfor.aspx.cs" Inherits="WebFormProductManage.ProductInfor1" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="buy__message">
            <div class="mes__close">
                <%--<i class="fa-solid fa-xmark"></i>--%>
                <asp:Button CssClass="mes__close" runat="server" style="border:none" Text="X" ID="btnClose" OnClick="btnClose_Click"/>
            </div>
            <div class="mes__success">
                <i class="fa-solid fa-check"></i> Thêm sản phẩm vào giỏ hàng thành công!
            </div>

            <div class="btn__navi-cart">
                
                 <%--<i class="fa-solid fa-arrow-right"></i>--%>
                <asp:Button CssClass="btn__navi-cart " runat="server" ID="btnNavi" Text="Đến giỏ hàng" OnClick="btnNavi_Click" style="text-decoration: none; font-size: 16px;border:none; font-weight: bold; color: white ; line-height: 40px; display: block; text-align: center;"/>

            </div>

        </div>

        <div class="directional container container-fluid mt-5">
            
            <a class="text-decoration-none" href="/">Trang chủ</a> / 
            <asp:Label ID="lbabc" runat="server" CssClass="breadcrumb-item active"> Quản lý sản phẩm</asp:Label>
           
        </div>

         <div class="block__product--info">
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

            </div>
       </ItemTemplate>
   </asp:Repeater>
              
             </div> 
        <div class="btn__buyNow mb-4" style="margin-left:530px" runat="server">
                    
                    <p class="amount" style="font-size:16px">Số lượng: <asp:TextBox Width="70px" runat="server" ID="tbAmount" TextMode="Number" min="1" MaxLength="50" >1</asp:TextBox></p>  
                    <button class="btn btn-info mt-4 " style="height:50px;width:170px;font-size:16px;font-weight:bold" >Mua ngay</button>
                    <%--<asp:Button  OnClick="btnAddCart_Click" ID="btnAddCart"  runat="server" CssClass="btn__message btn btn-danger mt-4 mx-5"  style="height:50px;width:170px;font-size:16px;font-weight:bold" Text="Thêm vào giỏ hàng"/>--%>
                    <button type="button" class="btn__message btn btn-danger mt-4 mx-5"  style="height:50px;width:170px;font-size:16px;font-weight:bold" >Thêm vào giỏ hàng</button>
        </div>
        <div class="related__products container container-fluid mt-5 text-center ">SẢN PHẨM LIÊN QUAN</div>
</asp:Content>
 