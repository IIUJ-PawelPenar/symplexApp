using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.algorytm
{
    class Algorytm
    {
        public RealVector WektorC;
        public List<String> WektorNazwC;
        public List<String> BazaNazwy;
        public RealVector BazaWartosci;
        public RealMatrix mtx;
        public RealVector prawaStrona;
        public RealVector Z;
        public RealVector Zc;
        bool typZadania; // 0 -max, 1-min
        int indexMax_Zc;
        int indexMin_Baza;
        public List<Obserwator> obserw;

        int nrIteracji;
        int nrKroku;
        public static RealVector getColumn(int column, RealMatrix m)
        {
            RealVector v = new RealVector(m.Count());
            int i = 0;
            foreach (List<double> vecM in m)
            {
                v[i] = vecM[column];
                i++;
            }
            return v;
        }
        public Algorytm(RealVector wekC,List<String> wekCNazwy, List<String> bazaNaz,RealVector bazaWart,
                        RealMatrix m,RealVector prawaStr,bool typ )
        {

            WektorC = wekC;
            WektorNazwC = wekCNazwy;
            BazaNazwy = bazaNaz;
            BazaWartosci = bazaWart;
            mtx = m;
            prawaStrona = prawaStr;
            typZadania = typ;
            Z = new RealVector(WektorC.Count);
            Zc = new RealVector(WektorC.Count);
            obserw = new List<Obserwator>();
            nrIteracji = 0;
            nrKroku = 0;
        }
        public void dodajObserwator(Obserwator o) {
            o.inicjalizacja(WektorC, WektorNazwC, BazaNazwy, BazaWartosci, mtx, prawaStrona);
            obserw.Add(o);
        }
        public void usunObserwator(Obserwator o) {
            obserw.Remove(o);
        }
   
        public void step1()
        {
            for (int i = 0; i < Z.Count; i++)
                Z[i] = BazaWartosci * Algorytm.getColumn(i, mtx);
            foreach(Obserwator o in obserw)
            o.updateStep1(Z);
        }
        public void step2()
        {
            Zc = Z-WektorC ;
            foreach (Obserwator o in obserw)
                o.updateStep2(Zc);
        }
        public void step3() {
            if (typZadania) //minimalizacja
            {
                if (FunkcjePomocnicze.DodWartWektoraIstnieje(Zc))
                {
                    indexMax_Zc = FunkcjePomocnicze.indexMaxWartoscWektora(Zc);
                    foreach (Obserwator o in obserw)
                        o.updateStep3(indexMax_Zc,typZadania);
                }
                else
                {
                    foreach (Obserwator o in obserw)
                        o.algoStop();
                }
            }
            else {  //maksymalizacja 
                if (FunkcjePomocnicze.UjemaWartWektoraIstnieje(Zc))
                {
                    indexMax_Zc = FunkcjePomocnicze.indexMinWartoscWektora(Zc);
                    foreach (Obserwator o in obserw)
                        o.updateStep3(indexMax_Zc,typZadania);
                }
                else
                {
                    foreach (Obserwator o in obserw)
                        o.algoStop();
                }        
            }
           
        }
        public void step4() {
            RealVector wybKolumna = Algorytm.getColumn(indexMax_Zc, mtx);
            List<String> informacjeODzieleniu = new List<string>();
            RealVector noweWart=new RealVector();
            RealVector mapaIndex = new RealVector();
            int i=0;
            foreach (double e in wybKolumna) {
                if (e > 0)
                {
                    noweWart.Add(prawaStrona[i] / e);
                    mapaIndex.Add(i);
                    informacjeODzieleniu.Add(prawaStrona[i].ToString("0.00") +
                        "/" + e.ToString("0.00") + "=" + noweWart.Last().ToString("0.00"));
                }
                else { 
                    informacjeODzieleniu.Add("Nie dzielimy");                   
                }
            i++;
            }
            int indexNewWart = FunkcjePomocnicze.
                                     indexMinWartoscWektora(noweWart);
            if (indexNewWart >= 0)
                indexMin_Baza = (int)mapaIndex[indexNewWart];
            else
                indexMin_Baza = -1;
            foreach (Obserwator o in obserw)
                o.updateStep4(indexMin_Baza,informacjeODzieleniu);
        }
        public void step5() {
            foreach (Obserwator o in obserw)
                o.updateStep5(indexMax_Zc, indexMin_Baza);
        }
        public void step6() {
            String elemNowejBazyNazwa = WektorNazwC[indexMax_Zc];
            double elemNowejBazyWart = WektorC[indexMax_Zc];
            BazaNazwy[indexMin_Baza] = elemNowejBazyNazwa;
            BazaWartosci[indexMin_Baza] = elemNowejBazyWart;
            foreach (Obserwator o in obserw)
                o.updateStep6(BazaWartosci,BazaNazwy);
        }
        public void step7() {
            RealVector columnBase = Algorytm.getColumn(indexMax_Zc, mtx);

            RealVector temp = mtx[indexMin_Baza];
            for (int i = 0; i < temp.Count; i++)
                temp[i] = temp[i] / columnBase[indexMin_Baza];
            mtx[indexMin_Baza] = temp;
            prawaStrona[indexMin_Baza] =
              prawaStrona[indexMin_Baza] / columnBase[indexMin_Baza];
            for (int i = 0; i < mtx.Count; i++)
            {
                if (i != indexMin_Baza)
                {
                    mtx[i] = mtx[i] + (-1) * columnBase[i] *
                                      mtx[indexMin_Baza];
                    prawaStrona[i] =
                        prawaStrona[i] + (-1) *
                        columnBase[i] * prawaStrona[indexMin_Baza];

                }

            }
            foreach (Obserwator o in obserw)
                o.updateStep7(prawaStrona, mtx);
        }
        public void step8() {
            foreach (Obserwator o in obserw)
                o.updateStep8(indexMax_Zc, indexMin_Baza);
        }
        public void nextStep() {
            foreach (Obserwator o in obserw) 
                o.nextStep(nrKroku, nrIteracji);
            if (nrKroku == 8) {
                nrKroku = 0;
                nrIteracji++;
                foreach (Obserwator o in obserw)
                    o.nextStep(nrKroku, nrIteracji);
            }
            switch (nrKroku) {
                case 0: step1(); break;
                case 1: step2(); break;
                case 2: step3(); break;
                case 3: step4(); break;
                case 4: step5(); break;
                case 5: step6(); break;
                case 6: step7(); break;
                case 7: step8(); break;

            }
            nrKroku++;

        }
    }
}
