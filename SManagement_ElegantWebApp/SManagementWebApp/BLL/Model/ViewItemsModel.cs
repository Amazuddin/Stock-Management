using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SManagementWebApp.BLL.Model
{
    public class ViewItemsModel
    {
        public int Item_Id { get; set; }
        public string Item_Name { get; set; }

        public int Category_Id { get; set; }
        public int Company_Id { get; set; }

        public string Company_Name { get; set; }
        public int Item_Quantity { get; set; }
        public string Category_Name { get; set; }
        public int Item_Reorder_level { get; set; }
    }
}