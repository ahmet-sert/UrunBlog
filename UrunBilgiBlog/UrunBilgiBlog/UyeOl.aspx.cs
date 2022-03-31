using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
namespace UrunBilgiBlog
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_üyeol_Click(object sender, EventArgs e)
        {
            Uye uy = new Uye();
            uy.Isim = tb_isim.Text;
            uy.Soyad = tb_soyad.Text;
            uy.KullaniciAdı = tb_kullaniciadi.Text;
            uy.Email = tb_mail.Text;
            uy.Sifre = tb_sifre.Text;
            uy.UyelikTarihi = DateTime.Now;
            uy.Durum = cb_onay.Checked;
            if (dm.UyeOL(uy))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;

            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Hata Meydana Geldi";

            }
        }
    }
}