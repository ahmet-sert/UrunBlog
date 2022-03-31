using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
namespace UrunBilgiBlog.Yonetici
{
    public partial class Yonetici : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                DataAccesLayer.Yonetici yon = (DataAccesLayer.Yonetici)Session["yonetici"];//Unboxing
                lbl_kullanici.Text = yon.Isim + " " + yon.Soyad;
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }

        protected void lbtn_cikisYap_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("Giris.aspx");


        }
    }
}