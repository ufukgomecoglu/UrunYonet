using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer
{
    public class Tedarikci
    {
        public int TedarikciID { get; set; }
        public string Adi { get; set; }
        public string Tel { get; set; }
        public string Eposta { get; set; }
        public string YetkiliAdi { get; set; }
        public bool IsDeleted { get; set; }
    }
}
