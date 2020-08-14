using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _173311068_ysa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NeuralNetwork neuralNetwork = new NeuralNetwork();

        int[] butonGirisDegerleri = new int[35]
        {
          0,0,0,0,0,
          0,0,0,0,0,
          0,0,0,0,0,
          0,0,0,0,0,
          0,0,0,0,0,
          0,0,0,0,0,
          0,0,0,0,0
        };

        private void btnEgit_Click(object sender, EventArgs e)
        {
            Veriler veriler = new Veriler();
            bool durum = neuralNetwork.Training(veriler.veriler, veriler.beklenenler);
            if (durum)
            {
                btnEgit.Enabled = true;
                button36.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int deger = int.Parse(btn.Name.Substring(6));
            if(btn.BackColor == Color.White)
            {
                butonGirisDegerleri[deger - 1] = 1;
                btn.BackColor = Color.Black;
            }
            else
            {
                butonGirisDegerleri[deger - 1] = 0;
                btn.BackColor = Color.White;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            neuralNetwork.tahmin(butonGirisDegerleri);
            lblASonuc.Text = neuralNetwork.sonuc[0].ToString();
            lblBSonuc.Text = neuralNetwork.sonuc[1].ToString();
            lblCSonuc.Text = neuralNetwork.sonuc[2].ToString();
            lblDSonuc.Text = neuralNetwork.sonuc[3].ToString();
            lblESonuc.Text = neuralNetwork.sonuc[4].ToString();

        }
    }
}

