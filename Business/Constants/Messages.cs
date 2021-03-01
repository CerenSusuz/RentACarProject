using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string Added = "Add process OK";
        public static string NotAdded = "Add process NOT OK";

        public static string Deleted = "Delete process OK";
        public static string NotDeleted = "Delete process NOT OK";

        public static string Updated = "Update process OK";
        public static string NotUpdated = "Update process NOT OK";

        public static string Listed = "List process OK";
        public static string NotListed = "List process NOT OK";

        public static string MaintenanceTime = "System is under maintenance";
        public static string FailedRental = "The car has not yet been delivered";
        public static string CarImageLimitExceeded = "More than 5 images cannot be added";
        public static string NoCarImages = "The car does NOT have any images";
        
        public static string UserNotFound = "User not found";
        public static string PasswordError = "PasswordError";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string UserRegistered = "SuccessUserRegistered";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "AuthorizationDenied";
    }
}
