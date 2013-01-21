using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.algorytm
{
    class ObserwatorTabela : Obserwator
    {
         tabela.Tabela tab;
        public ObserwatorTabela() { 
            
        }
        public override void inicjalizacja(
                         RealVector wekC, List<String> wekCNazwy, List<String> bazaNaz, RealVector bazaWart,
                        RealMatrix m, RealVector prawaStr)
        {
            tab = new tabela.Tabela();
            tab.setWielkoscIInit(wekC.Count,
                               bazaWart.Count);
            tab.updateWektorC(wekC);
            tab.updateWektorNazwC(wekCNazwy);
            tab.updateWektorBazaNazwy(bazaNaz);
            tab.updateWektorBazaWart(bazaWart);
            tab.updateMtx(m);
            tab.updatePrawaStronaWart(prawaStr);
        }
        public  tabela.Tabela getTab() { return tab; }
        public override void updateStep1(RealVector wektorZ)
        {
            tab.updateWektorZ(wektorZ);
        }
        public override void updateStep2(RealVector wektorZc)
        {
            tab.updateWektorZc(wektorZc);
        }
        public override void updateStep3(int indexZc,bool typ)
        {
            if(typ)
                tab.dodajInformacjeDoElemZc(indexZc, "MAX");
            else
                tab.dodajInformacjeDoElemZc(indexZc, "MIN");
            
            tab.zaznaczKolumneMtx(indexZc, Colors.Aqua);
        }
        public override void updateStep4(int indexMin, List<String> listaInfo)
        {
            if(indexMin>=0)
            tab.zaznaczWierszMtx(indexMin,Colors.DarkOrchid);
            tab.dodajInformacjeDoPrawejStr(listaInfo);
        }
        public override void updateStep5(int indexWekC, int indexWekBaza)
        {
            tab.zaznaczZmianeBazy(indexWekC, indexWekBaza, Colors.DarkRed);
        }
        public override void updateStep6(RealVector nBazaWart, List<String> nBazaNazwa)
        {
            tab.updateWektorBazaNazwy(nBazaNazwa);
            tab.updateWektorBazaWart(nBazaWart);
            tab.usunInformacjeZZc();
            tab.usunInformacjeZPrawejStr();
        }
        public override void updateStep7(RealVector pStrona, RealMatrix mtx)
        {
            tab.updatePrawaStronaWart(pStrona);
            tab.updateMtx(mtx);
        }
        public override void updateStep8(int indexMax_c, int indexMinBaza)
        {
            tab.zaznaczKolumneMtx(indexMax_c, Colors.White);
            tab.zaznaczWierszMtx(indexMinBaza, Colors.White);
            tab.zaznaczZmianeBazy(indexMax_c, indexMinBaza, Colors.White);
        }
   }
}
