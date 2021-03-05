using Entities.Concrete;
using System;
using System.Collections.Generic;
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
        public static string CustomerCanNotAdded = "Müşteri İsmini Tekrar Yazınız.";

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
        internal static string CustomerCanNotUpdated = "Müşteri Bilgileri Güncellenemedi.";
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
    }
}
