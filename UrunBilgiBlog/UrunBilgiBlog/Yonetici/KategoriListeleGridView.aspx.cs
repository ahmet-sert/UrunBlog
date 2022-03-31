using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
namespace UrunBilgiBlog.Yonetici
{
    public partial class KategoriListeleGridView : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            gv_kategoriler.DataSource = dm.KategoriListele();
            gv_kategoriler.DataBind();
        }
    }
}