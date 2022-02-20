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
        public int CusID { get; set; }
        public int UserID { get; set; }//database table a da ekledik
        public string CompanyName { get; set; }



    }
}
