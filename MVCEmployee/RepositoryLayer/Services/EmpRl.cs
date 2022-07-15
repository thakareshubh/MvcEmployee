using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmpRl : IEmpRl
    {
        private readonly IConfiguration configuration;
        public EmpRl(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpConnection"]))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startDate", employee.startDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return employee;
                }
                else
                {
                    return null;
                }
            }
        }

        public string DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpConnection"]))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", id);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return " Employee Deleted Successfully";
                }
                else
                {
                    return null;
                }
            }
        }

        // To View All Employee Details
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpConnection"]))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.salary = Convert.ToInt32(rdr["salary"]);
                    employee.startDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.notes = Convert.ToString(rdr["notes"]);

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        // Get details of a particular employee
        public EmployeeModel GetEmployeeData(int? id)
        {
            EmployeeModel employee = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpConnection"]))
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = Convert.ToString(rdr["Name"]);
                    employee.profileImage = Convert.ToString(rdr["profileImage"]);
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = Convert.ToString(rdr["Department"]);
                    employee.salary = Convert.ToInt32(rdr["salary"]);
                    employee.startDate = Convert.ToDateTime(rdr["startDate"]);
                    employee.notes = Convert.ToString(rdr["notes"]);
                }

            }
            return employee;
        }

        // To Update New Employee Record
        public string UpdateEmployee(EmployeeModel employee)
        {
             using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpConnection"]))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@profileImage", employee.profileImage);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@startDate", employee.startDate);
                cmd.Parameters.AddWithValue("@notes", employee.notes);

                con.Open();
                var result = cmd.ExecuteNonQuery();
                con.Close();

                if (result != 0)
                {
                    return "Employee Updated Successfully";
                }
                else
                {
                    return " Employee Update Unsuccessfull";
                }
            }
        }
    }
}
