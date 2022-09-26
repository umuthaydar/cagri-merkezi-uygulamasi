using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CagriMerkeziAPI.Models
{
    public class CagriDetay
    {
        public int id { get; set; }
        public string  musteriAdi { get; set; }
        public string konu { get; set; }
        public string aciklama { get; set; }
        public string  durum { get; set; }
        public string sonuc{ get; set; }
        public string servisElemani { get; set; }
        public DateTime cagriTarihi { get; set; }
    }
}
