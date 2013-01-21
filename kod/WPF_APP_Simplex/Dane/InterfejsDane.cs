using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_APP_Simplex.Dane
{
    interface InterfejsDane
    {
        bool dodajZadanie(Zadanie zad);
        bool dodajZadanie( string nazwa, string typ, string opis, string fCelu, List<String> ogr);
        bool usunZadanie(int id);
        bool edytuj(Zadanie zad);
        List<Zadanie> pobierzZadania();
    }
}
