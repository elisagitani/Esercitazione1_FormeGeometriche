using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione1_FormeGeometriche
{
    public class Cerchio: FormaGeometrica
    {
        public int[] CoordinateCentro { get; set; }
        public double Raggio { get; set; }

        public Cerchio(string name, int[] coordinateCentro, double raggio)
            :base(name)
        {
            CoordinateCentro = coordinateCentro;
            Raggio = raggio;
        }

        public override double CalcolaArea()
        {
            return Math.PI * Raggio * Raggio;
            //Console.WriteLine($"L'area del {Name} è pari a {area} mq");
        }

        public override void DisegnaForma()
        {
            base.DisegnaForma();
            Console.WriteLine($"Le coordinate del centro sono [{CoordinateCentro[0]}, {CoordinateCentro[1]}], il raggio misura {Raggio} metri e l'area è pari a {CalcolaArea()} mq");
        }

        public override void SaveToFile(string fileName)
        {
            try
            {
                if (!Directory.Exists(@"C:\Academy"))
                {
                    Directory.CreateDirectory(@"C:\Academy");
                }
                StreamWriter writer = File.CreateText(fileName);
                writer.WriteLine($"{Name}");
                writer.WriteLine($"{CoordinateCentro[0]}");
                writer.WriteLine($"{CoordinateCentro[1]}");
                writer.WriteLine($"{Raggio}");
                writer.Flush();
                writer.Close();
            }
            catch (IOException ioex)
            {
                Console.WriteLine($" ERRORE: {ioex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }
        public override void LoadFromFile(string fileName)
        {
            try
            {
                StreamReader reader = File.OpenText(fileName);
                Name = reader.ReadLine();
                int.TryParse(reader.ReadLine(), out int coordinata1);
                CoordinateCentro[0] = coordinata1;
                int.TryParse(reader.ReadLine(), out int coordinata2);
                CoordinateCentro[1]= coordinata2;
                double.TryParse(reader.ReadLine(), out double raggio);
                Raggio = raggio;
                reader.Close();
            }
            catch (IOException ioex)
            {
                Console.WriteLine($" ERRORE: {ioex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }

        public override async Task SaveToFileAsync(string fileName)
        {
            try
            {
                if (!Directory.Exists(@"C:\Academy"))
                {
                    Directory.CreateDirectory(@"C:\Academy");
                }
                StreamWriter writer = File.CreateText(fileName);
                await writer.WriteLineAsync($"{Name}");
                await writer.WriteLineAsync($"{CoordinateCentro[0]}");
                await writer.WriteLineAsync($"{CoordinateCentro[1]}");
                await writer.WriteLineAsync($"{Raggio}");
                await writer.FlushAsync();
                writer.Close();
            }
            catch (IOException ioex)
            {
                Console.WriteLine($" ERRORE: {ioex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }
        public override async Task LoadFromFileAsync(string fileName)
        {
            try
            {
                StreamReader reader = File.OpenText(fileName);
                Name= await reader.ReadLineAsync();
                int.TryParse(await reader.ReadLineAsync(), out int coordinata1);
                CoordinateCentro[0] = coordinata1;
                int.TryParse(await reader.ReadLineAsync(), out int coordinata2);
                CoordinateCentro[1] = coordinata2;
                double.TryParse(await reader.ReadLineAsync(), out double raggio);
                Raggio = raggio;
                reader.Close();
            }
            catch (IOException ioex)
            {
                Console.WriteLine($" ERRORE: {ioex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
        }
    }
}
