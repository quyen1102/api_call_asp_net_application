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
using System.Runtime.Serialization.Json;
using System.Collections.Specialized;
namespace API_Caller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getListSV();
        }
        public void getListSV()
        {
            string url = "http://localhost:90/School/api/th/listSV";
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(sinhvien[]));
            object data = js.ReadObject(res.GetResponseStream());
            sinhvien[] listSV = (sinhvien[])data;
            DataSVGrid.DataSource = listSV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getListSV();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string id = string.Format("?id={0}", maTxt.Text);
            string url = "http://localhost:90/School/api/th/findSV" + id;
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(sinhvien));
            object data = js.ReadObject(res.GetResponseStream());
            sinhvien sv = (sinhvien)data;
            DataSVGrid.DataSource = sv;
            maTxt.Text = sv.masv.ToString();
            tenTxt.Text = sv.hoten;
            diachiTxt.Text = sv.diachi;
            dtTxt.Text = sv.dienthoai;
            maLopTxt.Text = sv.malop.ToString();
            anhTxt.Text = sv.anh;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string url = "http://localhost:90/School/api/th/addSV";
            var client = new WebClient();
            var sv = new NameValueCollection();
            sv["masv"] = maTxt.Text;
            sv["hoten"] = tenTxt.Text;
            sv["diachi"] = diachiTxt.Text;
            sv["dienthoai"] = dtTxt.Text;
            sv["malop"] = maLopTxt.Text;
            sv["anh"] = anhTxt.Text;
            //them
            var res = client.UploadValues(url, sv);
            string msg = Encoding.UTF8.GetString(res);
            MessageBox.Show("Ket qua them " + msg);
            getListSV();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:90/School/api/th/editSV";
            var client = new WebClient();
            var sv = new NameValueCollection();
            sv["masv"] = maTxt.Text;
            sv["hoten"] = tenTxt.Text;
            sv["diachi"] = diachiTxt.Text;
            sv["dienthoai"] = dtTxt.Text;
            sv["malop"] = maLopTxt.Text;
            sv["anh"] = anhTxt.Text;
            //them
            var res = client.UploadValues(url,"PUT", sv);
            string msg = Encoding.UTF8.GetString(res);
            MessageBox.Show("Ket qua them " + msg);
            getListSV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = string.Format("?id={0}", maTxt.Text);
            string url = "http://localhost:90/School/api/th/delSV" + id;
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if(res.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Xoa thanh xong sv ma:" + maTxt.Text);
            }
            else
            {
                MessageBox.Show("Loi xoa sv ma:"+ maTxt.Text);
            }
        }
    }
}
