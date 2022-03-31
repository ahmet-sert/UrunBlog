<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="UrunBilgiBlog.Yonetici.UyeListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
       <div class="formtitle">
           <h3>Bilgilerim</h3>
       </div>
       <div class="formContent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_Uyeler" runat="server"    OnItemCommand="lv_Uyeler_ItemCommand">
               <LayoutTemplate>
                   <table class="listTable" cellspacing="0" cellpadding="0">
                       <tr>
                           <th>ID</th>                   
                           <th>Isim</th>
                           <th>Soyad</th>
                           <th>Kullanıcı Adı</th>
                           <th>Email</th>
                           <th>Şifre</th>
                           <th>Durum</th>
                           <th>Seçenekler</th>
                           
                         
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <td><%# Eval("ID") %></td>
                       <td><%# Eval("Isim") %></td>
                       <td><%# Eval("Soyad") %></td>
                       <td><%# Eval("KullaniciAdı") %></td>
                       <td><%# Eval("Email") %></td>
                       <td><%# Eval("Sifre") %></td>
                       <td><%# Eval("Durum") %></td>
                      
                       <td>
                           <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton status">Durum Değiştir</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                        
                       </td>
                   </tr>
               </ItemTemplate>
           </asp:ListView>
       </div>
   </div>
</asp:Content>
