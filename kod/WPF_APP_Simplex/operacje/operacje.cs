using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_APP_Simplex.operacje
{
    class operacje
    {
        List<String> ogr;
       public PostacStandardowaZadania zadStd;
        String funCelu;
        Parser p;
       public operacje(Dane.Zadanie zad) { 
           ogr= zad.Ograniczenie;
           funCelu=zad.FCelu;
           
           zadStd = new PostacStandardowaZadania();
           if (zad.Typ == "MAX")
               zadStd.Typ = false;
           else zadStd.Typ = true;
           p = new Parser();
        }
        public void stworzZadanieStd(){

            String t = "";
            p.parsujFunkcjeCelu(funCelu);
            zadStd.dodajFunkcjeCelu(p.zmienne, p.wsp);
            foreach (String f in ogr) {
                p.parsujOgr(f);
                zadStd.dodajOgraniczenie(p.zmienne, p.wsp,p.prawaStrona, p.nierownosc);
            }
            zadStd.liczNowaBaza();
            
     //       int i = 0;
        }
    }
}
