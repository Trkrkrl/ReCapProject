using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)//bu kesin olumlu sonuç yani success ve; mesaj iletsin  isteyene kod
        {

        }
        public ErrorResult() : base(false)//bu ise mesaj yok sadece success
        {

        }
    }
}
