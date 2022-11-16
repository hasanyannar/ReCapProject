using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
            new Car{Id=1,BrandId=1, ColorId=1, DailyPrice=50000, Description="opel", ModelYear=2021},
            new Car{Id=2,BrandId=2, ColorId=2, DailyPrice=70000, Description="wolswogen", ModelYear=2022},
            new Car{Id=3,BrandId=2, ColorId=1, DailyPrice=95000, Description="fiat", ModelYear=2023}
            };
        }

        public void Add(Car entity)
        {
            _car.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _car.First(p=>p.Id==entity.Id);
            _car.Remove(entity);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _car.First(p=>p.Id==entity.Id);
            carToUpdate.Id = entity.Id;
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.DailyPrice = entity.DailyPrice; 
            carToUpdate.Description = entity.Description;
            carToUpdate.ModelYear = entity.ModelYear;   
        }
    }
}
