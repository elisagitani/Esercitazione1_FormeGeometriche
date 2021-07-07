using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione1_FormeGeometriche
{
    public class FormaGeometrica : IFileSerializable
    {
        public string Name { get; set; }

        public FormaGeometrica(string name)
        {
            Name = name;
        }
        public virtual double CalcolaArea()
        {
            return 0;
        }

        public virtual void DisegnaForma()
        {
            Console.WriteLine($"\nLa forma geometrica è un {Name}");
        }

        public virtual void SaveToFile(string fileName)
        {
            
        }

        public virtual void LoadFromFile(string fileName)
        {
            
        }

        public virtual async Task SaveToFileAsync(string fileName)
        {
            
        }

        public virtual async Task LoadFromFileAsync(string fileName)
        {
            
        }
    }
}
