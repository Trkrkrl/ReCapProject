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
    public class BrandManager : IBrandService

    {
        IBrandDal _brandDal;//bu kısmı yaz ctor yap , diğerleri de implementasyon ile gelecek-bu nu tüm managerlerde yap
        //veeeeeeeeeeeeeeeeeeeeeeeeeeeeeee unutma  _branddal gibi _ bişey varsa aşağıdaki fonkları return _ bişeyDal. fonk ile doldur mutlaka
        //p=>p.İd vs li bişeyler de olacak

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        //--aşağısı imlementasyondan geldi

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int BrandId)
        {
            return _brandDal.Get(b => b.Id == BrandId);//soldaki var olanlar dan(b den) id sin benim vereceğim id(sağdaki)ne eşit olanları getir -- tesadüfen ikisininnde yazımı aynı gelmiş

        }
    }
}
