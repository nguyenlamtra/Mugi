using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mugi.Service.Services
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetAll();
        Property Add(Property property);
        bool Check(string propertyName);
    }

    public class PropertyService : IPropertyService
    {
        private IUnitOfWork UnitOfWork;

        public PropertyService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<Property> GetAll()
        {
            return this.UnitOfWork.PropertyRepository.Get(x => x.IsDeleted == false);
        }

        public Property Add(Property property)
        {
            try
            {
                this.UnitOfWork.PropertyRepository.Add(property);
                this.UnitOfWork.Save();
                return property;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public bool Check(string propertyName)
        {
            var property = this.UnitOfWork.PropertyRepository.GetWithNoTracking(x => x.PropertyName == propertyName).SingleOrDefault();
            if (property != null)
                return false;
            else
                return true;
        }
    }
}
