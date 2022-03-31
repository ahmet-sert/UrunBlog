<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici/Yonetici.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="UrunBilgiBlog.Yonetici.UrunEkle"  ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="formContainer">
        <div class="formtitle">
            <h3>Ürun Ekle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Ürün Ekleme İşlemi Başarıyla Gerçekleştirildi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width:650px; float:left">
                <div class="row">
                    <label>Isim</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
                </div>
                  
                <div class="row">
                    <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label>marka</label><br />
                    <asp:TextBox ID="tb_marka" runat="server" CssClass="formInput"></asp:TextBox>
                </div>
             

                <div class="row">
                    <label>Kapak Resim</label><br /><br />
                    Seçiniz : <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
                <div class="row">
                    <label>Urun Yayınla</label> 
                    <asp:CheckBox ID="cb_yayinla" runat="server"/>
                </div>
            </div>
            <div style="width:650px; float:left">
                <div class="row">
                    <label>Fiyat</label><br />
                    <asp:TextBox ID="tb_fiyat" runat="server" CssClass="formInput" ></asp:TextBox>
                </div>
                <div class="row">
                    <label>İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="clear:both">
                <asp:LinkButton ID="lbtn_ekle" runat="server"  OnClick="lbtn_ekle_Click" CssClass="formButton">Ürün Ekle</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
