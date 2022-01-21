using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICardal
    {// GetById, GetAll, Add, Update, Delete oprasyonlarını yazmalıyız ki inmemorye miras olarak verebilelim
        //ilerde entitity repositoryden alacağız muhtemelen

        List<Car> GetAll();
        List<Car> GetById();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
