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
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        

        CategoryManager categoryManager;

        public CategorySetupUI()
        {
            categoryManager=new CategoryManager();
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryGridView.DataSource = categoryManager.GetAllCategory();
                categoryGridView.DataBind();

                for (int i = 0; i < categoryGridView.Rows.Count; i++)
                {
                    TextBox textbox = (TextBox) categoryGridView.Rows[i].Cells[1].FindControl("updateTextBox");
                    LinkButton linkButton =
                        (LinkButton) categoryGridView.Rows[i].Cells[2].FindControl("confirmUpdateLinkButton");
                    linkButton.Visible = false;
                    textbox.Visible = false;
                }

            }
            warningLabel.Visible = false;
            
            //categoryGridView.DataSource = categoryManager.GetAllCategory();
            //categoryGridView.DataBind();
        }

        public void DoThis()
        {
            categoryGridView.DataSource = categoryManager.GetAllCategory();
            categoryGridView.DataBind();

            for (int i = 0; i < categoryGridView.Rows.Count; i++)
            {
                TextBox textbox = (TextBox)categoryGridView.Rows[i].Cells[1].FindControl("updateTextBox");
                LinkButton linkButton =
                    (LinkButton)categoryGridView.Rows[i].Cells[2].FindControl("confirmUpdateLinkButton");
                linkButton.Visible = false;
                textbox.Visible = false;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.Category_Name = categoryTextBox.Text;
            string result = categoryManager.CategoryInsert(categoryModel);
            warningLabel.Text = result;
            categoryTextBox.Text = "";

            warningLabel.Visible = true;
            DoThis();
        }

        protected void updateLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            DataControlFieldCell cell = linkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField idHiddenField = row.FindControl("idHiddenField") as HiddenField;

            Label label = row.FindControl("CLabel") as Label;
            label.Visible = false;

            TextBox textBox = row.FindControl("updateTextBox") as TextBox;
            textBox.Visible = true;

            LinkButton link = row.FindControl("confirmUpdateLinkButton") as LinkButton;
            LinkButton updatelink = row.FindControl("updateLinkButton") as LinkButton;
            link.Visible = true;
            updatelink.Visible = false;
            //Response.Redirect("CompanySetupUI.aspx?Id="+idHiddenField.Value);

        }

        public void confirmUpdateLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            DataControlFieldCell cell = linkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField idHiddenField = row.FindControl("idHiddenField") as HiddenField;
            TextBox editValue = row.FindControl("updateTextBox") as TextBox;

            
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.Category_Id = Convert.ToInt32(idHiddenField.Value);
            categoryModel.Category_Name = editValue.Text;

            string result = categoryManager.CategoryUpdate(categoryModel);

            warningLabel.Visible = true;
            warningLabel.Text = result;
            DoThis();
            //categoryGridView.DataSource = categoryManager.GetAllCategory();
            //categoryGridView.DataBind();
        }

        

        
        
    }
}