<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchUserControl1.ascx.cs" Inherits="WebFormProductManage.UC.SearchUserControl1" %>

<div class="header__input">
                    <div class="header__input--search">
                        <asp:TextBox OnTextChanged="tbSearch_TextChanged" CssClass="input__search"  AutoPostBack="true"  placeholder="Tìm kiếm tại đây"  runat="server" ID="tbSearch"></asp:TextBox>
                        <asp:Button OnClick="btSearch_Click"  runat="server" ID="btSearch" CssClass="btn__search" Text="." ForeColor="White" /><i style="position:absolute;left:962px;top:60px;font-size:20px" class="fa-solid fa-magnifying-glass icon__search"></i>
                    </div>   
                </div>