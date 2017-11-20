using System.Linq;
using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IOrderSubProductService
    {
        bool Insert(int orderId, int subProductId);
        IEnumerable<OrderSubProduct> GetSubProductByOrderId(int orderId);
    }
    public class OrderSubProductService : IOrderSubProductService
    {
        private IUnitOfWork UnitOfWork;

        public OrderSubProductService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<OrderSubProduct> GetSubProductByOrderId(int orderId)
        {
            return this.UnitOfWork.OrderSubProductRepository.Get(x=>x.OrderId==orderId,
                includeProperties: "Order,SubProduct,SubProduct.Product," +
                "SubProduct.PropertyDetailsSubProduct," +
                "SubProduct.PropertyDetailsSubProduct.PropertyDetails," +
                "SubProduct.PropertyDetailsSubProduct.PropertyDetails.Property").ToList();
        }

        public bool Insert(int orderId, int subProductId)
        {
            OrderSubProduct item = new OrderSubProduct();
            item.OrderId = orderId;
            try
            {
                this.UnitOfWork.OrderSubProductRepository.Add(item);
                this.UnitOfWork.Save();
                return true;
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
           
        }
    }
}
