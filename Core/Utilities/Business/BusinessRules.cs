using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;///parametre  il gönderilen iş kurallarında başarısız olanı business a haber ediyoruz
                }///business kardeş bak bu logic hatalı


            }
            return null;//başarılı is bişşey göndermesi gerekmez

        }
    }
}
