using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.tabela
{
    class Tabela:Canvas,InterfejsTabeli 
    {
        int lElemWektoraC;
        int lOgr;
        PodstElem e1;
        PodstElem cLabel;
        Wektor wektorGora_c;
        PodstElem e2;

        PodstElem bLabel;
        PodstElem e3;
        Wektor wektorGora_x;
        PodstElem wartLabel;

        Wektor wektorBaza;
        Wektor wektorWartBaza;
        Macierz mtx;
        Wektor wektorWart;

        PodstElem e4;
        PodstElem zLabel;
        Wektor wektorZ;
        PodstElem sum;

        PodstElem e5;
        PodstElem czLabel;
        Wektor wektorCz;
        PodstElem e6;
        public Tabela() { 
            
        
        }
        public void inicjalizacja(int wWekC,int iloscOgr){
        
            inicjalizacja1();
            inicjalizacja2();
            inicjalizacja3();
            inicjalizacja4();
            inicjalizacja5();
        }
        private void inicjalizacja1() {
            e1 = new PodstElem(new System.Windows.Point(10.0,10.0), "");
            e1.setKolorProstokat(Colors.Silver);
            cLabel = new PodstElem(e1.pobierzPozycjeNastPrawy(), "C");
            cLabel.setKolorProstokat(Colors.Azure);
            wektorGora_c = new Wektor(cLabel.pobierzPozycjeNastPrawy(), Wektor.Type.Horizontal);
            wektorGora_c.setElementy(lElemWektoraC);
            e2 = new PodstElem(wektorGora_c.pobierzPozycjeNastPrawy(), "");
            e2.setKolorProstokat(Colors.Silver);

            e1.dodajDoCanvas(this);
            cLabel.dodajDoCanvas(this);
            wektorGora_c.dodajdoCanvas(this);
            e2.dodajDoCanvas(this);

        }
        private void inicjalizacja2() {
            bLabel = new PodstElem(e1.pobierzPozycjeNastDol(), "B");
            e3 = new PodstElem(bLabel.pobierzPozycjeNastPrawy(), "");
            e3.setKolorProstokat(Colors.Silver);
            wektorGora_x = new Wektor(e3.pobierzPozycjeNastPrawy(), Wektor.Type.Horizontal);
            wektorGora_x.setElementy(lElemWektoraC);
            wartLabel = new PodstElem(wektorGora_x.pobierzPozycjeNastPrawy(), "Val");

            bLabel.dodajDoCanvas(this);
            e3.dodajDoCanvas(this);
            wektorGora_x.dodajdoCanvas(this);
            wartLabel.dodajDoCanvas(this);
        }
        private void inicjalizacja3() {
            wektorBaza = new Wektor(bLabel.pobierzPozycjeNastDol(), Wektor.Type.Vertical);
            wektorBaza.setElementy(lOgr);
            wektorWartBaza = new Wektor(wektorBaza.pobierzPozycjeNastPrawy(), Wektor.Type.Vertical);
            wektorWartBaza.setElementy(lOgr);
            mtx = new Macierz(wektorWartBaza.pobierzPozycjeNastPrawy());
            mtx.setMacierz(lElemWektoraC, lOgr);
            wektorWart = new Wektor(mtx.pobierzPozycjeNastPrawy(), Wektor.Type.Vertical);
            wektorWart.setElementy(lOgr);

            wektorBaza.dodajdoCanvas(this);
            wektorWartBaza.dodajdoCanvas(this);
            mtx.dodajdoCanvas(this);
            wektorWart.dodajdoCanvas(this);
        }
        private void inicjalizacja4() {
            e4 = new PodstElem(wektorBaza.pobierzPozycjeNastDol(), "");
            e4.setKolorProstokat(Colors.Silver);
            zLabel = new PodstElem(e4.pobierzPozycjeNastPrawy(), "Z");
            wektorZ = new Wektor(zLabel.pobierzPozycjeNastPrawy(), Wektor.Type.Horizontal);
            wektorZ.setElementy(lElemWektoraC);
            sum = new PodstElem(wektorZ.pobierzPozycjeNastPrawy(), "");

            e4.dodajDoCanvas(this);
            zLabel.dodajDoCanvas(this);
            wektorZ.dodajdoCanvas(this);
            sum.dodajDoCanvas(this);
        
        }
        private void inicjalizacja5() {
            e5 = new PodstElem(e4.pobierzPozycjeNastDol(), "");
            e5.setKolorProstokat(Colors.Silver);
            czLabel = new PodstElem(e5.pobierzPozycjeNastPrawy(), "Z-c");
            wektorCz = new Wektor(czLabel.pobierzPozycjeNastPrawy(), Wektor.Type.Horizontal);
            wektorCz.setElementy(lElemWektoraC);
            e6 = new PodstElem(wektorCz.pobierzPozycjeNastPrawy(), "");
            e6.setKolorProstokat(Colors.Silver);
            
            e5.dodajDoCanvas(this);
            czLabel.dodajDoCanvas(this);
            wektorCz.dodajdoCanvas(this);
            e6.dodajDoCanvas(this);
        
        }

        public void updateWektorC(RealVector v) {
            wektorGora_c.odswiez(v);
        }
        public void updateWektorNazwC(List<String> v) {
            wektorGora_x.odswiez(v);
        }
        public void updateWektorBazaWart(RealVector v)
        {
            wektorWartBaza.odswiez(v);
        }
        public void updateWektorBazaNazwy(List<String> v)
        {
            wektorBaza.odswiez(v);
        }
        public void updateMtx(RealMatrix m){mtx.odswiez(m);}
        public void updatePrawaStronaWart(RealVector v) { 
            wektorWart.odswiez(v);
        }


        public void setWielkoscIInit(int lElemWC, int logr)
        {
            lElemWektoraC = lElemWC;
            lOgr = logr;
            inicjalizacja(lElemWektoraC, lOgr);
        }


        public void updateWektorZ(RealVector v)
        {
            wektorZ.odswiez(v);
        }

        public void updateWektorZc(RealVector v)
        {
            wektorCz.odswiez(v);
        }


        public void dodajInformacjeDoElemZc(int index, string str)
        {
            wektorCz.getElement(index).dodajInformacje(str);
        }


        public void zaznaczKolumneMtx(int index, Color c)
        {
            mtx.zaznaczKolumne(index, c);
        }

        public void zaznaczWierszMtx(int index, Color c)
        {
            mtx.zaznaczWiersz(index, c);
        }


        public void dodajInformacjeDoPrawejStr(List<string> lista)
        {
            if(wektorWart.getElementy().Count == lista.Count){
                int i=0;
                foreach(String e in lista){
                    wektorWart.getElement(i).dodajInformacje(e);
                    i++;
            }
            }
        }


        public void zaznaczZmianeBazy(int indexWekC, int indexBaza,Color c)
        {
            wektorGora_x.getElement(indexWekC).setKolorProstokat(c);
            wektorBaza.getElement(indexBaza).setKolorProstokat(c);
        }


        public void usunInformacjeZZc()
        {
            foreach (PodstElem e in wektorCz.getElementy())
                e.usunInformacje();
        }

        public void usunInformacjeZPrawejStr()
        {
            foreach (PodstElem e in wektorWart.getElementy())
                e.usunInformacje();
        }
    }
}
