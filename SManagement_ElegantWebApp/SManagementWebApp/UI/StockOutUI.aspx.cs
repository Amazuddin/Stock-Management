using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SManagementWebApp.BLL.Manager;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        private ItemManager itemManager;
        private Dictionary<int, string> dictionary;
        private StockOutManager stockOutManager;

        public StockOutUI()
        {
            itemManager=new ItemManager();
            dictionary = new Dictionary<int, string>();
            stockOutManager = new StockOutManager();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemModel item = itemManager.GetCompanyList();
                companyDropDownList.DataSource = item.CompanyModelList;
                companyDropDownList.DataTextField = "Company_Name";
                companyDropDownList.DataValueField = "Company_Id";
                companyDropDownList.DataBind();
                companyDropDownList.SelectedIndex = -1;
                itemDropDownList.Enabled = false;
                DOTHIS();
                GridViewData();
            }
            messageLabel.Visible = false;
            HideAll();
            
        }

        public void GridViewData()
        {
            
            if (ViewState["StockOut"] != null)
            {
                List<StockOutModel> stockOutList = (List<StockOutModel>)ViewState["StockOut"];
                cartGridView.DataSource = stockOutList;
                cartGridView.DataBind();

               
                cartGridView.Visible = true;
                damageButton.Visible = true;
                sellButton.Visible = true;
                lostButton.Visible = true;

            }
        }

        public void DOTHIS()
        {
           
           
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockOutQuantityTextBox.Text = "";

            
            reorderLevelTextBox.Enabled = false;
            availableQuantityTextBox.Enabled = false;
            stockOutQuantityTextBox.Enabled = false;
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
                ItemModel items = itemManager.GetItemInfoById(value);

                
                stockOutQuantityTextBox.Enabled = true;
                reorderLevelTextBox.Text = items.Item_Reorder_level.ToString();

                if (ViewState["StockOut"] != null)
                {
                    int f = 0;
                    List<StockOutModel> stockOutList = (List<StockOutModel>)ViewState["StockOut"];
                    foreach (StockOutModel stock in stockOutList)
                    {
                        if (stock.Item_Id == value)
                        {
                            availableQuantityTextBox.Text = (items.Item_Quantity-stock.StockOutQuantity).ToString();
                            f = 1;
                            break;
                        }
                    }
                    if (f == 0)
                    {
                        availableQuantityTextBox.Text = items.Item_Quantity.ToString();
                    }
                }
                else
                {
                    availableQuantityTextBox.Text = items.Item_Quantity.ToString();
                }
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            int a = itemManager.CheckNumerical(stockOutQuantityTextBox.Text);
            if (a == 1)
            {
                int stockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
                int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);

                if (stockOutQuantity > availableQuantity)
                {
                    messageLabel.Visible = true;
                    messageLabel.Text = "Sorry StockOut Quantity Cannot Greater Then Available Quantity";
                }
                else if (stockOutQuantity == 0)
                {
                    messageLabel.Visible = true;
                    messageLabel.Text = "Sorry StockOut Quantity Cannot be 0";
                }
                else
                {
                    StockOutModel stockOutModel = new StockOutModel();
                    stockOutModel.Item_Id = Convert.ToInt32(itemDropDownList.SelectedValue);
                    stockOutModel.Company_Id = Convert.ToInt32(companyDropDownList.SelectedValue);
                    stockOutModel.Item_Name = itemDropDownList.SelectedItem.ToString();
                    stockOutModel.Company_Name = companyDropDownList.SelectedItem.ToString();

                    stockOutModel.AvailableQuantity = availableQuantity - stockOutQuantity;
                    stockOutModel.StockOutQuantity = stockOutQuantity;
                  

                    if (ViewState["StockOut"] != null)
                    {
                        int flag = 0;
                        List<StockOutModel> stockOutList = (List<StockOutModel>) ViewState["StockOut"];
                        foreach (StockOutModel stock in stockOutList)
                        {
                            if (stock.Item_Id == stockOutModel.Item_Id)
                            {
                                stock.AvailableQuantity = stockOutModel.AvailableQuantity;
                                stock.StockOutQuantity += stockOutModel.StockOutQuantity;
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            stockOutList.Add(stockOutModel);

                            ViewState["StockOut"] = stockOutList;
                        }

                        GridViewData();

                    }
                    else
                    {
                        List<StockOutModel> stockOutList = new List<StockOutModel>();

                        stockOutList.Add(stockOutModel);

                        ViewState["StockOut"] = stockOutList;
                        GridViewData();
                    }
                    availableQuantityTextBox.Text = stockOutModel.AvailableQuantity.ToString();
                }
            }
            else
            {
                messageLabel.Visible = true;
                messageLabel.Text = "Stockout Quantity Not Valid";
            }
            stockOutQuantityTextBox.Text = "";
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<StockOutModel> stockOutList = (List<StockOutModel>)ViewState["StockOut"];
            string result = stockOutManager.SellItem(stockOutList,"Sell");
            messageLabel.Visible = true;
            messageLabel.Text = result;
            companyDropDownList.SelectedIndex = -1;
            itemDropDownList.Enabled = false;
            itemDropDownList.Items.Clear();
            dictionary.Add(-1, "Select Item");
            itemDropDownList.DataSource = dictionary;
            itemDropDownList.DataTextField = "Value";
            itemDropDownList.DataValueField = "Key";
            itemDropDownList.DataBind();
            DOTHIS();
            ViewState["StockOut"] = null;
            HideAll();
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<StockOutModel> stockOutList = (List<StockOutModel>)ViewState["StockOut"];
            string result = stockOutManager.SellItem(stockOutList, "Damage");
            messageLabel.Visible = true;
            messageLabel.Text = result;
            companyDropDownList.SelectedIndex = -1;
            itemDropDownList.Enabled = false;
            itemDropDownList.Items.Clear();
            dictionary.Add(-1, "Select Item");
            itemDropDownList.DataSource = dictionary;
            itemDropDownList.DataTextField = "Value";
            itemDropDownList.DataValueField = "Key";
            itemDropDownList.DataBind();
            DOTHIS();
            ViewState["StockOut"] = null;
            HideAll();
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<StockOutModel> stockOutList = (List<StockOutModel>)ViewState["StockOut"];
            string result = stockOutManager.SellItem(stockOutList, "Lost");
            messageLabel.Visible = true;
            messageLabel.Text = result;
            companyDropDownList.SelectedIndex = -1;
            itemDropDownList.Enabled = false;
            itemDropDownList.Items.Clear();
            dictionary.Add(-1, "Select Item");
            itemDropDownList.DataSource = dictionary;
            itemDropDownList.DataTextField = "Value";
            itemDropDownList.DataValueField = "Key";
            itemDropDownList.DataBind();
            DOTHIS();
            ViewState["StockOut"] = null;
           
            HideAll();
        }

        public void HideAll()
        {
            if (ViewState["StockOut"] == null)
            {
                cartGridView.Visible = false;
                damageButton.Visible = false;
                sellButton.Visible = false;
                lostButton.Visible = false;
            }
        }

    }
}