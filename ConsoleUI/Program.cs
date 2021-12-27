using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll().Data;
            foreach (var item in result)
            {
                Console.WriteLine(item.ReturnDate);
            }
        }
    }
}
