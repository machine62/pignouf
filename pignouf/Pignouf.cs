using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using pignouf;
using pignouf.Core;


namespace pignouf
{
    class Pignouf
    {

        private Chessboard Chessboard;
        private Stack<MoveEncode> Move = new Stack<MoveEncode>();
        
    
        public  Pignouf()
        {
            MoveMask.InitMasks();

            Chessboard = new Chessboard();
            Chessboard.ResetChessBoard();
        }
        public void pignouf(string FENString )
        {
            
            MoveMask.InitMasks();

            Chessboard = new Chessboard();
            Chessboard.ResetChessBoard();
            FENParser FENp = new FENParser(FENString);
            FENp.Applytochessboard(ref Chessboard);
        }


              


     

    }
}
