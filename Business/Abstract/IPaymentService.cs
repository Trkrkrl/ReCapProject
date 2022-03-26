using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
        IDataResult<Payment> GetById(int paymentId);
        IDataResult<List<Payment>> GetAll();
    }
}
