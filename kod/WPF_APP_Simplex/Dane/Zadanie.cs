using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_APP_Simplex.Dane
{
    public class Zadanie
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        String nazwa;

        public String Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        String typ;

        public String Typ
        {
            get { return typ; }
            set { typ = value; }
        }
        String opis;

        public String Opis
        {
            get { return opis; }
            set { opis = value; }
        }
        String fCelu;

        public String FCelu
        {
            get { return fCelu; }
            set { fCelu = value; }
        }
        List<String> ograniczenie;

        public List<String> Ograniczenie
        {
            get { return ograniczenie; }
            set { ograniczenie = value; }
        }
        String wynik;

        public String Wynik
        {
            get { return wynik; }
            set { wynik = value; }
        }
    }
}
