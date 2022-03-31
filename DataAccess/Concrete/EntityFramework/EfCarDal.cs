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
                                 findeks = a.Findeks,
                                 //image path
                                 ImagePath = (from m in context.CarImages where m.carId == a.carId select m.imagePath).ToList(),
                                 IsRentable = !context.Rentals.Any(r => r.carId == a.carId) || !context.Rentals.Any(r => r.carId == a.carId && (r.returnDate == null || (r.returnDate.HasValue && r.returnDate > DateTime.Now)))
                             };//is rentable açıklaması:  rental içerisinde söylenen carid de bir car HİÇ YOK MU veya(rental içerisinde istenen car idye sahip ve( dönüş tarihi olmayan veya (dönüş tarihi olup ta şu anki tarihten ileri olan)))
                // yapana helal olsun  aracın dönüş tarihi yoksa, kiralanmışlar listesinde yoksa ture döner yani kiralanabilir

                return filter == null ? result.ToList() : result.Where(filter).ToList();


            }
        }
    }
}
