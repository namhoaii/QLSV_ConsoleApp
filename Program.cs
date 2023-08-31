using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class Program
    {
        static void Main(string[] args)
        {
            SinhVien sv = new SinhVien
            {
                MaSV = "c110",
                HoLot = "Them",
                Ten = "Vao",
                Phai = "nam",
                NgaySinh = DateTime.Now,
                HKTT = "a 2",
                MaLop = "No"
            };
            List<SinhVien> sinhVien = new List<SinhVien>();
            Console.Write("Nhap SL SV: ");
            sinhVien = ManagerSinhVien.GetInstance().Nhap(int.Parse(Console.ReadLine()));
            ManagerSinhVien.GetInstance().Xuat(sinhVien);
            /*ManagerSinhVien.GetInstance().ThemTheoVT(sinhVien, sv, 0);*/
            ManagerSinhVien.GetInstance().SortTen(sinhVien);

            Console.WriteLine("Sau khi Them");
            ManagerSinhVien.GetInstance().Xuat(sinhVien);


            Console.ReadKey();
        }
    }
}
