using DAL.QLsinhVien;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BUS
{

    public class SinhvienService
    {
        public Model1 context = new Model1();

        // Phương thức lấy toàn bộ sinh viên
        public List<Sinhvien> GetAllSinhviens()
        {
            return context.Sinhviens.ToList(); // Lấy sinh viên và liên kết lớp (nếu cần)
        }

        // Các phương thức khác: Add, Update, Delete
        public void AddSinhvien(Sinhvien sv)
        {
            context.Sinhviens.Add(sv);
            context.SaveChanges();
        }

        public void DeleteSinhvien(string maSV)
        {
            var sv = context.Sinhviens.Find(maSV);
            if (sv != null)
            {
                context.Sinhviens.Remove(sv);
                context.SaveChanges();
            }
        }

        public void UpdateSinhvien(Sinhvien sv)
        {
            var existingSV = context.Sinhviens.Find(sv.MaSV);
            if (existingSV != null)
            {
                existingSV.Hoten = sv.Hoten;
                existingSV.NgaySinh = sv.NgaySinh;
                existingSV.MaLop = sv.MaLop;
                context.SaveChanges();
            }
        }
        public List<Sinhvien> Search(string keyword)
        {
            return context.Sinhviens.Where(p => p.MaSV.Contains(keyword) || p.Hoten.Contains(keyword)).ToList();
        }
    }

}

