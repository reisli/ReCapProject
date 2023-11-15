using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityReposiotryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarID equals car.CarId
                             join brand in context.Brands on car.BrandID equals brand.BrandId
                             join customer in context.Customers on rental.CustomerID equals customer.CustomerId
                             join user in context.Users on customer.UserID equals user.UserId
                             select new RentalDetailDto { BrandName = brand.BrandName, FullName =$"{user.FirstName} {user.LastName}", RentalId = rental.RentalId, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate };
                return result.ToList();

            }
        }
    }
}
