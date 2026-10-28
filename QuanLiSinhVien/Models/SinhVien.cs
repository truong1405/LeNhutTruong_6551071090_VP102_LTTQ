using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThongTinSinhVien.Models;

[Table("SinhVien")]
public class SinhVien
{
    [Key]
    [Column("MaSinhVien")]
    public string MaSinhVien { get; set; } = string.Empty;

    [Required]
    [Column("TenSinhVien")]
    public string TenSinhVien { get; set; } = string.Empty;

    [Required]
    [Column("DiemTrungBinh")]
    public string DiemTrungBinh { get; set; } = string.Empty;
}
