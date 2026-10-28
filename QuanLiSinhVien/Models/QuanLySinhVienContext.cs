using Microsoft.EntityFrameworkCore;

namespace ThongTinSinhVien.Models;

public partial class QuanLySinhVienContext : DbContext
{
    // Chuỗi kết nối đến cơ sở dữ liệu DuLieu
    public static string ConnectionString = @"Server=.;Database=DuLieu;Trusted_Connection=True;TrustServerCertificate=True;";

    public QuanLySinhVienContext()
    {
    }

    public QuanLySinhVienContext(DbContextOptions<QuanLySinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.ToTable("SinhVien");
            entity.HasKey(e => e.MaSinhVien);
            entity.Property(e => e.MaSinhVien).HasColumnName("MaSinhVien").IsRequired();
            entity.Property(e => e.TenSinhVien).HasColumnName("TenSinhVien").HasColumnType("ntext").IsRequired();
            entity.Property(e => e.DiemTrungBinh).HasColumnName("DiemTrungBinh").IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
