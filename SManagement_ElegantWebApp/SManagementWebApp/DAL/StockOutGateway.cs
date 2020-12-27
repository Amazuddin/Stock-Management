using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.DAL
{
    public class StockOutGateway:BaseCategoryCompany
    {

        public int SellItem(List<StockOutModel> stock,string action)
        {
            int cont = 0,check=0 ;
            SqlConnection connection = new SqlConnection(connectionString);
            foreach (StockOutModel st in stock)
            {
                
                string date = DateTime.Now.ToString("yyyy-MM-dd");
               
                string query = "INSERT INTO StockOut VALUES("+st.Company_Id+","+st.Item_Id+","+st.StockOutQuantity+",'"+date+"','"+action+"')";
                string update = "UPDATE Item SET Item_Quantity="+st.AvailableQuantity+"WHERE Item_Id="+st.Item_Id;

                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand updateCommand = new SqlCommand(update,connection);
                connection.Open();
                int result = command.ExecuteNonQuery();
                int result2 = updateCommand.ExecuteNonQuery();

                connection.Close();
                
                
                if (result > 0 && result2>0)
                    cont++;

                check++;
            }

            if (cont == check)
                return 1;
            else
            {
                return check - cont;
            }

        }
    }
}