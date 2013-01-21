using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
namespace WPF_APP_Simplex.Dane
{
    class PlikXml:InterfejsDane
    {
        List<Zadanie> zadania;
        string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        XmlDocument doc;
        public PlikXml(string path) {
            Path = path;
            doc = new XmlDocument();
            doc.Load(path);
            zadania = new List<Zadanie>();
        }
        bool parse() { 
              XmlNodeList lista=  doc.GetElementsByTagName("Zadanie");
              foreach (XmlNode node in lista) {
                  Zadanie z = new Zadanie();
                  z.Id = int.Parse(node.ChildNodes[0].InnerText);
                  z.Nazwa = node.ChildNodes[1].InnerText;
                  z.Typ = node.ChildNodes[2].InnerText;
                  z.Opis = node.ChildNodes[3].InnerText;
                  z.FCelu = node.ChildNodes[4].InnerText;
                  z.Wynik = node.ChildNodes[5].InnerText;
                  XmlNodeList ogr = node.ChildNodes[6].ChildNodes;
                  List<String> ogrStr = new List<string>();
                  foreach (XmlNode n in ogr)
                      ogrStr.Add(n.InnerText);

                  z.Ograniczenie = ogrStr;
                  zadania.Add(z);
             }
              return true;
        }

        public bool dodajZadanie(Zadanie zad)
        {
            throw new NotImplementedException();
        }

        public bool usunZadanie(int id)
        {
            throw new NotImplementedException();
        }

        public bool edytuj(Zadanie zad)
        {
           
            throw new NotImplementedException();
        }

        public List<Zadanie> pobierzZadania()
        { 
            parse();
            return zadania;

        }


        public bool dodajZadanie( string nazwa, 
            string typ, string opis, string fCelu, List<string> ogr)
        {
            XmlNode idNode = doc.CreateNode(XmlNodeType.Element, "ID", null);
            idNode.InnerText = doc.GetElementsByTagName("Zadanie").Count.ToString();
            XmlNode nazwaNode = doc.CreateNode(XmlNodeType.Element, "Nazwa", null);
            nazwaNode.InnerText = nazwa;
            XmlNode typNode = doc.CreateNode(XmlNodeType.Element, "Typ", null);
            typNode.InnerText = typ;
            XmlNode opisNode = doc.CreateNode(XmlNodeType.Element, "Opis", null);
            opisNode.InnerText = opis;
            XmlNode fCeluNode = doc.CreateNode(XmlNodeType.Element, "fCelu", null);
            fCeluNode.InnerText = fCelu;
            XmlNode wynikNode = doc.CreateNode(XmlNodeType.Element, "Wynik", null);
            wynikNode.InnerText = "";           
            XmlNode ogrNode = doc.CreateNode(XmlNodeType.Element, "Ogr", null);
            foreach (String s in ogr) {
                XmlNode gNode = doc.CreateNode(XmlNodeType.Element, "g", null);
                gNode.InnerText =s;
                ogrNode.AppendChild(gNode);
            }
            XmlNode zadNode = doc.CreateNode(XmlNodeType.Element, "Zadanie", null);
            zadNode.AppendChild(idNode);
            zadNode.AppendChild(nazwaNode);
            zadNode.AppendChild(typNode);
            zadNode.AppendChild(opisNode);
            zadNode.AppendChild(fCeluNode);
            zadNode.AppendChild(wynikNode);
            zadNode.AppendChild(ogrNode);
            
            doc.DocumentElement.AppendChild(zadNode);
            doc.Save(path);
            return true;
        }
    }
}
