using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal()); bunun efcardal versiyonunu yazalım
            //CarTest();
            //brandtest
            //colortest
            //ColorTest();   testler daha sonra tekrar bak branddal vs kırmızı yanıydu
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {

                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {

                Console.WriteLine(brand.BrandName);
            }
        }
    }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());//Ef cardalımız yok-nereye kuracaz-in memory dataaccses concrete eydi-bu da data access entititframeworkte olmalı
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(
                             "Car's Description: " + item.CarName + " \n" +
                             "Car's Brand Name: " + item.BrandName + " \n" +
                             "Car's Color: " + item.ColorName + " \n" +
                             "Car's Daily Price: " + item.DailyPrice + " \n");

            }
        }
    }
}
        