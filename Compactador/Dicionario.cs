using CompactadorHuffman.Interface;
using CompactadorHuffman.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Compactador
{
    internal class Dicionario
    {
        public Dictionary<char, string> Gerar(IArvore arvore)
        {
            Dictionary<char, string> dicionario = new();
            arvore.Percorrer((caractere, codigo) => dicionario[caractere] = codigo);
            return dicionario;
        }

        public Dictionary<string, char> Inverter(Dictionary<char, string> dicionarioHuffman)
        {
            if (dicionarioHuffman == null || dicionarioHuffman.Count == 0)
            {
                throw new ArgumentException("O dicionário não pode ser nulo ou vazio.", nameof(dicionarioHuffman));
            }

            return dicionarioHuffman.Where(kv => kv.Key != '\0').ToDictionary(kv => kv.Value, kv => kv.Key);
        }
    }
}