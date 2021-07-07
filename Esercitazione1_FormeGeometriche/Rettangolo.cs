using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione1_FormeGeometriche
{
    public class Rettangolo: FormaGeometrica
    {
        public double Larghezza { get; set; }
        public double Altezza { get; set; }

        public Rettangolo(string name, double altezza, double larghezza)
            :base(name)
        {
            Altezza = altezza;
            Larghezza = larghezza;

        }

        public override double CalcolaArea()
        {
           return Altezza * Larghezza;
            //Console.WriteLine($"L'area del {Name} è pari a {area} mq");
        }

        public override void DisegnaForma()
        {
            base.DisegnaForma();
            Console.WriteLine($"L'altezza è pari a {Altezza} metri, la larghezza è pari a {Larghezza} metri e l'area è pari a {CalcolaArea()} mq");
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
                writer.WriteLine($"{Larghezza}");
                writer.WriteLine($"{Altezza}");
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
                double.TryParse(reader.ReadLine(), out double larghezza);
                Larghezza = larghezza;
                double.TryParse(reader.ReadLine(), out double altezza);
                Altezza = altezza;
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
                await writer.WriteLineAsync($"{Larghezza}");
                await writer.WriteLineAsync($"{Altezza}");
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
                Name = await reader.ReadLineAsync();
                double.TryParse(await reader.ReadLineAsync(), out double larghezza);
                Larghezza = larghezza;
                double.TryParse(await reader.ReadLineAsync(), out double altezza);
                Altezza = altezza;
               
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
