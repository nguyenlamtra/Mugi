using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mugi.Service.Services
{
    public interface IPriceDetailsService
    {
        IEnumerable<PriceDetails> GetAllPriceDetails();
        PriceDetails GetPriceDetailsByProductId(int productId);
    }
    public class PriceDetailsService : IPriceDetailsService
    {
        private IUnitOfWork unitOfWork;

        public PriceDetailsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PriceDetails> GetAllPriceDetails()
        {
            return unitOfWork.PriceDetailsRepository.Get().ToList();
        }

        public PriceDetails GetPriceDetailsByProductId(int productId)
        {
            return unitOfWork.PriceDetailsRepository.Get(x => x.Product.Id == productId).OrderByDescending(x => x.CreatedDate).Take(1).SingleOrDefault();
        }
    }
}
