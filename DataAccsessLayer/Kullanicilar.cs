using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer
{
    public class Kullanicilar
    {
        public int KullaniciID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string CepTel { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool IsDeleted { get; set; }
    }
}
