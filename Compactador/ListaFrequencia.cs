using CompactadorHuffman.Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Compactador
{
    internal class ListaFrequencia
    {
        public PriorityQueue<NodoHuffman, int> Gerar(string conteudo)
        {
            Dictionary<char, int> frequencias = new();

            foreach (char c in conteudo)
            {

                if ((char.IsControl(c) && c != '\n' && c != '\r' && c != '\t') || char.GetUnicodeCategory(c) == UnicodeCategory.OtherNotAssigned)
                {
                    continue;
                }

                if (frequencias.ContainsKey(c))
                {
                    frequencias[c]++;
                }
                else
                {
                    frequencias[c] = 1;
                }
            }

            PriorityQueue<NodoHuffman, int> fila = new();

            foreach (var par in frequencias)
            {
                NodoHuffman nodo = new(par.Key, par.Value);
                fila.Enqueue(nodo, nodo.Frequencia);
            }

            return fila;
        }
    }
}