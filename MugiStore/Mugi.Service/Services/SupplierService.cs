using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Service.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier Add(Supplier supplier);
    }

    public class SupplierService : ISupplierService
    {
        private IUnitOfWork unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return unitOfWork.SupplierRepository.Get();
        }
        
        public Supplier Add(Supplier supplier)
        {
            try
            {
                this.unitOfWork.SupplierRepository.Add(supplier);
                this.unitOfWork.Save();

                return supplier;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
