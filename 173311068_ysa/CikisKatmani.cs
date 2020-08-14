using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173311068_ysa
{
    class CikisKatmani
    {
        public Noron[] cikisKatmanNoronlari;

        double bias = 1;

        public CikisKatmani(int cikisKatmanSayisi)
        {
            cikisKatmanNoronlari = new Noron[cikisKatmanSayisi];

            for (int i = 0; i < cikisKatmanSayisi; i++)
            {
                Noron noron = new Noron();

                // Çıkış katmanın değerleri 0'lanır
                noron.cikisValue = 0;

                cikisKatmanNoronlari[i] = noron;
            }
        }
    }
}
