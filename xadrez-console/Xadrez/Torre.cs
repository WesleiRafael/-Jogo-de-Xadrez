﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace Xadrez
{
    class Torre: Peca
    {
        public Torre(Tabuleiro tab,Cor cor ): base(tab , cor) {

        }
        public override string ToString()
        {
            return "T";

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
            while(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
                if(tab.peca(pos) != null && podeMover(pos)) {
                    break;
                        }
                pos.linhas = pos.linhas - 1;

            }
            //Posição a baixo
            pos.definirValores(posicao.linhas + 1, posicao.colunas);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
                if (tab.peca(pos) != null && podeMover(pos)) {
                    break;
                }
                pos.linhas = pos.linhas + 1;

            }
            //Posição a direita
            pos.definirValores(posicao.linhas , posicao.colunas +1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
                if (tab.peca(pos) != null && podeMover(pos)){
                    break;
                }
                pos.colunas = pos.colunas + 1;

            }
            //Posição a esquerda
            pos.definirValores(posicao.linhas, posicao.colunas -1 );
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linhas, pos.colunas] = true;
                if (tab.peca(pos) != null && podeMover(pos)) {
                    break;
                }
                pos.colunas = pos.colunas - 1;

            }

            return mat;
        }

    }
}
