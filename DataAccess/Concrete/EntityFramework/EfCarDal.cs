using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal //buraya bir context gelmeli:ReCapcontext imizi yaptık DataAccess.Concrete.EntityFramework'te 
    {
        public List<CarDetailDto> GetCarDetails()
        {//alttaki ksımı kopyaladım

            using (ReCapContext context=new ReCapContext())
            {var result = from c in context.Cars
                          join b in context.Brands on c.BrandId equals b.Id
                          join r in context.Colors on c.ColorId equals r.ColorId
                          select new CarDetailDto
                          {
                              // CarName, BrandName, ColorName, DailyPrice
                              CarName = c.Description,
                              BrandName = b.BrandName,
                              ColorName = r.ColorName,
                              DailyPrice = c.DailyPrice
                          };




                return result.ToList();

            }
        }
    }
}
