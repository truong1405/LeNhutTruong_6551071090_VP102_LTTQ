using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThongTinSinhVien.Models;

namespace ThongTinSinhVien;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        SetupDataGridView();
        InitializeDatabase();
        LoadData();
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
        ResetForm();
    }

    private void SetupDataGridView()
    {
        dgvSinhVien.AutoGenerateColumns = false;
        dgvSinhVien.Columns.Clear();

        dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "MaSinhVien",
            HeaderText = "Mã Sinh Viên",
            Name = "MaSinhVien",
            FillWeight = 25
        });

        dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TenSinhVien",
            HeaderText = "Tên Sinh Viên",
            Name = "TenSinhVien",
            FillWeight = 50
        });

        dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "DiemTrungBinh",
            HeaderText = "Điểm Trung Bình",
            Name = "DiemTrungBinh",
            FillWeight = 25
        });
    }

    private void InitializeDatabase()
    {
        try
        {
            using var db = new QuanLySinhVienContext();

            var sinhVienMau = new List<SinhVien>
            {
                new SinhVien { MaSinhVien = "SV001", TenSinhVien = "Nguyễn Văn A", DiemTrungBinh = "8.5" },
                new SinhVien { MaSinhVien = "SV002", TenSinhVien = "Trần Thị B", DiemTrungBinh = "7.0" },
                new SinhVien { MaSinhVien = "SV003", TenSinhVien = "Lê Văn C", DiemTrungBinh = "9.0" },
                new SinhVien { MaSinhVien = "SV004", TenSinhVien = "Phạm Thị D", DiemTrungBinh = "6.5" },
                new SinhVien { MaSinhVien = "SV005", TenSinhVien = "Hoàng Văn E", DiemTrungBinh = "8.0" }
            };

            bool coThayDoi = false;
            foreach (var sv in sinhVienMau)
            {
                if (!db.SinhViens.Any(s => s.MaSinhVien == sv.MaSinhVien))
                {
                    db.SinhViens.Add(sv);
                    coThayDoi = true;
                }
            }

            if (coThayDoi)
            {
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi kết nối cơ sở dữ liệu DuLieu:\n" + ex.Message +
                            "\n\nVui lòng kiểm tra SQL Server của bạn.",
                            "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void LoadData()
    {
        try
        {
            using var db = new QuanLySinhVienContext();
            var danhSach = db.SinhViens.OrderBy(s => s.MaSinhVien).ToList();
            dgvSinhVien.DataSource = danhSach;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không thể tải danh sách sinh viên: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvSinhVien.Rows[e.RowIndex].DataBoundItem is SinhVien sv)
        {
            txtMaSV.Text = sv.MaSinhVien;
            txtTenSV.Text = sv.TenSinhVien;
            txtDiemTB.Text = sv.DiemTrungBinh;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }

    private void ResetForm()
    {
        txtMaSV.Clear();
        txtTenSV.Clear();
        txtDiemTB.Clear();

        dgvSinhVien.ClearSelection();
        dgvSinhVien.CurrentCell = null;

        btnSua.Enabled = false;
        btnXoa.Enabled = false;

        txtMaSV.Focus();
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        string maSV = txtMaSV.Text.Trim();
        string tenSV = txtTenSV.Text.Trim();
        string diemStr = txtDiemTB.Text.Trim();

        if (string.IsNullOrEmpty(maSV))
        {
            MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaSV.Focus();
            return;
        }

        if (string.IsNullOrEmpty(tenSV))
        {
            MessageBox.Show("Vui lòng nhập Tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenSV.Focus();
            return;
        }

        if (!double.TryParse(diemStr.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double diemTB) || diemTB < 0 || diemTB > 10)
        {
            MessageBox.Show("Điểm trung bình phải là số thực từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDiemTB.Focus();
            return;
        }

        try
        {
            using var db = new QuanLySinhVienContext();

            if (db.SinhViens.Any(s => s.MaSinhVien.ToLower() == maSV.ToLower()))
            {
                MessageBox.Show($"Mã sinh viên '{maSV}' đã tồn tại! Vui lòng nhập mã khác.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            var sinhVienMoi = new SinhVien
            {
                MaSinhVien = maSV,
                TenSinhVien = tenSV,
                DiemTrungBinh = Math.Round(diemTB, 2).ToString(System.Globalization.CultureInfo.InvariantCulture)
            };

            db.SinhViens.Add(sinhVienMoi);
            db.SaveChanges();

            MessageBox.Show("Thêm sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
            ResetForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        string maSV = txtMaSV.Text.Trim();
        string tenSV = txtTenSV.Text.Trim();
        string diemStr = txtDiemTB.Text.Trim();

        if (string.IsNullOrEmpty(maSV))
        {
            MessageBox.Show("Vui lòng chọn hoặc nhập Mã sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaSV.Focus();
            return;
        }

        if (string.IsNullOrEmpty(tenSV))
        {
            MessageBox.Show("Vui lòng nhập Tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenSV.Focus();
            return;
        }

        if (!double.TryParse(diemStr.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double diemTB) || diemTB < 0 || diemTB > 10)
        {
            MessageBox.Show("Điểm trung bình phải là số thực từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDiemTB.Focus();
            return;
        }

        try
        {
            using var db = new QuanLySinhVienContext();
            var sv = db.SinhViens.Find(maSV);

            if (sv == null)
            {
                MessageBox.Show($"Không tìm thấy sinh viên có mã '{maSV}' để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sv.TenSinhVien = tenSV;
            sv.DiemTrungBinh = Math.Round(diemTB, 2).ToString(System.Globalization.CultureInfo.InvariantCulture);

            db.SaveChanges();

            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
            ResetForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi sửa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        string maSV = txtMaSV.Text.Trim();

        if (string.IsNullOrEmpty(maSV))
        {
            MessageBox.Show("Vui lòng chọn sinh viên cần xóa trong danh sách hoặc nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaSV.Focus();
            return;
        }

        try
        {
            using var db = new QuanLySinhVienContext();
            var sv = db.SinhViens.Find(maSV);

            if (sv == null)
            {
                MessageBox.Show($"Không tìm thấy sinh viên có mã '{maSV}' để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên '{sv.TenSinhVien}' (Mã: {sv.MaSinhVien}) không?",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (xacNhan == DialogResult.Yes)
            {
                db.SinhViens.Remove(sv);
                db.SaveChanges();

                MessageBox.Show("Xóa sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ResetForm();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnThoat_Click(object sender, EventArgs e)
    {
        var xacNhan = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (xacNhan == DialogResult.Yes)
        {
            Close();
        }
    }
}
