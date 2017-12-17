using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mugi.Service.Services
{
    public interface IAccountService
    {
        bool InsertAccount(Account account);
        bool Verify(Account account);
        Account GetById(int accountId);
        bool Update(Account account);
        int GetAccountIdByUserName(string userName);
     
    }
    public class AccountService : IAccountService
    {
        private IUnitOfWork UnitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        public bool InsertAccount(Account account)
        {
            try
            {
                this.UnitOfWork.AccountRepository.Add(account);
                this.UnitOfWork.Save();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool Verify(Account account)
        {
            var item = this.UnitOfWork.AccountRepository.Get(x => x.UserName == account.UserName
            && x.Password == account.Password).SingleOrDefault();
            if (item != null)
                return true;
            else
                return false;
        }

        public Account GetById(int accountId)
        {
            return this.UnitOfWork.AccountRepository.GetById(accountId);
        }

        public bool Update(Account account)
        {
            try
            {
                this.UnitOfWork.AccountRepository.Update(account);
                this.UnitOfWork.Save();
                return true;
            }catch(Exception e)
            {

                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public int GetAccountIdByUserName(string userName)
        {
            return this.UnitOfWork.AccountRepository.Get(x => x.UserName == userName).Select(x=>x.Id).SingleOrDefault();
        }

    }
}
