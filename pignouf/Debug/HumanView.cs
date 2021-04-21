using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using pignouf.Utils;
using pignouf.Core;

namespace pignouf.Debug
{

    /// <summary>
    /// Representation visuelle des bitboards/chessboard
    /// </summary>
    class HumanView
{


        public static void MsgBitboard(ulong value, string txt = "affiche bitboard")
        {
            String StrReadableBitboard = UInt64toReadable(value);
            MessageBox((IntPtr)0, StrReadableBitboard, txt, 0);
        }
        public static void CnlBitboard(ulong value, string txt = "")
        {
            String StrReadableBitboard = UInt64toReadable(value);
            System.Diagnostics.Debug.WriteLine(txt);
            System.Diagnostics.Debug.WriteLine(StrReadableBitboard);
        }


        public static void MsgChessBoard(Chessboard CB, string txt = "affiche bitboard")
        {
            String StrReadableBitboard = ChessboardtoReadable(CB);
            MessageBox((IntPtr)0, StrReadableBitboard, txt, 0);
        }
        public static void CnlChessBoard(Chessboard CB, string txt = "affiche Chessboard")
        {
            String StrReadableBitboard = ChessboardtoReadable(CB);
            System.Diagnostics.Debug.WriteLine(txt);
            System.Diagnostics.Debug.WriteLine(StrReadableBitboard);
        }



        private static string UInt64toReadable(ulong value, string PieceRepresentation = "1", string EmptyRepresentation = "0")

        {
            string str = "";
            // positionnement des 1 / 0
            for (byte i = 0; i < 64; i++)
            {
                UInt64 nbTest = 0;
                BitOperation.SetBit(ref nbTest, i);
                if (BitOperation.CaseIsSet(value, nbTest))
                {
                    str += PieceRepresentation;
                }
                else
                {
                    str += EmptyRepresentation;
                }


            }
            string transfo = "";
            for (var i = 1; i <= 8; i++)
            {
                transfo = (Strings.Mid(str, 1 + ((i - 1) * 8), 8)) + Constants.vbCrLf + transfo;
            }

            return transfo;

        }


        private static string ChessboardtoReadable(Chessboard CB)
        {
            string str = "";
            // positionnement des 1 / 0
            for (byte i = 0; i < 64; i++)
            {
                String StrToAdd = "-";
                UInt64 nbTest = 0;
                BitOperation.SetBit(ref nbTest, i);

                //Blanc
                StrToAdd = (BitOperation.CaseIsSet(CB.WKing, nbTest)) ? "K" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.WQueen, nbTest)) ? "Q" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.WRook, nbTest)) ? "R" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.WKnight, nbTest)) ? "N" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.WBishop, nbTest)) ? "B" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.WPawn, nbTest)) ? "P" : StrToAdd;

                //noir
                StrToAdd = (BitOperation.CaseIsSet(CB.BKing, nbTest)) ? "k" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.BQueen, nbTest)) ? "q" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.BRook, nbTest)) ? "r" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.BKnight, nbTest)) ? "n" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.BBishop, nbTest)) ? "b" : StrToAdd;
                StrToAdd = (BitOperation.CaseIsSet(CB.BPawn, nbTest)) ? "p" : StrToAdd;



                str += StrToAdd;
            }


            string transfo = "";
            for (var i = 1; i <= 8; i++)
            {
                transfo = (9-i).ToString() +"   " + (Strings.Mid(str, 1 + ((i - 1) * 8), 8)) + Constants.vbCrLf + transfo;
            }
            transfo = transfo + Constants.vbCrLf + "    abcdefgh";
            return transfo;

        }





        // pour permettre affichae messageBox
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr h, string m, string c, int type);
    }
}
