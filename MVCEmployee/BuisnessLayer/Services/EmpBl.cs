using BuisnessLayer.InterFace;
using CommonLayer.Model;
using RepositoryLayer.InterFace;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Services
{
    public class EmpBl : IEmpBl
    {
        private readonly IEmpRl iEmpRl;
        public EmpBl(IEmpRl iEmpRl)
        {
            this.iEmpRl = iEmpRl;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            try
            {
                return this.iEmpRl.AddEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public string DeleteEmployee(int? id)
        {
            try
            {
                return this.iEmpRl.DeleteEmployee(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.iEmpRl.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return this.iEmpRl.GetEmployeeData(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                return this.iEmpRl.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
