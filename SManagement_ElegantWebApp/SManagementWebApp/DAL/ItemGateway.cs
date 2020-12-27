using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.DAL
{
    public class ItemGateway:BaseCategoryCompany
    {
       
        public int ItemSave(ItemModel item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Item VALUES("+item.Category_Id+","+item.Company_Id+",'" + item.Item_Name + "',"+item.Item_Reorder_level+",'"+item.Item_Quantity+"')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsNameExist(string itemName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Item WHERE Item_Name= '" + itemName + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isNameExist = reader.HasRows;
            connection.Close();
            return isNameExist;
        }

        public List<ItemModel> GetItemModelById(int value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Item WHERE Company_Id = "+value;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ItemModel> ItemList = new List<ItemModel>();

            while (reader.Read())
            {
                ItemModel itemModel = new ItemModel();
                itemModel.Item_Id = Convert.ToInt32(reader["Item_Id"]);
                itemModel.Item_Name = reader["Item_Name"].ToString();
                ItemList.Add(itemModel);
            }
            return ItemList;
        }

        public ItemModel GetItemInfo(int value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Item WHERE Item_Id = " + value;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            ItemModel itemModel = new ItemModel();
            itemModel.Item_Reorder_level = Convert.ToInt32(reader["Item_Reorder_level"]);
            itemModel.Item_Quantity = Convert.ToInt32(reader["Item_Quantity"]);
                
            return itemModel;
        }

        public int ItemQuantityUpdate(ItemModel item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Item SET Item_Reorder_level = " + item.Item_Reorder_level + ", Item_Quantity = "+item.Item_Quantity+" WHERE Item_Id = " + item.Item_Id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public List<ViewItemsModel> GetViewItemsList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM GetViewItemsList";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewItemsModel> viewItemLists = new List<ViewItemsModel>();
            while (reader.Read())
            {
                ViewItemsModel viewItems = new ViewItemsModel();
                viewItems.Item_Id = Convert.ToInt32(reader["Item_Id"]);
                viewItems.Item_Name = (reader["Item"].ToString());
                viewItems.Company_Name = (reader["CompanyName"].ToString());
                viewItems.Item_Quantity = Convert.ToInt32(reader["Quantity"]);
                viewItems.Item_Reorder_level = Convert.ToInt32(reader["Reorder_level"]);

                viewItemLists.Add(viewItems);
            }
            connection.Close();
            return viewItemLists;

        }
    }
}