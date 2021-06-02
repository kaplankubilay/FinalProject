using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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
            if (DateTime.Now.Hour == 22)
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
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList());
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
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);

            return new Result(true,Messages.ProductAdded);
        }

        public IDataResult<Product> GetByProductId(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }
    }
}
