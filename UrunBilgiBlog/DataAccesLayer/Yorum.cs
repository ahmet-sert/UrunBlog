﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Yorum
    {

        public int ID { get; set; }
        public int UyeID { get; set; }
        public string Uye { get; set; }
        public int UrunID { get; set; }
        public string Isim { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public bool OnayDurum { get; set; }
    }
}