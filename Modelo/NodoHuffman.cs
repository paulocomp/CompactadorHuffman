using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactadorHuffman.Modelo
{
    internal class NodoHuffman
    {
        public char? Caractere { get; set; }
        public int Frequencia { get; set; }
        public NodoHuffman? Esquerda { get; set; }
        public NodoHuffman? Direita { get; set; }

        public NodoHuffman()
        {
            this.Caractere = null;
            this.Frequencia = 0;
            this.Direita = null;
            this.Esquerda = null;
        }

        public NodoHuffman(char caractere,int frequencia, NodoHuffman? esquerda, NodoHuffman? direita)
        {
            this.Caractere = caractere;
            this.Frequencia = frequencia;
            this.Esquerda = esquerda;
            this.Direita = direita;
        }

        public NodoHuffman(int frequencia, NodoHuffman? esquerda, NodoHuffman? direita)
        {
            this.Caractere = null;
            this.Frequencia = frequencia;
            this.Esquerda = esquerda;
            this.Direita = direita;
        }

        public NodoHuffman(char? caractere, int Frequencia)
        {
            this.Caractere = caractere;
            this.Frequencia = Frequencia;
            this.Esquerda = null;
            this.Direita = null;
        }

        public bool Folha()
        {
            return this.Esquerda == null && this.Direita == null;
        }
    }
}