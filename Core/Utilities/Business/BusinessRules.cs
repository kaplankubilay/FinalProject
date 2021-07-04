using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        /// <summary>
        /// "params" kullanıldığında "," ile istenildiği kadar parametreyi(liste halinde) gönderebiliriz.
        /// kuralları gez uymayan kural varsa döndür.
        /// </summary>
        /// <param name="logics"></param>
        /// <returns></returns>
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
