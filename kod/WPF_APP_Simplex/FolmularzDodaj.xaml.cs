using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_APP_Simplex
{
    /// <summary>
    /// Interaction logic for FolmularzDodaj.xaml
    /// </summary>
    public partial class FolmularzDodaj : Window
    {
        List<TextBox> ogr;
        Dane.Dane dane;
        public FolmularzDodaj(Dane.Dane d)
        {
            InitializeComponent();
            ogr = new List<TextBox>();
            ogr.Add(TextBoxogr1);
            typComboBox.Items.Add("MIN");
            typComboBox.Items.Add("MAX");
            typComboBox.SelectedIndex = 0;
            dane = d;
        }
        private void dodajOgraniczenie(object sender, RoutedEventArgs e)
        {
            TextBox newOggr = new TextBox();
            Grid.SetRow(newOggr, ogr.Count - 1);
            Grid.SetColumn(newOggr, 0);
            gridOgr.Children.Add(newOggr);
            ogr.Add(newOggr);
        }
        private void dodajZad_Click(object sender, RoutedEventArgs e)
        {
            List<String> temp = new List<string>();
            foreach (TextBox t in ogr)
                temp.Add(t.Text);
             
            dane.dodajZadanie(nazwaTextBox.Text,
                typComboBox.SelectedItem.ToString(),
                opisTextBox.Text,
                funkcjaCeluTextBox.Text, temp);
            Close();
        }
    }
}
