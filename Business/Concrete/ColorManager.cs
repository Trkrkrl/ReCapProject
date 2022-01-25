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
    public class ColorManager : IColorService//implemente et  en üste dal ve ctor

    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int ColorId)
        {
            return _colorDal.Get(c => c.ColorId == ColorId);//sağdaki burada verilen yani birinin gireceği ve buraya gellecek değer- soldaki ise databasedeki

        }
    }
}
