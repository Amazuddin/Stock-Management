using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.DAL
{
    public class BaseCategoryCompany
    {
        public string connectionString;
        public BaseCategoryCompany()
        {
            connectionString =
           WebConfigurationManager.ConnectionStrings["ConnectingDBString"].ConnectionString;

        }
        
        public List<CompanyModel> GetAllCompany()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Company";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CompanyModel> companyList = new List<CompanyModel>();

            while (reader.Read())
            {
                CompanyModel company = new CompanyModel();
                company.Company_Id = Convert.ToInt32(reader["Company_Id"]);
                company.Company_Name = reader["Company_Name"].ToString();


                companyList.Add(company);
            }
            return companyList;
        }
        public List<CategoryModel> GetAllCategory()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CategoryModel> categoryList = new List<CategoryModel>();

            while (reader.Read())
            {
                CategoryModel categoryModel = new CategoryModel();

                categoryModel.Category_Id = Convert.ToInt32(reader["Category_Id"]);

                categoryModel.Category_Name = reader["Category_Name"].ToString();

                categoryList.Add(categoryModel);
            }

            connection.Close();
            return categoryList;
        }

        public List<ViewItemsModel> GetCategoryById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Company.Company_Name,Category.Category_Name,Item.Item_Name,Item.Item_Quantity,Item.Item_Reorder_level " +
                           "FROM Item LEFT JOIN Category on Item.Category_Id=Category.Category_Id " +
                           "LEFT JOIN Company on Company.Company_Id=Item.Company_Id " +
                           "WHERE Item.Category_Id="+id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewItemsModel> viewItem = new List<ViewItemsModel>();

            while (reader.Read())
            {
                ViewItemsModel viewItems = new ViewItemsModel();

                viewItems.Category_Name = reader["Category_Name"].ToString();
                viewItems.Company_Name = reader["Company_Name"].ToString();
                viewItems.Item_Name = reader["Item_Name"].ToString();
                viewItems.Item_Quantity = Convert.ToInt32(reader["Item_Quantity"]);
                viewItems.Item_Reorder_level = Convert.ToInt32(reader["Item_Reorder_level"]);
                viewItem.Add(viewItems);
            }

            connection.Close();
            return viewItem;
        }
        public List<ViewItemsModel> GetCompanyById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Company.Company_Name,Category.Category_Name,Item.Item_Name,Item.Item_Quantity,Item.Item_Reorder_level " +
                           "FROM Item LEFT JOIN Category on Item.Category_Id=Category.Category_Id " +
                           "LEFT JOIN Company on Company.Company_Id=Item.Company_Id " +
                           "WHERE Item.Company_Id=" + id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewItemsModel> viewItem = new List<ViewItemsModel>();

            while (reader.Read())
            {
                ViewItemsModel viewItems = new ViewItemsModel();

                viewItems.Category_Name = reader["Category_Name"].ToString();
                viewItems.Company_Name = reader["Company_Name"].ToString();
                viewItems.Item_Name = reader["Item_Name"].ToString();
                viewItems.Item_Quantity = Convert.ToInt32(reader["Item_Quantity"]);
                viewItems.Item_Reorder_level = Convert.ToInt32(reader["Item_Reorder_level"]);
                viewItem.Add(viewItems);
            }

            connection.Close();
            return viewItem;
        }
        public List<ViewItemsModel> GetCategoryCompanyById(int categoryid,int companyId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Company.Company_Name,Category.Category_Name,Item.Item_Name,Item.Item_Quantity,Item.Item_Reorder_level " +
                           "FROM Item LEFT JOIN Category on Item.Category_Id=Category.Category_Id " +
                           "LEFT JOIN Company on Company.Company_Id=Item.Company_Id " +
                           "WHERE Item.Category_Id=" + categoryid + "AND Item.Company_Id=" + companyId;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewItemsModel> viewItem = new List<ViewItemsModel>();

            while (reader.Read())
            {
                ViewItemsModel viewItems = new ViewItemsModel();

                viewItems.Category_Name = reader["Category_Name"].ToString();
                viewItems.Company_Name = reader["Company_Name"].ToString();
                viewItems.Item_Name = reader["Item_Name"].ToString();
                viewItems.Item_Quantity = Convert.ToInt32(reader["Item_Quantity"]);
                viewItems.Item_Reorder_level = Convert.ToInt32(reader["Item_Reorder_level"]);
                viewItem.Add(viewItems);
            }

            connection.Close();
            return viewItem;
        }
    }
}