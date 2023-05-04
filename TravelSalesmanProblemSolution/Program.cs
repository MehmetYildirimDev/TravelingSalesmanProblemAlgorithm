using System;
using System.Collections.Generic;
using System.Globalization;

namespace TravelSalesmanProblemSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime baslangicZamani = DateTime.Now;


            CultureInfo culture = CultureInfo.InvariantCulture;

            List<Tuple<double, double>> cities = new List<Tuple<double, double>>();

            //5 124 1000 5915 11849 85900
            string dosya_yolu = @"D:\Üniversite\3.SINIF\2. Dönem\Algoritma Analizi ve Tasarımı\Ödev 1\uygulama dosyaları\85900";

            string[] lines = System.IO.File.ReadAllLines(dosya_yolu);

            double pathLenght = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] coordinates = lines[i].Split(" ");
                cities.Add(Tuple.Create(double.Parse(coordinates[0], culture), double.Parse(coordinates[1], culture)));
            }

            int startCity = 0;

            int[] tour = new int[cities.Count + 1];//en bastaki sehre dondugu icin +1
            bool[] visited = new bool[cities.Count];

            visited[startCity] = true;

            tour[0] = startCity;

            for (int i = 1; i < cities.Count; i++)
            {
                int nearestCity = -1;
                double nearestDistance = double.MaxValue;

                for (int j = 0; j < cities.Count; j++)
                {
                    if (!visited[j])
                    {
                        double distance = Distance(cities[i - 1], cities[j]);
                        if (distance < nearestDistance)
                        {
                            nearestDistance = distance;
                            nearestCity = j;
                            pathLenght += nearestDistance;
                        }

                    }
                }

                visited[nearestCity] = true;
                tour[i] = nearestCity;

            }

            //baslangic noktasina dönme
            double returnValue = Distance(cities[startCity], cities[tour.Length - 2]);
            tour[tour.Length - 1] = startCity;
            pathLenght += returnValue;

            // Yolu ekrana yazdırın
            Console.WriteLine("En kısa yol:");
            foreach (int city in tour)
            {
                Console.Write(city + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Yolun Uzunluğu " + pathLenght);

            DateTime bitisZamani = DateTime.Now;
            TimeSpan calismaSuresi = bitisZamani - baslangicZamani;
            Console.WriteLine("Program çalışma süresi: " + calismaSuresi.TotalSeconds + " saniye");

            // Programın sonunda beklemek için bir tuşa basılmasını isteyin
            Console.WriteLine("Çıkmak için herhangi bir tuşa basın...");
            Console.ReadKey();

        }

        static double Distance(Tuple<double, double> point1, Tuple<double, double> point2)
        {
            double dx = point1.Item1 - point2.Item1;
            double dy = point1.Item2 - point2.Item2;
            return Math.Sqrt(dx * dx + dy * dy);

        }


    }//program
}//namespace
