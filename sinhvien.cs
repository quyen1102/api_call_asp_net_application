using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Caller
{
    public class sinhvien
    {
        public int masv { get; set; }
        public string hoten{ get; set; }
        public string diachi { get; set; }
        public string dienthoai { get; set; }
        public int malop { get; set; }
        public string anh { get; set; }

        public sinhvien()
        {
        }

        public sinhvien(int masv, string hoten, string diachi, string dienthoai, int malop, string anh)
        {
            this.masv = masv;
            this.hoten = hoten;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
            this.malop = malop;
            this.anh = anh;
        }
    }
}
