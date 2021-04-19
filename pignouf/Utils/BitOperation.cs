using System;
using System.Collections.Generic;
using System.Text;

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

    
    
    
    
    
    }
}
