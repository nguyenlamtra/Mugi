using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mugi.Service.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetSubCategoriesByCategoryId(int categoryId);
        IEnumerable<Category> GetAllCategoriesAndSub();
        IEnumerable<Category> GetTest();
        bool Add(Category category);
        bool Update(Category category);
        string GetDescription(int categoryId);
        bool IsExistName(string categoryName);
        bool CheckUpdate(string categoryName, int categoryId);
        bool Delete(int id);
    }

    public class CategoryService : ICategoryService
    {
        //private IRepository<Category> categoryRepository;
        private IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            //this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return unitOfWork.CategoryRepository.Get(x=>x.IsDeleted==false);
        }

        public IEnumerable<Category> GetAllCategoriesAndSub()
        {
            return unitOfWork.CategoryRepository.Get(x=>x.IsDeleted==false, includeProperties: "SubCategories");
        }

        public IEnumerable<Category> GetSubCategoriesByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetTest()
        {
            return this.unitOfWork.CategoryRepository.Get(includeProperties: "SubCategories,SubCategories.Products");
        }

        public bool Add(Category category)
        {
            try
            {
                this.unitOfWork.CategoryRepository.Add(category);
                this.unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            
        }
        
        public string GetDescription(int categoryId)
        {

            return this.unitOfWork.CategoryRepository.GetById(categoryId).CategoryDescription;
        }
        
        public bool IsExistName(string categoryName)
        {
            var category = this.unitOfWork.CategoryRepository.Get(x => x.CategoryName == categoryName);
            if (category.Any())
                return true;
            else
                return false ;
        }
        
        public bool Update(Category category)
        {
            try
            {
                this.unitOfWork.CategoryRepository.Update(category);
                this.unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }


        }
        public bool CheckUpdate(string categoryName, int categoryId)
        {
            var category = this.unitOfWork.CategoryRepository.GetWithNoTracking(x => x.CategoryName == categoryName).SingleOrDefault();
            if (category != null)
            {
                if (category.Id != categoryId)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                unitOfWork.CategoryRepository.Delete(id);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
