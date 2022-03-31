using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOS
{
    public class CustomerDetailDto : IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int Findeks { get; set; }

    }
}
