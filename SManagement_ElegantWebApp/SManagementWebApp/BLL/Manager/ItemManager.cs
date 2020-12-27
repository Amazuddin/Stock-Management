
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.DAL;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.DAL;

namespace SManagementWebApp.BLL.Manager
{
    
    public class ItemManager
    {
        private ItemGateway itemGateway;


        public ItemManager()
        {
            itemGateway = new ItemGateway();
        }

        public string ItemSave(ItemModel item)
        {
            if (item.Category_Id == -1)
            {
                return "Category Not Selected";
            }
            if (item.Company_Id == -1)
            {
                return "Company Not Selected";
            }


            string temp = String.Empty;
            int ik = 0;
            for (int i = 0; i < item.Item_Name.Length; i++)
            {
                if (item.Item_Name[i] == ' ' && ik == 0)
                {
                    continue;
                }
                else if ((item.Item_Name[i] >= 'a' && item.Item_Name[i] <= 'z')
                         || (item.Item_Name[i] >= 'A' && item.Item_Name[i] <= 'Z')
                         || (item.Item_Name[i] == ' ' && ik == 1))
                {
                    temp += item.Item_Name[i];
                    ik = 1;
                }
            }

            item.Item_Name = temp;

            if (item.Item_Name.Equals(String.Empty))
            {
                return "Cannot Enter Blank Items Name";
            }
            

            bool isNameExist = itemGateway.IsNameExist(item.Item_Name);
            if (isNameExist)
            {
                return "Name Already Exists";
            }
            else
            {
                int rowAffect = itemGateway.ItemSave(item);

                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save failed";
                }
            }
        }

        public ItemModel GetCategoryCompanylist()
        {

            ItemModel itemModel = new ItemModel();

            itemModel.CategoryModelList = itemGateway.GetAllCategory();
            itemModel.CompanyModelList = itemGateway.GetAllCompany();


            return itemModel;
        }

        public ItemModel GetCompanyList()
        {
            ItemModel itemModel = new ItemModel();
            itemModel.CompanyModelList = itemGateway.GetAllCompany();
            return itemModel;
        }

        public List<ItemModel> GetItemModelById(int value)
        {
            return itemGateway.GetItemModelById(value);
        }


        public ItemModel GetItemInfoById(int value)
        {
            return itemGateway.GetItemInfo(value);
        }

        public string ItemQuantityUpdate(ItemModel item)
        {
            item.Item_Quantity = item.Item_Available_Quantity + item.Item_Quantity;

            int result = itemGateway.ItemQuantityUpdate(item);
            if (result > 0)
            {
                return "Item Stock In Successful";
            }
            else
            {
                return "Item Stock In Failed";
            }
        }


        public int CheckQuantity(int value)
        {
            if (value <= 0)
            {
                return 0;
            }
            else return 1;
        }

        public int CheckNumerical(string value)
        {
            int temp = 1;
            if (value == "")
                return 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] >= '0' && value[i] <= '9')
                    continue;
                else
                {
                    temp = 0;
                    break;
                }
            }
            return temp;
        }

        public List<ViewItemsModel> GetCategoryById(int id)
        {
            return itemGateway.GetCategoryById(id);
        }
        public List<ViewItemsModel> GetCompanyById(int id)
        {
            return itemGateway.GetCompanyById(id);
        }
        public List<ViewItemsModel> GetCategoryCompanyById(int categoryId,int CompanyId)
        {
            return itemGateway.GetCategoryCompanyById(categoryId, CompanyId);
        }
        //GetCategoryById

        


    }
}