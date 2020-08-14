using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173311068_ysa
{
    class NeuralNetwork
    {
        GirisKatmani girisKatmani;
        GizliKatman gizliKatman;
        CikisKatmani cikisKatmani;

        int girisKatmaniSayisi;
        int cikisKatmaniSayisi;
        int gizlikatmanSayisi;
        
        public double[] sonuc;

        //public static List<double> hatalar = new List<double>();
        
        List<double> biasListesi = new List<double>();

        public NeuralNetwork(int girisKatmaniSayisi = 35, int cikisKatmaniSayisi = 5, int gizlikatmanSayisi = 5)
        {
            this.girisKatmaniSayisi = girisKatmaniSayisi;
            this.cikisKatmaniSayisi = cikisKatmaniSayisi;
            this.gizlikatmanSayisi = gizlikatmanSayisi;
            sonuc = new double[cikisKatmaniSayisi];

            // Katmanların oluşturulması
            girisKatmani = new GirisKatmani(girisKatmaniSayisi, gizlikatmanSayisi);
            gizliKatman = new GizliKatman(gizlikatmanSayisi, cikisKatmaniSayisi);
            cikisKatmani = new CikisKatmani(cikisKatmaniSayisi);

        }

        // Öğrenmenin yapıldığı 
        public bool Training(int[][] veriler,int[][] beklenenler) 
        {
            int epoch = 10000;
            double errorSinir = 0.01;
            double hata = 0;

            for (int i = 0; i < epoch ; i++)
            {
                hata = 0;
                for(int j = 0; j < veriler.Length; j++)
                {
                    this.ileriHesaplama(veriler[j]);
                    hata += hataHesaplama(beklenenler[j]);
                    this.geriHesaplama(beklenenler[j]);
                }
                // hata değeri 0.01 olana kadar devam edecektir.
                //if (errorSinir > hata) break;
            }
            return true;
        }

        public double hataHesaplama(int[] beklenenler)
        {
            double hata = 0;

            // Beklenenler ile çıkış nöronları arasındaki farkı hesaplıyoruz
            for(int i = 0; i < this.cikisKatmaniSayisi; i++)
            {
                double beklenenValue = beklenenler[i];
                hata += 0.5 * Math.Pow((beklenenValue - this.cikisKatmani.cikisKatmanNoronlari[i].cikisValue), 2) ;
            }

            return hata;
        }

        public void ileriHesaplama(int[] veriler)
        {
            // Giriş katmanının değeri ile ağırlığının çarpılarak toplanması ve toplanan sonuçların bias eklenerek sigmoid fonksiyonuna sokuluyor.
            // Daha sonra ise Çıkış value'ye atanıyor.
            for(int i = 0; i < gizlikatmanSayisi; i++)
            {
                Noron noron = gizliKatman.gizliKatmanNoronlari[i];
                double toplam = 0;
                for(int j = 0; j < girisKatmaniSayisi; j++)
                {
                    Noron girisNoron = girisKatmani.girisKatmanNoronlari[j];
                    toplam += girisNoron.value * girisNoron.agirliklar[i];
                }
                noron.value = Sigmoid(toplam + noron.bias);
            }

            // Gizli katmanının değeri ile ağırlığının çarpılarak toplanması ve toplanan sonuçların bias eklenerek sigmoid fonksiyonuna sokuluyor.
            // Daha sonra ise Çıkış value'ye atanıyor.
            for (int i = 0; i < cikisKatmani.cikisKatmanNoronlari.Length; i++)
            {
                Noron noron = cikisKatmani.cikisKatmanNoronlari[i];
                double toplam = 0;
                for (int j = 0; j < this.gizlikatmanSayisi; j++)
                {
                    Noron gizliNoron = gizliKatman.gizliKatmanNoronlari[j];
                    toplam += gizliNoron.value * gizliNoron.agirliklar[i];
                }
                noron.cikisValue += Sigmoid(toplam + noron.bias);
            }
        }

        public void geriHesaplama(int[] veriler)
        {
            // Geri hesaplama birkaç hatam var tam olarak nerede olduğunu çözemedim. Onun için çıkış değerleri yüksek değer veriyor.
            double ogrenmeKatsayisi = 0.4; 
            double momentum = 0.5; 
            double hata = 0;

            // Çıktı ile beklenenlerin hesaplanması
            // Hata = Beklenen çıktı - çıkan veri
            for(int i = 0; i < cikisKatmaniSayisi; i++)
            {
                cikisKatmani.cikisKatmanNoronlari[i].hata = veriler[i] - cikisKatmani.cikisKatmanNoronlari[i].cikisValue;
                //hatalar.Add(cikisKatmani.cikisKatmanNoronlari[i].hata);
            }

            // Çıkış katmanı için hatanın hesabı
            // dagitilacak hata = Çıktı * (1-Çıktı) * hata
            for(int i = 0; i < 5; i++)
            {
                cikisKatmani.cikisKatmanNoronlari[i].dagitilacakHata = cikisKatmani.cikisKatmanNoronlari[i].cikisValue *
                                                                       (1 - cikisKatmani.cikisKatmanNoronlari[i].cikisValue) *
                                                                       cikisKatmani.cikisKatmanNoronlari[i].hata;
            }

            // Ağırlık = Ogrenme * Dagıtılacak Hata  * Çıkış Degeri + momentum * önceki değer
            // Gizli Ağırlıkların değişim miktarını hesaplama ve atama
            for(int i = 0; i < 5;i++)
            {
                hata = cikisKatmani.cikisKatmanNoronlari[i].dagitilacakHata *
                       ogrenmeKatsayisi *
                       cikisKatmani.cikisKatmanNoronlari[i].cikisValue + 
                       momentum * 
                       cikisKatmani.cikisKatmanNoronlari[i].cikisValueOncesi;

                // Çıkış değerini önceki değere atanıyor
                cikisKatmani.cikisKatmanNoronlari[i].cikisValueOncesi = cikisKatmani.cikisKatmanNoronlari[i].cikisValue;
                for (int j = 0; j < 5; j++)
                {
                    // Ağırlık değerini hata değeri kadar azaltıyoruz
                    gizliKatman.gizliKatmanNoronlari[j].agirliklar[j] -= hata;
                    // Bias değerini hata değeri kadar azaltıyoruz
                    gizliKatman.gizliKatmanNoronlari[j].bias -= hata;
                }
            }

            // Giriş katmanı için hata hesabı
            for (int i = 0; i < 35; i++)
            {
                girisKatmani.girisKatmanNoronlari[i].dagitilacakHata = gizliKatman.gizliKatmanNoronlari[0].cikisValueOncesi *
                                                                        girisKatmani.girisKatmanNoronlari[i % 5].dagitilacakHata *
                                                                       (1 - girisKatmani.girisKatmanNoronlari[i].cikisValue) *
                                                                       girisKatmani.girisKatmanNoronlari[i].cikisValue;
            }

            // Giriş katmanı yeni değerler
            for (int i = 0; i < 35; i++)
            {
                hata = ogrenmeKatsayisi *
                       girisKatmani.girisKatmanNoronlari[i].dagitilacakHata *
                       gizliKatman.gizliKatmanNoronlari[i % 5].agirliklar[0] +
                       girisKatmani.girisKatmanNoronlari[i].cikisValueOncesi *
                       momentum;

                girisKatmani.girisKatmanNoronlari[i].cikisValueOncesi = girisKatmani.girisKatmanNoronlari[i].cikisValue;
                for (int j = 0; j < 5; j++)
                {
                    girisKatmani.girisKatmanNoronlari[i].agirliklar[j] -= hata;
                    girisKatmani.girisKatmanNoronlari[i].bias -= hata;
                }
            }
        }

        public void tahmin(int[] veriler)
        {
            // Form ekranından girilen harf burada ileri hesaplama ile hesaplanıyor ve çıkış katmanındaki değerleri gösteriyor
            this.ileriHesaplama(veriler);

            for(int i = 0; i < this.cikisKatmaniSayisi; i++)
            {
                sonuc[i] = cikisKatmani.cikisKatmanNoronlari[i].cikisValue;
            }
            
        }

        public static double Sigmoid(double value)
        {
            return 1.0d / (1.0d + Math.Pow(Math.E,-value));
        }

    }
}
