namespace Ictshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nguoidung")]
    public partial class Nguoidung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nguoidung()
        {
            Donhang = new HashSet<Donhang>();
        }

        [Key]
        public int MaNguoiDung { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Anhdaidien { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên bắt buộc nhập")]
        public string Hoten { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email bắt buộc nhập")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail sai định dạng")]
        public string Email { get; set; }

        [StringLength(10)]
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Điện thoại bắt buộc nhập")]
        public string Dienthoai { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc nhập")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "Độ dài mật khẩu từ 8-20 kí tự")]
        [Display(Name = "Mật khẩu")]
        public string Matkhau { get; set; }

        public int? IDQuyen { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donhang> Donhang { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
