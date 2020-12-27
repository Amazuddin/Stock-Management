using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SManagementWebApp.BLL.Model;
using SManagementWebApp.DAL;

namespace SManagementWebApp.BLL.Manager
{
    public class CategoryManager
    {

        private CategoryGateway categoryGateway;

        public CategoryManager()
        {
            categoryGateway = new CategoryGateway();
        }

        public string CategoryInsert(CategoryModel categoryModel)
        {
            string temp = String.Empty;
            int ik = 0;
            for (int i = 0; i < categoryModel.Category_Name.Length; i++)
            {

                if (categoryModel.Category_Name[i] == ' ' && ik == 0)
                {
                    continue;
                }
                else if ((categoryModel.Category_Name[i] >= 'a' && categoryModel.Category_Name[i] <= 'z')
                    || (categoryModel.Category_Name[i] >= 'A' && categoryModel.Category_Name[i] <= 'Z')
                    || (categoryModel.Category_Name[i] == ' ' && ik == 1))
                {
                    temp += categoryModel.Category_Name[i];
                    ik = 1;
                }
            }
            categoryModel.Category_Name = temp;
            if (categoryModel.Category_Name == String.Empty)
            {
                return "Sorry, You Cannot Enter Blank Category";
            }
            bool isCategoryExist = categoryGateway.IsCategoryExists(categoryModel.Category_Name);

            if (isCategoryExist)
            {
                return "Category Name Already Exists";
            }
            else
            {
                int result = categoryGateway.CategoryInsert(categoryModel);

                if (result > 0)
                {
                    return "Category Name Insert Successful";
                }
                else
                {
                    return "Category Name Insert Failed";
                }
            }
            
        }

        public List<CategoryModel> GetAllCategory()
        {
            return categoryGateway.GetAllCategory();
        }

        public string CategoryUpdate(CategoryModel categoryModel)
        {
            string temp = String.Empty;
            int ik = 0;
            for (int i = 0; i < categoryModel.Category_Name.Length; i++)
            {

                if (categoryModel.Category_Name[i] == ' ' && ik == 0)
                {
                    continue;
                }
                else if ((categoryModel.Category_Name[i] >= 'a' && categoryModel.Category_Name[i] <= 'z')
                    || (categoryModel.Category_Name[i] >= 'A' && categoryModel.Category_Name[i] <= 'Z')
                    || (categoryModel.Category_Name[i] == ' ' && ik == 1))
                {
                    temp += categoryModel.Category_Name[i];
                    ik = 1;
                }
            }
            categoryModel.Category_Name = temp;

            if (categoryModel.Category_Name == String.Empty)
            {
                return "Sorry, You Cannot Enter Blank Category";
            }
            bool isCategoryExist = categoryGateway.IsCategoryExists(categoryModel.Category_Name);
            if (isCategoryExist)
            {
                return "Category Name Already Exists";
            }
            else
            {
                int result = categoryGateway.CategoryUpdate(categoryModel);

                if (result > 0)
                {
                    return "Category Name Update Successful";
                }
                else
                {
                    return "Category Name Update Failed";
                }
            }
        }
    }
}