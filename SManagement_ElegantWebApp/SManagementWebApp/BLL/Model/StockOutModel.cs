using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SManagementWebApp.BLL.Model
{
    [Serializable]
    public class StockOutModel
    {
        public int Item_Id { get; set; }
        public int Company_Id { get; set; }
        public int AvailableQuantity { get; set; }
        public int StockOutQuantity { get; set; }

        public string Item_Name { get; set; }
        public string Company_Name { get; set; }

    }
}