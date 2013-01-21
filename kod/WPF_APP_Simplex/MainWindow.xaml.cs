using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_APP_Simplex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public Dane.Dane zadania;
       operacje.operacje oper;
       algorytm.Algorytm a;
        public MainWindow()
        {
            InitializeComponent();
            zadania = new Dane.Dane("plikXML.xml");

            foreach (Dane.Zadanie z in zadania.pobierzZadania())
            {
                zadaniaCombo.Items.Add(z.Nazwa+":"+z.Opis);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void dodajZad(object sender, RoutedEventArgs e)
        {
            
        }

        private void dodajZadanieBut_Click(object sender, RoutedEventArgs e)
        {
            WPF_APP_Simplex.FolmularzDodaj f = new FolmularzDodaj(zadania);
            f.Show();
        
        }

        private void zadaniaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            oper = new operacje.operacje(zadania.pobierzZadania()[zadaniaCombo.SelectedIndex]);

            oper.stworzZadanieStd();
            algorytm.ObserwatorTabela obserwTab = new algorytm.ObserwatorTabela();
            algorytm.ObserwatorAlgoStan obserwStan = new algorytm.ObserwatorAlgoStan(boxKrok, boxIter);
         

            a = new algorytm.Algorytm(oper.zadStd.getWektorC(),
                oper.zadStd.getWektorNazwC(), oper.zadStd.getBazaNazwy(), oper.zadStd.getBazaWartosci(), 
                oper.zadStd.getMtx(),
                oper.zadStd.getPrawaStrona(), oper.zadStd.Typ);
            a.dodajObserwator(obserwTab);
            a.dodajObserwator(obserwStan);
            mainCanvas.Children.Add(obserwTab.getTab());
        }

        private void buttonNextStep_Click(object sender, RoutedEventArgs e)
        {
            a.nextStep();
        }   
    }
}
