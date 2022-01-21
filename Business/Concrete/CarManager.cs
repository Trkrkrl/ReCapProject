using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {// program cs diyor ki burada ctor yok- ekledik Icardal_cardal ile

        ICardal _cardal; // bunu ctor ladık

        public CarManager(ICardal cardal)
        {
            _cardal = cardal;
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
