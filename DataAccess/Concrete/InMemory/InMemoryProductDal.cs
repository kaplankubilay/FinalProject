﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        /// <summary>
        /// This field is naming convention
        /// Simulation Data in the SQL-Oracle-PostgreSql.
        /// </summary>
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products= new List<Product>
            {
                new Product {ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnitPrice = 15,UnitsInStock = 15},
                new Product {ProductId = 2,CategoryId = 1,ProductName = "Kamera",UnitPrice = 500,UnitsInStock = 3},
                new Product {ProductId = 3,CategoryId = 2,ProductName = "Telefon",UnitPrice = 1500,UnitsInStock = 2},
                new Product {ProductId = 4,CategoryId = 2,ProductName = "Klavye",UnitPrice = 150,UnitsInStock = 65},
                new Product {ProductId = 5,CategoryId = 2,ProductName = "Fare",UnitPrice = 85,UnitsInStock = 1}
            };
        }

        public IList<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public IList<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
