﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
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

            return new DataResult<List<Product>>((List<Product>)_productDal.GetAll(), true, Messages.ProductListed);
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            if (!CategoryCountControl(product.CategoryId).Success)
            {
                return new ErrorResult(Messages.CategoryCountFailed);
            }

            if (!ProductNameControl(product.ProductName).Success)
            {
                return new ErrorResult(Messages.AlreadyProductNameExist);
            }

            _productDal.Add(product);

            return new Result(true, Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult UpdateProduct(Product product)
        {
            if (!CategoryCountControl(product.CategoryId).Success)
            {
                return new ErrorResult(Messages.CategoryCountFailed);
            }

            //business code
            _productDal.Update(product);

            return new Result(true, Messages.ProductAdded);
        }

        public IDataResult<Product> GetByProductId(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        private IResult CategoryCountControl(int categoryId)
        {
            var count =_productDal.GetAll(x => x.CategoryId == categoryId).Count;
            if (count>=10)
            {
                return new ErrorResult(Messages.CategoryCountFailed);
            }

            return new SuccessResult();
        }

        private IResult ProductNameControl(string productName)
        {
            bool countName = _productDal.GetAll(x => x.ProductName == productName).Any();
            if (countName)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
