using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        private ICategoryService _categoryService;

        /// <summary>
        /// bir manager içerisinde kendisinden başka dal eklenemez!...
        /// </summary>
        /// <param name="productDal"></param>
        /// <param name="categoryService"></param>
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
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

        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            //iş kurallarını çalıştıracak.dönüş null ise/tüm kurallara uyuyorsa dönüş null dır.
            IResult result = BusinessRules.Run(PruductCountControl(product.CategoryId), ProductNameControl(product.ProductName),CategoryCountControl());
            
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult UpdateProduct(Product product)
        {
            if (!PruductCountControl(product.CategoryId).Success)
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

        /// <summary>
        /// bir kategoriden 10 dan fazla ürün eklenemez.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        private IResult PruductCountControl(int categoryId)
        {
            var count =_productDal.GetAll(x => x.CategoryId == categoryId).Count;
            if (count>=10)
            {
                return new ErrorResult(Messages.CategoryCountFailed);
            }

            return new SuccessResult();
        }

        /// <summary>
        /// Bir isimden sadece bir kez kullanılabilir.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        private IResult ProductNameControl(string productName)
        {
            bool countName = _productDal.GetAll(x => x.ProductName == productName).Any();
            if (countName)
            {
                return new ErrorResult(Messages.AlreadyProductNameExist);
            }
            return new SuccessResult();
        }

        private IResult CategoryCountControl()
        {
            var categoryCount = _categoryService.GetAll();
            if (categoryCount.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
