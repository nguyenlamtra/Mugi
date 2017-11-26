using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IShopOrderService
    {
        //bool Save(ShopOrder shopOrder);
    }
    public class ShopOrderService : IShopOrderService
    {
        //private IUnitOfWork UnitOfWork;

        //public ShopOrderService(IUnitOfWork unitOfWork)
        //{
        //    this.UnitOfWork = unitOfWork;
        //}

        //public bool Save(ShopOrder shopOrder)
        //{
        //    try
        //    {
        //        this.UnitOfWork.ShopOrderRepository.Add(shopOrder);
        //        this.UnitOfWork.Save();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //}
    }
}
