using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        Car GetById(int carId);
        void Add(Car Car);
        void Update(Car Car);
        void Delete(Car Car);
    }
}
