using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.operacje
{
    class PostacStandardowaZadania
    {
        Funkcja funkcjaCelu;
     public   List<Funkcja> ograniczenia;
        List<String> bazaPocz;
        bool typ;

        public bool Typ
        {
            get { return typ; }
            set { typ = value; }
        }
        public PostacStandardowaZadania() {
            bazaPocz = new List<string>();
            funkcjaCelu = new Funkcja();
            ograniczenia = new List<Funkcja>();
        }
        public List<String> getBazaPocz() { return bazaPocz; }
        public void setBazaPocz(List<String> b) {
            bazaPocz = b;
        }
        public void dodajElementBazy(String e) {
            bazaPocz.Add(e);
        }
        public RealVector getWektorC() {
            RealVector temp = new RealVector();
            foreach (String e in funkcjaCelu.getWspZmiennych())
                temp.Add(double.Parse(e));
            return temp;
        }
       
        public List<String> getWektorNazwC()
        {
            List<String> temp = new List<string>();
            foreach (String e in funkcjaCelu.getNazwyZmiennych())
                temp.Add(e);
            return temp;
        }
        public List<String> getBazaNazwy() { return bazaPocz; }
        public RealVector getBazaWartosci() {
            RealVector temp = new RealVector();
            for (int i = 0; i < bazaPocz.Count; i++) {
                temp.Add(0.0);
            }
            return temp;
        }
      //  public bool getTyp() { return getFunkcjaCelu().getTypFunkcji(); }
        public RealMatrix getMtx(){
            RealMatrix temp = new RealMatrix();
            foreach(Funkcja e in ograniczenia){
                RealVector t = new RealVector();
            for (int i = 0; i <e.getWspZmiennych().Count; i++) {
                t.Add(double.Parse(e.getWspZmiennych()[i]));
            }
                temp.Add(t);   
            }
        return temp;
        }
        public RealVector getPrawaStrona() { 
            RealVector temp = new RealVector();
            foreach(Funkcja e in ograniczenia)
                temp.Add(double.Parse(e.getPrawaStrona()));
            return temp;
        }
        public void dodajFunkcjeCelu(List<String> nazwyZmiennych,
            List<String> wspZmiennych) {
                funkcjaCelu.setListaNazwyZmiennych(nazwyZmiennych);
                funkcjaCelu.setListaWspZmiennych(wspZmiennych);
        }
        public void dodajOgraniczenie(List<String> nazwyZmiennych,
            List<String> wspZmiennych,string pStr,bool nierow)
        {
            ograniczenia.Add(new Funkcja(nazwyZmiennych,wspZmiennych,pStr,nierow));
        }
        public void liczNowaBaza() {
            int nr = 1;
            for (int i = 0; i < ograniczenia.Count; i++)
            {
                if (ograniczenia[i].isNierownosc())
                {
                    ograniczenia[i].dodajPare("s" + nr.ToString(), "1");
                    for (int j = 0; j < ograniczenia.Count; j++)
                        if (j != i)
                            ograniczenia[j].dodajPare("s" + nr.ToString(), "0");

                    funkcjaCelu.dodajPare("s" + nr.ToString(), "0");
                    ograniczenia[i].setNierownosc(false);
                    dodajElementBazy("s" + nr.ToString());

                    nr++;
                }

            }
        
        }
      }
       
    }
