using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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

        public IList<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public IList<Category> GetById(int categoryId)
        {
            return (IList<Category>)_categoryDal.Get(x => x.CategoryId == categoryId);
        }
    }
}
