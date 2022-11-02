<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormProductManage.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="rptProductHot">
        <ItemTemplate>
            <div class="product__list product__list--06">
                <div class="product__item">
                    <div class="product__img">
                        <a href="/productinfor?productid=<%#Eval("ID") %>" class="product__link pd__img">
                           <img src="<%# ResolveUrl(Convert.ToString(Eval("Thumbnail"))) %>" style="width:88%"/>
                        </a>
                    </div>

                    <div class="product__info">
                        <a href="/productinfor?productid=<%#Eval("ID") %>" class="product__link product__title">
                             <%#Eval("Name") %>
                        </a>

                        <div class="price">
                            <span class="price__new">
                                <%#Eval("Price")%> đ
                            </span>

                        </div>
                       
                    </div>
                </div>
                <div style="position: absolute;
                            top: 2px;
                            background-color: red;
                            width: 50px;
                            height: 50px;
                            border-radius: 50%;
                            color: #fff;
                            font-weight: bold;
                            text-align: center;
                            line-height: 50px;
                            left: 10px">
                    HOT
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
