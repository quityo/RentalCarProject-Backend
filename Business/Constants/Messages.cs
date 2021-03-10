using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Bilgiler Eklendi.";
        public static string Updated = "Bilgiler Güncellendi.";
        public static string Deleted = "Bilgiler Silindi.";
        public static string BrandCanNotAdded = "Araç Markasını Tekrar Yazınız.";
        public static string ColorCanNotAdded = "Araç Rengini Tekrar Yazınız.";
        public static string CarCanNotAdded = "Araç İsmini ya da Günlük Kiralama Bedelini Tekrar Yazınız.";
        public static string CustomerAdded = "Müşteri İsmini Eklendi.";

        public static string GetAll = "Bilgiler Listelendi.";
        public static string GetBrandByBrandId = "Araç Markaları Listesi.";
        public static string GetColorByColorId = "Araç Renkleri Listesi.";
        public static string GetCarByCarId = "Araç Listesi.";
        public static string GetUserByUserId = "Müşteri Listesi";

        public static string GetCustomerByUserId = "Müşteri Listesi.";
        public static string GetRentalByRentalId = "Kiralama Bilgileri.";
        public static string GetCarDetailsById = "Araç Detayları.";
        public static string GetRentalDetails = "Kiralama Detayları.";
        public static string GetRentalDetailsById = "Kiralama Detayları.";

        public static string GetCarsByColorId = "Rengine Göre Araç Listesi.";
        public static string GetCarsByBrandId = "Markasına Göre Araç Listesi";
        public static string GetCarsWithDetails = "Detaylara Göre Araç Listesi";
        internal static string BrandCanNotUpdated = "Araç Markası Güncellenemedi.";
        internal static string CarCanNotUpdated = "Araç Güncellenemedi.";
        internal static string CustomerUpdated = "Müşteri Bilgileri Güncellenedi.";
        internal static string ColorCanNotUpdated = "Araç Rengi Güncellenemedi.";
        internal static string MaintenanceTime = "Araç Kullanımda.";
        internal static string CarNameAlredyExists = "Bu isimde Ürün Var.";
        internal static string ImageAdded = "Resim Yüklendi";
        internal static string CarImageNotFound = "Resim bulundamadı.";
        internal static string ImageDeleted = "Resim Silindi.";
        internal static string AllImageDeleted = "Tüm Resimler Silindi";
        internal static string ImageUpdated = "Resim Güncellendi";
        internal static string FileUploadAmountExceeded = "Bişiler Bişiler";
        internal static string CarImageLimitExceeded = "Hede Hudu";
        internal static string AuthorizationDenied = " Yetkiniz Yok";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı";
        public static string UserRegistered = "Başarılı";
        public static string AccessTokenCreated = "Access token oluşturuldu";
        public static string CarDailyPriceInvalid = "Araç Günlük fiyat hoff";
        internal static string RentalUpdated = " Kiralama bilgileri güncellenmiştir";
        internal static string UserAdded = "Kullanıcı eklendi.";
        internal static string UserDeleted = "Kullanıcı Silindi";
        internal static string UsersListed = "Kullanıcı Listesi";
        internal static string UserUpdated = "Kullanıcı Güncellendi";
        internal static string BrandNameInvalid = "Araç Bulunamadı";
        internal static string BrandAdded = "Araç Eklendi";
        internal static string BrandDeleted = "Araç silindi.";
        internal static string BrandsListed = "Araçlar Listelendi.";
        internal static string BrandUpdated = "Araç Bilgileri Güncellendi";
        internal static string CarNameInvalid = "Araç bulunamadı.";
        internal static string CarsListed = "Araçlar Listelendi.";
        internal static string CompanyNameInvalid = "Şirket ismi bulunamadı";
        internal static string CustomerDeleted = "Müşteri ismi silindi.";
        internal static string CustomersListed = "Müşteri Listesi";
        internal static string RentalDeleted = "Kiralama kaydı silindi.";
        internal static string RentalsListed = "Kiralık araç listesi";
        internal static string ColorsListed = "Araç Renkleri Listesi";
        internal static string RentedCar = "Araç Kullanımda";
        internal static string RentalCar = "Kiralanabilen araçlar";
        internal static string UserNameInvalid = " Kullanıcı İsmini tekrar giriniz";

    }
}
