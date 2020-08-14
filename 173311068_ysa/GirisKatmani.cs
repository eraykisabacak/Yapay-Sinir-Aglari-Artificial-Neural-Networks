using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173311068_ysa
{
    class GirisKatmani
    {
        public Noron[] girisKatmanNoronlari;

        double bias = 1;

        public static readonly Object kilitlemeNesnesi = new Object();
        public static readonly Random rnd = new Random();

        public GirisKatmani(int noronSayisi,int gizliNoronSayisi)
        {
            girisKatmanNoronlari = new Noron[noronSayisi];

            for (int i = 0; i < noronSayisi; i++)
            {
                Random rnd = new Random();
                Noron noron = new Noron();

                // Giris Katmanın değerlerini 0'lanır
                // noron.value = 0;
                noron.value = GetRandomNumber(-1, 1);

                // Gizli katman sayısı kadar ağırlık oluşturuldu
                noron.agirliklar = new double[gizliNoronSayisi];

                // Her bir noron için random sayılar atandı;
                for(int j = 0; j < gizliNoronSayisi; j++)
                {
                    noron.agirliklar[j] = GetRandomNumber(-1, 1);
                }

                //Giriş katmanı için bias
                noron.bias = this.bias;

                // Oluşturduğumuz noronu dizimize ekliyoruz.
                girisKatmanNoronlari[i] = noron;
            }
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            // Aynı random sayı gelmemesi için bir lock oluşturulmuştur.
            lock (kilitlemeNesnesi)
            {
                return rnd.NextDouble() * (maximum - minimum) + minimum;
            }
        }
    }
}
