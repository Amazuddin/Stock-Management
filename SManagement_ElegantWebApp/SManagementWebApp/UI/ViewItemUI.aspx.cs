using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using SManagementWebApp.BLL.Manager;
using SManagementWebApp.BLL.Model;

namespace SManagementWebApp.UI
{
    public partial class ViewItemUI : System.Web.UI.Page
    {
        private ItemManager itemManager;
        private ViewItemsModel viewItemsModel;

        public ViewItemUI()
        {
            itemManager=new ItemManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemModel it = new ItemModel();
                it = itemManager.GetCategoryCompanylist();
                companyDropDownList.DataSource = it.CompanyModelList;
                companyDropDownList.DataTextField = "Company_Name";
                companyDropDownList.DataValueField = "Company_Id";
                companyDropDownList.DataBind();
                companyDropDownList.SelectedIndex = -1;

                categoryDropDownList.DataSource = it.CategoryModelList;
                categoryDropDownList.DataTextField = "Category_Name";
                categoryDropDownList.DataValueField = "Category_Id";
                categoryDropDownList.DataBind();
                categoryDropDownList.SelectedIndex = -1;
            }
            messageLabel.Visible = false;
            pdfButton.Visible = false;
        }
      
       protected void searchButton_Click(object sender, EventArgs e)
       {
           
           int categoryId,companyId;
           List<ViewItemsModel> viewItems;

            if (companyDropDownList.SelectedValue.Equals("-1"))
           {
               categoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
              viewItems = itemManager.GetCategoryById(categoryId);
               viewItemGridView.DataSource = viewItems;
                viewItemGridView.DataBind();
           }
           else if (categoryDropDownList.SelectedValue.Equals("-1"))
           {
               companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
              viewItems= itemManager.GetCompanyById(companyId);
              viewItemGridView.DataSource = viewItems;
              viewItemGridView.DataBind();
           }
           else
           {
               categoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
               companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
              viewItems= itemManager.GetCategoryCompanyById(categoryId, companyId);
              viewItemGridView.DataSource = viewItems;
              viewItemGridView.DataBind();
           }
           if (viewItems.Count == 0)
           {
               messageLabel.Visible = true;
               messageLabel.Text = "NO Item Found";
               categoryDropDownList.SelectedIndex = -1;
               companyDropDownList.SelectedIndex = -1;
           }
           else
           {
               pdfButton.Visible = true;
           }
       }
       public override void VerifyRenderingInServerForm(Control control)
       {
           //required to avoid the runtime error "  
           //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
       }  
        protected void pdfButton_OnClick(object sender, EventArgs e)
        {
            int k = 0;
            PdfPTable pdfPTable = new PdfPTable(viewItemGridView.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in viewItemGridView.HeaderRow.Cells)
            {
                if (k == 0)
                {
                    PdfPCell pdfPCell = new PdfPCell(new Phrase("Serial No."));
                    pdfPTable.AddCell(pdfPCell);
                    k = 1;
                }
                else
                {
                    PdfPCell pdfPCell = new PdfPCell(new Phrase(headerCell.Text));
                    pdfPTable.AddCell(pdfPCell);
                }
        }

            int i;
           // viewItemGridView.Columns[0].Visible = false;
            foreach (GridViewRow gridViewRow in viewItemGridView.Rows)
            {
                i = 0;
               
                
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    if (i==0)
                    {
                        PdfPCell pdfPCell = new PdfPCell(new Phrase(k++.ToString()));
                        pdfPTable.AddCell(pdfPCell);
                        i = 1;
                    }
                    else
                    {
                        PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                        pdfPTable.AddCell(pdfPCell);
                    }
                }
            }

            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
            pdfdoc.Open();

            Font font = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD);
            Paragraph para= new Paragraph("Item Report\n\n",font);
            para.Alignment = Element.ALIGN_CENTER; ;
           
            pdfdoc.Add(para);
            pdfdoc.Add(pdfPTable);
            pdfdoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ItemsReport.pdf");
            Response.Write(pdfdoc);
            Response.Flush();
            Response.End();
        }
    }
}