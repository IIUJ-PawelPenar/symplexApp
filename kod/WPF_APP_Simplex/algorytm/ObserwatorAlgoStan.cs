using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
namespace WPF_APP_Simplex.algorytm
{
    class ObserwatorAlgoStan:Obserwator
    {
    
        private TextBox textBoxKrok;
        private TextBox textBoxIter;
      
        public ObserwatorAlgoStan(TextBox textBoxKrok, TextBox textBoxIter)
        {
            // TODO: Complete member initialization
            this.textBoxKrok = textBoxKrok;
            this.textBoxIter = textBoxIter;
        }
        public override void nextStep(int nrKroku, int nrIter) {
            textBoxIter.Text = nrIter.ToString();
            textBoxKrok.Text = nrKroku.ToString();
        }
        public override void algoStop() {
            textBoxIter.Text = "STOP";
            textBoxKrok.Text = "STOP";
        }
    }
}
