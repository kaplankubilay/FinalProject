using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        //redis cache for getall
        //Task<IDataResult<List<Product>>> GetAll();

        IDataResult<IList<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<IList<ProductDetailDto>> GetProductDetails();
        IResult AddProduct(Product product);
        IDataResult<Product> GetByProductId(int id);
        IResult UpdateProduct(Product product);

        IResult AddTransactionalTest(Product product);
    }
}
