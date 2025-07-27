using CompactadorHuffman.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Compactador
{
    internal class GeradorArvore
    {
        public NodoHuffman Gerar(PriorityQueue<NodoHuffman, int> listaFrequencia)
        {
            while (listaFrequencia.Count > 1)
            {
                NodoHuffman menor1 = listaFrequencia.Dequeue();
                NodoHuffman menor2 = listaFrequencia.Dequeue();

                int somaFrequencias = menor1.Frequencia + menor2.Frequencia;

                NodoHuffman novoNodo = new NodoHuffman
                {
                    Caractere = null,
                    Frequencia = somaFrequencias,
                    Esquerda = menor1,
                    Direita = menor2
                };

                listaFrequencia.Enqueue(novoNodo, novoNodo.Frequencia);
            }

            return listaFrequencia.Dequeue();
        }
    }
}
