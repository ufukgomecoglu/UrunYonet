using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer
{
    public class YapilanIslemler
    {
        public int ID { get; set; }
        public DateTime Tarih { get; set; }
        public int KullaniciID { get; set; }
        public int KategoriID { get; set; }
        public int TedarikciID { get; set; }
        public int AltKategoriID { get; set; }
        public int UrunID { get; set; }
        public int BirimID { get; set; }
        public int SiparisID { get; set; }
        public string Aciklama { get; set; }
    }
}
