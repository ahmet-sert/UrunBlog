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
    public partial class UrunEkle : System.Web.UI.Page
        
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }



        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;
            Urun U= new Urun();
            U.Isim= tb_isim.Text;
            U.Marka = tb_marka.Text;
            U.Icerik = tb_icerik.Text;
            U.Fiyat = tb_fiyat.Text;
            U.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            U.Durum = cb_yayinla.Checked;
            DataAccesLayer.Yonetici y = (DataAccesLayer.Yonetici)Session["yonetici"];
            U.EklemeTarihi = DateTime.Now;
            U.YazarID = y.ID;

            if (fu_resim.HasFile)//Resim Seçilmiş ise
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//.jpg,.png
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/UrunResimleri/" + resimadi));
                    U.KapakResim = resimadi;
                    resimformat = true;
                }
            }
            else
            {
                U.KapakResim = "none.png";
            }
            if (resimformat)
            {
                if (dm.UrunEkle(U))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı jpg veya png olmalıdır";
            }

        }
    }
}