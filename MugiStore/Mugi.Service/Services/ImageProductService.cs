using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IImageProductService
    {
        IEnumerable<ImageProduct> GetAllImageProduct();
        IEnumerable<ImageProduct> GetImageProductByProductId(int productId);
        bool Add(int productId , string url);
        bool Delete(int imageId);
    }

    public class ImageProductService : IImageProductService
    {
        private IUnitOfWork unitOfWork;

        public ImageProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ImageProduct> GetAllImageProduct()
        {
            return unitOfWork.ImageProductRepository.Get().ToList();
        }

        

        public IEnumerable<ImageProduct> GetImageProductByProductId(int productId)
        {
            return unitOfWork.ImageProductRepository.Get(x => x.Product.Id == productId && x.IsDeleted == false);
        }

        public bool Add(int productId, string url)
        {
            try
            {
                ImageProduct image = new ImageProduct(productId,url);
                this.unitOfWork.ImageProductRepository.Add(image);
                this.unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        public bool Update(ImageProduct image)
        {
            try
            {
                this.unitOfWork.ImageProductRepository.Update(image);
                this.unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool Delete(int imageId)
        {
            try
            {
                var image = unitOfWork.ImageProductRepository.GetById(imageId);
                if (image != null)
                {
                    this.unitOfWork.ImageProductRepository.Delete(image);
                    this.unitOfWork.Save();
                    return true;
                }
                else return false;
                //var image = this.unitOfWork.ImageProductRepository
                //    .GetWithNoTracking(x => x.Id == imageId).SingleOrDefault();
                //image.IsDeleted = true;
                //this.unitOfWork.ImageProductRepository.Update(image);
                //this.unitOfWork.Save();

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
