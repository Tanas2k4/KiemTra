using DAL.QLsinhVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LopService
    {
        private Model1 context; // DbContext để tương tác với cơ sở dữ liệu

        public LopService()
        {
            context = new Model1(); // Khởi tạo DbContext
        }

        // Phương thức lấy toàn bộ lớp
        public List<Lop> GetAllLops()
        {
            return context.Lops.ToList(); // Lấy danh sách lớp từ cơ sở dữ liệu
        }

        // Phương thức thêm lớp mới
        public void AddLop(Lop lop)
        {
            context.Lops.Add(lop);
            context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Phương thức xóa lớp theo Mã lớp
        public void DeleteLop(string maLop)
        {
            var lop = context.Lops.Find(maLop); // Tìm lớp theo Mã lớp
            if (lop != null)
            {
                context.Lops.Remove(lop); // Xóa lớp
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }

        // Phương thức cập nhật thông tin lớp
        public void UpdateLop(Lop lop)
        {
            var existingLop = context.Lops.Find(lop.MaLop); // Tìm lớp theo Mã lớp
            if (existingLop != null)
            {
                existingLop.TenLop = lop.TenLop; // Cập nhật tên lớp
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
