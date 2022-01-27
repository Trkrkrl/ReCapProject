using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {//successdata resultu çevirerek yazdık
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)//mesaj olayına girmek istemezse-sadece data ver
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)//nadiren de olsa datayı default , sadece mesaj gönder
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
