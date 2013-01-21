using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_APP_Simplex.Dane
{
    public class Dane
    {
        String xmlPath;
        PlikXml xml;
        public Dane(String xmlPath) {
            xml = new PlikXml(xmlPath);
            this.xmlPath = xmlPath;
        }
        public bool dodajZadanie(string nazwa,
            string typ, string opis, string fCelu, List<string> ogr) {
                return xml.dodajZadanie(nazwa, typ, opis, fCelu, ogr);
        }
        public bool usunZadanie(int id) {
            return xml.usunZadanie(id);
        }
        public List<Zadanie> pobierzZadania() {
            return xml.pobierzZadania();
        }
       


    }
}
