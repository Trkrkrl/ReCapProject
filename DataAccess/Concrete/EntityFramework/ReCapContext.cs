using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext :DbContext                   //bu context sayesinde bulunduğumuz entity framework klasöründeki dallardaki kodların çoğu ortak alan olara efentitiryreposistorybase  e gidecek
        //ders projesindeki gibi yapalım ,
        //servera bağlanalım

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentaCar;Trusted_Connection=true;");//sql kullanacğımızı belirtelim\ ter sılaş kullanacağında @ kullanırız


        }
        //Hangi nesne hangi nesneye bağlanacak
        //aşağıda dbset ile yapıcaz
        //dbset içerisindeki bizimki
        //sağdaki veritabanındaki tablo adı
        //prop ile yapıyoz
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        // ilerde customer user ve rental  da gelecek


        public DbSet<Customer> Customers { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
