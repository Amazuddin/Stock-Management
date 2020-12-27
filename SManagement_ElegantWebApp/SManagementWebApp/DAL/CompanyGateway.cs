using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.DAL
{
    public class CompanyGateway:BaseCategoryCompany
    {
         public int CompanySave(CompanyModel company)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Company VALUES('" + company.Company_Name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsCompanyExist(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Company WHERE Company_Name= '" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isCompanyExist = reader.HasRows;
            connection.Close();
            return isCompanyExist;
        }
    }
}