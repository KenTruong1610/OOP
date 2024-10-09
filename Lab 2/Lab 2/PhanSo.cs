using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class PhanSo
    {
        private int _tuSoGoc;
        private int _mauSoGoc;

        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0)
                throw new ArgumentException("Mẫu số không thể là 0.");

            _tuSoGoc = tuSo;
            _mauSoGoc = mauSo;

            TuSo = tuSo;
            MauSo = mauSo;
            RutGon();
        }

        public void RutGon()
        {
            int ucln = UCLN(TuSo, MauSo);
            TuSo /= ucln;
            MauSo /= ucln;
        }

        public int UCLN(int a, int b)
        {
            return b == 0 ? Math.Abs(a) : UCLN(b, a % b);
        }

        public override string ToString()
        {
            return $"{_tuSoGoc}/{_mauSoGoc}";
        }

        public PhanSo Cong(PhanSo ps)
        {
            int tuSo, mauSo;

            if (this.MauSo == ps.MauSo)
            {
                tuSo = this.TuSo + ps.TuSo;
                mauSo = this.MauSo;
            }
            else
            {
                tuSo = this.TuSo * ps.MauSo + ps.TuSo * this.MauSo;
                mauSo = this.MauSo * ps.MauSo;
            }

            return new PhanSo(tuSo, mauSo);
        }

        public PhanSo Tru(PhanSo ps)
        {
            int tuSo, mauSo;

            if (this.MauSo == ps.MauSo)
            {
                tuSo = this.TuSo - ps.TuSo;
                mauSo = this.MauSo;
            }
            else
            {
                tuSo = this.TuSo * ps.MauSo - ps.TuSo * this.MauSo;
                mauSo = this.MauSo * ps.MauSo;
            }

            return new PhanSo(tuSo, mauSo);
        }

        public PhanSo Nhan(PhanSo ps)
        {
            int tuSo = this.TuSo * ps.TuSo;
            int mauSo = this.MauSo * ps.MauSo;
            return new PhanSo(tuSo, mauSo);
        }

        public PhanSo Chia(PhanSo ps)
        {
            int tuSo = this.TuSo * ps.MauSo;
            int mauSo = this.MauSo * ps.TuSo;
            return new PhanSo(tuSo, mauSo);
        }
    }
}
