using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Configuration;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.DAL
{
    public class ViewSalesGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["ConnectingDBString"].ConnectionString;

        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;


        public List<ViewSalesModel> GetAllViewSales(string fromDate, string toDate)
        {
            connection = new SqlConnection(connectionString);
            string query = "SELECT Item.Item_Name, Company.Company_Name, SUM(StockOut.StockOut_Quantity)StockOut_Quantity " +
                           "FROM StockOut " +
                           "INNER JOIN Item " +
                           "on  StockOut.Item_Id = Item.Item_Id AND StockOut.Date BETWEEN  '" + fromDate +"'  AND '" + toDate + "' AND StockOut.Action='Sell' " +
                           "INNER JOIN Company on Company.Company_Id = StockOut.Company_Id AND StockOut.Date BETWEEN '" + fromDate + "'  AND '" + toDate + "' AND StockOut.Action='Sell'" +
                           "GROUP BY Item.Item_Name,Company.Company_Name";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<ViewSalesModel> itemListViewModel = new List<ViewSalesModel>();

            while (reader.Read())
            {
                ViewSalesModel itemViewModel = new ViewSalesModel();
                itemViewModel.Item_Name = reader["Item_Name"].ToString();
                itemViewModel.Company_Name = reader["Company_Name"].ToString();
                itemViewModel.StockOut_Quantity = Convert.ToInt32(reader["StockOut_Quantity"]);

                itemListViewModel.Add(itemViewModel);
            }
            connection.Close();
            return itemListViewModel;
        }
    }
}

