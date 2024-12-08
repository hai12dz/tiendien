namespace cuoikyKiemtrade60phut
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMaKH = new System.Windows.Forms.TextBox();
            this.textBoxHoTenKH = new System.Windows.Forms.TextBox();
            this.textBoxDiaChi = new System.Windows.Forms.TextBox();
            this.textBoxNgayChotSo = new System.Windows.Forms.TextBox();
            this.textBoxSoThangTruoc = new System.Windows.Forms.TextBox();
            this.textBoxSoThangSau = new System.Windows.Forms.TextBox();
            this.dataGridViewHienThi = new System.Windows.Forms.DataGridView();
            this.btnThemDS = new System.Windows.Forms.Button();
            this.btnClearTextBox = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã KH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên KH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày chốt số";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số tháng trước";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số tháng sau";
            // 
            // textBoxMaKH
            // 
            this.textBoxMaKH.Location = new System.Drawing.Point(149, 44);
            this.textBoxMaKH.Name = "textBoxMaKH";
            this.textBoxMaKH.Size = new System.Drawing.Size(186, 22);
            this.textBoxMaKH.TabIndex = 6;
            // 
            // textBoxHoTenKH
            // 
            this.textBoxHoTenKH.Location = new System.Drawing.Point(149, 96);
            this.textBoxHoTenKH.Name = "textBoxHoTenKH";
            this.textBoxHoTenKH.Size = new System.Drawing.Size(186, 22);
            this.textBoxHoTenKH.TabIndex = 7;
            // 
            // textBoxDiaChi
            // 
            this.textBoxDiaChi.Location = new System.Drawing.Point(149, 160);
            this.textBoxDiaChi.Name = "textBoxDiaChi";
            this.textBoxDiaChi.Size = new System.Drawing.Size(186, 22);
            this.textBoxDiaChi.TabIndex = 8;
            // 
            // textBoxNgayChotSo
            // 
            this.textBoxNgayChotSo.Location = new System.Drawing.Point(149, 219);
            this.textBoxNgayChotSo.Name = "textBoxNgayChotSo";
            this.textBoxNgayChotSo.Size = new System.Drawing.Size(186, 22);
            this.textBoxNgayChotSo.TabIndex = 9;
            // 
            // textBoxSoThangTruoc
            // 
            this.textBoxSoThangTruoc.Location = new System.Drawing.Point(149, 301);
            this.textBoxSoThangTruoc.Name = "textBoxSoThangTruoc";
            this.textBoxSoThangTruoc.Size = new System.Drawing.Size(186, 22);
            this.textBoxSoThangTruoc.TabIndex = 10;
            this.textBoxSoThangTruoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress_ChiNhapSo);
            // 
            // textBoxSoThangSau
            // 
            this.textBoxSoThangSau.Location = new System.Drawing.Point(149, 368);
            this.textBoxSoThangSau.Name = "textBoxSoThangSau";
            this.textBoxSoThangSau.Size = new System.Drawing.Size(186, 22);
            this.textBoxSoThangSau.TabIndex = 11;
            this.textBoxSoThangSau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress_ChiNhapSo);
            // 
            // dataGridViewHienThi
            // 
            this.dataGridViewHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHienThi.Location = new System.Drawing.Point(388, 44);
            this.dataGridViewHienThi.Name = "dataGridViewHienThi";
            this.dataGridViewHienThi.RowHeadersWidth = 51;
            this.dataGridViewHienThi.RowTemplate.Height = 24;
            this.dataGridViewHienThi.Size = new System.Drawing.Size(400, 155);
            this.dataGridViewHienThi.TabIndex = 12;
            this.dataGridViewHienThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHienThi_CellClick);
            // 
            // btnThemDS
            // 
            this.btnThemDS.Location = new System.Drawing.Point(44, 420);
            this.btnThemDS.Name = "btnThemDS";
            this.btnThemDS.Size = new System.Drawing.Size(134, 23);
            this.btnThemDS.TabIndex = 13;
            this.btnThemDS.Text = "Thêm vào DS(&T)";
            this.btnThemDS.UseVisualStyleBackColor = true;
            this.btnThemDS.Click += new System.EventHandler(this.btnThemDS_Click);
            // 
            // btnClearTextBox
            // 
            this.btnClearTextBox.Location = new System.Drawing.Point(184, 420);
            this.btnClearTextBox.Name = "btnClearTextBox";
            this.btnClearTextBox.Size = new System.Drawing.Size(104, 23);
            this.btnClearTextBox.TabIndex = 14;
            this.btnClearTextBox.Text = "Thêm mới (&M)";
            this.btnClearTextBox.UseVisualStyleBackColor = true;
            this.btnClearTextBox.Click += new System.EventHandler(this.btnClearTextBox_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(312, 420);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(422, 420);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(115, 23);
            this.btnCapNhat.TabIndex = 16;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Location = new System.Drawing.Point(543, 420);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(75, 23);
            this.btnXuatFile.TabIndex = 17;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(666, 420);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát (&H)";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnClearTextBox);
            this.Controls.Add(this.btnThemDS);
            this.Controls.Add(this.dataGridViewHienThi);
            this.Controls.Add(this.textBoxSoThangSau);
            this.Controls.Add(this.textBoxSoThangTruoc);
            this.Controls.Add(this.textBoxNgayChotSo);
            this.Controls.Add(this.textBoxDiaChi);
            this.Controls.Add(this.textBoxHoTenKH);
            this.Controls.Add(this.textBoxMaKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMaKH;
        private System.Windows.Forms.TextBox textBoxHoTenKH;
        private System.Windows.Forms.TextBox textBoxDiaChi;
        private System.Windows.Forms.TextBox textBoxNgayChotSo;
        private System.Windows.Forms.TextBox textBoxSoThangTruoc;
        private System.Windows.Forms.TextBox textBoxSoThangSau;
        private System.Windows.Forms.DataGridView dataGridViewHienThi;
        private System.Windows.Forms.Button btnThemDS;
        private System.Windows.Forms.Button btnClearTextBox;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnThoat;
    }
}

