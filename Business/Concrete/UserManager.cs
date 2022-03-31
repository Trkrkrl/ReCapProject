using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
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
using Core.Utilities.Security.Hashing;
using System.Security.Cryptography.X509Certificates;

namespace Business.Concrete
{
    public class UserManager : IUserService
        
    {// ctro ile _dallı yapımızı unutmayalım-bunun için gerekli dal interfaceini da yapmayı unutmayalım-konum:dataaccesss.abstract
        IUserDal _userDal;
        ICustomerDal _customerDal;

        public UserManager(IUserDal userDal,ICustomerDal customerDal)
        {
            _userDal = userDal;
            _customerDal =customerDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.GetAll(u => u.Email == email).FirstOrDefault());
        }
        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessDataResult<Customer>(Messages.CustomerAdded);
        }
        //aşağıdakiler yeni

        public IResult Delete(User user)
        {
            var result = BusinessRules.Run(CheckIfUserExists(user.userId));
            if (result != null)
            {
                return new ErrorResult(Messages.UserCantDeleted);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

       

        public IResult Update(User user)
        {

            var currentUser = _userDal.Get(u => u.userId == user.userId);
            if (currentUser == null)
            {
                return new ErrorResult("User Doesn't exists");
            }

            var userForUpdate = user;
            userForUpdate.Status = currentUser.Status;
            userForUpdate.passwordHash = currentUser.passwordHash;
            userForUpdate.passwordSalt = currentUser.passwordSalt;
            _userDal.Update(userForUpdate);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.userId == userId), Messages.GetByUserId);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.userId== customerId), Messages.UserByCustomerId);
        }

        public IResult ChangeUserPassword(ChangePasswordDto changePasswordDto)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = GetByMail(changePasswordDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(changePasswordDto.OldPassWord, userToCheck.Data.passwordHash, userToCheck.Data.passwordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.Data.passwordHash = passwordHash;
            userToCheck.Data.passwordSalt = passwordSalt;
            _userDal.Update(userToCheck.Data);
            return new SuccessResult(Messages.passwordChanged);
        }
        //business rule



        private IResult CheckIfUserExists(int userId)
        {
            var result = _userDal.Any(x => x.userId == userId);
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
