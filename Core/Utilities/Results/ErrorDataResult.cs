using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    /// <summary>
    /// girilecek değere göre 4 farklı kullanım versiyonu yapıldı.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ErrorDataResult<T> : DataResult<T>
    {
        /// <summary>
        /// data,durum,message
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        /// <summary>
        /// data,durum
        /// </summary>
        /// <param name="data"></param>
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        /// <summary>
        /// "default" data tipi ne verilirse onu kabul et.durum,message
        /// </summary>
        /// <param name="message"></param>
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        /// <summary>
        /// defaultdata,durum
        /// </summary>
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
