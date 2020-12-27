using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SManagementWebApp.BLL.Manager;
using SManagementWebApp.BLL.Model;


namespace SManagementWebApp.UI
{
    public partial class ViewSalesUI : System.Web.UI.Page
    {
        private ViewSalesManager viewSalesManager;
            
            public ViewSalesUI ()
	        {
                viewSalesManager = new ViewSalesManager();
	        }
                    
        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Visible = false;
            pdfButton.Visible = false;

        }

        protected void searchButton_OnClick(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;
            if (fromDate == "" || toDate == "")
            {
                fromDateTextBox.Text = "";
                toDateTextBox.Text = "";
                messageLabel.Visible = true;
                messageLabel.Text = "Dates are not valid or Empty";
            }
            else
            {
                fromDateTextBox.Text = "";
                toDateTextBox.Text = "";
                List<ViewSalesModel> tempList = viewSalesManager.GetAllViewSales(fromDate, toDate);
                if (tempList.Count > 0)
                {
                    viewSalesGridView.DataSource = tempList;
                    viewSalesGridView.DataBind();
                    pdfButton.Visible = true;
                }
                else
                {
                    messageLabel.Visible = true;
                messageLabel.Text = "No Data available";
                }
            }
                
            
            
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            PdfPTable pdfPTable = new PdfPTable(viewSalesGridView.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in viewSalesGridView.HeaderRow.Cells)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfPTable.AddCell(pdfPCell);
            }

            int i, k = 1;
            // viewItemGridView.Columns[0].Visible = false;
            foreach (GridViewRow gridViewRow in viewSalesGridView.Rows)
            {
                i = 0;


                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    if (i == 0)
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
            Paragraph para = new Paragraph("Sales Report\n\n", font);
            para.Alignment = Element.ALIGN_CENTER; ;

            pdfdoc.Add(para);

            pdfdoc.Add(pdfPTable);
            pdfdoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=SalesReport.pdf");
            Response.Write(pdfdoc);
            Response.Flush();
            Response.End();
        }

       
    }
}