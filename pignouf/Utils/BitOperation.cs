using System;
using System.Collections.Generic;
using System.Text;
using pignouf;


namespace pignouf.Utils
{
    class BitOperation
    {
        /// <summary>
        ///  passe la valeur bit à 1 sur l'index defini 
        /// </summary>
        /// <param name="value">valeur à modifier</param>
        /// <param name="index">index du bit à modifier</param>
        public static UInt64 SetBit( UInt64 value, byte index)
        {
            value |= ((ulong)1 << index);
            return value;
        }

        /// <summary>
        ///  passe la valeur bit à 1 sur l'index defini 
        /// </summary>
        /// <param name="value">valeur à modifier</param>
        /// <param name="index">index du bit à modifier</param>
        public static void SetBit(ref UInt64 value, byte index)
        {
            value |= ((ulong)1 << index);
        }



        /// <summary>
        /// Verification de la presence d'un pion sur la case ( un 1 sur chaque bitboard )
        /// </summary>
        /// <param name="bit_board"></param>
        /// <param name="bit_board_de_la_case"></param>
        /// <returns></returns>
        public static bool CaseIsSet(UInt64 bit_board, UInt64 bit_board_de_la_case)
        {

            bool retour = ((bit_board & bit_board_de_la_case) != 0);
            return retour;
            // if ((bit_board & bit_board_de_la_case) != 0)
            //     return true;
            // else
            //     return false;
        }

        /// <summary>
        /// variante de la vérification de la presence recherche via un index
        /// </summary>
        /// <param name="bit_board"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool CaseIsSet(UInt64 bit_board, byte index)
        {
            UInt64 value = 0;
            SetBit(ref value, index);
            bool retour = ((bit_board & value) != 0);
            return retour;
        }



        public static UInt64 GetColumn(byte bitcase)
        {
            return (UInt64)bitcase & 7;
        }

        public static UInt64 Getline(byte bitcase)
        {
            return (UInt64)bitcase >> 3;
        }


        private const UInt64 DEBRUIJN64 = 0x03f79d71b4cb0a89;
        private static readonly Byte[] INDEX64 =
        {
             0, 47,  1, 56, 48, 27,  2, 60,
            57, 49, 41, 37, 28, 16,  3, 61,
            54, 58, 35, 52, 50, 42, 21, 44,
            38, 32, 29, 23, 17, 11,  4, 62,
            46, 55, 26, 59, 40, 36, 15, 53,
            34, 51, 20, 43, 31, 22, 10, 45,
            25, 39, 14, 33, 19, 30,  9, 24,
            13, 18,  8, 12,  7,  6,  5, 63
            };

        public static Byte BitScanForward(UInt64 bitmap)
        {
            //todo evaluer (System.Numerics.BitOperations.TrailingZeroCount(value);)
            // ne doit pas etre a 0(bitmap != 0);
            return INDEX64[((bitmap ^ (bitmap - 1)) * DEBRUIJN64) >> 58];
        }


        public static Byte BitScanForwardWithreset(ref UInt64 bitmap)
        {
            // ne doit pas etre a 0(bitmap != 0);
            byte index = INDEX64[((bitmap ^ (bitmap - 1)) * DEBRUIJN64) >> 58];
            //reset bit
            bitmap &= bitmap - 1;
            return index;

        }


    }
}
