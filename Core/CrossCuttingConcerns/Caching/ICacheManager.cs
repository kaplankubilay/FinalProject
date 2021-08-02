using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    /// <summary>
    /// kullanılabilek tüm teknolojiler için bağımsız bir interface.
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Verilen key e göre değerini getir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        object Get(string key);

        /// <summary>
        /// Cache eklerken kullanılacak metot.
        /// </summary>
        /// <param name="key">Key değeri</param>
        /// <param name="value">Key e bağlı değer</param>
        /// <param name="duration">süre</param>
        void Add(string key, object value,int duration);

        /// <summary>
        /// cache te var mı kontrolü yapan metot.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsAdd(string key);

        /// <summary>
        /// cache ten silmek için kullanılacak metot.
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// REGEX-Reqular Epxressions ile içerisinde get olan metotların cache ini sil, şeklinde çalışacak kendi patternimizi yaptığımız metot.
        /// </summary>
        void RemoveByPattern(string pattern);
    }
}
