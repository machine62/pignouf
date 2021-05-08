using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using pignouf.Cst;
using pignouf.Utils;

namespace pignouf.Core
{
    class FENParser
    {
        string _fenBrut;
        string _position;
        bool _trait; // white true / black false
        private bool _WhitePR = false; // blanc petit roque, si true : possible
        private bool _WhiteGR = false;
        private bool _BlackPR = false;
        private bool _BlackGR = false;
        private Byte _NBCoup = 0;
        private Byte _derniereprise = 0;
        private Byte _PriseEnPassant = (byte)EnumCST.cases.nocase;




        public FENParser(string txt)
        {
            // récupération des elements d'un FEN
            string txtFEN = CleanUp(txt);
            _fenBrut = txtFEN.Trim();
            parseTxtFen();






        }

        private string CleanUp(string txt)
        {
            string message_retour;
            message_retour = Strings.Replace(txt, "position fen ", ""); // on retire aussi le " " pour la fonction split
                                                                        // faut effacer la suite : si jamais moves !!!
            if (message_retour.Contains(" moves "))
            {
                string[] txt_split = message_retour.Split(System.Convert.ToChar("moves "));
                // en renvoi uniquement la premiere partie
                message_retour = txt_split[0];
            }
            return message_retour;
        }


        private void parseTxtFen()
        {
            // https://en.wikipedia.org/wiki/Forsyth%E2%80%93Edwards_Notation

            // exemple :
            // r1bqkb1r/pp1ppppp/2n2n2/2p5/2P5/2N2N2/PP1PPPPP/R1BQKB1R w KQkq - 4 4 
            // 6 Champs au total

            string txtFEN = _fenBrut;

            string[] champs = txtFEN.Split(System.Convert.ToChar(" "));
            if (champs.Length != 6)
            {
                Console.WriteLine("Applytochessboard non implementé");
                throw new InvalidProgramException("Applytochessboard non implementé");
            }
            // Champ 1:  description de la position avec les lettres correspondant aux noms anglais 
            // Champ 2:  couleur au trait: w si c'est aux blancs de jouer, b pour les noirs
            // Champ 3:  validité des roques: la présence d'une lettre indique que le roque est possible; on utilise respectivement les lettres K et Q pour le petit et grand roque blanc, et les lettres k et q pour les noirs.Si aucun roque n'est possible, on utilise le caractère - 
            // Champ 4:  quand un pion a été joué, on indique la case d'arrivée d'un pion adverse qui pourrait le prendre en passant. Sinon - 
            // Champ 5:  nombre de demi-coups depuis une capture ou un mouvement de pion (utilisé pour la règle des 50 coups) 
            // Champ 6:  nombre de coups de la partie (incrémenté à chaque coup des blancs) 




            parseTxtFen_position(champs[0]);
            parseTxtFen_trait(champs[1]);
            parseTxtFen_roque(champs[2]);
            parseTxtFen_pap(champs[3]);

            if (champs[4] == "-")
                _NBCoup = 0;
            else if (System.Convert.ToInt32(champs[4]) > 0)
                _NBCoup = System.Convert.ToByte(champs[4]);

            if (champs[5] == "-")
                _NBCoup = 0;
            else if (System.Convert.ToInt32(champs[5]) > 0)
                _NBCoup = System.Convert.ToByte(champs[5]);




        }

        private void parseTxtFen_position(string txtFENpos)
        {
            string pos = txtFENpos;
            pos = pos.Replace("1", "0");
            pos = pos.Replace("2", "00");
            pos = pos.Replace("3", "000");
            pos = pos.Replace("4", "0000");
            pos = pos.Replace("5", "00000");
            pos = pos.Replace("6", "000000");
            pos = pos.Replace("7", "0000000");
            pos = pos.Replace("8", "00000000");
            // on remet dans un ordre lisible a8 => h8 ... a1 => h1
            string[] ligne;
            ligne = pos.Split(System.Convert.ToChar("/"));
            string position_fen = "";
            position_fen += ligne[7].ToString();
            position_fen += ligne[6].ToString();
            position_fen += ligne[5].ToString();
            position_fen += ligne[4].ToString();
            position_fen += ligne[3].ToString();
            position_fen += ligne[2].ToString();
            position_fen += ligne[1].ToString();
            position_fen += ligne[0].ToString();

            _position = position_fen;

        }

        private void parseTxtFen_trait(string txtFENtrait)
        {
            bool trait;
            if (txtFENtrait.Contains("w"))
                trait = true;
            else if (txtFENtrait.Contains("b"))
                trait = false;
            else
            {
                Console.WriteLine("Personne n'a la trait");
                throw new InvalidProgramException("Personne n'a la trait");
            }
            _trait = trait;


        }


        private void parseTxtFen_roque(string txtFENroque)
        {
            if (txtFENroque.Contains("K"))
                _WhitePR = true;
            if (txtFENroque.Contains("k"))
                _BlackPR = true;
            if (txtFENroque.Contains("Q"))
                _WhiteGR = true;
            if (txtFENroque.Contains("q"))
                _BlackGR = true;
        }

        private void parseTxtFen_pap(string txtFENpap)
        {

            // sinon on met l index de la case qui peut etre prise en passant ( 2*8 possibilite seulement)
            switch (txtFENpap)
            {
                case "a3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.a3; ;
                        break;
                    }

                case "b3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.b3; ;
                        break;
                    }

                case "c3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.c3;
                        break;
                    }

                case "d3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.d3;
                        break;
                    }

                case "e3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.e3;
                        break;
                    }

                case "f3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.f3;
                        break;
                    }

                case "g3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.g3;
                        break;
                    }

                case "h3":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.h3;
                        break;
                    }

                case "a6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.a6;
                        break;
                    }

                case "b6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.b6;
                        break;
                    }

                case "c6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.c6;
                        break;
                    }

                case "d6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.d6;
                        break;
                    }

                case "e6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.e6;
                        break;
                    }

                case "f6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.f6;
                        break;
                    }
                case "g6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.g6;
                        break;
                    }

                case "h6":
                    {
                        _PriseEnPassant = (byte)EnumCST.cases.h6;
                        break;
                    }
            }



        }




        //   private void parseTxtFen(string txtFEN);
        //  {   
        // exemple :
        // r1bqkb1r/pp1ppppp/2n2n2/2p5/2P5/2N2N2/PP1PPPPP/R1BQKB1R w KQkq - 4 4 
        // 6 Champs au total

        //   string[] champs = txtFEN.Split(System.Convert.ToChar(" "));
        //   Dim champs() As String
        //          champs = txt.Split(CChar(" "))




        //   }



        public void Applytochessboard(ref Chessboard board)
        {
            // on reinitialise le' echiquier
            board.ResetChessBoard();

            // on place les pieces dans les bitboard correspondant
            byte index = 0;
            foreach (char letter in _position)
            {
                if (letter == 'R')
                {
                    board.WRook = BitOperation.SetBit(board.WRook, index);
                 
                }
                if (letter == 'N')
                {
                    board.WKnight = BitOperation.SetBit(board.WKnight, index);
                }
                if (letter == 'B')
                {
                    board.WBishop = BitOperation.SetBit(board.WBishop, index);
                }
                if (letter == 'Q')
                {
                    board.WQueen = BitOperation.SetBit(board.WQueen, index);
                }
                if (letter == 'K')
                {
                    board.WKing = BitOperation.SetBit(board.WKing, index);
                }
                if (letter == 'P')
                {
                    board.WPawn = BitOperation.SetBit(board.WPawn, index);
                }

                if (letter == 'r')
                {
                    board.BRook = BitOperation.SetBit(board.BRook, index);
                }
                if (letter == 'n')
                {
                    board.BKnight = BitOperation.SetBit(board.BKnight, index);
                }
                if (letter == 'b')
                {
                    board.BBishop = BitOperation.SetBit(board.BBishop, index);
}
                if (letter == 'q')
                {
                    board.BQueen = BitOperation.SetBit(board.BQueen, index);
             
                }
                if (letter == 'k')
                {
                    board.BKing = BitOperation.SetBit(board.BKing, index);
                }
                if (letter == 'p')
                {
                    board.BPawn = BitOperation.SetBit(board.BPawn, index);
                }


                index++;
            }

            //roque
            board.castle = (int)EnumCST.castle.No;

            board.castle = (this._WhitePR) ? board.castle | (int)EnumCST.castle.WK : board.castle;
            board.castle = (this._WhiteGR) ? board.castle | (int)EnumCST.castle.WQ : board.castle;
            board.castle = (this._BlackPR) ? board.castle | (int)EnumCST.castle.BK : board.castle;
            board.castle = (this._BlackGR) ? board.castle | (int)EnumCST.castle.BQ : board.castle;


            //trait 
            board.Trait = (this._trait) ? EnumCST.Trait.White : EnumCST.Trait.Black;

            //autres
            board.DernierePrise = this._derniereprise;
            board.NBCoup = this._NBCoup;
            board.PriseEnPassant = this._PriseEnPassant;






        }
    }
}
