<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="UrunBilgiBlog.UyeOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/Uye.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class=" formTitle">
        <h4>Üye ol</h4>
    </div>
    <div class=" girisForm form">
        
          <asp:Panel ID="pnl_basarili" runat="server" CssClass=" basariliMesaj" Visible="false">
                <label>Üye olma işlemi başarı ile gerçekleşti</label>
            </asp:Panel>

        <asp:panel ID="pnl_basarisiz" runat="server" CssClass=" basarisizMesaj" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:panel>
        <div class="userdiv">

            
             <div class=" Userresim">
                  <img src="Images/user.png" />
            </div>
     
        <div class=" row">
         
            <asp:TextBox ID="tb_isim" runat="server" CssClass=" textbox" placeholder="Isim"></asp:TextBox>
        </div>
        <div class=" row">
          
            <asp:TextBox ID="tb_soyad" runat="server" CssClass=" textbox" placeholder="Soyisim"></asp:TextBox>
        </div>
         <div class=" row">
          
            <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass=" textbox" placeholder="Kullanıcı adı"></asp:TextBox>
        </div>
         <div class=" row">
          
            <asp:TextBox ID="tb_mail" runat="server" CssClass=" textbox" placeholder="Email"></asp:TextBox>
        </div>
            <div class=" row">
          
            <asp:TextBox ID="tb_sifre" runat="server" CssClass=" textbox" placeholder="Sifre"></asp:TextBox>
        </div>
      
              <div class="  row">
                    <label>Onaylıyorum</label> 
                    <asp:CheckBox ID="cb_onay" runat="server"/>
                </div>


        <div class="row" style="text-align:center">
            <asp:LinkButton ID="lbtn_üyeol" runat="server" Text="Üye Ol" OnClick="lbtn_üyeol_Click" CssClass=" UyeButton"></asp:LinkButton>

       </div>
           </div>
       
    </div>
    
</asp:Content>
