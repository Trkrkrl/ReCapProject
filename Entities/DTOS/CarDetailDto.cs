using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOS
{
    public class CarDetailDto:IDto
    {// CarName, BrandName, ColorName, DailyPrice
        
        public int carId { get; set; }
        public int colorId { get; set; }
        public int brandId { get; set; }
        public string modelYear { get; set; }
        public string modelName { get; set; }
        public string brandName { get; set; }
        public string colorName { get; set; }
        public decimal dailyPrice { get; set; }
        public string Description { get; set; }
        public List<string> ImagePath { get; set; }

        //car servicce de list olarakfonk ekle
        public bool IsRentable { get; set; }
    }
}
