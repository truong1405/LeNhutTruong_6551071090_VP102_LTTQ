namespace ThongTinSinhVien;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnThoat = new Button();
        groupBox1 = new GroupBox();
        txtDiemTB = new TextBox();
        lblDiemTB = new Label();
        txtTenSV = new TextBox();
        lblTenSV = new Label();
        txtMaSV = new TextBox();
        lblMaSV = new Label();
        groupBox2 = new GroupBox();
        dgvSinhVien = new DataGridView();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
        SuspendLayout();
        // 
        // btnThem
        // 
        btnThem.Font = new Font("Segoe UI", 9F);
        btnThem.Location = new Point(45, 18);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(85, 32);
        btnThem.TabIndex = 0;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;
        // 
        // btnSua
        // 
        btnSua.Enabled = false;
        btnSua.Font = new Font("Segoe UI", 9F);
        btnSua.Location = new Point(140, 18);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(85, 32);
        btnSua.TabIndex = 1;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;
        // 
        // btnXoa
        // 
        btnXoa.Enabled = false;
        btnXoa.Font = new Font("Segoe UI", 9F);
        btnXoa.Location = new Point(235, 18);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(85, 32);
        btnXoa.TabIndex = 2;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;
        // 
        // btnThoat
        // 
        btnThoat.Font = new Font("Segoe UI", 9F);
        btnThoat.Location = new Point(330, 18);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(85, 32);
        btnThoat.TabIndex = 3;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        groupBox1.Controls.Add(txtDiemTB);
        groupBox1.Controls.Add(lblDiemTB);
        groupBox1.Controls.Add(txtTenSV);
        groupBox1.Controls.Add(lblTenSV);
        groupBox1.Controls.Add(txtMaSV);
        groupBox1.Controls.Add(lblMaSV);
        groupBox1.Font = new Font("Segoe UI", 9F);
        groupBox1.Location = new Point(480, 65);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(275, 360);
        groupBox1.TabIndex = 5;
        groupBox1.TabStop = false;
        groupBox1.Text = "Thông tin sinh viên";
        // 
        // txtDiemTB
        // 
        txtDiemTB.Font = new Font("Segoe UI", 9F);
        txtDiemTB.Location = new Point(25, 230);
        txtDiemTB.Name = "txtDiemTB";
        txtDiemTB.Size = new Size(225, 27);
        txtDiemTB.TabIndex = 5;
        // 
        // lblDiemTB
        // 
        lblDiemTB.AutoSize = true;
        lblDiemTB.Font = new Font("Segoe UI", 9F);
        lblDiemTB.Location = new Point(25, 205);
        lblDiemTB.Name = "lblDiemTB";
        lblDiemTB.Size = new Size(120, 20);
        lblDiemTB.TabIndex = 4;
        lblDiemTB.Text = "Điểm trung bình:";
        // 
        // txtTenSV
        // 
        txtTenSV.Font = new Font("Segoe UI", 9F);
        txtTenSV.Location = new Point(25, 145);
        txtTenSV.Name = "txtTenSV";
        txtTenSV.Size = new Size(225, 27);
        txtTenSV.TabIndex = 3;
        // 
        // lblTenSV
        // 
        lblTenSV.AutoSize = true;
        lblTenSV.Font = new Font("Segoe UI", 9F);
        lblTenSV.Location = new Point(25, 120);
        lblTenSV.Name = "lblTenSV";
        lblTenSV.Size = new Size(96, 20);
        lblTenSV.TabIndex = 2;
        lblTenSV.Text = "Tên sinh viên:";
        // 
        // txtMaSV
        // 
        txtMaSV.Font = new Font("Segoe UI", 9F);
        txtMaSV.Location = new Point(25, 65);
        txtMaSV.Name = "txtMaSV";
        txtMaSV.Size = new Size(225, 27);
        txtMaSV.TabIndex = 1;
        // 
        // lblMaSV
        // 
        lblMaSV.AutoSize = true;
        lblMaSV.Font = new Font("Segoe UI", 9F);
        lblMaSV.Location = new Point(25, 40);
        lblMaSV.Name = "lblMaSV";
        lblMaSV.Size = new Size(94, 20);
        lblMaSV.TabIndex = 0;
        lblMaSV.Text = "Mã sinh viên:";
        // 
        // groupBox2
        // 
        groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox2.Controls.Add(dgvSinhVien);
        groupBox2.Font = new Font("Segoe UI", 9F);
        groupBox2.Location = new Point(25, 65);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(435, 360);
        groupBox2.TabIndex = 4;
        groupBox2.TabStop = false;
        groupBox2.Text = "Danh sách sinh viên";
        // 
        // dgvSinhVien
        // 
        dgvSinhVien.AllowUserToAddRows = false;
        dgvSinhVien.AllowUserToDeleteRows = false;
        dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvSinhVien.BackgroundColor = SystemColors.ControlLight;
        dgvSinhVien.ColumnHeadersHeight = 35;
        dgvSinhVien.Location = new Point(15, 25);
        dgvSinhVien.MultiSelect = false;
        dgvSinhVien.Name = "dgvSinhVien";
        dgvSinhVien.ReadOnly = true;
        dgvSinhVien.RowHeadersVisible = false;
        dgvSinhVien.RowHeadersWidth = 51;
        dgvSinhVien.RowTemplate.Height = 28;
        dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvSinhVien.Size = new Size(405, 320);
        dgvSinhVien.TabIndex = 0;
        dgvSinhVien.CellClick += dgvSinhVien_CellClick;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(780, 450);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Controls.Add(btnThoat);
        Controls.Add(btnXoa);
        Controls.Add(btnSua);
        Controls.Add(btnThem);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý hồ sơ sinh viên / Học phần - VP102";
        Load += Form1_Load;
        Shown += Form1_Shown;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnThoat;
    private GroupBox groupBox1;
    private TextBox txtDiemTB;
    private Label lblDiemTB;
    private TextBox txtTenSV;
    private Label lblTenSV;
    private TextBox txtMaSV;
    private Label lblMaSV;
    private GroupBox groupBox2;
    private DataGridView dgvSinhVien;
}
