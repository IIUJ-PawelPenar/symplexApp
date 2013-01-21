using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
namespace WPF_APP_Simplex.operacje
{
    class Parser
    {
        Regex cyfra;
        Regex litera;
        Regex znak;
        public String prawaStrona;
        String stosZmiennych;
        String stosWsp;
        public bool nierownosc;
        public List<String> zmienne;
        public List<String> wsp;
        public String stan; 
        bool minusUn;
        public Parser()
        {
            stan = "wsp";
            stosWsp = "";
            stosZmiennych = "";
            zmienne = new List<string>();
            wsp = new List<string>();
            minusUn = false;
            nierownosc = false;
            znak = new Regex(@"\+|\-");
            cyfra = new Regex(@"\d");
            litera = new Regex(@"[a-z]");
        }
        bool isZnak(string s)
        {
            return znak.IsMatch(s);
        }
        bool isCyfra(string s)
        {
            return cyfra.IsMatch(s);
        }
        bool isLitera(string s)
        {
            return litera.IsMatch(s);
        }
        public void parsujFunkcjeCelu(String s)
        {
            string[] czesci = s.Split('=');
            zmienne.Clear();
            wsp.Clear();
            parsujRownanie(czesci[1]);

        }
        public void parsujOgr(String s)
        {
            zmienne.Clear();
            wsp.Clear();
            int index = s.IndexOf("<=");
            if (index > -1)
            {
                string[] czesci = s.Split('<');
                zmienne.Clear();
                wsp.Clear();
                nierownosc = true;
                prawaStrona = czesci[1].Substring(1);
                parsujRownanie(czesci[0]);
            }
            else
            {
                string[] czesci = s.Split('=');
                zmienne.Clear();
                wsp.Clear();
                nierownosc = false;
                prawaStrona = czesci[1];
                parsujRownanie(czesci[0]);
            }
           
        }

        public void parsujRownanie(String s)
        {
            stosWsp = "";
            stosZmiennych = "";
            if (isZnak(s[0].ToString()))
            {
                minusUn = true;
                s = s.Substring(1);
            }
            for (int i = 0; i < s.Length; i++)
            {

                if (isCyfra(s[i].ToString()) && stan.Equals("wsp"))
                {
                    stan = "wsp";
                    stosWsp += s[i].ToString();
                }
                if (isLitera(s[i].ToString()))
                {
                    stan = "zm";
                    stosZmiennych += s[i].ToString();
                }
                if (isCyfra(s[i].ToString()) && stan.Equals("zm"))
                {
                    stan = "zm";
                    stosZmiennych += s[i].ToString();
                }
                if (s[i].Equals("."))
                {
                    stan = "wsp";
                    stosWsp += s[i].ToString();
                }
                if (isZnak(s[i].ToString()) || i == (s.Length - 1))
                {
                    stan = "wsp";
                    if (minusUn)
                    {
                        stosWsp = "-" + stosWsp;
                        //  wsp.Add(temp);
                    }
                    if (stosWsp.Equals("") || stosWsp.Equals("-"))
                        stosWsp += "1";
                    zmienne.Add(stosZmiennych);
                    wsp.Add(stosWsp);

                    stosZmiennych = "";
                    stosWsp = "";
                    if (s[i].Equals('-')) minusUn = true;
                    else minusUn = false;
                }



            }
        }
    }
}
