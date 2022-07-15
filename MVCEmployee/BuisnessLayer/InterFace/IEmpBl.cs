﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.InterFace
{
    public interface IEmpBl
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
        public string UpdateEmployee(EmployeeModel employee);
        public string DeleteEmployee(int? id);
    }
}
