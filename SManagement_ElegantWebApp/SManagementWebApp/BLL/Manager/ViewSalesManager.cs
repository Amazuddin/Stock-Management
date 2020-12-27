using System.Collections.Generic;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.DAL;

namespace SManagementWebApp.BLL.Manager
{
    public class ViewSalesManager
    {
        private ViewSalesGateway viewSalesGateway;

        public ViewSalesManager()
        {
            viewSalesGateway = new ViewSalesGateway();
        }

        public List<ViewSalesModel> GetAllViewSales(string fromDate, string toDate)
        {
            
            return viewSalesGateway.GetAllViewSales(fromDate, toDate);
        }
    }
}