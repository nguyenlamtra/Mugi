using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IPromotionService
    {
        bool Add(Promotion promotion, int staffId);
        IEnumerable<Promotion> GetNowPromotion();
    }

    public class PromotionService : IPromotionService
    {
        private IUnitOfWork UnitOfWork;

        public PromotionService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Promotion> GetNowPromotion()
        {
            StringBuilder include = new StringBuilder();
            include.Append("PromotionProducts");
            return this.UnitOfWork.PromotionRepository
                .GetWithNoTracking(x => x.BeginDay < DateTime.Now && x.EndDay > DateTime.Now, 
                includeProperties: include.ToString());
        }

        public bool Add(Promotion promotion, int staffId)
        {
            try
            {
                promotion.CreatedDate = DateTime.Now;
                promotion.StaffId = staffId;
                this.UnitOfWork.PromotionRepository.Add(promotion);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
    }
}
