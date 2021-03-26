using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated";
        public static string CarPriceInvalid = "Price must be greater than 0";
        public static string CarsListed = "Cars Listed";
        public static string CarNameInvalid = "CarNameInvalid";
        public static string CarDailyPriceInvalid = "CarDailyPriceInvalid";
        



        public static string BrandAdded = "Brand Added";
        public static string BrandDeleted = "Brand Deleted";
        public static string BrandUpdated = "Brand Updated";
        public static string BrandNameInvalid = "The Brand Name must consist of a minimum of 2 characters.";
        public static string BrandsListed = "Brands Listed";

        
        public static string CarUpdatedError = "Araba güncelleme islemi basarisiz";

        public static string CarDetail = "Araba detayları listelendi";
        public static string CarDetailError = "Araba detayları listeleme islemi basarisiz";

        public static string CarListed = "Araba listeleme başarili";
        public static string CarListedError = "Araba listeleme basarisiz";



        
        public static string BrandAddedError = "Marka ekleme islemi basarisiz";

        
        public static string BrandDeletedError = "Marka silme islemi basarisiz";

        
        public static string BrandUpdatedError = "Marka güncelleme islemi basarisiz";

        public static string BrandListed = "Marka listelendi";
        public static string BrandListedError = "Marka listelenme islemi basarisiz";



        public static string ColorAdded = "Renk eklendi";
        public static string ColorAddedError = "Renk ekleme islemi basarisiz";

        public static string ColorDeleted = "Renk silindi";
        public static string ColorDeletedError = "Renk silme islemi basarisiz";

        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorUpdatedError = "Renk güncellene islemi basarisiz";

        public static string ColorListed = "Renk listelendi";
        public static string ColorListedError = "Renk silme islemi basarisiz";
        public static string CarAvailable = "Araç Müsait";
        public static string CarNotAvailable = "Araç Müşteride";

        public static string RentalAdded = "Rental Added";
        public static string RentalDeleted = "Rental Deleted";
        public static string RentalUpdated = "Rental Updated";
        public static string RentalsListed = "Rentals Listed";
        public static string RentalDeliverInvalid = "To Rent a car, it must first be delivered";
        public static string CarIsntAvailable = "CarIsntAvailable";
        public static string NumberOfImagesError = "number of pictures exceeded";

        public static string CarImageAdded = "CarImage Added";
        public static string CarImageDeleted = "CarImage Deleted";
        public static string CarImageUpdated = "CarImage Updated";
        public static string CarImageLimitExceeded = "CarImage Limit Exceeded";
        public static string CarImageCountExceeded = "CarImageCountExceeded";
        public static string CarImageNotFound = "CarImageNotFound";
        

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Sifre hatali";
        public static string UserRegistered = "Kullanici kaydı başarili";

        public static string RentalDetailListed = "Kira detayi listelendi";
    }

}
