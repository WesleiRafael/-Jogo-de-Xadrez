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
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
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
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimentos == 0;
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
            pos.definirValores(posicao.linhas + 1, posicao.colunas + 1);
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
            // #jogadaespecial roque
            if (qtdMovimentos == 0 && !partida.xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(posicao.linhas, posicao.colunas + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linhas, posicao.colunas + 1);
                    Posicao p2 = new Posicao(posicao.linhas, posicao.colunas + 2);
                    if (tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.linhas, posicao.colunas + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(posicao.linhas, posicao.colunas - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linhas, posicao.colunas - 1);
                    Posicao p2 = new Posicao(posicao.linhas, posicao.colunas - 2);
                    Posicao p3 = new Posicao(posicao.linhas, posicao.colunas - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.linhas, posicao.colunas - 2] = true;
                    }
                }

            }
            return mat;
        }
    }
}

