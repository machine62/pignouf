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




        public static void InitMasks()
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




                // Knight Masks
                Mask = 0;
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







    }
}
