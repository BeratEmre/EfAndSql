using Business.Concrete;
using DataAccess.Concrete.Ef;
using Entities.Concrete;
using System;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var product in userManager.GetAll())
            {
                Console.WriteLine($"{product.FirstName} / {product.LastName} / {product.Email} / {product.PasswordSalt} / {product.Id} ");
            }

        }
    }
}
