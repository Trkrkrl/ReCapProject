using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOS;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {//InMemory formatta GetById, GetAll, Add, Update, Delete oprasyonlarını yazınız. bundan önce ICardal da yazmalıyız ve bunu ordan miras almalıyı

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                   /* new Car{CarID=1,BrandId=1,ColorId=1, DailyPrice=5000, ModelYear="2007", Description="Undamaged"},
                    new Car{CarID=2,BrandId=2,ColorId=1, DailyPrice=15000, ModelYear="2009", Description="Damaged"},
                    new Car{CarID=3,BrandId=2,ColorId=5, DailyPrice=25000, ModelYear="2008", Description="Undamaged"},
                    new Car{CarID=4,BrandId=3,ColorId=3, DailyPrice=500, ModelYear="2009", Description="Damaged"},
                    new Car{CarID=5,BrandId=4,ColorId=2, DailyPrice=35000, ModelYear="2009", Description="Undamaged"},
                    new Car{CarID=6,BrandId=5,ColorId=1, DailyPrice=45000, ModelYear="2000", Description="Damaged"},*/
                };

        }
        //buranın implementastonu unutulmuştu düzenlendi
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(item => item.carId == car.carId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.carId ==Id ).ToList();
        }

        

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(item => item.carId == car.carId);
            carToUpdate.carId = car.carId;
            carToUpdate.modelYear = car.modelYear;
            carToUpdate.dailyPrice = car.dailyPrice;
            carToUpdate.brandId = car.brandId;
            carToUpdate.Description = car.Description;
            carToUpdate.colorId = car.colorId;
        }
    }
}
