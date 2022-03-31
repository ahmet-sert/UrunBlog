using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Uye
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdı { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public bool Durum { get; set; }

    }
}
