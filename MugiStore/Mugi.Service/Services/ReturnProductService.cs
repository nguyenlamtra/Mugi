using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IReturnProductService
    {
        bool Add(ReturnProduct returnProduct);
        IEnumerable<ReturnProduct> GetReturnProduct(int orderId);
    }
    public class ReturnProductService : IReturnProductService
    {
        private IUnitOfWork UnitOfWork;

        public ReturnProductService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public bool Add(ReturnProduct returnProduct)
        {
            try
            {
                returnProduct.CreatedDate = DateTime.Now;
                
                this.UnitOfWork.ReturnProductRepository.Add(returnProduct);
                this.UnitOfWork.Save();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public IEnumerable<ReturnProduct> GetReturnProduct(int orderId)
        {
            return this.UnitOfWork.ReturnProductRepository.GetWithNoTracking(x => x.OrderId == orderId,
                includeProperties: "ReturnProductSubProducts,ReturnProductSubProducts.SubProduct");
        }
    }
}
