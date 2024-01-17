using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    class Posicao
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.linhas = linha;
            this.colunas = coluna;
        }

        public void definirValores(int linhas, int colunas)
        {
            this.linhas = linhas;   
            this.colunas = colunas;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - linhas, colunas - 'a');
        }
        public override string ToString()
        {
            return linhas + " , " + colunas;
        }
    }
}
