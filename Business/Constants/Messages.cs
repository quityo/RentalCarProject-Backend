using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Added ";
        public static string CarNameInvalid = "Car Name Invalid";
        public static string MaintenanceTime = "Maintenance Time";
        public static string CarsListed = "Cars Listed";
        public static string CarUpdated = "Car Updated";
        public static string BrandAdded = "Brand Added";
        public static string ColorAdded = "Color Added";
        public static string CustomerAdded = "Customer Added ";
        public static string UserAdded = "User Added";
        public static string InvalidSale = "Araba şuan elimizde değil";
        public static string RentalAdded = "Araba kiralandı";
        public static string CarImageAdded = "Car Image Added Successfully!";
        public static string CarImageCarIdInvalid = "Invalid Car Id, Registration Failed.";
        public static string CarImageDeleted = "Car Image Deleted Successfully!";
        public static string CarImageUpdated = "Car Image Updated Successfully!";
        public static string CarImageLimitExceeded = "Car Image Limit Exceeded!";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string TokenCreated = "Token Oluşturuld!";
        public static string Registered = "Kayıt olundu!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string WrongPassword = "Yanlış Şifre!";
        public static string SuccessfulLogin = "Başarılı giriş!";
        public static string UserAvailable = "Kullanıcı mevcut!";
        public static string CarImagesCountExceded = "Bir aracın en fazla 5 resmi olabilir.";
        public static string succeed = "başarılı";
        public static string listed = "listelendi";
    }
}