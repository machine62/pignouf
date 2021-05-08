using System;
using System.Collections.Generic;
using System.Text;
using pignouf.Utils;
using pignouf.Cst;



namespace pignouf.Core
{
    /// <summary>
    /// Mouvements précalculés
    /// </summary>
    class MoveMask
    {

        static public UInt64[] KingMoveMask = new UInt64[64];
        static public UInt64[] KnightMoveMask = new UInt64[64];

        //pion attaque
        static public UInt64[,] PawnMoveMaskA = new UInt64[2, 64];





        public static void InitMasks()
        {
            InitMasksKing();
            InitMasksKnight();

            InitMasksPawnA();
        }
        private static void InitMasksKing()
        {
            // King Masks
            for (int i = 0; i < 64; i++)
            {
                UInt64 Mask = 0;
                Mask |= ((ulong)1 << i);

                // on effectue une horizontale de 3 bit
                Mask = Mask | (Mask << 1) & ~BitCST.col_1;
                Mask = Mask | (Mask >> 1) & ~BitCST.col_8;

                // on decale de +8 et de - 8
                Mask = Mask | (Mask << 8) | (Mask >> 8);

                // on supp la place du roi du pattern
                Mask = Mask ^ ((ulong)1 << i);

                KingMoveMask[i] = Mask;
                //System.Diagnostics.Debug.WriteLine("index : " + i);
                //Debug.HumanView.CnlBitboard(Mask);

            }
        }



        private static void InitMasksKnight()
        {
            // King Masks
            for (int i = 0; i < 64; i++)
            {

                // Knight Masks
                UInt64 Mask = 0;
                Mask |= ((ulong)1 << i);

                UInt64 pattern1 = 0;
                UInt64 pattern2 = 0;


                pattern1 = (((Mask << 10) | (Mask >> 6)) & ~(BitCST.col_2));
                pattern1 = (pattern1 | ((Mask << 17) | (Mask >> 15))) & ~(BitCST.col_1);

                pattern2 = (((Mask >> 10) | (Mask << 6)) & ~(BitCST.col_7));
                pattern2 = (pattern2 | ((Mask >> 17) | (Mask << 15))) & ~(BitCST.col_8);


                Mask = pattern1 | pattern2;
                KnightMoveMask[i] = Mask;

                //System.Diagnostics.Debug.WriteLine("index : " + i);
                //Debug.HumanView.CnlBitboard(KnightMoveMask[i]);

            }
        }




        private static void InitMasksPawnA()
        {

            //Blancs
            // normalement a borner  de 8 a 57
            // 00000000
            // 11111111
            // 11111111
            // 11111111
            // 11111111
            // 11111111
            // 11111111
            // 00000000
            for (int i = 0; i < 64; i++)
            {

                UInt64 Mask = 0;
                Mask |= ((ulong)1 << i);
                // le pion peut prendre à +7 et +9
                Mask = (Mask << 9 & BitCST.SquareFullNoCol_1) | (Mask << 7 & BitCST.SquareFullNoCol_8);
                PawnMoveMaskA[(int)Cst.EnumCST.Trait.White, i] = Mask;
                //System.Diagnostics.Debug.WriteLine("index : " + i);
                //Debug.HumanView.CnlBitboard(PawnMoveMaskA[(int)Cst.EnumCST.Trait.White, i]);

            }

            // Noir
            for (int i = 0; i < 64; i++)
            {

                UInt64 Mask = 0;
                Mask |= ((ulong)1 << i);
                // le pion peut prendre à +7 et +9
                Mask = (Mask >> 9 & BitCST.SquareFullNoCol_8) | (Mask >> 7 & BitCST.SquareFullNoCol_1);
                PawnMoveMaskA[(int)Cst.EnumCST.Trait.Black, i] = Mask;
                System.Diagnostics.Debug.WriteLine("index : " + i);
                Debug.HumanView.CnlBitboard(PawnMoveMaskA[(int)Cst.EnumCST.Trait.Black, i]);

            }

        }








    }
}
