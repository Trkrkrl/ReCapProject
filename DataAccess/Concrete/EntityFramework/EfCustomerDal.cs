using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerList(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                IQueryable<CustomerDetailDto> customerDetails = from u in context.Users
                                                                join cu in context.Customers on u.userId equals cu.userId

                                                                join r in context.Rentals on cu.customerId equals r.customerId

                                                                join cr in context.Cars on r.carId equals cr.carId

                                                                select new CustomerDetailDto
                                                                {
                                                                    UserId = u.userId,
                                                                    CustomerId = cu.customerId,
                                                                    CarId = cr.carId,
                                                                    CustomerName = u.firstName + " " + u.lastName,
                                                                    CompanyName = cu.companyName,
                                                                    Findeks = cu.findeks

                                                                };
                return filter == null ? customerDetails.ToList() : customerDetails.Where(filter).ToList();
            }
        }
    }
}
