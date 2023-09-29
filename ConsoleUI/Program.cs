
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore.Query.Internal;


UserManager userManager = new(new EfUserDal());

userManager.Add(new() { FirstName = "Ulvi", LastName = "Raisli", Email = "Ulvi.Raisli@mail.ru", Password = "12345" });


CustomerManager customerManager = new(new EfCustomerDal());

var result = customerManager.Add(new() { CompanyName = "DOST-MMC", UserID = 1 });

if (result.Success)
{
    Console.WriteLine(result.Message);
}
else
{
    Console.WriteLine(result.Message);
}


