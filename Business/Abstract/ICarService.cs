using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {//10.gün 3. adım çalışmaları kapsamında servicelerdeki void->IResult ve List<> ->IDataResult<List<T>> şeklinde dönüştürülecek
        IDataResult<List<Car>> GetAll();


        IDataResult<List<Car>> GetAllByBrandId(int id);

        IDataResult<List<Car>> GetAllByColorId(int id);

        
        IDataResult<List<CarDetailDto>> GetCarDetails();//
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);

        IResult Delete(Car car);
        //--sonradan eklenen-frontend istedi
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId,int brandId);



        IDataResult<int> CarFindex(int carId);








    }
}
