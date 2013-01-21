using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using LinearAlgebra.Matrices;
using LinearAlgebra.Vectors.Numeric;
namespace WPF_APP_Simplex.tabela
{
    interface InterfejsTabeli
    {
        void setWielkoscIInit(int lElemWC, int logr);
        void updateWektorC(RealVector v);
        void updateWektorNazwC(List<String> v);
        void updateWektorBazaWart(RealVector v);
        void updateWektorBazaNazwy(List<String> v);
        void updateMtx(RealMatrix m);
        void updatePrawaStronaWart(RealVector v);

        void updateWektorZ(RealVector v);
        void updateWektorZc(RealVector v);
        void dodajInformacjeDoElemZc(int index, String str);
        void usunInformacjeZZc();
        void dodajInformacjeDoPrawejStr(List<String> lista);
        void usunInformacjeZPrawejStr();
        void zaznaczKolumneMtx(int index, Color c);
        void zaznaczWierszMtx(int index, Color c);
        void zaznaczZmianeBazy(int indexWekC, int indexBaza,Color c);


    }
}
