using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new DataResult<List<Product>>((List<Product>)_productDal.GetAll(),true,Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>((List<Product>)_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            List<Product> products = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            return new SuccessDataResult<List<Product>>(products);
        }

        public IDataResult<IList<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour != 22)
            {
                return new ErrorDataResult<IList<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<IList<ProductDetailDto>>(_productDal.GetProductDetails()); 
        }

        public IResult AddProduct(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Add(product);

            return new Result(true,Messages.ProductAdded);
        }

        public IDataResult<Product> GetByProductId(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }
    }
}
