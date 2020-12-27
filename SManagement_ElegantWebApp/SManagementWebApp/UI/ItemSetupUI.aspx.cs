using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SManagementWebApp.BLL.Manager;
using SManagementWebApp.BLL.Model;
using SManagement_Elegan_ItemSetuptWebApp;

namespace SManagement_Elegan_ItemSetuptWebApp.UI
{
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        private ItemManager itemManager;

        public ItemSetupUI()
        {
            itemManager=new ItemManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ItemModel dt = new ItemModel();

                dt = itemManager.GetCategoryCompanylist();
                categoryDropDownList.DataSource = dt.CategoryModelList;
                categoryDropDownList.DataTextField = "Category_Name";
                categoryDropDownList.DataValueField = "Category_Id";
                categoryDropDownList.DataBind();

                companyDropDownList.DataSource = dt.CompanyModelList;
                companyDropDownList.DataTextField = "Company_Name";
                companyDropDownList.DataValueField = "Company_Id";
                companyDropDownList.DataBind();
            }
            messageLabel.Visible = false;
           
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            ItemModel item=new ItemModel();
            item.Category_Id = Convert.ToInt32(categoryDropDownList.SelectedValue);
            item.Company_Id = Convert.ToInt32(companyDropDownList.SelectedValue);
            item.Item_Name = nameTextBox.Text;

            if (itemManager.CheckNumerical(reorderTextBox.Text) == 1)
            {
                item.Item_Reorder_level = Convert.ToInt32(reorderTextBox.Text);
                string message = itemManager.ItemSave(item);
                messageLabel.Visible = true;
                messageLabel.Text = message;

                categoryDropDownList.SelectedIndex = -1;
                companyDropDownList.SelectedIndex = -1;
                nameTextBox.Text = "";
                reorderTextBox.Text = "";
            }
            else
            {
                messageLabel.Visible = true;
                messageLabel.Text = "Reorder Level is not valid";
            }
        }
    }
}