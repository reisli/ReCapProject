
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore.Query.Internal;

CarManager carManager = new CarManager(new EfCarDal());


foreach (var item in carManager.GetCarDetail())
{
    Console.WriteLine(string.Format("{0} , {1} , {2}  {3}",item.CarId,item.BrandName,item.ColorName,item.DailyPrice));
}