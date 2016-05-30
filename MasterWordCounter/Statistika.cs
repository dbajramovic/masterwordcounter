using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterWordCounter
{
    class Statistika
    {
        private int id;
        private int rijec_id;
        private int tekst_id;
        // 1= naivna, 2=sa gramatikom
        private int tip_statistike;
        private int broj_ponavljanja;
        private int rank_unutar_teksta;
        private Decimal procenat_pojave_unutar_teksta;
        private string rijec_tekst;
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

        public int Rijec_id
        {
            get
            {
                return rijec_id;
            }

            set
            {
                rijec_id = value;
            }
        }

        public int Tekst_id
        {
            get
            {
                return tekst_id;
            }

            set
            {
                tekst_id = value;
            }
        }

        public int Tip_statistike
        {
            get
            {
                return tip_statistike;
            }

            set
            {
                tip_statistike = value;
            }
        }

        public int Broj_ponavljanja
        {
            get
            {
                return broj_ponavljanja;
            }

            set
            {
                broj_ponavljanja = value;
            }
        }

        public int Rank_unutar_teksta
        {
            get
            {
                return rank_unutar_teksta;
            }

            set
            {
                rank_unutar_teksta = value;
            }
        }

        public Decimal Procenat_pojave_unutar_teksta
        {
            get
            {
                return procenat_pojave_unutar_teksta;
            }

            set
            {
                procenat_pojave_unutar_teksta = value;
            }
        }

        public string Rijec_tekst
        {
            get
            {
                return rijec_tekst;
            }

            set
            {
                rijec_tekst = value;
            }
        }
    }
}
