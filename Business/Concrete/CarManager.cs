using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {// program cs diyor ki burada ctor yok- ekledik Icardal_cardal ile

        ICarDal _cardal; // bunu ctor ladık

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }
        //-bunları da implementason ile getirdik
        public void Add(Car car)//araba ekleme fonk ve kurallarını yazacaz galiba
        {
            
            
                
                if (car.Description.Length > 2 && car.DailyPrice > 0)
                {
                    _cardal.Add(car);

                }
                else
                {
                    Console.WriteLine("Araba ismi en az 2 karakter olmalıdır ve günlük fiyat 0'dan büyük olmalıdır");

                }


        }

        public void Delete(Car car)
        {
            _cardal.Delete(car);
        }
        public void Update(Car car)
        {
            _cardal.Update(car);

        }

        //aşağıdakileri IcarService ten implementasyon ile getirdik
        public List<Car> GetAll()
        {
            return _cardal.GetAll();
        }

        

        public List<Car> GetAllByBrandId(int id)
        {
            return _cardal.GetAll(c => c.Id == id);
        }

       
        

       

        public List<Car> GetAllByColorId(int id)
        {
            return _cardal.GetAll(c => c.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()//bunun çalışması için ICardal a 
        {
            return _cardal.GetCarDetails();
        }
    }
}
