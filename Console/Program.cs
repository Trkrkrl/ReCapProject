using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
            //car test 2. olarak 1 tane daha yaptım

            //!!!!!!!!!!!!!!!! dikkat sql tablolarında 1 er tane renk , brand ve araba ekle sırassyıla , veri yoksa veri göstermezz

            // CarTest2();
            //10. gün 4. ödev kapsamında rental testi yapıalcaktır
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer
            {
                companyName = "North Star Inc."
            });


            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                Email = "asd@asd.com",
                firstName = "TESTKULLANICIADI",
                lastName = "TESTSOYAD",
                //Password = "1234",
               // CustomerId=1//bu değer mevcut müşterilerden birinin idsi
                

            });
        }

        private static void CarTest2()
        {
            Car MyCar = new Car
            {
                brandId = 4,
                colorId = 3,
                modelYear = "2016",
                dailyPrice = 498000,
                Description = "Volvo XC40"
            };

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(
                               "Car's Description: " + item.CarName + " \n" +
                               "Car's Brand Name: " + item.BrandName + " \n" +
                               "Car's Color: " + item.ColorName + " \n" +
                               "Car's Daily Price: " + item.DailyPrice + " \n" +
                             
                               "******************************************"
                        );
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {

                Console.WriteLine(color.colorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {

                Console.WriteLine(brand.brandName);
            }
        }
        


    }

        
    
}
        