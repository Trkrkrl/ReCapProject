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
    public class BrandManager : IBrandService

    {
        IBrandDal _brandDal;

        //10.gün 4. adım aşamalarında eski kodları sildik ve implementasyon ile , 3. adımda service te güncellenmiş olan kodları çektik
        //return leri yapalım şimdi
        //fakat öncesinde Business .Constants.Messages  classımızı yapalım ve içerrisinde mesajları tanımlaralım



        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, Messages.BrandDeleted);
        }


        [ValidationAspect(typeof(BrandValidator))]

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true);
        }
        //Ibrand service kırmmızı yandı- getall ı public yap dedi
        public IDataResult<List<Brand>> GetAll()//data, true false/ message
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(),true,Messages.CarsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.brandId == brandId));
        }

      
    }
}
