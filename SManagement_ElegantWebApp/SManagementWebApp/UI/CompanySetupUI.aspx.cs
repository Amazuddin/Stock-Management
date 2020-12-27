using System;
using SManagementWebApp.BLL.Manager;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.UI
{
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        private CompanyManager companySetupManager;

        public CompanySetupUI()
        {
            companySetupManager=new CompanyManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            warningLabel.Visible = false;
            companyNameGridView.DataSource = companySetupManager.GetAllCompany();
            companyNameGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            CompanyModel company=new CompanyModel();
            company.Company_Name = nameTextBox.Text;

            nameTextBox.Text=String.Empty;
            warningLabel.Visible = true;
            string message = companySetupManager.CompanySave(company);
            warningLabel.Text = message;

            companyNameGridView.DataSource = companySetupManager.GetAllCompany();
            companyNameGridView.DataBind();
        }
    }
}