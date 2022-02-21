using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims//küçük harfle başlayan  büyüğü temsil ediyor
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.operationClaimId equals userOperationClaim.operationClaimId
                             where userOperationClaim.userId == user.Id
                             select new OperationClaim { operationClaimId = operationClaim.operationClaimId, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
