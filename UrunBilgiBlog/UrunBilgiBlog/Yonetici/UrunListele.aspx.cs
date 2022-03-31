using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace UrunBilgiBlog.Yonetici
{
    public partial class UrunListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Urunler.DataSource = dm.Urunlistele();
            lv_Urunler.DataBind();

        }

        protected void lv_Urunler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.UrunSil(id);
            }
            if (e.CommandName == "durum")
            {
                dm.UrunDurumDegistir(id);
            }
            lv_Urunler.DataSource = dm.Urunlistele();
            lv_Urunler.DataBind();

        }
    }
}