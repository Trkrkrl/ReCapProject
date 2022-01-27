using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)//mesaj olayına girmek istemezse-sadece data ver
        {

        }
        public SuccessDataResult(string message) : base(default, true, message)//nadiren de olsa datayı default , sadece mesaj gönder
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
