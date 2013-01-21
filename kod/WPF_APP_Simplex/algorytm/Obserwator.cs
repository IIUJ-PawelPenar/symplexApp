using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.algorytm
{
    class Obserwator
    {
   
        public Obserwator() { 
        
        }
        public virtual void inicjalizacja(RealVector wekC, List<String> wekCNazwy, List<String> bazaNaz, RealVector bazaWart,
                        RealMatrix m, RealVector prawaStr) { }
        public virtual void updateStep1(RealVector wektorZ) { }
        public virtual void updateStep2(RealVector wektorZc) { }
        public virtual void updateStep3(int indexZc,bool typ) { }
        public virtual void updateStep4(int indexMin, List<String> listaInfo) { }
        public virtual void updateStep5(int indexWekC, int indexWekBaza) { }
        public virtual void updateStep6(RealVector nBazaWart,
            List<String> nBazaNazwa) { }
        public virtual void updateStep7(RealVector pStrona, RealMatrix mtx) { }
        public virtual void updateStep8(int indexMax_c, int indexMinBaza) { }
        public virtual void nextStep(int nrKroku, int nrIter) { }
        public virtual void algoStop() { }
    }
}
