using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows;
using System.Media;
namespace WPF_APP_Simplex.tabela
{
    class PodstElem
    {

        public System.Windows.Shapes.Rectangle Prostokat;
        public Label LabelTekst;
        public Label LabelInformacja; 
        public Point Start;
        private Canvas canvas = null;
        public PodstElem(Point s, int w, int h) {
            LabelTekst = new Label();
            LabelTekst.Foreground = new SolidColorBrush(Colors.Black);
            LabelTekst.Background = new SolidColorBrush(Colors.White);
            LabelTekst.FontSize = 20;
            LabelTekst.BorderBrush = new SolidColorBrush(Colors.White);
            LabelInformacja = new Label();
            Prostokat = new System.Windows.Shapes.Rectangle();
            Prostokat.Width = w;
            Prostokat.Height = h;
            Prostokat.StrokeThickness = 2;
            Prostokat.Stroke = new SolidColorBrush(Colors.Black);
            Prostokat.Fill = new SolidColorBrush(Colors.White);
            Start = s;
        }
        public PodstElem(Point s, String str) {
            LabelTekst = new Label();
            LabelTekst.Content = str;
            LabelTekst.Foreground = new SolidColorBrush(Colors.Black);
            LabelTekst.Background = new SolidColorBrush(Colors.White);
            LabelTekst.FontSize = 20;
            LabelTekst.BorderBrush = new SolidColorBrush(Colors.White);
            LabelInformacja = new Label();
            Start = s;
            Prostokat = new System.Windows.Shapes.Rectangle();
            Prostokat.Width = 80;
            Prostokat.Height = 60;
            Prostokat.StrokeThickness = 2;
            Prostokat.Stroke = new SolidColorBrush(Colors.Black);
            Prostokat.Fill = new SolidColorBrush(Colors.White);
         }
        public Point pobierzPozycjeNastPrawy()
        {
            return new Point(Start.X + (int)Prostokat.Width
                -(int)Prostokat.StrokeThickness, Start.Y);
        }
        public Point pobierzPozycjeNastDol()
        {
            return new Point(Start.X, 
                Start.Y + (int)Prostokat.Height - (int)Prostokat.StrokeThickness);
        }
        public void dodajDoCanvas(Canvas c)
        {
            canvas = c;
            int _x = (int)Start.X;
            int _y = (int)Start.Y;
            int _tx = (int)Start.X + 10;
            int _ty = (int)Start.Y + 5;

            Canvas.SetLeft(Prostokat, _x);
            Canvas.SetTop(Prostokat, _y);
            canvas.Children.Add(Prostokat);

            Canvas.SetLeft(LabelTekst, _tx);
            Canvas.SetTop(LabelTekst, _ty);
            canvas.Children.Add(LabelTekst);
        }
        public void dodajInformacje(String text)
        {
            LabelInformacja = new Label();
            LabelInformacja.Content = text;
            LabelInformacja.Foreground = new SolidColorBrush(Colors.Black);
            LabelInformacja.Background = new SolidColorBrush(Colors.YellowGreen);
            LabelInformacja.FontSize = 15;
            LabelInformacja.BorderBrush = new SolidColorBrush(Colors.YellowGreen);
            if (canvas != null)
            {
                Canvas.SetLeft(LabelInformacja,
            pobierzPozycjeNastPrawy().X - (int)Prostokat.Width / 2);
                Canvas.SetTop(LabelInformacja,pobierzPozycjeNastPrawy().Y);
                Canvas.SetZIndex(LabelInformacja, 2);
                canvas.Children.Add(LabelInformacja);
            }
        }
        public void usunInformacje()
        {
            if (LabelInformacja != null && canvas!=null)
                canvas.Children.Remove(LabelInformacja);
        }
        public void setKolorProstokat(System.Windows.Media.Color c){
            Prostokat.Fill = new SolidColorBrush(c);
            LabelTekst.Background = new SolidColorBrush(c);
        }
        public void setKolorTekst(System.Windows.Media.Color c)
        {
            LabelTekst.Foreground = new SolidColorBrush(c);
        }
        public void setTekst(String s) {
            LabelTekst.Content = s;
        }
        public String getText() { return (String)LabelTekst.Content; }
        public int getWysokosc() { return (int)Prostokat.Height; }
        public void setWysokosc(int h) {
            Prostokat.Height = (double)h;
        }
        public int getSzerokosc() { return (int)Prostokat.Width; }
        public void setSzerokosc(int w)
        {
            Prostokat.Width = (double)w;
        }
        public int getSzerokoscLinii() { return (int)Prostokat.StrokeThickness; }
        public void setSzerokoscLinii(int w)
        {
            Prostokat.StrokeThickness = (double)w;
        }
    }
}
