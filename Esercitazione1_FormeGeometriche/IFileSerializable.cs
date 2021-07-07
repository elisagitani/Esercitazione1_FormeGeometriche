using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione1_FormeGeometriche
{
    interface IFileSerializable
    {
        public void SaveToFile(string fileName);
        public void LoadFromFile(string fileName);
        public Task SaveToFileAsync(string fileName);
        public Task LoadFromFileAsync(string fileName);
    }
}
