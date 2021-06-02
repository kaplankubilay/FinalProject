using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    /// <summary>
    /// "DataResult<T>" hem Result hemde IDataResult üzerinden inherit edildi.
    /// "base" e success ve message ı gönerdik.
    /// base ile inherit edilen Result sınıfı referans edildi.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }

        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
