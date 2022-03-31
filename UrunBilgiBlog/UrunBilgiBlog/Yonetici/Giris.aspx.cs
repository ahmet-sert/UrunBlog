﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
namespace UrunBilgiBlog.Yonetici
{
    public partial class Giris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                string mail = tb_mail.Text;
                string sifre = tb_sifre.Text;

                DataAccesLayer.Yonetici y = dm.YoneticiGiris(mail, sifre);
                if (y != null)
                {
                    Session["yonetici"] = y;//boxing işlemi yapar
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lbl_mesaj.Text = "Kullanıcı Bulunamadı";
                    pnl_hata.Visible = true;
                }
            }
            else
            {
                lbl_mesaj.Text = "Mail ve Şifre Boş Bırakılamaz";
                pnl_hata.Visible = true;
            }

        }
    }
}