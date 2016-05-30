using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterWordCounter
{
    class StatistikaTekst
    {
        private long id;
        private String ime_teksta;
        private List<String> top_10_rijeci;
        private double RMSE_N;
        private double RMSE_G;
        private double pct_diff;

        public long Id
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

        public string Ime_teksta
        {
            get
            {
                return ime_teksta;
            }

            set
            {
                ime_teksta = value;
            }
        }

        public List<string> Top_10_rijeci
        {
            get
            {
                return top_10_rijeci;
            }

            set
            {
                top_10_rijeci = value;
            }
        }

        public double RMSE_N1
        {
            get
            {
                return RMSE_N;
            }

            set
            {
                RMSE_N = value;
            }
        }

        public double RMSE_G1
        {
            get
            {
                return RMSE_G;
            }

            set
            {
                RMSE_G = value;
            }
        }

        public double Pct_diff
        {
            get
            {
                return pct_diff;
            }

            set
            {
                pct_diff = value;
            }
        }
        public void Clear()
        {
            ime_teksta = "";
            if(top_10_rijeci!= null)
                top_10_rijeci.Clear();
            RMSE_G = 0.0;
            RMSE_N = 0.0;
            pct_diff = 0.0;
        }
    }
}
