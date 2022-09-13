using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceShuttle
{
    struct Space
    {
        public string KilovesKod;
        public string Datum;
        public string UrsikloNev;
        public int Nap;
        public int Ora;
        public string LegitamaszNev;
        public int LegenysegSzama;

        public Space(string sor)
        {
            var dbok = sor.Split(';');
            this.KilovesKod = dbok[0];
            this.Datum = dbok[1];
            this.UrsikloNev = dbok[2];
            this.Nap = int.Parse(dbok[3]);
            this.Ora = int.Parse(dbok[4]);
            this.LegitamaszNev = dbok[5];
            this.LegenysegSzama = int.Parse(dbok[6]);
        }
    }
    internal class Program
    {
        static List<Space> List = new List<Space>();
        static void Main(string[] args)
        {
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat9();
            Feladat10();
            Console.ReadLine();
        }

        private static void Feladat10()
        {
            List<string> UrsikloNev = new List<string>();
            foreach (var item in List)
            {
                if (!UrsikloNev.Contains(item.UrsikloNev))
                {
                    UrsikloNev.Add(item.UrsikloNev);
                }
            }
            foreach (var item1 in List)
            {
                foreach (var item2 in UrsikloNev)
                {

                }
            }
            StreamWriter sw = new StreamWriter(@"ursiklok.txt", false, Encoding.UTF8);
            foreach (var item in UrsikloNev)
            {
                sw.WriteLine($"{item} : ");
            }
            sw.Close();
        }

        private static void Feladat9()
        {
            double db = 0;
            foreach (var item in List)
            {
                if (item.LegitamaszNev == "Kennedy")
                {
                    db++;
                }
            }
            Console.WriteLine($"9. feladat\n\tA küldetések {(db*100)/List.Count:0.00} fejeződött be a Kennedy űrközpontban");
        }

        private static void Feladat8()
        {
            Console.WriteLine("8. feladat");
            Console.Write("\tÉvszám: ");
            string Evszam = Console.ReadLine();
            int KuldetesekSzama = 0;
            foreach (var item in List)
            {
                if (item.Datum.Split('.')[0] == Evszam)
                {
                    KuldetesekSzama++;
                }
            }
            if (KuldetesekSzama > 0) { Console.WriteLine($"\tEbben az évben {KuldetesekSzama} küldetés volt"); }
            else Console.WriteLine("\tEbben az évben nem indult küldetés");
        }

        private static void Feladat7()
        {
            int MaxIdo = int.MinValue;
            string Nev = "";
            string KuldetesKod = "";
            foreach (var item in List)
            {
                if (item.Nap*24+item.Ora > MaxIdo)
                {
                    Nev = item.UrsikloNev;
                    KuldetesKod = item.KilovesKod;
                    MaxIdo = item.Nap * 24 + item.Ora;
                }
            }
            Console.WriteLine($"Feladat 7.\n\tLeghosszabb ideig a {Nev} volt az űrben a {KuldetesKod} során\nÖsszesen {MaxIdo} órát volt távol a Földtől");
        }

        private static void Feladat6()
        {
            int AsztronautakSzama = 0;
            foreach (var item in List)
            {
                if (item.UrsikloNev == "Columbia" && item.Datum == "2003.01.16")
                {
                    AsztronautakSzama = item.LegenysegSzama;
                }
            }
            Console.WriteLine($"Feladat 6.\n\t{AsztronautakSzama} asztronauta volt a Columbia fedélzetén annak utolsó útján");
        }

        private static void Feladat5()
        {
            int KevesebbMint5 = 0;
            foreach (var item in List)
            {
                if (item.LegenysegSzama < 5)
                {
                    KevesebbMint5++;
                }
            }
            Console.WriteLine($"5. feladat\n\tÖsszesen {KevesebbMint5} alkalommal küldtek kevesebb, mint 5 embert az űrbe.");
        }

        private static void Feladat4()
        {
            int OsszUtas = 0;
            foreach (var item in List)
            {
                OsszUtas += item.LegenysegSzama;
            }
            Console.WriteLine($"4. feladat\n\t{OsszUtas} utas indult az űrbe összesen.");
        }

        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat\n\tÖsszesen {List.Count} alkalommal indítottak űrhajót");
        }

        private static void Feladat2()
        {
            StreamReader sr = new StreamReader(@"kuldetesek.csv", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                List.Add(new Space(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
