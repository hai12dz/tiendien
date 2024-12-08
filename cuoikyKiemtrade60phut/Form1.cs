using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cuoikyKiemtrade60phut
{
    public partial class Form1 : Form
    {
        string connectString = @"Data Source=hai\SQLEXPRESS;Initial Catalog=cuoikydmt;Integrated Security=True;Encrypt=False";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(connectString);
            loadData();
        }

        private void loadData()
        {
            try
            {
                dt.Clear();
                con.Open();

                // Truy vấn danh sách khách hàng
                cmd = new SqlCommand("SELECT * FROM KhachHang", con);
                adt = new SqlDataAdapter(cmd);
                adt.Fill(dt);
                con.Close();

                dataGridViewHienThi.DataSource = dt;

                // Đặt tiêu đề cột
                dataGridViewHienThi.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                dataGridViewHienThi.Columns["HoTen"].HeaderText = "Họ tên";
                dataGridViewHienThi.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dataGridViewHienThi.Columns["NgayChotSo"].HeaderText = "Ngày chốt số (ngày)";
                dataGridViewHienThi.Columns["SoThangTruoc"].HeaderText = "Số tháng trước";
                dataGridViewHienThi.Columns["SoThangSau"].HeaderText = "Số tháng sau";
                dataGridViewHienThi.Columns["TongTien"].HeaderText = "Tổng tiền";
;
                // Định dạng giao diện
                dataGridViewHienThi.DefaultCellStyle.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private float TinhTienDien(int soThangTruoc, int soThangSau)
        {
            int soDien = soThangSau - soThangTruoc;
            float tongTien = 0;

            if (soDien > 200)
            {
                tongTien += (soDien - 200) * 400 + 100 * 300 + 50 * 200 + 50 * 100;
            }
            else if (soDien > 100)
            {
                tongTien += (soDien - 100) * 300 + 50 * 200 + 50 * 100;
            }
            else if (soDien > 50)
            {
                tongTien += (soDien - 50) * 200 + 50 * 100;
            }
            else
            {
                tongTien += soDien * 100;
            }

            // Thêm thuế GTGT (10%)
            tongTien += tongTien * 0.1f;

            return tongTien;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnClearTextBox_Click(object sender, EventArgs e)
        {
            textBoxMaKH.Enabled = true;
            textBoxMaKH.Clear();
            textBoxHoTenKH.Clear();
            textBoxDiaChi.Clear();
            textBoxNgayChotSo.Clear();
            textBoxSoThangTruoc.Clear();
            textBoxSoThangSau.Clear();
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            textBoxMaKH.Clear();
            textBoxHoTenKH.Clear();
            textBoxDiaChi.Clear();
            textBoxNgayChotSo.Clear();
            textBoxSoThangTruoc.Clear();
            textBoxSoThangSau.Clear();
            textBoxMaKH.Enabled = true; // Cho phép nhập lại mã KH
            textBoxMaKH.Focus();
        }
        private void textBox_KeyPress_ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều hướng
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnThemDS_Click(object sender, EventArgs e)
        {
            int soThangTruoc = 0; // Khởi tạo biến với giá trị mặc định
            int soThangSau = 0;   // Khởi tạo biến với giá trị mặc định

            // Kiểm tra dữ liệu nhập
            if (textBoxMaKH.Text.Length != 6 ||
                string.IsNullOrWhiteSpace(textBoxHoTenKH.Text) ||
                string.IsNullOrWhiteSpace(textBoxDiaChi.Text) ||
                !DateTime.TryParse(textBoxNgayChotSo.Text, out DateTime ngayChotSo) ||
                !int.TryParse(textBoxSoThangTruoc.Text, out soThangTruoc) || // gán giá trị vào soThangTruoc
                !int.TryParse(textBoxSoThangSau.Text, out soThangSau) || // gán giá trị vào soThangSau
                soThangTruoc >= soThangSau)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại!");
                return;
            }

            float tongTien = TinhTienDien(soThangTruoc, soThangSau);

            try
            {
                con.Open();
                string query = "INSERT INTO KhachHang (MaKH, HoTen, DiaChi, NgayChotSo, SoThangTruoc, SoThangSau, TongTien) " +
                               "VALUES (@MaKH, @HoTen, @DiaChi, @NgayChotSo, @SoThangTruoc, @SoThangSau, @TongTien)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaKH", textBoxMaKH.Text);
                cmd.Parameters.AddWithValue("@HoTen", textBoxHoTenKH.Text);
                cmd.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text);
                cmd.Parameters.AddWithValue("@NgayChotSo", ngayChotSo);
                cmd.Parameters.AddWithValue("@SoThangTruoc", soThangTruoc);
                cmd.Parameters.AddWithValue("@SoThangSau", soThangSau);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Thêm thành công! Tổng tiền: {tongTien:N0} VNĐ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                con.Close();
                loadData();
            }
        }

        private void dataGridViewHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewHienThi.Rows[e.RowIndex];

                textBoxMaKH.Text = selectedRow.Cells["MaKH"].Value?.ToString();
                textBoxHoTenKH.Text = selectedRow.Cells["HoTen"].Value?.ToString();
                textBoxDiaChi.Text = selectedRow.Cells["DiaChi"].Value?.ToString();
                textBoxNgayChotSo.Text = selectedRow.Cells["NgayChotSo"].Value?.ToString();
                textBoxSoThangTruoc.Text = selectedRow.Cells["SoThangTruoc"].Value?.ToString();
                textBoxSoThangSau.Text = selectedRow.Cells["SoThangSau"].Value?.ToString();
             
                textBoxMaKH.Enabled = false; // Không cho phép sửa mã KH
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dataGridViewHienThi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.");
                return;
            }

            string maKH = dataGridViewHienThi.CurrentRow.Cells["MaKH"].Value.ToString();

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(textBoxHoTenKH.Text) ||
                string.IsNullOrWhiteSpace(textBoxDiaChi.Text) ||
                !DateTime.TryParse(textBoxNgayChotSo.Text, out DateTime ngayChotSo) ||
                !int.TryParse(textBoxSoThangTruoc.Text, out int soThangTruoc) ||
                !int.TryParse(textBoxSoThangSau.Text, out int soThangSau) ||
                soThangTruoc > soThangSau) // Kiểm tra số tháng trước và số tháng sau
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại!");
                return;
            }

            // Tính tổng tiền sau khi đã kiểm tra dữ liệu hợp lệ
            float tongTien = TinhTienDien(soThangTruoc, soThangSau);

            // Kiểm tra nếu tổng tiền là âm
            if (tongTien < 0)
            {
                MessageBox.Show("Tổng tiền không thể âm. Vui lòng kiểm tra lại số tháng trước và số tháng sau.");
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn cập nhật thông tin khách hàng {maKH}?", "Xác nhận cập nhật", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    string query = "UPDATE KhachHang SET HoTen = @HoTen, DiaChi = @DiaChi, NgayChotSo = @NgayChotSo, " +
                                   "SoThangTruoc = @SoThangTruoc, SoThangSau = @SoThangSau, TongTien = @TongTien " +
                                   "WHERE MaKH = @MaKH";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@HoTen", textBoxHoTenKH.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", textBoxDiaChi.Text);
                    cmd.Parameters.AddWithValue("@NgayChotSo", ngayChotSo);
                    cmd.Parameters.AddWithValue("@SoThangTruoc", soThangTruoc);
                    cmd.Parameters.AddWithValue("@SoThangSau", soThangSau);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
                finally
                {
                    con.Close();
                    loadData();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewHienThi.CurrentRow != null)
            {
                string maKH = dataGridViewHienThi.CurrentRow.Cells["MaKH"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {maKH}?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MaKH", maKH);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                        loadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dataGridViewHienThi.Rows.Count > 0)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DanhSachKhachHang");

                    // Thêm tiêu đề
                    worksheet.Cell("B1").Value = "Công ty XYZ";
                    worksheet.Range("B1:H1").Merge();
                    worksheet.Range("B1:H1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Range("B1:H1").Style.Font.FontColor = XLColor.Blue;

                    worksheet.Cell("B2").Value = "Địa Chỉ: VIETNAM";
                    worksheet.Range("B2:H2").Merge();
                    worksheet.Range("B2:H2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    worksheet.Cell("B4").Value = "DANH SÁCH KHÁCH HÀNG";
                    worksheet.Range("B4:H4").Merge();
                    worksheet.Range("B4:H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Range("B4:H4").Style.Font.FontColor = XLColor.Red;

                    // Thêm tiêu đề cột
                    worksheet.Cell("B6").Value = "STT";
                    worksheet.Cell("C6").Value = "Mã Khách Hàng";
                    worksheet.Cell("D6").Value = "Họ Tên";
                    worksheet.Cell("E6").Value = "Địa Chỉ";
                    worksheet.Cell("F6").Value = "Ngày Chốt Số";
                    worksheet.Cell("G6").Value = "Số Tháng Trước";
                    worksheet.Cell("H6").Value = "Số Tháng Sau";
                    worksheet.Cell("I6").Value = "Tổng Tiền";

                    worksheet.Range("B6:I6").Style.Font.Bold = true;
                    worksheet.Range("B6:I6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Điền dữ liệu từ DataGridView
                    decimal totalAmount = 0;
                    int row = 7;
                    for (int i = 0; i < dataGridViewHienThi.Rows.Count - 1; i++)
                    {
                        worksheet.Cell(row, 2).Value = (i + 1).ToString();
                        worksheet.Cell(row, 3).Value = dataGridViewHienThi.Rows[i].Cells["MaKH"].Value?.ToString();
                        worksheet.Cell(row, 4).Value = dataGridViewHienThi.Rows[i].Cells["HoTen"].Value?.ToString();
                        worksheet.Cell(row, 5).Value = dataGridViewHienThi.Rows[i].Cells["DiaChi"].Value?.ToString();
                        worksheet.Cell(row, 6).Value = dataGridViewHienThi.Rows[i].Cells["NgayChotSo"].Value?.ToString();
                        worksheet.Cell(row, 7).Value = dataGridViewHienThi.Rows[i].Cells["SoThangTruoc"].Value?.ToString();
                        worksheet.Cell(row, 8).Value = dataGridViewHienThi.Rows[i].Cells["SoThangSau"].Value?.ToString();

                        // Tính tổng tiền
                        decimal tongTien = Convert.ToDecimal(dataGridViewHienThi.Rows[i].Cells["TongTien"].Value);
                        worksheet.Cell(row, 9).Value = tongTien;
                        totalAmount += tongTien; // Cộng dồn tổng tiền

                        row++;
                    }

                    // Tính tổng tiền
                    worksheet.Cell(row, 8).Value = "TỔNG TIỀN:";
                    worksheet.Cell(row, 9).Value = totalAmount;
                    worksheet.Cell(row, 9).Style.Font.Bold = true;

                    // Tự động điều chỉnh độ rộng cột
                    worksheet.Columns().AdjustToContents();

                    // Lưu file
                    string filePath = @"E:\zalo\trucquan\cuoikyKiemtrade60phut\xuatFile\DanhSachKhachHang.xlsx"; // Đổi đường dẫn nếu cần
                    workbook.SaveAs(filePath);

                    MessageBox.Show("Lưu thành công tại " + filePath);
                }
            }
            else
            {
                MessageBox.Show("Không có danh sách khách hàng để xuất.");
            }
        }

    }
}
