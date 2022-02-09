using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
   public static class Messages
    {//aşağıdaki mesaj türleri : 
        public static string CarAdded = "Araba Adı EKlendi";
        public static string CarNameInvalid = "Girdiğiniz Araba Adı Geçersiz";
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarsDeleted = "Araba Silindi";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        
        
        public static string ColorAdded = "Renk eklendi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string ColorDeleted = "Renk silindi";

        public static string CustomerAdded = "Customer eklendi";
        public static string CustomerListed = "Customer Listelendi";
        public static string CustomerDeleted = "Customer silindi";

        public static string UserAdded = "User eklendi";
        public static string UserListed = "User Listelendi";
        public static string UserDeleted = "User silindi";

        public static string RentalAdded = "Rental eklendi";
        public static string RentalListed = "Rental Listelendi";
        public static string RentalFailed = "Rental Başarısız ,Araç geri teslim eilmedi.";
        public static string RentalDeleted = "Rental Silindi.";


        public static string MaintenanceTime = "Şu an bakım aşamasındayız";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";

        public static string SuccessfulLogin = "Başarılı Giriş";

        public static string UserAlreadyExists = "Bu Kullanıcı Zaten Mevcut";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string AccessTokenCreated = "AccessToken Oluşturuldu";

        public static string PasswordError = "Hatalı şifre";
    }
}
