using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.DAL
{
    public class CategoryGateway:BaseCategoryCompany
    {
        public int CategoryInsert(CategoryModel categoryModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Category VALUES('" + categoryModel.Category_Name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public bool IsCategoryExists(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Category WHERE Category_Name = '" + name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isCategoryExist = reader.HasRows;
            connection.Close();
            return isCategoryExist;
        }

        public int CategoryUpdate(CategoryModel categoryModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Category SET Category_Name = '" + categoryModel.Category_Name + "' WHERE Category_Id = " + categoryModel.Category_Id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}