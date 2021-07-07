using System;
using System.Collections.Generic;

namespace Esercitazione1_FormeGeometriche
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<FormaGeometrica> forme = new List<FormaGeometrica>();

            GetDatiCerchio(out int[] coordinate, out double raggio);

            Cerchio c = new Cerchio("Cerchio",coordinate,raggio);

            forme.Add(c);

            GetDatiRettangolo(out double altezza, out double larghezza);

            Rettangolo r = new Rettangolo("Rettangolo", altezza, larghezza);
            forme.Add(r);

            GetDatiTriangolo(out double _altezza, out double _base);
            
            Triangolo t = new Triangolo("Triangolo",_altezza,_base);
            forme.Add(t);
            
            Console.WriteLine();
            foreach(var item in forme)
            {
                item.DisegnaForma();  
            }

            string fileName = @"C:\Users\elisa.gitani\Desktop\Academy\Dati.txt";

            //IFileSerializable[] figure = new IFileSerializable[] {c,r,t};

            //Console.WriteLine("\nSalvataggio Dati");
            foreach (var item in forme)
            {
                item.SaveToFile(fileName);
                item.LoadFromFile(fileName);
                item.DisegnaForma();
            }

            
           

            //Console.WriteLine("\nCaricamento Dati");
            //foreach (var item in figure)
            //{
            //    item.LoadFromFile(fileName);
            //}
        }

        public static void GetDatiCerchio(out int[] coordinate, out double raggio)
        {
            Console.WriteLine("\nInserisci i dati del cerchio: ");
            coordinate = new int[2];
            for (int i = 0; i < coordinate.Length; i++)
            {
                do
                {
                    Console.Write($"Inserisci la coordinata {i + 1} del centro: ");
                } while (!int.TryParse(Console.ReadLine(), out coordinate[i]));

            }
            
            do
            {
                Console.Write($"Inserisci il raggio: ");
            } while (!double.TryParse(Console.ReadLine(), out raggio));
        }

        public static void GetDatiRettangolo(out double altezza, out double larghezza)
        {
            Console.WriteLine("\nInserisci i dati del rettangolo: ");
           
            do
            {
                Console.Write($"Inserisci l'altezza del rettangolo: ");
            } while (!double.TryParse(Console.ReadLine(), out altezza));

            do
            {
                Console.Write($"Inserisci la larghezza del rettangolo: ");
            } while (!double.TryParse(Console.ReadLine(), out larghezza));
        }

        public static void GetDatiTriangolo(out double _altezza, out double _base)
        {
            Console.WriteLine("\nInserisci i dati del triangolo: ");
           
            do
            {
                Console.Write($"Inserisci l'altezza del triangolo: ");
            } while (!double.TryParse(Console.ReadLine(), out _altezza));

            
            do
            {
                Console.Write($"Inserisci la base del triangolo: ");
            } while (!double.TryParse(Console.ReadLine(), out _base));

        }

    }
}
