using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    /// <summary>
    /// IDataResult hem data döndürecek hemde IResult tan inherit edildiği için bool sonuç ve message döndürecek.
    /// interface tarafından miras alınan interface, ekstra implemente edilmesine gerek yok. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
