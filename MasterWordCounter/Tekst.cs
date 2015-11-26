using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterWordCounter
{
    public class Tekst
    {
        private string naziv;
        private string sadrzaj;
        //private Statistiska statistika;
        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

        public string Sadrzaj
        {
            get
            {
                return sadrzaj;
            }

            set
            {
                sadrzaj = value;
            }
        }
        public override string ToString()
        {
            return Naziv;// + " "+ Sadrzaj;
        }
    }
}
