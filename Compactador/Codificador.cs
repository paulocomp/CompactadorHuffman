using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactadorHuffman.Util;

namespace CompactadorHuffman.Compactador
{
    internal class Codificador
    {
        public Codificador() { }
        public string Compactar(string conteudo, Dictionary<char, string> dicionario)
        {
            ValidadorParametros.NuloOuVazio(conteudo, nameof(conteudo));
            ValidadorParametros.Nulo(dicionario, nameof(dicionario));

            StringBuilder resultado = new StringBuilder();

            foreach (char caractere in conteudo)
            {
                if (dicionario.TryGetValue(caractere, out string? codigo))
                {
                    resultado.Append(codigo);
                }
                else
                {
                    throw new KeyNotFoundException($"O caractere '{caractere}' não está presente no dicionário codificador.");
                }
            }

            return resultado.ToString();
        }
    }
}
