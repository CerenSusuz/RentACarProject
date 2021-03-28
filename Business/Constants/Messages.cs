using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string NoCar = "There is NO car with this details";
        public static string NotEnough = "Score not enough";
        public static string NotCarAvailable = "NOT available";
        public static string MaintenanceTime = "System is under maintenance";
        public static string CarImageLimitExceeded = "More than 5 images cannot be added";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "PasswordError";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string UserRegistered = "SuccessUserRegistered";
        public static string AccessTokenCreated = "Access token created";
        public static string AuthorizationDenied = "AuthorizationDenied";
        public static string CardExist ="There is the credit card";
    }
}
