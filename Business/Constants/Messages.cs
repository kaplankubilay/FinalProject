using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun eklendi.";
        public static string ProductNameInvalid = "Urun ismi gecersiz.";
        public static string MaintenanceTime = "Sistem bakimda.";
        public static string ProductListed = "Urun listelendi.";

        public static string CategoryCountFailed = "Kategori sayisi 10 dan fazla olamaz..";
        public static string AlreadyProductNameExist = "Bu isimde urun ismi zaten var..";

        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni kategory eklenemiyor.";

        public static string AuthorizationDenied = "Gecersiz kullanıcı.";
        
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        
        public static string PasswordError = "Parola Hatası.";
        
        public static string SuccessfulLogin = "Giriş başarılı.";
        
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
