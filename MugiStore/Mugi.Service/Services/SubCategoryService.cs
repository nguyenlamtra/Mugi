using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Service.Services
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategory> GetAll();
        bool Add(SubCategory subCategory);
        IEnumerable<SubCategory> GetByCategoryId(int categoryId);
        bool CheckNameForInsert(string subCategoryName, int categoryId);
        bool CheckNameForUpdate(string subCategoryName, int subCategoryId, int categoryId);
        bool Update(SubCategory subCategory);
        bool IsExistName(string SubCategoryName);
        bool Delete(int id);
    }

    public class SubCategoryService : ISubCategoryService
    {
        private IUnitOfWork UnitOfWork;
        public SubCategoryService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return this.UnitOfWork.SubCategoryRepository.Get();
        }

        public bool Add(SubCategory subCategory)
        {
            try
            {
                this.UnitOfWork.SubCategoryRepository.Add(subCategory);
                this.UnitOfWork.Save();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public IEnumerable<SubCategory> GetByCategoryId(int categoryId)
        {
            return this.UnitOfWork.SubCategoryRepository.Get(x => x.CategoryId == categoryId);
        }

        public bool CheckNameForInsert(string subCategoryName, int categoryId)
        {
            try
            {
                var subCategory = this.UnitOfWork.SubCategoryRepository
                    .Get(x => x.SubCategoryName == subCategoryName && x.CategoryId==categoryId).SingleOrDefault();
                if (subCategory != null) return true;
                else return false ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return true ;
            }

        }

        public bool CheckNameForUpdate(string subCategoryName, int subCategoryId, int categoryId)
        {
            try
            {
                var subCategory = this.UnitOfWork.SubCategoryRepository
                    .GetWithNoTracking(x => x.SubCategoryName == subCategoryName && x.CategoryId == categoryId).SingleOrDefault();
                if (subCategory != null){
                    if (subCategory.Id == subCategoryId)
                        return true;
                    else return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        public bool Update(SubCategory subCategory)
        {
            try
            {
                this.UnitOfWork.SubCategoryRepository.Update(subCategory);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool IsExistName(string subCategoryName)
        {
            var subCategory = this.UnitOfWork.SubCategoryRepository.Get(x => x.SubCategoryName == subCategoryName);
            if (subCategory.Any())
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            try
            {
                UnitOfWork.SubCategoryRepository.Delete(id);
                UnitOfWork.Save();
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
