using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {//mantıgı su: a a tablosunu b btablusunu temsil etsin anın aid si ve b nin b idsi esit oldugunu diyoz 
         //buna gore de asagida dtodaki ver ile db den belirttigimiz veriyi esleyecez   
            using (ReCapContext context = new ReCapContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars on re.carId equals ca.carId
                             join co in context.Colors on ca.colorId equals co.colorId
                             join b in context.Brands on ca.brandId equals b.brandId
                             join cus in context.Customers on re.customerId equals cus.customerId
                             join u in context.Users on cus.userId equals u.userId
                             //sorunu çözdüm- customers ve users tablosunu hem customerid hem userid leri esit olanları joinledim-bir de en üsteki rental seçtim

                             /*from u in context.Users//users tablosu core entities concreteden geliyor oradaki proplara bak
                             join cu in context.Customers on u.userId equals cu.userId
                             //bu tabloları istenilen id leri eslesenler seklinde birlestirdik,simdi
                             //bu baglantilari sayesinde istedigimiz veriye erisimimiz var*/
                             select new RentalDetailDto
                             {
                                 carId = ca.carId,
                                 brandId = b.brandId,
                                 colorName = co.colorName,
                                 brandName = b.brandName,
                                 modelName = ca.modelName,
                                 rentalId = re.rentalId,
                                 RentDate = re.rentDate,
                                 ReturnDate = re.returnDate,
                                 customerName = u.firstName,
                                 customerLastname = u.lastName,
                                 customerId=cus.customerId
                                 //soldakiler dto-sağdakiler database ler-
                             };
                return result.ToList();


            }
        }
    }
}
