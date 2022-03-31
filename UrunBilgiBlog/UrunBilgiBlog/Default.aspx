<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UrunBilgiBlog.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ListView ID="lv_urunler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
           <%-- <div class=" silder">
                <img src="Images/reklam.png" />
            </div>--%>
            
            <div class="urun">       

                <div class=" Urunisim" >
                    <h2><%# Eval("Isim") %></h2> 
                </div>                            
                <div class="image">
                    <img src='UrunResimleri/<%# Eval("KapakResim") %>' />
                </div>
                <div class="subcontent">
                    Kategori: <%# Eval("Kategori") %> 
                </div>
                <div class="summary">
                    <%# Eval("Marka") %> || Fiyat: <%# Eval("Fiyat") %>
                </div>
                <div class=" urunbilgi">
                    <a href="UrunBilgi.aspx?mid= <%# Eval("ID") %>">Ürün   Bilgi</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
