using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOS
{
    public class RentalDetailDto
    {
        public int rentalId { get; set; }

        public int carId { get; set; }
        public int brandId { get; set; }
        public int customerId { get; set; }

        public string colorName { get; set; }
        public string brandName { get; set; }
        public string modelName { get; set; }
        public string customerName { get; set; }
        public string customerLastname { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }//soru isareti enden null olabileceginden mi acaba
        
        


    }
}
