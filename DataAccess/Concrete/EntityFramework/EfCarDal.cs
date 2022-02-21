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
        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {//alttaki ksımı kopyaladım
            //SQL VERİTABANINA DİKKAT ET GEREKLİ TABLOLAR YAPILDI MI

            using (ReCapContext context=new ReCapContext())
            {var result = from a in context.Cars
                          join b in context.Brands on a.brandId equals b.brandId
                          join r in context.Colors on a.colorId equals r.colorId
                          select new CarDetailDto
                          {
                              // CarName, BrandName, ColorName, DailyPrice
                              CarName = a.Description,
                              BrandName = b.brandName,
                              ColorName = r.colorName,
                              DailyPrice = a.dailyPrice
                          };




                return result.ToList();

            }
        }
    }
}
