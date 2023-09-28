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
    public class EfCarDal : EfEntityReposiotryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context=new())
            {
                var result = from car in context.Cars
                             join c in context.Colors on car.ColorID equals c.ColorId
                             join b in context.Brands on car.BrandID equals b.BrandId
                             select new CarDetailDto { CarId = car.CarId, BrandName = b.BrandName, ColorName = c.ColorName, DailyPrice = car.DailyPrice };
                return result.ToList();
            }
        }
    }
}
