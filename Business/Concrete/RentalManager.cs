using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //-----------------------------------
        [ValidationAspect(typeof(RentalValidator))]

        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsCarAvailable(rental.carId)); //, CheckIfFindeks(rental.CarID, rental.CustomerID));

            if(result != null)
            {
                return new ErrorResult();
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
             return new SuccessDataResult<Rental>(Messages.RentalDeleted);
           // return new Result(true, Messages.RentalDeleted);
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true);
        }

        public IDataResult<List<Rental>> GetAll()//buradadata result list t verilmiş aşağısı da öyle oalcak
        {
            
            return new DataResult<List<Rental>>  (_rentalDal.GetAll(),true, Messages.RentalListed);//data bool ve mesaj istiyor
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.rentalId==rentalId));
        }
        //---
        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        //-----
        private IResult IsCarAvailable(int carId)
        {
            var result = _rentalDal.GetAll(c => c.carId == carId && (c.rentDate == null || c.returnDate > DateTime.Now)).Any();
            if (result)
            {
                return new ErrorResult(Messages.NotAvailable);
            }

            return new SuccessResult();
        }


    }
}
