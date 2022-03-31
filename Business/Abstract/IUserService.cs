using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);//bu vardı

        IResult Add(User user);//bu da vardı
        IResult Delete(User user);
        IResult Update(User user);

        IDataResult<User> GetByMail(string email);//bu da vardı
        IDataResult<User> GetByUserId(int userId);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByCustomerId(int customerId);

        IResult ChangeUserPassword(ChangePasswordDto changePasswordDto);
















        /*eski kodlari buraya yoruma aldim guvenemedim cunku yeni kodlara
         //aslında bir üst katman yapılırsa T ve entity şeklinde , bunlar da direkt implemente edebilirdik->ilerde yapacaz heralde
        IDataResult<List<User>> GetAll();//burada T yani Vustomer nesnesini kulalnabilmek için entitites te yaratmış olman gerekli
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);*/

    }
}
