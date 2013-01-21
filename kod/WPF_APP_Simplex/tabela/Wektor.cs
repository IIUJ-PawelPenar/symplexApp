using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Drawing;
using System.Windows;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.tabela
{
    class Wektor
    {
        public enum Type { Horizontal, Vertical }
        List<PodstElem> elementyWektora;
        Point start;
        Type typ;
     public Wektor(Point s,Type t){
            elementyWektora = new List<PodstElem>();         
            start = s;
            typ = t;
        }
        public Wektor(Point _start, Type t,RealVector v)
        {
            elementyWektora = new List<PodstElem>();         
            start = _start;
            typ = t;
            setElementy(v);
        }
        public Wektor(Point _start, Type t,List<String> v)
        {
            elementyWektora = new List<PodstElem>();         
            start = _start;
            typ = t;
            setElementy(v);
        }
         public void setElementy(List<String> rV)
        {
           elementyWektora = new List<PodstElem>();
           elementyWektora.Add(new PodstElem(start,rV.First().ToString()));
            for(int i=1;i<rV.Count;i++)
                if(typ == Type.Horizontal)
               elementyWektora.Add(
                   new PodstElem(elementyWektora.Last().pobierzPozycjeNastPrawy(),rV[i].ToString()));
                else
                elementyWektora.Add(
                    new PodstElem(elementyWektora.Last().pobierzPozycjeNastDol(), rV[i].ToString()));
        }
        public void setElementy(RealVector rV) {
              List<String> temp = new List<String>();
              foreach(double e in rV)
                    temp.Add(e.ToString("0.00"));
              setElementy(temp);
          }

        public void setElementy(int size)
        {
            List<String> temp = new List<String>();
            for (int i = 0; i < size; i++) { 
                temp.Add("");
            }
              setElementy(temp);
        }
        public void odswiez(RealVector v)
        {
            int i = 0;
            foreach (PodstElem e in elementyWektora)
            {
                e.setTekst(v[i].ToString("0.00"));
                i++;
            }
        }
        public void odswiez(List<String> v)
        {
            int i = 0;
            foreach (PodstElem e in elementyWektora)
            {
                e.setTekst(v[i].ToString());
                i++;
            }
        }
        public void odswiezElem(int index, String val)
        {
            if (index <= elementyWektora.Count)
                elementyWektora[index].setTekst(val);
        }

        public void zaznaczWektor(System.Windows.Media.Color c)
        {
            foreach (PodstElem e in elementyWektora)
                e.setKolorProstokat(c);
        }
        public Point pobierzPozycjeNastPrawy()
        {
            if (typ == Type.Horizontal)
                return elementyWektora.Last().pobierzPozycjeNastPrawy();
            else
                return elementyWektora.First().pobierzPozycjeNastPrawy();
        }
        public Point pobierzPozycjeNastDol()
        {
            if (typ == Type.Horizontal)
                return elementyWektora.First().pobierzPozycjeNastDol();
            else
                return elementyWektora.Last().pobierzPozycjeNastDol();
        }
        public void dodajdoCanvas(Canvas c) {
            foreach (PodstElem e in elementyWektora)
                e.dodajDoCanvas(c);
        }
        public List<PodstElem> getElementy() { return elementyWektora; }
        public PodstElem getElement(int index) {
            if (index < elementyWektora.Count)
                return elementyWektora[index];
            else
                return null;
        }
        }
}