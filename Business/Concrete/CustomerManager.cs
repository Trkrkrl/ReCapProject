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
    public class CustomerManager : ICustomerService

    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }



        //------------------------------------------//not: messages i güncellemeyi unutma ki aşapıda mesaj verecez
        [ValidationAspect(typeof(CustomerValidator))]

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessDataResult<Customer>(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new Result(true, Messages.CustomerDeleted);  
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new DataResult<List<Customer>>(_customerDal.GetAll(), true, Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(C=> C.customerId == customerId));
        }
        //-getbyuserid sonradan eklendi
        public IDataResult<Customer> GetByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.userId == userId));
        }
        //-
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);//I resultta result oluyor-update de mesaj veya eri gelimyo sadece bool
            return new Result(true);
        }
    }
}
