using System.Linq;
using Mugi.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Mugi.Domain.Entities;

namespace Mugi.Service.Services
{
    public interface IPropertyDetailsService
    {
        int[] GetPropertyIdsByPropertyDetailsIds(int[] propertyDetailsIds);
        bool Add(PropertyDetails propertyDetails);
        bool CheckExist(string propertyValue);
    }

    public class PropertyDetailsService : IPropertyDetailsService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        public PropertyDetailsService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public int[] GetPropertyIdsByPropertyDetailsIds(int[] propertyDetailsIds)
        {
            return this.UnitOfWork.PropertyDetailsRepository
                .Get(x => propertyDetailsIds.Contains(x.Id), includeProperties: "Property")
                .Select(x => x.Property.Id).ToArray();
        }

        public bool Add(PropertyDetails propertyDetails)
        {
            try
            {
                this.UnitOfWork.PropertyDetailsRepository.Add(propertyDetails);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool CheckExist(string propertyValue)
        {
            var propertyDetails = this.UnitOfWork.PropertyDetailsRepository.GetWithNoTracking(x => x.PropertyValue == propertyValue).SingleOrDefault();
            if (propertyDetails != null)
                return false;
            else return true;
        }
    }
}
