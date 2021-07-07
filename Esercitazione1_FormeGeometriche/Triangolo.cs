using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione1_FormeGeometriche
{
    public class Triangolo: FormaGeometrica
    {
        public double Base { get; set; }
        public double Altezza { get; set; }

        public Triangolo(string name, double altezza, double _base)
            :base(name)
        {
            Altezza = altezza;
            Base = _base;
        }

        public override double CalcolaArea()
        {
            return (Base * Altezza) / 2;
            //Console.WriteLine($"L'area del {Name} è pari a {area} mq");
        }

        public override void DisegnaForma()
        {
            base.DisegnaForma();
            Console.WriteLine($"L'altezza è pari a {Altezza} metri, la base è pari a {Base} metri e l'area è pari a {CalcolaArea()} mq");
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
                writer.WriteLine($"{Altezza}");
                writer.WriteLine($"{Base}");
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
                double.TryParse(reader.ReadLine(), out double altezza);
                Altezza = altezza;
                double.TryParse(reader.ReadLine(), out double _base);
                Base = _base;
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
                await writer.WriteLineAsync($"{Base}");
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
                double.TryParse(await reader.ReadLineAsync(), out double _base);
                Base = _base;
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
