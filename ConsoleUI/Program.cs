using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetProductName();

            //GetPersonelName();

            //GetCategoryName();

            GetProductDto();
        }

        private static void GetProductDto()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var productDetailDto in productManager.GetProductDetails())
            {
                Console.WriteLine("{0}  {1}  {2}", productDetailDto.ProductName, productDetailDto.CategoryName, productDetailDto.UnitsInStock);
            }
        }

        private static void GetCategoryName()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void GetPersonelName()
        {
            PersonelManager personelManager = new PersonelManager(new EfPersonelDal());
            foreach (var personel in personelManager.GetAll())
            {
                Console.WriteLine("{0} / {1} / {2}", personel.Id, personel.Name, personel.Surname);
            }
        }

        private static void GetProductName()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(20, 40))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
