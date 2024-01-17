using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "R";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];


            Posicao pos = new Posicao(0, 0);
            //Posição acima
            pos.definirValores(posicao.linhas - 1, posicao.colunas);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }
            // Posição Nordeste
            pos.definirValores(posicao.linhas - 1, posicao.colunas + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }

            //Posição a direita

            pos.definirValores(posicao.linhas, posicao.colunas + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }
            //Posição a sudeste
            pos.definirValores(posicao.linhas+1, posicao.colunas + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }
            //Posição a baixo
            pos.definirValores(posicao.linhas + 1, posicao.colunas);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }
            //Posição a sudoeste
            pos.definirValores(posicao.linhas + 1, posicao.colunas - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }
            //Posição a esquerda
            pos.definirValores(posicao.linhas, posicao.colunas - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }
            //Posição a noroeste
            pos.definirValores(posicao.linhas - 1, posicao.colunas - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
            }
            return mat;
        }
    }
}
