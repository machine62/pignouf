using System;
using System.Collections.Generic;
using System.Text;
using pignouf.Cst;

namespace pignouf.Core
{
    struct MoveEncode
    {
        // encoder tout cela sur un int https://www.chessprogramming.org/Encoding_Moves#From-To_Based
        public EnumCST.cases SourceSquare;
        public EnumCST.cases TargetSquare;
        public EnumCST.pieces PieceMove;
        public Boolean isAttaque;// si prise
        public EnumCST.pieces PiecePromote;// si promotion

        public Boolean Castle; // si roque
        public Boolean Pep; // si prise en passant
        public Boolean PanwDoublePush; // genere une case possible de pep sur chessboard





        //FAire function
        // is capture
        //....



    }
}
