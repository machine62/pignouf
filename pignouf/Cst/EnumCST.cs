using System;
using System.Collections.Generic;
using System.Text;

namespace pignouf.Cst
{
    class EnumCST
    {
        public enum pieces : byte
        {
            No = 0,
            WKing,
            WQueen,
            WRook,
            WKnight,
            WBishop,
            WPawn,
            BKing,
            BQueen,
            BRook,
            BKnight,
            BBishop,
            BPawn
        }

        public enum cases : byte
        {
            a1 = 0,
            b1 = 1,
            c1 = 2,
            d1 = 3,
            e1 = 4,
            f1 = 5,
            g1 = 6,
            h1 = 7,
            a2 = 8,
            b2 = 9,
            c2 = 10,
            d2 = 11,
            e2 = 12,
            f2 = 13,
            g2 = 14,
            h2 = 15,
            a3 = 16,
            b3 = 17,
            c3 = 18,
            d3 = 19,
            e3 = 20,
            f3 = 21,
            g3 = 22,
            h3 = 23,
            a4 = 24,
            b4 = 25,
            c4 = 26,
            d4 = 27,
            e4 = 28,
            f4 = 29,
            g4 = 30,
            h4 = 31,
            a5 = 32,
            b5 = 33,
            c5 = 34,
            d5 = 35,
            e5 = 36,
            f5 = 37,
            g5 = 38,
            h5 = 39,
            a6 = 40,
            b6 = 41,
            c6 = 42,
            d6 = 43,
            e6 = 44,
            f6 = 45,
            g6 = 46,
            h6 = 47,
            a7 = 48,
            b7 = 49,
            c7 = 50,
            d7 = 51,
            e7 = 52,
            f7 = 53,
            g7 = 54,
            h7 = 55,
            a8 = 56,
            b8 = 57,
            c8 = 58,
            d8 = 59,
            e8 = 60,
            f8 = 61,
            g8 = 62,
            h8 = 63,
            nocase = 250 // on se retrouve hors des 64 cases
        }

        public enum castle : int
        {
            No = 0,
            WK = 1 , //roque blanc coté roi
            WQ = 2 , //roque blanc coté dame
            BK = 4,  //roque noir coté roi
            BQ = 8,  //roque noir coté dame
            Full = 15,
        }

        public enum Trait : int
        {
            No = -1 ,
            White = 0,
            Black = 1
        }

    }

}
