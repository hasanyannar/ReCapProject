using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //UserTest();
            //CustomerTest();
            RentalTest();
        }
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var addedRental = rentalManager.Add(new Rental
            { CarId = 3, CustomerId = 2, RentDate = DateTime.Now });
            Console.WriteLine(addedRental.Message);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserId = 2, CompanyName = "Çalışkan Veterinelik" });
            foreach (var customer in customerManager.GetCustomerDetails().Data)
            {
                Console.WriteLine(customer.CustomerName + " " + customer.CompanyName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            //userManager.Add(new User { FirstName = "Mehmet", LastName = "ÇAlışkan", Email = "vet.hekim_mehmet@gmail.com", Password = "12345" });

            foreach (var user in userManager.GetAllUser().Data)
            {
                Console.WriteLine(user.FirstName + " "+ user.LastName + " " + user.Email);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));

            //carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2022, DailyPrice = 875000, Description = "c4" });

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("   Arabanın Markası:  " + car.BrandName + "   Arabanın Adı:  " + car.Description
                      + "   Abarnın Rengi:  " + car.ColorName);               
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }       
        }
    }
}