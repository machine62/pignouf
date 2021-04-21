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




    }
}
