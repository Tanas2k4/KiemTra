using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS; // Thư viện cho lớp SinhvienService
using DAL.QLsinhVien; // Thư viện cho lớp Sinhvien (Entity class)
namespace TranTrongTan_2280602883
{
    public partial class Form1 : Form
    {
        private SinhvienService sinhvienService;
        private LopService lopService; // Khởi tạo LopService
        public Form1()
        {
            InitializeComponent();
            sinhvienService = new SinhvienService(); // Khởi tạo lớp SinhvienService
            lopService = new LopService(); // Khởi tạo lớp LopService
            LoadSinhVienData();
            LoadLopData();
        }

        private void LoadLopData()
        {
            var lops = lopService.GetAllLops(); // Lấy danh sách lớp
            cbbLop.DataSource = lops; // Đặt DataSource cho ComboBox
            cbbLop.DisplayMember = "TenLop"; // Hiển thị tên lớp
            cbbLop.ValueMember = "MaLop"; // Giá trị lớp
        }
        // Load dữ liệu sinh viên vào DataGridView
        private void LoadSinhVienData()
        {
            dgvSinhvien.DataSource = sinhvienService.GetAllSinhviens();           
            // Ẩn cột "MaLop"
            if (dgvSinhvien.Columns["MaLop"] != null)
            {
                dgvSinhvien.Columns["MaLop"].Visible = false;
            }
            // Thay đổi tên tiêu đề cột
            dgvSinhvien.Columns["MaSV"].HeaderText = "Mã SV"; // Đặt tên cho cột Mã SV
            dgvSinhvien.Columns["Hoten"].HeaderText = "Họ và Tên"; // Đặt tên cho cột Họ và Tên
            dgvSinhvien.Columns["NgaySinh"].HeaderText = "Ngày Sinh"; // Đặt tên cho cột Ngày Sinh
            dgvSinhvien.Columns["Lop"].HeaderText = "Lớp"; // Đặt tên cho cột Lớp
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Sinhvien sv = new Sinhvien
            {
                MaSV = txtMaSV.Text,
                Hoten = txtHoTenSV.Text,
                NgaySinh = dateTimePicker1.Value,
                MaLop = cbbLop.SelectedValue.ToString()
            };

            sinhvienService.AddSinhvien(sv);
            LoadSinhVienData(); // Cập nhật lại DataGridView sau khi thêm
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            sinhvienService.DeleteSinhvien(maSV);
            LoadSinhVienData(); // Cập nhật lại DataGridView sau khi xóa
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sinhvien sv = new Sinhvien
            {
                MaSV = txtMaSV.Text,
                Hoten = txtHoTenSV.Text,
                NgaySinh = dateTimePicker1.Value,
                MaLop = cbbLop.SelectedValue.ToString(),
            };

            sinhvienService.UpdateSinhvien(sv);
            LoadSinhVienData(); // Cập nhật lại DataGridView sau khi sửa
        }

        private void dgvSinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dgvSinhvien.Rows[e.RowIndex];

                // Đổ dữ liệu vào các textbox
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHoTenSV.Text = row.Cells["Hoten"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                cbbLop.Text = row.Cells["Lop"].Value.ToString();
            }
        }
    }
}
