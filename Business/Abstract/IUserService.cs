using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    { //aslında bir üst katman yapılırsa T ve entity şeklinde , bunlar da direkt implemente edebilirdik->ilerde yapacaz heralde
        IDataResult<List<User>> GetAll();//burada T yani Vustomer nesnesini kulalnabilmek için entitites te yaratmış olman gerekli
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

    }
}
