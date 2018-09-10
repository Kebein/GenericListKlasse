using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListKlasse
{
    class Program
    {
        static void Main(string[] args)
        {
            //<BEGIN> Befüllen
            List<string> testliste = new List<string>();
            testliste.Add("hallo");
            testliste.Add("welt");
            Liste<string> liste = new Liste<string>();
            liste.Add("hallo");
            liste.Add("welt");
            
            for (int i = 0; i <= 20; i++)
            {
                testliste.Add(i.ToString());
                liste.Add(i.ToString());
            }
            //<END> Befüllen
            printAuswertungParallel(liste, testliste);

            //<BEGIN> Reverse
            Console.WriteLine("******************Reverse***************");
            liste.Reverse();
            testliste.Reverse();
            printAuswertungParallel(liste, testliste);

            //<END> Reverse

            //<BEGIN> RemoveAt
            Console.WriteLine("*************RemoveAt**************");

            liste.RemoveAt(12);
            testliste.RemoveAt(12);

            printAuswertungParallel(liste, testliste);

            //<END> RemoveAt

            //<BEGIN> RemoveRange
            Console.WriteLine("*************RemoveRange*************");
            liste.RemoveRange(5, 2);
            testliste.RemoveRange(5, 2);
            printAuswertungParallel(liste, testliste);

            //<END> RemoveRange

            //<BEGIN> AddRange
            Console.WriteLine("**************AddRange**************");
            List<string> range = new List<string>();
            for(int i = 1; i < 10; i++)
            {
                range.Add((i * 100).ToString());
            }
            liste.AddRange(range);
            testliste.AddRange(range);
            printAuswertungParallel(liste, testliste);

            //<END> AddRange
            liste.AddRange(range);
            testliste.AddRange(range);

            printAuswertungParallel(liste, testliste);

            Console.ReadKey();
        }


        static public void printAuswertung(Liste<string> ownList, List<string> stdList)
        {
            Console.WriteLine("************Eigene Liste*************");
            foreach (var item in ownList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************Normale Liste*************");
            foreach (var item in stdList)
            {
                Console.WriteLine(item);
            }
        }

        static public void printAuswertungParallel(Liste<string> ownList, List<string> stdList)
        {
            Console.WriteLine("*\tEigene*****Original*");
            int i = 0;
            foreach (var item in ownList)
            {
                Console.WriteLine($"\t{item}*****{stdList[i]}");
                i++;
            }
        }
    }
}
