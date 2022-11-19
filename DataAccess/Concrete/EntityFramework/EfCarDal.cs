using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ProjectDbContext context =new ProjectDbContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join r in context.Color
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = r.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
