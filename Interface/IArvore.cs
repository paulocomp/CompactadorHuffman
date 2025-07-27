using CompactadorHuffman.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Interface
{
    internal interface IArvore
    {
        public void Percorrer(Action<char, string> aoEncontrarFolha);
    }
}
