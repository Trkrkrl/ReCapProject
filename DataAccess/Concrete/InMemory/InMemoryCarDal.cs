using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICardal
    {//InMemory formatta GetById, GetAll, Add, Update, Delete oprasyonlarını yazınız. bundan önce ICardal da yazmalıyız ve bunu ordan miras almalıyı

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                    new Car{Id=1,BrandId=1,ColorId=1, DailyPrice=5000, ModelYear="2007", Description="Undamaged"},
                    new Car{Id=2,BrandId=2,ColorId=1, DailyPrice=15000, ModelYear="2009", Description="Damaged"},
                    new Car{Id=3,BrandId=2,ColorId=5, DailyPrice=25000, ModelYear="2008", Description="Undamaged"},
                    new Car{Id=4,BrandId=3,ColorId=3, DailyPrice=500, ModelYear="2009", Description="Damaged"},
                    new Car{Id=5,BrandId=4,ColorId=2, DailyPrice=35000, ModelYear="2009", Description="Undamaged"},
                    new Car{Id=6,BrandId=5,ColorId=1, DailyPrice=45000, ModelYear="2000", Description="Damaged"},
                };

        }

    }
}
