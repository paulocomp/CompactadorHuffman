using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Interface
{
    internal interface IArquivo<T>
    {
        public T Ler(string caminhoArquivo);
        public void Gravar(string caminhoArquivo, string conteudo);
    }
}
