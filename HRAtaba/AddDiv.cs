using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace HRAtaba
{
    public partial class AddDiv : DevExpress.XtraEditors.XtraForm
    {
        public AddDiv()
        {
            InitializeComponent();
            ReadSection("http://localhost:6066/employees/gets/section");

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


        public async Task AddDevtodata()
        {

            var url = "http://localhost:6066/employees/adddivision";
            var client = new RestClient(url);

            var request = new RestRequest(url, RestSharp.Method.Post);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("idSection", SectionTxt.EditValue.ToString());
            request.AddParameter("Name", NameTxt.Text);





            RestResponse response = await client.ExecuteAsync(request);

        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (NameTxt.Text == "")
            {
                MessageBox.Show("يرجى ادخال  اسم القسم", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            else
            {
                await AddDevtodata();
                MessageBox.Show("تمت عملية الأضافة بنجاح", "الأضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}