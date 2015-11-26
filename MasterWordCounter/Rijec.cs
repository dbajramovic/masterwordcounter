using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterWordCounter
{
    public class Rijec
    {
        private string tekst;
        private string korijen;
        private int ponavljanje;
        private int tip;

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
    }
}
