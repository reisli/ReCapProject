using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;
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
            _car = new List<Car> {
              new Car { CarId = 1, BrandID = 1, ColorID = 1, DailyPrice = 69.99M, ModelYear = "2012", Description = "BMW" },
              new Car { CarId = 2, BrandID = 2, ColorID = 4, DailyPrice = 29.99M, ModelYear = "2014", Description = "Volvo" },
              new Car { CarId = 3, BrandID = 3, ColorID = 5, DailyPrice = 39.99M, ModelYear = "2015", Description = "Mercedes" },
              new Car { CarId = 4, BrandID = 4, ColorID = 2, DailyPrice = 49.99M, ModelYear = "2017", Description = "Kia" },
              new Car { CarId = 5, BrandID = 5, ColorID = 3, DailyPrice = 59.99M, ModelYear = "2019", Description = "Hyundai" }
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

        public Car GetById(int carId)
        {
            return _car.SingleOrDefault(c => c.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
