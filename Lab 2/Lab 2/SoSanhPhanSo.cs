using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class SoSanhPhanSo
    {
        public bool BangNhau(PhanSo ps1, PhanSo ps2)
        {
            int tuSo1 = ps1.TuSo;
            int mauSo1 = ps1.MauSo;
            int tuSo2 = ps2.TuSo;
            int mauSo2 = ps2.MauSo;

            return tuSo1 == tuSo2 && mauSo1 == mauSo2;
        }
    }
}
