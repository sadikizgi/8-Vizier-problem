using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _14253607HW2
{
    class vezir
    {
        int neredeSatir;
        int neredeSutun;
        int veziryer;
        int vezirsayisi = 0;
        string[] konumlar = { "", "", "", "", "", "", "", "" };//konum kaydı için boş string oluşturuldu.
        public vezir(int neredeSatir = 0, int neredeSutun = 0, int veziryer = 0)
        {
            this.neredeSatir = neredeSatir;
            this.neredeSutun = neredeSutun;
            this.veziryer = veziryer;
        }

        public void cizdir()
        {
            int[,] matris = new int[8, 8];

            Random rastgele1 = new Random();//İlk vezir rastgele yerleştirildi.
            neredeSatir = rastgele1.Next(0, 7);
            neredeSutun = rastgele1.Next(0, 7);
            matris[neredeSatir, neredeSutun] = 1;
            konumlar[0] = neredeSatir + "+" + neredeSutun;
            

            while (vezirsayisi != 6)
            {
                //konumlar string dizisi integer'a cast edildi ve yerleştirilecek yerler belirlendi.
                if (int.Parse(konumlar[vezirsayisi][0].ToString()) + 1==7)//Bir alta inip oradan sonra iki sağa geçildi ve taşma kontrolleri yapıldı
                {
                    neredeSatir = 7;
                }
                else
                {
                    neredeSatir = ((int.Parse(konumlar[vezirsayisi][0].ToString())) + 1) % 8;//konumlar stringi içinde konumlar + ile birleştirildi ve konumların x ve y eksenleri char olarak çekildi ve modu alındı.
                }
                if (int.Parse(konumlar[vezirsayisi][2].ToString())+2==7)
                {
                    neredeSutun = 7;
                }
                else
                {

                    neredeSutun = ((int.Parse(konumlar[vezirsayisi][2].ToString())) + 2) % 8;
                }//kontrol sonu

                for (int i = 0; i <= 7; i++)//eğer vezirler birbirlerini yiyorsa bir sağa geçiliyor ve tüm vezirler kontrol ediliyor.
                {
                    if (konumlar[i] != "" && neredeSatir == (int.Parse(konumlar[i][0].ToString())))
                    {
                        neredeSatir=(neredeSatir+1)%7;
                    }
                    else if (konumlar[i] != "" && neredeSutun == (int.Parse(konumlar[i][2].ToString())))
                    {
                        neredeSutun=(neredeSutun+1)%7;
                    }
                    
                }




                vezirsayisi++;

                matris[neredeSatir, neredeSutun] = 1;//vezirlerin yerleştirildiği yerler matrise eklendi.
                konumlar[vezirsayisi] = neredeSatir + "+" + neredeSutun;//konumlar kaydedildi.
            }








             // matrix şeklinde yazdırma bölümü 
            for (int i = 0; i < matris.GetLength(0); i++)
                {

                    for (int k = 0; k < matris.GetLength(1); k++)
                    {

                        if (matris[i, k] == 1)
                        {
                            Console.Write(/*matris[i, k] + */"V ");
                        }
                        else
                            Console.Write("- ");
                    }
                    Console.WriteLine();
                }
            }

        }
    }


