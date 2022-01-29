using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult//altında bağlı olan classlar SuccessResult,ErrorResult ve DataResult
    {
        //IResultatn implemente ettiğimiz bu iki kodu get liyoz en alttaki
        //success ve message içeriği olan farklımkod kombinasyonlarımız vardı, dersten hatıral onları yapalım
        //ctorlayalım
        //sucess bool tipiindeydi
        //message string tipindeydi
        //burada iki tane ctor yapıyoruz, çünkü iki parametreden sadece biri verilirse, ve ikisi de verilirse durumları için
        //ctorların içerisine özel yapılan setleme işlemi yapıyoruz(sadece get yazmıştık bu sayede bu klasssta bir nevi setlemmiş olduk)



        public Result(bool success, string message) : this(success)
        {
            Message = message;
            //Success = success;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }

}