using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IGoodsReceiptProductService
    {
        
    }

    public class GoodsReceiptProductService : IGoodsReceiptProductService
    {
        private IUnitOfWork UnitOfWork;

        public GoodsReceiptProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

       
    }
}
