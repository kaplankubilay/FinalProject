using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GetProductName();

            //GetPersonelName();

            //GetCategoryName();

            //GetProductDto();
        }

        private static void GetProductDto()
        {
            //ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            //GetProductDetails in Data/durum/message sını, aldık ancak message yada durum(true-false) unuda alabilirdik.

            //var result = productManager.GetProductDetails();

            //if (result.Success)
            //{
            //    foreach (var productDetailDto in result.Data)
            //    {
            //        Console.WriteLine("{0}  {1}  {2}", productDetailDto.ProductName, productDetailDto.CategoryName, productDetailDto.UnitsInStock);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            
        }

        private static void GetCategoryName()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //var result =categoryManager.
            
            foreach (var category in categoryManager.GetAll().Data)
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
            //ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            //foreach (var product in productManager.GetByUnitPrice(20, 40).Data)
            //{
            //    Console.WriteLine(product.ProductName);
            //}
        }
    }
}
