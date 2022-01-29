using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        //aslında bir üst katman yapılırsa T ve entity şeklinde , bunlar da direkt implemente edebilirdik->ilerde yapacaz heralde
        IDataResult<List<Rental>> GetAll();//burada T yani Vustomer nesnesini kulalnabilmek için entitites te yaratmış olman gerekli
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

    }
}
