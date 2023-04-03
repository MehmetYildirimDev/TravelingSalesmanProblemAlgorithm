using System;
using System.Collections.Generic;
using System.IO;

namespace TravelSalesmanProblemSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> dots = new Dictionary<string, string[]>();

            List<string> path = new List<string>();

            double pathLength = 0;
            int yolSayisi = 0;

            string dosya_yolu = @"D:\Üniversite\3.SINIF\2. Dönem\Algoritma Analizi ve Tasarımı\Ödev 1\uygulama dosyaları\5";

            string[] lines = System.IO.File.ReadAllLines(dosya_yolu);


            for (int i = 1; i < lines.Length; i++)
            {

                string[] coordinates = lines[i].Split(" ");
                dots.Add((i - 1).ToString(), coordinates);

            }


            for (int i = 0; i < dots.Count; i++)
            {
                string[] coors1;
                dots.TryGetValue(i.ToString(), out coors1);

                string[] coors2;
                bool isLast = dots.TryGetValue((i + 1).ToString(), out coors2);
                if (!isLast)
                {
                    Console.WriteLine("bitti");
                    break;

                }
                yolSayisi++;
                pathLength += distanceCalculate(double.Parse(coors1[0]), double.Parse(coors1[1]), double.Parse(coors2[0]), double.Parse(coors2[1]));
            }

            Console.WriteLine("yol uzunlugu : " + pathLength + " || Yol adedi: " + yolSayisi);
            Console.ReadKey();
        }//main






        private static double distanceCalculate(double x1, double y1, double x2, double y2)
        {
            double distance = 0f;

            distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            return distance;
        }


    }//program
}//namespace
