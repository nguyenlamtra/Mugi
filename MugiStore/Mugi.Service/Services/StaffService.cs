using Mugi.Core.Infrastructure;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mugi.Service.Services
{
    public interface IStaffServie
    {
        IEnumerable<Staff> GetAll();
        bool AddStaff(Staff staff, string roleName);
        Staff GetByUserName(string userName);
        Staff GetById(int staffId);
        bool Update(Staff staff);
        int GetAccountIdByStaffId(int staffId);
        int GetStaffIdByEmail(string email);
        bool CheckStaff(int staffId);
    }
    public class StaffService : IStaffServie
    {
        IUnitOfWork UnitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public Staff GetByUserName(string userName)
        {
            var staff = this.UnitOfWork.StaffRepository.Get(x => x.Account.UserName == userName,
                includeProperties:"Account,Account.Role").SingleOrDefault();
            return staff;
        }

        public bool AddStaff(Staff staff, string roleName)
        {
            try
            {
                var role = this.UnitOfWork.RoleRepository.Get(x => x.RoleName == roleName).SingleOrDefault();
                staff.Account.RoleId = role.Id;
                this.UnitOfWork.StaffRepository.Add(staff);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
        public Staff GetById(int staffId)
        {
            return this.UnitOfWork.StaffRepository
                .Get(x => x.Id == staffId, includeProperties: "Account").SingleOrDefault();
        }
        public bool Update(Staff staff)
        {
            try
            {
                this.UnitOfWork.StaffRepository.Update(staff);
                this.UnitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public int GetAccountIdByStaffId(int staffId)
        {
            return this.UnitOfWork.StaffRepository
                .Get(x => x.Id == staffId, includeProperties: "Account")
                .Select(x => x.Account.Id).SingleOrDefault();
        }
        public int GetStaffIdByEmail(string email)
        {
            return this.UnitOfWork.StaffRepository.Get(x => x.Mail == email).Select(x => x.Id).SingleOrDefault();
        }

        public IEnumerable<Staff> GetAll()
        {
            return this.UnitOfWork.StaffRepository.Get(x => x.IsDeleted == false).OrderBy(x => x.Name);
        }

        public bool CheckStaff(int staffId)
        {
            try
            {
                var staff = this.UnitOfWork.StaffRepository.GetWithNoTracking(x => x.Id == staffId).SingleOrDefault();
                if (staff != null){
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
