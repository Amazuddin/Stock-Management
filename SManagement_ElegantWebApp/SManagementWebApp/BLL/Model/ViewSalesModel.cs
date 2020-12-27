namespace SManagementWebApp.BLL.Model
{
    public class ViewSalesModel
    {
        public string  Item_Name { get; set; }
        public string Company_Name { get; set; }
        public int StockOut_Quantity { get; set; }        
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
}