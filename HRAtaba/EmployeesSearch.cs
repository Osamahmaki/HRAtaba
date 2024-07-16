using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using RestSharp;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.LookAndFeel;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using DevExpress.Xpo.DB;

namespace HRAtaba
{
    public partial class EmployeesSearch : DevExpress.XtraEditors.XtraForm
    {
        public EmployeesSearch()
        {
            InitializeComponent();


            ReadAllEmpl("http://localhost:6066/employees/");

            gridView1.BestFitColumns();
          
        }

        private  void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ReadAllEmpl("http://localhost:6066/employees/");

                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }

        private void ReadAllEmpl(string uri)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject<JArray>(s);
                    gridControl1.DataSource = arr;
                }
                else
                {
                    MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {




                this.gridView1.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
                this.gridView1.AppearancePrint.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;
                this.gridView1.OptionsPrint.UsePrintStyles = true;
                PrintingSystem printingSystem = new PrintingSystem();
                PrintableComponentLink printableComponentLink = new PrintableComponentLink(new PrintingSystem());
                printableComponentLink.Component = this.gridControl1;
                printableComponentLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(this.pl_CreateReportHeaderArea);
                printableComponentLink.CreateReportFooterArea += new CreateAreaEventHandler(this.pl_CreateReportFooterArea);
                printableComponentLink.Margins.Left = 10;
                printableComponentLink.Margins.Right = 10;
                printableComponentLink.Margins.Top = 185;
                printableComponentLink.Margins.Bottom = 10;
                printableComponentLink.Landscape = true;
                printableComponentLink.RightToLeftLayout = true;
                printableComponentLink.CreateDocument();
                printableComponentLink.ShowPreview();




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public void pl_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {

            string text = "كشف الموظفين";

            PrintableComponentLink printableComponentLink = sender as PrintableComponentLink;
            e.Graph.Font = new Font("Arial", 12, FontStyle.Bold);


            e.Graph.DrawString(text, Color.Navy, new RectangleF(0.0f, 115f, e.Graph.ClientPageSize.Width, 38f), DevExpress.XtraPrinting.BorderSide.All).StringFormat = new BrickStringFormat(StringAlignment.Far);
        }

        public void pl_CreateReportFooterArea(object sender, CreateAreaEventArgs e)
        {
            string text = "Powered by Osamah Maki / Made in Iraq / Info: +964 7810094624";
            PrintableComponentLink printableComponentLink = sender as PrintableComponentLink;
            e.Graph.DrawString(text, Color.Navy, new RectangleF(0.0f, 60f, e.Graph.ClientPageSize.Width, 35f), DevExpress.XtraPrinting.BorderSide.None).StringFormat = new BrickStringFormat(StringAlignment.Center);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            new AddNewEmpl().ShowDialog();
            ReadAllEmpl("http://localhost:6066/employees/get/1");
        }

        private void BtnShow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            

          var rowH = gridView1.FocusedRowHandle;

         DataRow focusedDataRow = this.gridView1.GetFocusedDataRow();
            
          var id = gridView1.GetFocusedRowCellValue("id");

                 

          new AddNewEmpl(Convert.ToInt32(id)).ShowDialog();
           ReadAllEmpl("http://localhost:6066/employees/");

           gridView1.FocusedRowHandle = rowH;




        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (Convert.ToInt32(e.RowHandle.ToString()) + 1).ToString();

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ReadAllEmpl("http://localhost:6066/employees/get/1");
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                ReadAllEmpl("http://localhost:6066/employees/get/0");
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void EmployeesSearch_Load(object sender, EventArgs e)
        {

        }
    }
}