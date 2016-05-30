using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterWordCounter
{
    public class Tekst
    {
        private int id;
        private string naziv;
        private string sadrzaj;
        private string autor;
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

        public string Autor
        {
            get
            {
                return autor;
            }

            set
            {
                autor = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public override string ToString()
        {
            return "["+Id+"] "+Autor+" - "+Naziv;// + " "+ Sadrzaj;
        }
    }
}
