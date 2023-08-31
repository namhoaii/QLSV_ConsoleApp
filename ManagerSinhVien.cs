using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class ManagerSinhVien
    {
        private static ManagerSinhVien _instance = null;
        public static ManagerSinhVien GetInstance()
        {
            if (_instance == null)
                _instance = new ManagerSinhVien();
            return _instance;
        }
        //Nhập thông tin
        public List<SinhVien> Nhap(int soLuong)
        {
            List<SinhVien> sinhVien = new List<SinhVien>();
            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}:");

                Console.Write("Mã SV: ");
                string maSV = Console.ReadLine();

                Console.Write("Họ lót: ");
                string hoLot = Console.ReadLine();

                Console.Write("Tên: ");
                string ten = Console.ReadLine();

                Console.Write("Phái: ");
                string phai = Console.ReadLine();

                Console.Write("Ngày sinh (dd/MM/yyyy): ");
                DateTime ngaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Console.Write("Hộ khẩu thường trú: ");
                string hktt = Console.ReadLine();

                Console.Write("Mã lớp: ");
                string maLop = Console.ReadLine();

                SinhVien sv = new SinhVien
                {
                    MaSV = maSV,
                    HoLot = hoLot,
                    Ten = ten,
                    Phai = phai,
                    NgaySinh = ngaySinh,
                    HKTT = hktt,
                    MaLop = maLop
                };

                sinhVien.Add(sv);
            }

            return sinhVien;
        }

        //Xuất
        public void Xuat(List<SinhVien> sinhVien)
        {
            foreach (var sv in sinhVien)
            {
                Console.Write($"Mã SV: {sv.MaSV}");
                Console.Write($"Họ lót: {sv.HoLot}");
                Console.Write($"Tên: {sv.Ten}");
                Console.Write($"Phái: {sv.Phai}");
                Console.Write($"Ngày sinh: {sv.NgaySinh.ToString("dd/MM/yyyy")}");
                Console.Write($"Hộ khẩu thường trú: {sv.HKTT}");
                Console.Write($"Mã lớp: {sv.MaLop}");
                Console.WriteLine(); // In một dòng trống sau mỗi sinh viên
            }
        }

        //Tach ho lot
        public static string HoLot(string hoVaTen) => hoVaTen.Substring(0, hoVaTen.LastIndexOf(" "));

        //tách tên
        public static string Ten(string hoVaTen) => hoVaTen.Substring(hoVaTen.LastIndexOf(" ") + 1);

        //chỉ nhập 1 para
        public SinhVien TimKiem(List<SinhVien> sinhVien, string ten = "", string hoVaTen = "", string maSV = "")
        {
            if(ten != "")
            {
                return sinhVien.FirstOrDefault(m => m.Ten == ten);
            }
            if(maSV != "")
            {
                return sinhVien.FirstOrDefault(m => m.MaSV == maSV);
            }
            if(hoVaTen != "")
            {
                string hoSV = HoLot(hoVaTen);
                string tenSV = Ten(hoVaTen);
                return sinhVien.FirstOrDefault(m => m.Ten == tenSV && m.HoLot == hoSV);
            }
            return null;
        }

        public SinhVien TimKiemTheoMaLop(List<SinhVien> sinhVien, string maLop) => sinhVien.FirstOrDefault(m => m.MaLop == maLop);

        //xóa
        public bool XoaSV(List<SinhVien> sinhViens, SinhVien sv)
        {
            try
            {
                sinhViens.Remove(sv);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        ////xóa sv theo lớp
        public bool XoaSVTheoLop(List<SinhVien> sinhVien, string maLop)
        {
            try
            {
                for (int i = sinhVien.Count - 1; i >= 0; i--)
                {
                    if (sinhVien[i].MaLop == maLop)
                    {
                        sinhVien.RemoveAt(i);
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        //them sv
        public void ThemVaoDau(List<SinhVien> sinhVien, SinhVien sv) => sinhVien.Insert(0, sv);
        public void ThemVaoCuoi(List<SinhVien> sinhVien, SinhVien sv) => sinhVien.Add(sv);
        public void ThemTheoVT(List<SinhVien> sinhVien, SinhVien sv, int vt) => sinhVien.Insert(vt, sv);

        //sap xep 

        //sắp xếp bằng order by
        public void SortTen(ref List<SinhVien> sinhVien) => sinhVien = sinhVien.OrderBy(m => m.Ten).ToList();

        //Sắp xếp bằng sort (không cần truyền ref)
        public void SortTen(List<SinhVien> sinhVien) => sinhVien.Sort((sv1, sv2) => sv1.Ten.CompareTo(sv2.Ten));
      
        public void SortHoLot(ref List<SinhVien> sinhVien) => sinhVien = sinhVien.OrderBy(m => m.HoLot).ToList();
    }
}
