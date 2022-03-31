<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="UrunListele.aspx.cs" Inherits="UrunBilgiBlog.Yonetici.UrunListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
       <div class="formtitle">
           <h3>Urunler</h3>
       </div>
       <div class="formContent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_Urunler" runat="server"  OnItemCommand="lv_Urunler_ItemCommand">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>Resim</th>
                           <th>ID</th>
                           <th>Isim</th>
                           <th>Marka</th>
                           <th>Fiyat</th>
                           <th>Kategori</th>
                           <th>Yazar</th>
                           <th>Ekleme Tarihi</th>
                           <th>Görüntülenme Sayısı</th>
                           <th>Durum</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                      <td><img src='../UrunResimleri/<%# Eval("KapakResim") %>' width="100" /></td>
                       <td><%# Eval("ID") %></td>
                       <td><%# Eval("Isim") %></td>
                       <td><%# Eval("Marka") %></td>
                       <td><%# Eval("Fiyat") %></td>
                       <td><%# Eval("Kategori") %></td>
                       <td><%# Eval("Yazar") %></td>
                       <td><%# Eval("EklemeTarihi") %></td>
                       <td><%# Eval("GoruntulenmeSayısı") %></td>
                       <td><%# Eval("Durum") %></td>
                       <td>
                           <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton status">Durum Değiştir</asp:LinkButton>
                           <a href='Urunguncelle.aspx?urn=<%# Eval("ID") %>' class="tablebutton update">Güncelle</a>
                           <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                       </td>
                   </tr>
               </ItemTemplate>
           </asp:ListView>
       </div>
   </div>
</asp:Content>
