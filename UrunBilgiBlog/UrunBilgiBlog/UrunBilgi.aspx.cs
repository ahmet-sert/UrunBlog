using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
namespace UrunBilgiBlog
{
    public partial class UrunBilgi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                Urun u = dm.UrunGetir(id);
                ltrl_isim.Text = u.Isim;
                ltrl_icerik.Text = u.Icerik;
                ltrl_kategori.Text = u.Kategori;               
                img_resim.ImageUrl = "UrunResimleri/" + u.KapakResim;
                if (Session["uye"] != null)
                {
                    pnl_girisVar.Visible = true;
                    pnl_girisyok.Visible = false;
                }
                else
                {
                    pnl_girisVar.Visible = false;
                    pnl_girisyok.Visible = true;
                }
                rp_yorumlar.DataSource = dm.YorumListele(id);
                rp_yorumlar.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Yorum y = new Yorum();
            y.UrunID = id;
            y.UyeID = ((Uye)Session["uye"]).ID;
            y.Icerik = tb_yorum.Text;
            y.Tarih = DateTime.Now;
            y.OnayDurum = false;

            if (dm.YorumEkle(y))
            {
                Response.Write("<script>alert('Yorum Alındı. Onay Sonrasında yayınlanacaktır')</script>");
            }
            else
            {
                Response.Write("<script>alert('Başarısız')</script>");
            }
        }
    }
}