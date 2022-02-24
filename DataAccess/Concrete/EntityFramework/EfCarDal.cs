using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal //buraya bir context gelmeli:ReCapcontext imizi yaptık DataAccess.Concrete.EntityFramework'te 
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from a in context.Cars
                             join b in context.Brands on a.brandId equals b.brandId
                             join r in context.Colors on a.colorId equals r.colorId

                             select new CarDetailDto
                             {
                                 // CarName, BrandName, ColorName, DailyPrice
                                 carId = a.carId,
                                 colorId = r.colorId,
                                 brandName = b.brandName,
                                 colorName = r.colorName,
                                 modelYear = a.modelYear,
                                 dailyPrice = a.dailyPrice,
                                 brandId = b.brandId,
                                 modelName = a.modelName,
                                 Description = a.Description,
                                 //image path
                                 imagePath = (from m in context.CarImages where m.carId == a.carId select m.imagePath).FirstOrDefault()

                             };




                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
