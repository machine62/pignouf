using System;
using pignouf;
using pignouf.Core;


namespace pignouf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            do
            {
                string cmdString = Console.ReadLine();
                
                if (cmdString != null && cmdString != "")
                {
                    Console.WriteLine(cmdString);

                    MoveMask.InitMasks();

                    //Chessboard CB = new Chessboard();
                    //FENParser FEN = new FENParser("r3k2r/p1ppqpb1/bn2pnp1/3PN3/1p2P3/2N2Q1p/PPPBBPPP/R3K2R w KQkq - 0 1 ");
                    //FEN.Applytochessboard(ref CB);
                    //Debug.HumanView.CnlChessBoard(CB);

                    }

            } while (true);

        }






    }
}
