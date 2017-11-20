using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mugi.Service.Services
{

    public interface IAdvertisementService
    {
        IEnumerable<Advertisement> GetAdvertisements();
        bool Add(Advertisement advertisement);
    }

    public class AdvertisementService : IAdvertisementService
    {
        private IUnitOfWork UnitOfWork;

        public AdvertisementService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return UnitOfWork.AdvertisementRepository.Get().ToList();
        }
        
        public bool Add(Advertisement advertisement)
        {
            try
            {
                advertisement.CreatedDate = DateTime.Now;
                this.UnitOfWork.AdvertisementRepository.Add(advertisement);
                this.UnitOfWork.Save();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
