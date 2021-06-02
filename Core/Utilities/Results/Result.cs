using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        /// <summary>
        /// iki parametre alan ctor.
        /// :this demek Result sınıfını temsil eder. "Bu metodu" da çalıştır anlamındadır. 
        /// </summary>
        /// <param name="message"></param>
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        /// <summary>
        /// tek parametre alan ctor.
        /// </summary>
        /// <param name="success"></param>
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}