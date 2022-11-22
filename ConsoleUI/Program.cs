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
            CarTest();
            //BrandTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = 2020, DailyPrice = 175000, Description = "Megane" });

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(" **Arabanın Markası: " + car.BrandName + " **Arabanın Adı: " + car.Description
                        + " **Abarnın Rengi: " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            

            
        }
    }
}