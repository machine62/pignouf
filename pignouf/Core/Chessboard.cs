using System;
using System.Collections.Generic;
using System.Text;
using pignouf.Cst;


namespace pignouf.Core
{
    class Chessboard
    {

        // piece Roi 0  | Dame 1 | tour 2 | cavalier 3 | fou 4 | pion 5  *2
        //Blanc
        public UInt64 WKing { get; set; }
        public UInt64 WQueen { get; set; }
        public UInt64 WRook { get; set; }
        public UInt64 WKnight { get; set; }
        public UInt64 WBishop { get; set; }
        public UInt64 WPawn { get; set; }
        //Noir
        public UInt64 BKing { get; set; }
        public UInt64 BQueen { get; set; }
        public UInt64 BRook { get; set; }
        public UInt64 BKnight { get; set; }
        public UInt64 BBishop { get; set; }
        public UInt64 BPawn { get; set; }

        // A qui de jouer 
        public int Trait { get; set; }

        // enpassant 
        public int enpassant { get; set; }

        // Droit roque
        public int castle { get; set; }


        public byte NBCoup;
        public byte DernierePrise;
        public byte PriseEnPassant;

        public UInt64 WOcc {  get {return WKing | WQueen | WRook | WKnight | WBishop | WPawn ; } } // occupation blanche
        public UInt64 BOcc { get { return BKing | BQueen | BRook | BKnight | BBishop | BPawn; } } // occupation noir
        public UInt64 AllOcc { get { return WOcc | BOcc; } } // occupation Totale

        public void ResetChessBoard()
        {

            WKing = ulong.MinValue;
            WQueen = ulong.MinValue;
            WRook = ulong.MinValue;
            WKnight = ulong.MinValue;
            WBishop = ulong.MinValue;
            WPawn = ulong.MinValue;
            //Noir
            BKing = ulong.MinValue;
            BQueen = ulong.MinValue;
            BRook = ulong.MinValue;
            BKnight = ulong.MinValue;
            BBishop = ulong.MinValue;
            BPawn = ulong.MinValue;

            // A qui de jouer 
            Trait = (int)EnumCST.trait.No;

            // enpassant 
            enpassant = (int)Cst.EnumCST.cases.nocase;
        }





    }
}
