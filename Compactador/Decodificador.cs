using CompactadorHuffman.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Compactador
{
    internal class Decodificador
    {
        public Decodificador() { }
        public string Descompactar(string conteudo, Dictionary<string, char> dicionarioInvertido)
        {
            ValidadorParametros.NuloOuVazio(conteudo, nameof(conteudo));
            ValidadorParametros.Nulo(dicionarioInvertido, nameof(dicionarioInvertido));

            StringBuilder resultado = new StringBuilder();
            string buffer = string.Empty;

            foreach (char bit in conteudo)
            {
                buffer += bit;

                if (dicionarioInvertido.TryGetValue(buffer, out char caractere))
                {
                    resultado.Append(caractere);
                    buffer = string.Empty;
                }
            }

            return resultado.ToString();
        }
    }
}
