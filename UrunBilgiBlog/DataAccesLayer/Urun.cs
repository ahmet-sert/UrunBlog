using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Urun
    {
       public int ID { get; set; }
       public int KategoriID { get; set; }

        public string Yazar { get; set; }
       public int YazarID { get; set; }
       public string Isim { get; set; }
       public string Marka { get; set; }
       public string Fiyat { get; set; }
       public string Icerik { get; set; }
       public string KapakResim { get; set; }
       public  int GoruntulenmeSayısı { get; set; }
       public bool Durum { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string Kategori { get; set; }





    }
}
