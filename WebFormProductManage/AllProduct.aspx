<%@ Page Title="" Language="C#" MasterPageFile="~/AllProduct.Master" AutoEventWireup="true" CodeBehind="AllProduct.aspx.cs" Inherits="WebFormProductManage.AllProduct1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
        <div class="allproduct" style=" display: flex;
    flex-wrap: wrap;height: auto;">
            <div class="sort">
                    <div class="box__search">
                        <asp:TextBox OnTextChanged="tbSearch_TextChanged"  ID="tbSearch" runat="server" AutoPostBack="true" class="search__allproduct" placeholder="Nhập để tìm kiếm..." ></asp:TextBox>
                        <asp:Button OnClick="btSearch_Click" ID="btSearch"  runat="server" class="btn__searchProduct" Text="Tìm"/>
                    </div>
                    
                </div>

            <asp:Repeater runat="server" ID="rptAllProduct">
        <ItemTemplate>
            <div class="product__list product__list--04" style="width: 25%;">
                    <div class="product__item">
                        <div class="product__img">
                            <a href="/productinfor?productid=<%#Eval("ID") %>" class="product__link pd__img">
                                 <img src="<%# ResolveUrl(Convert.ToString(Eval("Thumbnail"))) %>" style="width:88%"/>
                            </a>
                        </div>
    
                        <div class="product__info">
                            <a href="" title="" class="product__link product__title">
                               <%#Eval("Name") %>
                            </a>
    
                            <div class="price">
                                <span class="price__new">
                                    <%#Eval("Price")%> đ
                                </span>
                            </div>
                           
                        </div>
                    </div>

                </div>
        </ItemTemplate>
    </asp:Repeater>
     
        </div>
    
</asp:Content>
