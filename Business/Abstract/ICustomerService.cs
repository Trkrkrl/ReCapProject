using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        //aslında bir üst katman yapılırsa T ve entity şeklinde , bunlar da direkt implemente edebilirdik->ilerde yapacaz heralde
        IDataResult<List<Customer>> GetAll();//burada T yani Vustomer nesnesini kulalnabilmek için entitites te yaratmış olman gerekli
        IDataResult<Customer> GetById(int customerId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);



    }
}
