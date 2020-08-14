using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173311068_ysa
{
    class GizliKatman
    {
        public Noron[] gizliKatmanNoronlari;

        double bias = 1;

        public static readonly Object kilitlemeNesnesi = new Object();
        public static readonly Random rnd = new Random();

        public GizliKatman(int gizliKatmanSayisi, int cikisKatmanSayisi)
        {
            gizliKatmanNoronlari = new Noron[gizliKatmanSayisi];

            for (int i = 0; i < gizliKatmanSayisi; i++)
            {
                Random rnd = new Random();
                Noron noron = new Noron();

                // Gizli Katmanın değerlerini 0'lanır
                //noron.value = 0;
                noron.value = GetRandomNumber(-1, 1);

                // Gizli katman sayısı kadar ağırlık oluşturuldu
                noron.agirliklar = new double[cikisKatmanSayisi];

                // Her bir noron için random sayılar atandı;
                for (int j = 0; j < cikisKatmanSayisi; j++)
                {
                    noron.agirliklar[j] = GetRandomNumber(-1, 1);
                }

                noron.bias = this.bias;

                // Oluşturduğumuz noronu dizimize ekliyoruz.
                gizliKatmanNoronlari[i] = noron;
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
