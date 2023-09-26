using DataAccess.Abstract;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car> {
              new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 69.99M, ModelYear = "2012", Description = "BMW" },
              new Car { CarId = 2, BrandId = 2, ColorId = 4, DailyPrice = 29.99M, ModelYear = "2014", Description = "Volvo" },
              new Car { CarId = 3, BrandId = 3, ColorId = 5, DailyPrice = 39.99M, ModelYear = "2015", Description = "Mercedes" },
              new Car { CarId = 4, BrandId = 4, ColorId = 2, DailyPrice = 49.99M, ModelYear = "2017", Description = "Kia" },
              new Car { CarId = 5, BrandId = 5, ColorId = 3, DailyPrice = 59.99M, ModelYear = "2019", Description = "Hyundai" }
              };
        }
        public void Add(Car Car)
        {
            _car.Add(Car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public Car GetById(int carId)
        {
            return _car.SingleOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
