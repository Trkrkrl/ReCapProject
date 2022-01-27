using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message)//bu kesin olumlu sonuç yani success ve; mesaj iletsin  isteyene kod
        {

        }
        public SuccessResult() : base(true)//bu ise mesaj yok sadece success
        {

        }
    }
}
