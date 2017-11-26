using System.Linq;
using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IOrderService
    {
        int InsertOrder(Order order, int customerId);
        IEnumerable<Order> GetOrderByCustomerId(int customerId);
        Order GetForOrderDetails(int orderId);
        Order GetById(int orderId);
        IEnumerable<Order> GetOrderForStaff();
        bool Update(Order order);
        bool UpdateDeliver(int orderId, int staffId);
        bool UpdateComplete(int orderId, int staffId);
        bool UpdateDeny(int orderId, int staffId);
        bool CheckOrder(int orderId);
        IEnumerable<Order> Filter(string query);
        bool UpdateConfirm(int orderId, int staffId);
        string GetStatus(int orderId);
        List<Order> GetStatistical(DateTime StartTime, DateTime EndTime);
    }
    public class OrderService : IOrderService
    {
        private IUnitOfWork UnitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public Order GetById(int orderId)
        {
            return this.UnitOfWork.OrderRepository.GetById(orderId);
        }

        public IEnumerable<Order> GetOrderByCustomerId(int customerId)
        {
            StringBuilder include = new StringBuilder();
            include.Append("OrderSubProducts,OrderSubProducts.SubProduct,");
            include.Append("OrderSubProducts.SubProduct.Product,OrderSubProducts.SubProduct.PropertyDetailsSubProducts,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails.Property,");
            include.Append("OrderProducts,OrderProducts.Product");
            return this.UnitOfWork.OrderRepository.Get(x => x.Customer.Id == customerId,
                includeProperties: include.ToString()).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public bool UpdateStatusToConfirm(int orderId)
        {
            try
            {
                var order = GetById(orderId);
                //order.ModifiedDate = DateTime.Now;
                order.Status = "Confirmed";
                this.UnitOfWork.OrderRepository.Update(order);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }


        public IEnumerable<Order> GetOrderForStaff()
        {
            StringBuilder include = new StringBuilder();
            include.Append("OrderSubProducts,OrderSubProducts.SubProduct,");
            include.Append("OrderSubProducts.SubProduct.Product,OrderSubProducts.SubProduct.PropertyDetailsSubProducts,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails.Property,");
            include.Append("OrderProducts,OrderProducts.Product,Customer");
            return this.UnitOfWork.OrderRepository.Get(
               includeProperties: include.ToString())
               .OrderByDescending(x => x.CreatedDate).ToList();
        }

        public int InsertOrder(Order order, int customerId)
        {
            try
            {
                order.Status = "Handling";
                order.CreatedDate = DateTime.Now;
                order.CustomerId = customerId;
                foreach (var item in order.OrderSubProducts)
                {
                    var subProduct = this.UnitOfWork.SubProductRepository
                        .GetWithNoTracking(x => x.Id == item.SubProductId).SingleOrDefault();
                    subProduct.ProductLeft -= item.Quantity;
                    this.UnitOfWork.SubProductRepository.Update(subProduct);
                }
                this.UnitOfWork.OrderRepository.Add(order);

                this.UnitOfWork.Save();
                return order.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public Order GetForOrderDetails(int orderId)
        {
            StringBuilder include = new StringBuilder();
            include.Append("OrderSubProducts, OrderSubProducts.SubProduct, ");
            include.Append("OrderSubProducts.SubProduct.Product,OrderSubProducts.SubProduct.PropertyDetailsSubProducts,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails.Property,");
            include.Append("OrderProducts,OrderProducts.Product,Customer");
            return this.UnitOfWork.OrderRepository.Get(x => x.Id == orderId, includeProperties: include.ToString()).SingleOrDefault();
        }

        public bool Update(Order order)
        {
            try
            {
                this.UnitOfWork.OrderRepository.Update(order);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool CheckOrder(int orderId)
        {
            try
            {
                var order = this.UnitOfWork.OrderRepository.GetWithNoTracking(x => x.Id == orderId).SingleOrDefault();
                if (order != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public IEnumerable<Order> Filter(string query)
        {
            StringBuilder include = new StringBuilder();
            include.Append("OrderSubProducts,OrderSubProducts.SubProduct,");
            include.Append("OrderSubProducts.SubProduct.Product,OrderSubProducts.SubProduct.PropertyDetailsSubProducts,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails,");
            include.Append("OrderSubProducts.SubProduct.PropertyDetailsSubProducts.PropertyDetails.Property,");
            include.Append("OrderProducts,OrderProducts.Product");
            switch (query)
            {
                case "all":
                    return this.UnitOfWork.OrderRepository.Get(x => x.IsDeleted == false, includeProperties: include.ToString()).OrderByDescending(x => x.CreatedDate);
                case "unassign":
                    return this.UnitOfWork.OrderRepository.Get(x => x.IsDeleted == false && x.Status == "Handling", includeProperties: include.ToString()).OrderByDescending(x => x.CreatedDate);
                case "assigned":
                    return this.UnitOfWork.OrderRepository.Get(x => x.IsDeleted == false && x.Status == "Delivering", includeProperties: include.ToString()).OrderByDescending(x => x.CreatedDate);
                case "completed":
                    return this.UnitOfWork.OrderRepository.Get(x => x.IsDeleted == false && x.Status == "Completed", includeProperties: include.ToString()).OrderByDescending(x => x.CreatedDate);
                default:
                    return null;
            }
        }

        public bool UpdateComplete(int orderId, int staffId)
        {
            var order = GetById(orderId);
            if (order.Id != 0)
            {
                order.Status = "Completed";
                order.CompleteDate = DateTime.Now;
                order.CompleteId = staffId;
                if (this.Update(order))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool UpdateConfirm(int orderId, int staffId)
        {
            var order = GetById(orderId);
            if (order.Id != 0)
            {
                order.Status = "Confirmed";
                order.ConfirmId = staffId;
                order.ConfirmDate = DateTime.Now;
                if (this.Update(order))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool UpdateDeny(int orderId, int staffId)
        {
            var order = this.UnitOfWork.OrderRepository.GetWithNoTracking(x => x.Id == orderId,
                   includeProperties: "OrderSubProducts").SingleOrDefault();
            foreach (var i in order.OrderSubProducts)
            {
                var subProduct = this.UnitOfWork.SubProductRepository.GetById(i.SubProductId);
                subProduct.ProductLeft += i.Quantity;
            }
            if (order.Id != 0)
            {
                order.Status = "Denied";
                order.IsDeleted = true;
                order.ConfirmId = staffId;
                order.ConfirmDate = DateTime.Now;

                if (this.Update(order))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDeliver(int orderId, int staffId)
        {
            var order = GetById(orderId);
            if (order.Id != 0)
            {
                order.Status = "Delivering";
                order.DeliverId = staffId;
                if (this.Update(order))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string GetStatus(int orderId)
        {
            try
            {
                return this.UnitOfWork.OrderRepository.GetById(orderId).Status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "";
            }

        }

        public List<Order> GetStatistical(DateTime StartTime, DateTime EndTime)
        {
            return UnitOfWork.OrderRepository
                .Get(x => x.Status == "Completed" && x.ConfirmDate >= StartTime 
                && x.ConfirmDate <= EndTime, 
                includeProperties: "OrderProducts,OrderProducts.Product" +
                ",OrderSubProducts,OrderSubProducts.SubProduct").ToList();
        }
    }
}
