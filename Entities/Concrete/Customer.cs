using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]//CUSTOMER PRİMARY KEY İSTEDİ - YUKARDAKİ COMPONENTMODEL.DATAANNPTATIONS  kütüphanesini kullandık
        public int customerId { get; set; }
        public int userId { get; set; }//database table a da ekledik
        public string companyName { get; set; }
        public int findeks { get; set; }



    }
}
