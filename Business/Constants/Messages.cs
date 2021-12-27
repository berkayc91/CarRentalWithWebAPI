using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Brand added.";
        public static string BrandDeleted = "Brand deleted.";
        public static string BrandUpdated = "Brand updated.";
        public static string BrandsListed = "Brands listed.";

        public static string CarAdded = "Car added.";
        public static string CarUpdated = "Car updated.";
        public static string CarDeleted = "Car deleted.";
        public static string CarNameInvalid = "Car name is invalid.";
        public static string CarPriceInvalid = "Car daily price is invalid.";
        public static string CarsListed = "Cars listed";
        public static string CarListed = "Car listed";

        public static string ColorAdded = "Color added.";
        public static string ColorUpdated = "Color updated.";
        public static string ColorDeleted = "Color deleted.";
        public static string ColorsListed = "Colors listed";

        public static string CustomerAdded = "Customer added.";
        public static string CustomerUpdated = "Customer updated.";
        public static string CustomerDeleted = "Customer deleted.";
        public static string CustomersListed = "Customers listed";


        public static string UserAdded = "User added.";
        public static string UserUpdated = "User updated.";
        public static string UserDeleted = "User deleted.";
        public static string UsersListed = "Users listed";

        public static string RentalAdded = "The car is rented.";
        public static string RentalUpdated = "Rental updated.";
        public static string RentalDeleted = "Rental deleted.";
        public static string RentalsListed = "Rentals listed";
        public static string RentalCarAppropriate = "The car is not appropriate.";

        public static string CarImageCount = "The car must have maximum 5 images.";
        public static string CarImageAdd = "Car Image Added";
        public static string CarImageUpdated = "Car Image Updated";
        public static string CarImageDelete = " Car Image Deleted.";
        public static string CarImageNull = "Car Image wasn't found";

        public static string AuthorizationDenied = "Authorization Denied";
        public static string UserRegistered= "User registered";
        public static string UserNotFound="User not found";
        public static string PasswordError="Password Error";
        public static string SuccessfulLogin="Successful login";
        
        public static string AccessTokenCreated="Access Token Created";
        public static string UserAlreadyExist= "User already exists";
    }
}
