using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {//10.gün 3. adım çalışmaları kapsamında servicelerdeki void->IResult ve List<> ->IDataResult<List<T>> şeklinde dönüştürülecek

        IDataResult<List<Brand>> GetAll();


        IDataResult<Brand> GetById(int brandId);
        //9. gün ödevinde unutmuşum -add-update-delete->Iresult oalcak 
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
