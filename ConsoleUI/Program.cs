


using Business.Concrete;
using DataAccess.Concrete.InMemory;

CarManager carManager = new CarManager(new InMemoryCarDal());

//foreach (var item in carManager.GetAll())
//{
//    Console.WriteLine(item.CarId+ " " +  item.Description + " " + item.ModelYear);
//}

Console.WriteLine(carManager.GetById(3).Description);
