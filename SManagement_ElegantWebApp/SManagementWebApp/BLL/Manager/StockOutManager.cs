using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.DAL;

namespace SManagementWebApp.BLL.Manager
{
    public class StockOutManager
    {
        private StockOutGateway stockOutGateway;

        public StockOutManager()
        {
            stockOutGateway = new StockOutGateway();
        }
        public string SellItem(List<StockOutModel> stock,string action)
        {
            int result = stockOutGateway.SellItem(stock,action);
            if (result > 0)
                return "Item Added as "+action+" Successful";
            else
            {
                return "Problems found in" + result + "Rows";
            }
        }
    }
}