using System;
using System.Collections.Generic;
using System.Text;

namespace pignouf.Core
{
    class Perft
    {
        private Chessboard CB;

        public Perft(ref Chessboard Board)
        {
            CB = Board;
        }


        public UInt64 simpleperft(int depth)
        {
            MoveGen Movegenerator = new MoveGen(ref CB);

            List<MoveEncode> ListMove = Movegenerator.GetAllMove;

            int n_moves, i;
            UInt64 nodes = 0;

            if (depth == 0)
                return 1UL;

            n_moves = ListMove.Count;
            for (i = 0; i < n_moves; i++)
            {
                //faire mvt
                //si mvt n'expose pas le roi on lance node+= simpleperft(i-1) 
                //on retire le mvt 
            }
            return nodes;

        }



    }




}
