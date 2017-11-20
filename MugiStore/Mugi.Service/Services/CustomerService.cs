using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mugi.Service.Services
{
    public interface ICustomerService
    {
        bool InsertCustomer(Customer customer, string roleName);
        Customer GetByUserName(string userName);
        Customer GetById(int customerId);
        bool Update(Customer customer);
        int GetAccountIdByCustomerId(int customerId);
        int GetCustomerIdByEmail(string email);
    }
    public class CustomerService : ICustomerService
    {
        IUnitOfWork UnitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public Customer GetByUserName(string userName)
        {
            var customer = this.UnitOfWork.CustomerRepository
                .Get(x => x.Account.UserName == userName,includeProperties: "Account,Account.Role").SingleOrDefault();
            return customer;
        }

        public bool InsertCustomer(Customer customer, string roleName)
        {
            try
            {
                var role = this.UnitOfWork.RoleRepository.Get(x => x.RoleName == roleName).SingleOrDefault();
                customer.Account.RoleId = role.Id;
                this.UnitOfWork.CustomerRepository.Add(customer);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public Customer GetById(int customerId)
        {
            return this.UnitOfWork.CustomerRepository
                .Get(x=>x.Id == customerId, includeProperties: "Account").SingleOrDefault();
        }
        public bool Update(Customer customer)
        {
            try
            {
                this.UnitOfWork.CustomerRepository.Update(customer);
                this.UnitOfWork.Save();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public int GetAccountIdByCustomerId(int customerId)
        {
            return this.UnitOfWork.CustomerRepository
                .Get(x => x.Id == customerId, includeProperties: "Account")
                .Select(x => x.Account.Id).SingleOrDefault();
        }
        public int GetCustomerIdByEmail(string email)
        {
            return this.UnitOfWork.CustomerRepository.Get(x => x.Mail == email).Select(x=>x.Id).SingleOrDefault();
        }

       
    }
}
