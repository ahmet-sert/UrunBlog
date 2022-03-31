using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
namespace UrunBilgiBlog.Yonetici
{
    public partial class UyeListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
             lv_Uyeler.DataSource = dm.UyeLisetle();
             lv_Uyeler.DataBind();
        }

        protected void lv_Uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.UyeSil(id);
            }
            if (e.CommandName == "durum")
            {
                dm.UyeDurumDegistir(id);
            }
            lv_Uyeler.DataSource =dm.Urunlistele(id);
            lv_Uyeler.DataBind();
        }
    }
}