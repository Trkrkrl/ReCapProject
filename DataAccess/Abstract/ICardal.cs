using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> 
    {// GetById, GetAll, Add, Update, Delete oprasyonlarını yazmalıyız ki inmemorye miras olarak verebilelim
        //ilerde entitity repositoryden alacağız muhtemelen
            
       
        
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);//car manager den generate method ile aldık

        //--frontend için eklenen kısım silind bunun yerine yukaridaki fonksiiyon icerisine expression  ve filter getirildi
       

    }
}
