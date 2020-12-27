using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.BLL.Model
{
    public class ItemModel
    {
        public int Item_Id { get; set; }
        public int Category_Id { get; set; }
        public int Company_Id { get; set; }
        public string Item_Name { get; set; }
        public int Item_Reorder_level { get; set; }
        public int Item_Quantity { get; set; }

        public int Item_Available_Quantity { get; set; }
        public List<CategoryModel> CategoryModelList{ get; set; }
        public List<CompanyModel> CompanyModelList{ get; set; }

    }


       
}