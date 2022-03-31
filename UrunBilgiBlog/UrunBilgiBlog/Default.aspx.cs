using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace UrunBilgiBlog
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                lv_urunler.DataSource = dm.Urunlistele();
                lv_urunler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["kid"]);
                lv_urunler.DataSource = dm.Urunlistele(id);
       
                lv_urunler.DataBind();
            }

        }
    }
}