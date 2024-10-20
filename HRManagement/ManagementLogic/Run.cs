﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLogic
{
    public class Run // main thuc thi hanh dong ow day, tien xu li
    {
        private Management management = null;
        public Run() { }
        public void Login(string username, string password)
        {
            List<Account> accounts = Data.LoadAccounts();

            Account account = accounts.Find(a => a.IsValidUsername(username));
            if (account == null)
            {
                throw new Exception("Username does not exist.");
            }
            if (!account.IsValidPassword(password))
            {
                throw new Exception("Login failed: Incorrect password.");
            }
            
            management = Data.LoadData(account.GetFilePath());
            management.SetFilePath(account.GetFilePath());
            management.SetCurrentAccount(account);
        }
        public void addADMIN(string username, string password)
        {
            try
            {
                management.AddADMIN(username, password);
            }
            catch (Exception e) { }
        }
        public void ChangePass(string password, string newPassword)
        {
            try
            {
                management.ChangePasssword(password, newPassword);
            }
            catch (Exception e) { }
        }
        public List<Employee> FindEmployees(string keyword = "")
        {
            return new List<Employee>();
        }
        public List<Department> FindIDeparment(string keyword = "")
        {
            return new List<Department>();
        }
        
    }
}
