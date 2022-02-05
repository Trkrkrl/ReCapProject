using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            if (rental.ReturnDate.Year == 2022)
            {
                _rentalDal.Add(rental);
                return new SuccessDataResult<Rental>(Messages.RentalAdded);
            }
            else
                return new ErrorDataResult<Rental>(Messages.RentalFailed);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
             return new SuccessDataResult<Rental>(Messages.RentalDeleted);
           // return new Result(true, Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()//buradadata result list t verilmiş aşağısı da öyle oalcak
        {
            
            return new DataResult<List<Rental>>  (_rentalDal.GetAll(),true, Messages.RentalListed);//data bool ve mesaj istiyor
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id==rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true);
        }
    }
}
