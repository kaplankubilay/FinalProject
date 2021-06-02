using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    /// <summary>
    /// girilecek değere göre 4 farklı kullanım versiyonu yapıldı.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SuccessDataResult<T>:DataResult<T>
    {
        /// <summary>
        /// data,durum,message
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
            
        }
        /// <summary>
        /// data,durum
        /// </summary>
        /// <param name="data"></param>
        public SuccessDataResult(T data):base(data,true)
        {
            
        }

        /// <summary>
        /// "default" data tipi ne verilirse onu kabul et.durum,message
        /// </summary>
        /// <param name="message"></param>
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }
        /// <summary>
        /// defaultdata,durum
        /// </summary>
        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
