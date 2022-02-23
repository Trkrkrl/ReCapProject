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

            return JoinTablolama();
        }


        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            return JoinTablolama();
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            return JoinTablolama();
        }

        public List<CarDetailDto> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            return JoinTablolama();
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            return JoinTablolama();
        }



        private static List<CarDetailDto> JoinTablolama()
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




                return result.ToList();

            }
        }

    }
}
