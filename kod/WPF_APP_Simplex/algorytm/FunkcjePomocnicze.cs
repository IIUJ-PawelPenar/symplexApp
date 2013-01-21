using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.algorytm
{
    class FunkcjePomocnicze
    {
        public static int indexMaxWartoscWektora(RealVector v)
        {
            if (v.Count == 0) return -1;
            int index = 0;
            double temp = v[0];
            for (int i = 1; i < v.Count; i++)
            {
                if (v[i] > temp)
                {
                    temp = v[i];
                    index = i;
                }
            }
            return index;
        }
        public static int indexMinWartoscWektora(RealVector v)
        {
            if (v.Count == 0) return -1;
            int index = 0;
            double temp = v[0];
            for (int i = 1; i < v.Count; i++)
            {
                if (v[i] < temp)
                {
                    temp = v[i];
                    index = i;
                }
            }
            return index;
        }
        public static bool DodWartWektoraIstnieje(RealVector v)
        {
            foreach (double e in v)
                if (e > 0) return true;
            return false;
        }
        public static bool UjemaWartWektoraIstnieje(RealVector v)
        {
            foreach (double e in v)
                if (e < 0) return true;
            return false;
        }
    }
}
