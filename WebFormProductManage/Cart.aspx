<%@ Page Title="" Language="C#" MasterPageFile="~/ProductInfor.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebFormProductManage.Cart"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server">
                                
                            <ContentTemplate>
    <div class="cart__product">
            <div class="directional container container-fluid mt-5" >
            
           
            <p class="text-dark" style="font-weight:bold;font-size:18px"> GIỎ HÀNG</p>
            </div>
        </div>
            <div class="cart__item container container-fluid mt-5 mb-5">
                <div class="cart__left">
                    <div class="cart__thead">
                        <div style="width: 17%; height: 100%; text-align: center; line-height: 45px; font-weight: bold; font-size: 14px;">Ảnh sản phẩm</div>
                        <div style="width: 30%; height: 100%; text-align: center; line-height: 45px; font-weight: bold; font-size: 14px;">Tên sản phẩm</div>
                        <div style="width: 15%; height: 100%; text-align: center; line-height: 45px; font-weight: bold; font-size: 14px;">Giá bán lẻ</div>
                        <div style="width: 14%; height: 100%; text-align: center; line-height: 45px; font-weight: bold; font-size: 14px;">Số lượng</div>
                        <div style="width: 15%; height: 100%; text-align: center; line-height: 45px; font-weight: bold; font-size: 14px;">Tạm tính</div>
                        <div style="width: 9%; height: 100%; text-align: center; line-height: 45px; font-weight: bold; font-size: 14px;">Xóa</div>
                    </div>

                    <div class="cart__tbody">
                       

                        <asp:Repeater runat="server" ID="rptCartItems" OnItemCommand="rptCartItems_ItemCommand" OnItemCreated="rptCartItems_ItemCreated" OnItemDataBound="rptCartItems_ItemDataBound" >
                            <ItemTemplate>
                                <div class="cart__product--buy">
                                    <div style="width: 17%; height: 100%; text-align: center; padding-top: 10px;">
                                        <asp:Label ID="lbID" runat="server" Visible="false" Text='<%# Container.ItemIndex%>'></asp:Label>
                                        <a href="/productinfor?productid=<%#Eval("ID") %>">
                                            <img src="<%# ResolveUrl(Convert.ToString(Eval("Thumbnail"))) %>" style="width:75px;height:75px"/>
                                        </a>
                                        
                                    </div>
                                    <div style="width: 30%; height: 100%; text-align: center; margin-top:32px; font-size: 14px;">
                                        <a class="text-decoration-none" href="/productinfor?productid=<%#Eval("ID") %>">
                                            <%# Eval("Name") %>
                                        </a>
                                        
                                    </div>
                                    <div style="width: 15%; height: 100%; text-align: center;  margin-top:37px">
                                        <asp:Label runat="server" ID="lbPrice"  style="color: #fd475a; font-size: 14px; font-weight: bold;" Text='<%#Eval("Price")%>'></asp:Label><u style="color: #fd475a; font-size: 14px; font-weight: bold;">đ</u>
                                    </div>
                                    <div style="width: 14%; height: 100%;  margin-top:37px;display:flex;justify-content:center"> 
                                        
                                        <asp:TextBox CssClass="form-control" AutoPostBack="true" OnTextChanged="tbAmount_TextChanged" ID="tbAmount" Height="30px" min="1" max="50" runat="server" TextMode="Number" Text='<%#Eval("Amount") %>' style="width: 50px; height: 30px;font-size:13px ;"></asp:TextBox>
                                        
                                    </div>
                                    <div style="width: 15%; height: 100%; text-align: center; margin-top:37px">
                                        <asp:Label runat="server" ID="lbTotalPrice" style="color: #fd475a; font-size: 14px; font-weight: bold;" Text='<%#Eval("TotalPrice") %> ' ></asp:Label><u style="color: #fd475a; font-size: 14px; font-weight: bold;">đ</u>
                                    </div>
                                    <div   style="width: 9%; height: 100%; text-align: center; margin-top:32px"> 
                                        <asp:ImageButton  ID="btnDelete" CommandArgument="<%# Container.ItemIndex %>" CommandName="Delete"  CssClass="icondelete" runat="server" ImageUrl="~/Assets/client/img/352303_delete_icon.png"/>
                                         <%--<button class="p-3" style="border: none; cursor: pointer; "><i class="fa-solid fa-trash"></i></button> --%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>   
                              
                         

                    </div>
                   
                    
                </div>

                <div class="cart__right">
                    <div class="price__buy alert alert-warning">
                        <h1  style="font-size:26px">TỔNG TIỀN: <asp:Label runat="server" ID="lbAllPrice"></asp:Label>0<u>đ</u></h1>
                    </div>

                    <div class="btn__buyContact" style="width: 100%; height: 50px; margin: 20px 0;">
                        <a href="" class="btn btn-danger " style="font-size:20px;padding-top:8px;width: 100%; height: 100%; color: #fff; text-align: center; display: block;"><i class="fa-solid fa-check"></i> Tiến hành đặt hàng</a>
                    </div>

                    <div class="btn__previous" style="width: 100%; height: 50px;  ">
                        
                        <a href="/" class="btn btn-success " style="font-size:20px;padding-top:8px;width: 100%; height: 100%; color: #fff;text-align: center; display: block;"><i class="fa-solid fa-arrow-left"></i> Tiếp tục mua hàng</a>
                    </div>
                </div>
            </div>
   </ContentTemplate>
                            
                        </asp:UpdatePanel>
</asp:Content>
