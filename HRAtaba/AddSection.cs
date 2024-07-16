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

namespace HRAtaba
{
    public partial class AddSection : DevExpress.XtraEditors.XtraForm
    {
        public AddSection()
        {
            InitializeComponent();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (NameTxt.Text == "")
            {
                MessageBox.Show("يرجى ادخال  اسم القسم", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            else
            {
                await AddSectiontodata();
                MessageBox.Show("تمت عملية الأضافة بنجاح", "الأضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public async Task AddSectiontodata()
        {

            var url = "http://localhost:6066/employees/addsection";
            var client = new RestClient(url);

            var request = new RestRequest(url, RestSharp.Method.Post);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("Name", NameTxt.Text);
         




            RestResponse response = await client.ExecuteAsync(request);

        }
    }
}