using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
using System.IO;
namespace UrunBilgiBlog.Yonetici
{
    public partial class UrunGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {


                if (!IsPostBack)
                {
                    ddl_kategoriler.DataSource = dm.KategoriListele();
                    ddl_kategoriler.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["urn"]);
                    Urun u = dm.UrunGetir(id);
                    tb_isim.Text = u.Isim;
                    tb_icerik.Text = u.Icerik;
                    tb_fiyat.Text = u.Fiyat;
                    tb_marka.Text = u.Marka;
                    ddl_kategoriler.SelectedValue = Convert.ToString(u.KategoriID);
                    img_resim.ImageUrl = "../UrunResimleri/" + u.KapakResim;
                    cb_yayinla.Checked = u.Durum;
                }

            }
            else
            {
                Response.Redirect("UrunListele.aspx");
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            bool uygunMu = true;
            int id = Convert.ToInt32(Request.QueryString["urn"]);
            Urun u = dm.UrunGetir(id);
            u.Isim = tb_isim.Text;
            u.Icerik = tb_icerik.Text;
            u.Fiyat = tb_fiyat.Text;
            u.Marka = tb_marka.Text;
            u.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            u.Durum = cb_yayinla.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                string dosyaadi = Guid.NewGuid() + uzanti;
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    fu_resim.SaveAs(Server.MapPath("~/UrunResimleri/" + dosyaadi));
                    u.KapakResim = dosyaadi;
                }
                else
                {
                    uygunMu = false;
                }
            }
            if (uygunMu)
            {
                if (dm.UrunGuncelle(u))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı png,jpg veya jpeg olmalıdır";
            }

        }
    }
}