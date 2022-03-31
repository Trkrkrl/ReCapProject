using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {//Id, BrandId, ColorId, ModelYear, DailyPrice, Description
        public int carId { get; set; }
        public int brandId { get; set; }
        public int colorId { get; set; }
        public string modelYear { get; set; }
        public decimal dailyPrice { get; set; }
        public string modelName { get; set; }//bunu yanlış  yazmıştık
        public string Description { get; set; }

        //
        public int Findeks { get; set; }
    }
}
