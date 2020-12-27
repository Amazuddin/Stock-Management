using System;
using System.Collections.Generic;
using System.Web.UI;
using SManagementWebApp.BLL.Manager;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        private CompanyManager companyManager = new CompanyManager();
        private Dictionary<int, string> dictionary = new Dictionary<int, string>();
        private ItemManager itemManager = new ItemManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = companyManager.GetAllCompany();
                companyDropDownList.DataTextField = "Company_Name";
                companyDropDownList.DataValueField = "Company_Id";
                companyDropDownList.DataBind();
                companyDropDownList.SelectedIndex = -1;
                itemDropDownList.Enabled = false;
                DOTHIS();
            }
            messageLevel.Visible = false;
        }

        public void DOTHIS()
        {
            
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockInQuantityTextBox.Text = "";

            
            reorderLevelTextBox.Enabled = false;
            availableQuantityTextBox.Enabled = false;
            stockInQuantityTextBox.Enabled = false;
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(companyDropDownList.SelectedValue);
            itemDropDownList.Items.Clear();
            dictionary.Add(-1, "Select Item");
            itemDropDownList.DataSource = dictionary;
            itemDropDownList.DataTextField = "Value";
            itemDropDownList.DataValueField = "Key";
            itemDropDownList.DataBind();

            if (value == -1)
            {
                companyDropDownList.SelectedIndex = -1;
                itemDropDownList.Enabled = false;
                DOTHIS();
            }

            if (value != -1)
            {
                itemDropDownList.Enabled = true;
                itemDropDownList.DataSource = itemManager.GetItemModelById(value);
                itemDropDownList.DataTextField = "Item_Name";
                itemDropDownList.DataValueField = "Item_Id";
                itemDropDownList.DataBind();
                DOTHIS();
            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(itemDropDownList.SelectedValue);

            if (value == -1)
            {
                
                DOTHIS();
            }
            if (value != -1)
            {
                var items = itemManager.GetItemInfoById(value);

                reorderLevelTextBox.Enabled = true;
                stockInQuantityTextBox.Enabled = true;
                reorderLevelTextBox.Text = items.Item_Reorder_level.ToString();
                availableQuantityTextBox.Text = items.Item_Quantity.ToString();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            var items = new ItemModel();
            items.Item_Id = Convert.ToInt32(itemDropDownList.SelectedValue);
            var a = itemManager.CheckNumerical(reorderLevelTextBox.Text);
            var b = itemManager.CheckNumerical(stockInQuantityTextBox.Text);

            if (a == 1 && b == 1)
            {
                items.Item_Reorder_level = Convert.ToInt32(reorderLevelTextBox.Text);

                items.Item_Quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                if (itemManager.CheckQuantity(items.Item_Quantity) == 1)
                {
                    items.Item_Available_Quantity = Convert.ToInt32(availableQuantityTextBox.Text);

                    var result = itemManager.ItemQuantityUpdate(items);

                    messageLevel.Visible = true;
                    messageLevel.Text = result;

                    companyDropDownList.SelectedIndex = -1;
                    itemDropDownList.Enabled = false;
                    itemDropDownList.Items.Clear();
                    dictionary.Add(-1, "Select Item");
                    itemDropDownList.DataSource = dictionary;
                    itemDropDownList.DataTextField = "Value";
                    itemDropDownList.DataValueField = "Key";
                    itemDropDownList.DataBind();
                    itemDropDownList.SelectedIndex = -1;
                    DOTHIS();
                }
                else
                {
                    messageLevel.Visible = true;
                    messageLevel.Text = "Stock In Quantity Not Valid";
                }
            }
            else
            {
                messageLevel.Visible = true;
                messageLevel.Text = "Numerical Field are Invalid Or Negative";
            }
        }
    }
}