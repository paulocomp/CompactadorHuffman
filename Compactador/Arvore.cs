using CompactadorHuffman.Interface;
using CompactadorHuffman.Modelo;
using CompactadorHuffman.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Compactador
{
    internal class Arvore : IArvore
    {
        private readonly NodoHuffman _raiz;

        public Arvore(NodoHuffman raiz)
        {
            _raiz = raiz ?? throw new ArgumentNullException(nameof(raiz));
        }

        public void Percorrer(Action<char, string> aoEncontrarFolha)
        {
            PercorrerInterno(_raiz, "", aoEncontrarFolha);
        }

        private void PercorrerInterno(NodoHuffman nodo, string caminho, Action<char, string> aoEncontrarFolha)
        {
            if (nodo == null)
            {
                return;
            }

            if (nodo.Folha() && nodo.Caractere.HasValue)
            {
                aoEncontrarFolha(nodo.Caractere.Value, caminho);
            }

            if (nodo.Esquerda != null)
            {
                PercorrerInterno(nodo.Esquerda, caminho + "0", aoEncontrarFolha);
            }

            if (nodo.Direita != null)
            {
                PercorrerInterno(nodo.Direita, caminho + "1", aoEncontrarFolha);
            }
        }
    }
}