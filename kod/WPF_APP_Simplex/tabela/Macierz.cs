using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Controls;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
using System.Windows;
namespace WPF_APP_Simplex.tabela
{
    class Macierz
    {
        public List<Wektor> Mtx;
        public Point Start;
        public Macierz(Point s) {
            Mtx = new List<Wektor>();
            Start =s;
        }
        public Macierz(Point s,RealMatrix matrix)
        {
            Mtx = new List<Wektor>();
            Start = s;
            setMacierz(matrix);
        }
        public void setMacierz(RealMatrix m) {
           Wektor temp= new Wektor(Start, Wektor.Type.Horizontal);
            temp.setElementy(m[0]);
            
            Mtx.Add(temp);
            for (int i = 1; i < m.Count; i++)
            {
                temp = new Wektor(Mtx.Last().pobierzPozycjeNastDol(),
                    Wektor.Type.Horizontal,m[i]);
                Mtx.Add(temp);
            }
        
        }
        public void setMacierz(int m,int n)
        {
            Wektor temp = new Wektor(Start, Wektor.Type.Horizontal);
            temp.setElementy(m);

            Mtx.Add(temp);
            for (int i = 1; i < n; i++)
            {
                temp = new Wektor(Mtx.Last().pobierzPozycjeNastDol(),
                    Wektor.Type.Horizontal);
                temp.setElementy(m);
                Mtx.Add(temp);
            }

        }
        public void odswiez(RealMatrix m)
        {
            int i = 0, j = 0;
            foreach (Wektor vec in Mtx)
            {
                i = 0;
                foreach (PodstElem e in vec.getElementy())
                {
                    e.setTekst(m[j][i].ToString("0.00"));
                    i++;
                }
                j++;
            }
        }
        public Point pobierzPozycjeNastPrawy()
        {
            return Mtx[0].getElementy().Last().pobierzPozycjeNastPrawy();
        }
        public void zaznaczKolumne(int index, System.Windows.Media.Color c)
        {
            for (int i = 0; i < Mtx.Count; i++)
            {
                Mtx[i].getElementy()[index].setKolorProstokat(c);
            }

        }
        public void zaznaczWiersz(int index, System.Windows.Media.Color c)
        {
            foreach (PodstElem e in Mtx[index].getElementy())
            {
                e.setKolorProstokat(c);
            }

        }
        public void dodajdoCanvas(Canvas c)
        {
            foreach (Wektor e in Mtx)
                e.dodajdoCanvas(c);
        }
    }
}
