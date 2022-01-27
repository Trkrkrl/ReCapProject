using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
   public  class DataResult<T>:Result,IDataResult<T>//ErrorDataResult'u ve SucessDataResult'u bağlıyor
    {
        //sen bişr resultclassısın, onu içeriyorsun--result voidler içindi 
        
        
        public DataResult(T data, bool success, string message) : base(success, message)
        //data,işlemin sonucu, mesaj
        //bi zahmet base e de succses ve mesajı yolla-resulttaki success ve message gönderdiğimiz kodu bir daha yazmamamız anlamına geliyor

        {
            Data = data;

        }
        public DataResult(T data, bool success) : base(success)//mesajı gönndermek sitemeyebilridi
        {
            Data = data;
        }
        public T Data { get; }

    

    }
}
