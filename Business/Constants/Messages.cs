using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAvailable = "NOT available";
        public static string MaintenanceTime = "System is under maintenance";
        public static string CarImageLimitExceeded = "More than 5 images cannot be added";
        
        public static string UserNotFound = "User not found";
        public static string PasswordError = "PasswordError";
        public static string SuccessfullLogin = "SuccessfullLogin";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string UserRegistered = "SuccessUserRegistered";
        public static string AccessTokenCreated = "Access token created";
        public static string AuthorizationDenied = "AuthorizationDenied";
        public static string NotAvailableCar = " Car not available";
    }
}
