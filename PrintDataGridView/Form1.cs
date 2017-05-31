using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace PrintDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StockEntities db = new StockEntities())
            {
                productBindingSource.DataSource = db.Products.ToList();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Factura";//header
            printer.SubTitle = string.Format("Data: {0}", DateTime.Now.Date.ToString());
            printer.TitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.PrintHeader = true;
           
            printer.PrintPreviewDataGridView(dataGridView);
           // printer.PrintDataGridView(dataGridView);
            //printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Footer";
            printer.FooterSpacing = 15;
           


            
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //deschidem dialogul cu imprimanta
        //    PrintDialog printDialog = new PrintDialog();
        //    PrintDocument printDocument = new PrintDocument();
        //    printDialog.Document = printDocument;
        //    printDialog.UseEXDialog = true;
        //    //aici primim documentul
        //    if (DialogResult.OK == printDialog.ShowDialog())
        //    {
        //        printDocument.DocumentName = "De test";
        //        printDocument.Print();
        //    }
        //}

        
        }
        
}
