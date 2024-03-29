﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

        ICarDal _carDal; // bunu ctor ladık

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Car car)
        {
            
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]

        public IResult Delete(Car car)
        {
                return new Result(true, Messages.CarsDeleted);

        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]

        public IResult Update(Car car)
        {
                _carDal.Update(car);
                return new Result(true);
        }
        //--------------------------------------------

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()// bakım var emsajı gelecek şekilde yapalım bunu
        {
                if (DateTime.Now.Hour == 02 )
                    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

                return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.CarsListed);
            }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.brandId == id));
            }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.colorId == id));//bu C.ID doğru mu karı
            }

        [CacheAspect]
        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.carId == carId));//sağdaki serverden gelen sanirim
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
                if (DateTime.Now.Hour == 02)
                {
                    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
                }
                else
                {
                    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
                }
        }

        public IDataResult<Car> GetById(int carId)
        {
           return new SuccessDataResult<Car>(_carDal.Get(c => c.carId == carId));
        }

        //--asagisi frontend dto 177.odevde eklendi
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.brandId==brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.colorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.carId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(a=>a.colorId==colorId && a.brandId == brandId));
        }//-----------
        //findeks son odev
        public IDataResult<int> CarFindex(int carId)
        {
            var result = _carDal.Get(x => x.carId == carId);
            return new SuccessDataResult<int>(result.Findeks);
        }





        //  Business rules
        private IResult CheckIfCarIdExist(int carId)
        {
            var result = _carDal.GetAll(c => c.carId == carId);
            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
