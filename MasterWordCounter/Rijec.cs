using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterWordCounter
{
    public class Rijec
    {
        private int id;
        private string tekst;
        private string korijen;
        private int ponavljanje;
        private int tip;
        private bool irregular;
        public override string ToString()
        {
            return tekst;
        }
        public string Tekst
        {
            get
            {
                return tekst;
            }

            set
            {
                tekst = value;
            }
        }

        public string Korijen
        {
            get
            {
                return korijen;
            }

            set
            {
                korijen = value;
            }
        }

        public int Ponavljanje
        {
            get
            {
                return ponavljanje;
            }

            set
            {
                ponavljanje = value;
            }
        }

        public int Tip
        {
            get
            {
                return tip;
            }

            set
            {
                tip = value;
            }
        }

        public bool Irregular
        {
            get
            {
                return irregular;
            }

            set
            {
                irregular = value;
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
    }
}
