using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        
        public IDataResult<IList<Category>> GetAll()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            Category categoryGetById = _categoryDal.Get(x => x.CategoryId == categoryId);
            return new SuccessDataResult<Category>(categoryGetById);
        }
    }
}
