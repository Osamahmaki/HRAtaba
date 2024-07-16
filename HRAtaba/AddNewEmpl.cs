using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraEditors.Controls;
namespace HRAtaba
{
    public partial class AddNewEmpl : DevExpress.XtraEditors.XtraForm
    {
        int id;
        bool updateemp = false;
        public AddNewEmpl()
        {
            InitializeComponent();
            ReadSection("http://localhost:6066/employees/gets/section");
            Readdivision("http://localhost:6066/employees/getd/division/" + SectionTxt.EditValue);

        }

        public AddNewEmpl(int id)
        {
            InitializeComponent();

            this.id= id;
            updateemp = true;
     
            ReadSection("http://localhost:6066/employees/gets/section");
            Readdivision("http://localhost:6066/employees/getd/division/" + SectionTxt.EditValue);
            ReadEmple("http://localhost:6066/employees/" + id);
        }
        private void ReadEmple(string uri)
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
                    NameEmplTxt.Text = arr[0]["NameEmploye"].ToString();
                    SectionTxt.EditValue = arr[0]["Section"];
                    DivTxt.EditValue = arr[0]["Division"];
                    JobTitleTxt.Text = arr[0]["JobTitle"].ToString();
                    PhoneTxt.Text = arr[0]["Phone"].ToString();
                    AddressTxt.Text = arr[0]["Address"].ToString();
                    DateOfBrithTxt.Text = arr[0]["Dateofcontract"].ToString();
                    SalTxt.Text = arr[0]["Salary"].ToString();
                    IdTxt.Text = arr[0]["id"].ToString();

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

        private void ReadSection(string uri)
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
                    SectionTxt.Properties.DataSource = arr;
                    SectionTxt.Properties.DisplayMember = "Name";
                    SectionTxt.Properties.ValueMember = "id";
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

        private void Readdivision(string uri)
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
                    DivTxt.Properties.DataSource = arr;
                    DivTxt.Properties.DisplayMember = "Name";
                    DivTxt.Properties.ValueMember = "id";
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



        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            updateemp = false;
            ClearTxt();
            BtnSave.Enabled = true;
            BtnNew.Enabled = false;
            BtnUpdate.Enabled = false;
            BtnCnx.Enabled = true;
            BtnCnx.BringToFront();

        }

        public void ClearTxt()
        {
            NameEmplTxt.Text = string.Empty;
            SectionTxt.EditValue = 0;
            DivTxt.EditValue = 0;
            JobTitleTxt.Text = string.Empty;
            PhoneTxt.Text = string.Empty;
            AddressTxt.Text = string.Empty;
            SalTxt.EditValue = 0;

        }

        public async Task AddEmpl()
        {
          
                var url = "http://localhost:6066/employees";
                var client = new RestClient(url);

                var request = new RestRequest(url, RestSharp.Method.Post);

                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("NumEmploye", NumberEmpltxt.Text);
                request.AddParameter("NameEmploye", NameEmplTxt.Text);
                request.AddParameter("Section", SectionTxt.EditValue.ToString());
                request.AddParameter("Division", DivTxt.EditValue.ToString());
                request.AddParameter("JobTitle", JobTitleTxt.Text);
                request.AddParameter("Phone", PhoneTxt.Text);
                request.AddParameter("Address", AddressTxt.Text);
                request.AddParameter("Dateofcontract", DateOfBrithTxt.Text);
                request.AddParameter("Salary", SalTxt.EditValue.ToString());
               



                RestResponse response = await client.ExecuteAsync(request);
            
        }


        public async Task UpdateEmpl()
        {

            var url = "http://localhost:6066/employees/updateemploy";
            var client = new RestClient(url);

            var request = new RestRequest(url, RestSharp.Method.Post);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("NumEmploye", NumberEmpltxt.Text);
            request.AddParameter("NameEmploye", NameEmplTxt.Text);
            request.AddParameter("Section", SectionTxt.EditValue.ToString());
            request.AddParameter("Division", DivTxt.EditValue.ToString());
            request.AddParameter("JobTitle", JobTitleTxt.Text);
            request.AddParameter("Phone", PhoneTxt.Text);
            request.AddParameter("Address", AddressTxt.Text);
            request.AddParameter("Dateofcontract", DateOfBrithTxt.Text);
            request.AddParameter("Salary", SalTxt.EditValue.ToString());
            request.AddParameter("id", IdTxt.Text);





            RestResponse response = await client.ExecuteAsync(request);

        }

        public async Task DeleteEmpl()
        {

            var url = "http://localhost:6066/employees/deleteemploy";
            var client = new RestClient(url);

            var request = new RestRequest(url, RestSharp.Method.Post);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("id", IdTxt.EditValue.ToString());


            RestResponse response = await client.ExecuteAsync(request);

        }



        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (NameEmplTxt.Text == "")
            {
                MessageBox.Show("يرجى ادخال اسم الموظف", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else if (SectionTxt.Text == "")
            {
                MessageBox.Show("يرجى ادخال قسم الموظف", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            else if (DivTxt.Text == "")
            {
                MessageBox.Show("يرجى ادخال الشعبه", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else if (JobTitleTxt.Text == "")
            {
                MessageBox.Show("يرجى ادخال العنوان الوظيفي للموظف", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else if (SalTxt.Text == "" || Convert.ToInt32(SalTxt.EditValue) <= 0)
            {
                MessageBox.Show("يرجى ادخال الراتب الاسمي لللموظف", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

          
            else
            {
                if(updateemp==true)
                {
                    await UpdateEmpl();
                    MessageBox.Show("تمت عملية التعديل بنجاح", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    await AddEmpl();
                    MessageBox.Show("تمت عملية الأضافة بنجاح", "الأضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }

        private void AddNewEmpl_Load(object sender, EventArgs e)
        {

        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من الحذف ؟ ", "حذف", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                await DeleteEmpl();

               
                MessageBox.Show("تمت عملية الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
             

                if (updateemp)
                {
                    this.Close();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            updateemp=true;
            BtnNew.Enabled = false;
            BtnSave.Enabled = true;
            BtnUpdate.Enabled = false;
            BtnCnx.BringToFront();
            BtnCnx.Enabled = true;
        }

        private void BtnCnx_Click(object sender, EventArgs e)
        {
            BtnCnx.Enabled = false;
            BtnCnx.SendToBack();
            BtnSave.Enabled = false;
            BtnNew.Enabled = true;
            BtnUpdate.Enabled = true;
            //proceBindingSource.MoveLast();
            BtnNew.BringToFront();
        }

        private void SectionTxt_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = sender as ButtonEdit;
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                new AddSection().ShowDialog();
                ReadSection("http://localhost:6066/employees/gets/section");


            }
            else if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                ReadSection("http://localhost:6066/employees/gets/section");


            }
        }

        private void DivTxt_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = sender as ButtonEdit;
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                new AddDiv().ShowDialog();
                Readdivision("http://localhost:6066/employees/getd/division/" + SectionTxt.EditValue);


            }
            else if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                Readdivision("http://localhost:6066/employees/getd/division/"+ SectionTxt.EditValue);


            }
        }

        private void DivTxt_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SectionTxt_EditValueChanged(object sender, EventArgs e)
        {
            if(SectionTxt.Text!=string.Empty)
            {
                Readdivision("http://localhost:6066/employees/getd/division/"+ SectionTxt.EditValue);

            }
        }
    }
}