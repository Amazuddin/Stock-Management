using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.DAL;

namespace SManagementWebApp.BLL.Manager
{
    public class CompanyManager
    {
        private CompanyGateway companySetupGateway;
        public CompanyManager()
        {
            companySetupGateway = new CompanyGateway();
        }
        public string CompanySave(CompanyModel company)
        {
            string temp = String.Empty;
            int ik = 0;
            for (int i = 0; i < company.Company_Name.Length; i++)
            {

                if (company.Company_Name[i] == ' ' && ik == 0)
                {
                    continue;
                }
                else if ((company.Company_Name[i] >= 'a' && company.Company_Name[i] <= 'z')
                    || (company.Company_Name[i] >= 'A' && company.Company_Name[i] <= 'Z')
                    || (company.Company_Name[i] == ' ' && ik == 1))
                {
                    temp += company.Company_Name[i];
                    ik = 1;
                }
            }
            company.Company_Name = temp;
            if (company.Company_Name == String.Empty)
            {
                return "Sorry, You Cannot Enter Blank Category";
            }
            bool isExist = companySetupGateway.IsCompanyExist(company.Company_Name);
            if (isExist)
            {
                return "Name Already Exists";
            }
            else
            {
                int rowAffect = companySetupGateway.CompanySave(company);

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

        public List<CompanyModel> GetAllCompany()
        {
            return companySetupGateway.GetAllCompany();
        }
    }
}