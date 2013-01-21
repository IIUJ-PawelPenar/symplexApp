using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  WPF_APP_Simplex.operacje
{
    class Funkcja
    {
        List<String> nazwyZmiennych;
        List<String> wspZmiennych;
        String prawaStrona;
        bool nierownosc;
        public Funkcja() {
            nazwyZmiennych = new List<string>();
            wspZmiennych = new List<string>();
        }
        public Funkcja(List<string> nazwyZm, List<string> nazwyWsp, bool n) {
            nazwyZmiennych = new List<string>(nazwyZm);
            wspZmiennych = new List<string>(nazwyWsp);
            nierownosc = n;
        }
        public Funkcja(List<string> nazwyZm, List<string> nazwyWsp,string pStr,bool n)
        {
            nazwyZmiennych = new List<string>(nazwyZm);
            wspZmiennych = new List<string>(nazwyWsp);
            prawaStrona = pStr;
            nierownosc = n;
        }
        public List<String> getNazwyZmiennych() { return nazwyZmiennych; }
        public List<String> getWspZmiennych() { return wspZmiennych; }
        public String getPrawaStrona() { return prawaStrona;}
        public bool isNierownosc(){return nierownosc;}
        public void setListaNazwyZmiennych(List<String> nazwyZm)
        {
            nazwyZmiennych = nazwyZm;
        }
        public void setListaWspZmiennych(List<String> wspZm) {
            wspZmiennych = wspZm;
        }
        public void dodajPare(String nazwaZm, String wspZm) {
            nazwyZmiennych.Add(nazwaZm);
            wspZmiennych.Add(wspZm);
        }
        public void setPrawaStrona(String n) { prawaStrona = n; }
        public void setNierownosc(bool n) { nierownosc = n; }
    }
}
