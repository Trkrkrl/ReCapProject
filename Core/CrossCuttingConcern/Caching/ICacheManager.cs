using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);

        void Add(string key, object value, int duration);
        bool isAdd(string key);//cache de varmı kontrolü
        void Remove(string key);
        void RemoveByPattern(string pattern);// burrada patternden kastı- fonksiyon adında get varmı veya category varmı,
       
        //method adinda boyle şeyler olanları remove et-uçur yani

    }
}
