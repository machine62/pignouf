using System;
using System.Collections.Generic;
using System.Text;
using pignouf;
using pignouf.Cst;
using pignouf.Utils;

namespace pignouf.Core
{
    class MoveGen
    {
        List<MoveEncode> MovesList;
        Chessboard CB;
        public MoveGen(ref Chessboard board)
        {
           this.MovesList = new List<MoveEncode>();
           this.CB =  board;
        }


        public List<MoveEncode> GetAllMove 
        {
            get
            {
                return this.MovesList;
            } 
        }

        public void ResetMove()
        {
            List<MoveEncode> MovesList = new List<MoveEncode>();
        }

        public void CalculAllMove()
        {
            this.ResetMove();

            UInt64 ATTKing=0;
            UInt64 ATTQueen = 0;
            UInt64 ATTRook = 0;
            UInt64 ATTKnight = 0;
            UInt64 ATTBishop = 0;
            UInt64 ATTPawn = 0;
            UInt64 ATTAll = 0;

            UInt64 DEFKing = 0;
            UInt64 DEFQueen = 0;
            UInt64 DEFRook = 0;
            UInt64 DEFKnight = 0;
            UInt64 DEFBishop = 0;
            UInt64 DEFPawn = 0;
            UInt64 DEFAll = 0;

            UInt64 AllOcc = 0;


            if (CB.Trait == EnumCST.Trait.White)
            {
                ATTKing = CB.WKing;
                ATTQueen = CB.WQueen;
                ATTRook = CB.WRook;
                ATTKnight = CB.WKnight;
                ATTBishop = CB.WBishop;
                ATTPawn = CB.WBishop;
                ATTAll = CB.WOcc;

                DEFKing = CB.BKing;
                DEFQueen = CB.BQueen;
                DEFRook = CB.BRook;
                DEFKnight = CB.BKnight;
                DEFBishop = CB.BBishop;
                DEFPawn = CB.BBishop;
                DEFAll = CB.BOcc;

                AllOcc = CB.AllOcc;
            }
            else if (CB.Trait == EnumCST.Trait.Black)
            {
                DEFKing = CB.WKing;
                DEFQueen = CB.WQueen;
                DEFRook = CB.WRook;
                DEFKnight = CB.WKnight;
                DEFBishop = CB.WBishop;
                DEFPawn = CB.WBishop;
                DEFAll = CB.WOcc;

                ATTKing = CB.BKing;
                ATTQueen = CB.BQueen;
                ATTRook = CB.BRook;
                ATTKnight = CB.BKnight;
                ATTBishop = CB.BBishop;
                ATTPawn = CB.BBishop;
                ATTAll = CB.BOcc;

                AllOcc = CB.AllOcc;
            }

            // Coup possible
            //roi coup simple                ==================================  OK
            //roi coup d'attaque             ==================================  OK
            //roi roque                      ==================================  NO OK
            //reine coup simple              ==================================  NO OK
            //reine coup attaque             ==================================  NO OK
            //tour coup simple               ==================================  NO OK
            //tour coup attaque              ==================================  NO OK
            //cavalier coup simple           ==================================  OK
            //cavalier cou d attaque         ==================================  OK
            //fou coup simple                ==================================  NO OK
            //fou coup d'attaque             ==================================  NO OK
            //pions coup double ( + 1 + 2)   ==================================  NO OK
            //pions prise en passant         ==================================  NO OK
            //pions promotion                ==================================  NO OK

            // pour routine movegen
            UInt64 PatternATT;
            UInt64 PatternQuiet;

            ///!\\ ---------------------king---------------------//!\\\
            if (ATTKing != 0)
            {
                EnumCST.pieces ATTKingP;  // piece à bouger
                ATTKingP = (CB.Trait == EnumCST.Trait.White) ? EnumCST.pieces.WKing : EnumCST.pieces.BKing;
      

                byte FromSquare = BitOperation.BitScanForwardWithreset(ref ATTKing); // on recupere la case de la piece
                UInt64 pattern = MoveMask.KingMoveMask[FromSquare]; // on va chercher le pattern de mvt précalculé

                // Suppression des pieces de memes couleurs, on ne s'attaque pas
                 pattern = pattern & ~ATTAll;
               
                 PatternATT = pattern & DEFAll; // calcul coup Attaque
                 PatternQuiet = pattern & ~DEFAll; // coup calme

                //attaque
                if (PatternATT != 0)
                {
                    do
                    {
                        byte ToSquare = BitOperation.BitScanForwardWithreset(ref PatternATT);
                        MoveEncode MoveE = new MoveEncode();
                        MoveE.PieceMove = ATTKingP;
                        MoveE.SourceSquare = (EnumCST.cases)FromSquare;
                        MoveE.TargetSquare = (EnumCST.cases)ToSquare;
                        MoveE.isAttaque = true;

                        MovesList.Add(MoveE);
                    } while (PatternATT != 0); 
                }

                //coup calm
                if (PatternQuiet != 0)
                {
                    do
                    {
                        byte ToSquare = BitOperation.BitScanForwardWithreset(ref PatternQuiet);
                        MoveEncode MoveE = new MoveEncode();
                        MoveE.PieceMove = ATTKingP;
                        MoveE.SourceSquare = (EnumCST.cases)FromSquare;
                        MoveE.TargetSquare = (EnumCST.cases)ToSquare;
                        MoveE.isAttaque = false;

                        MovesList.Add(MoveE);
                    } while (PatternQuiet != 0);
                }

                //TODO roque\\




            }


            ///!\\ -------------------fin king-------------------------//!\\\

            ///!\\ -----------------------Knight---------------------//!\\\
            if (ATTKnight != 0)
            {
                EnumCST.pieces ATTKnightP;  // piece à bouger
                ATTKnightP = (CB.Trait == EnumCST.Trait.White) ? EnumCST.pieces.WKnight : EnumCST.pieces.BKnight;

                byte FromSquare = BitOperation.BitScanForwardWithreset(ref ATTKnight); // on recupere la case de la piece
                UInt64 pattern = MoveMask.KnightMoveMask[FromSquare]; // on va chercher le pattern de mvt précalculé

                // Suppression des pieces de memes couleurs, on ne s'attaque pas
                pattern = pattern & ~ATTAll;

                 PatternATT = pattern & DEFAll; // calcul coup Attaque
                 PatternQuiet = pattern & ~DEFAll; // coup calme

                //attaque
                if (PatternATT != 0)
                {
                    do
                    {
                        byte ToSquare = BitOperation.BitScanForwardWithreset(ref PatternATT);
                        MoveEncode MoveE = new MoveEncode();
                        MoveE.PieceMove = ATTKnightP;
                        MoveE.SourceSquare = (EnumCST.cases)FromSquare;
                        MoveE.TargetSquare = (EnumCST.cases)ToSquare;
                        MoveE.isAttaque = true;
                        MovesList.Add(MoveE);
                    } while (PatternATT != 0);
                }

                //coup calme
                if (PatternQuiet != 0)
                {
                    do
                    {
                        byte ToSquare = BitOperation.BitScanForwardWithreset(ref PatternQuiet);
                        MoveEncode MoveE = new MoveEncode();
                        MoveE.PieceMove = ATTKnightP;
                        MoveE.SourceSquare = (EnumCST.cases)FromSquare;
                        MoveE.TargetSquare = (EnumCST.cases)ToSquare;
                        MoveE.isAttaque = false;
                        MovesList.Add(MoveE);
                    } while (PatternQuiet != 0);
                }


            }
            ///!\\ ---------------------Fin Knight---------------------//!\\\

        }






    }
}
