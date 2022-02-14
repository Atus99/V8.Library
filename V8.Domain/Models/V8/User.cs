using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using V8.Domain.Models.Abstractions;

namespace V8.Domain.Models.V8
{
    [Description("Bảng người dùng hệ thống")]
    public class User : Auditable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Khóa chính")]
        public int ID { get; set; }

        public int IDChannel { get; set; } = 0;

        [Description("ID chức vụ")]
        public int? IDPosition { get; set; }

        [Description("ID đơn vị")]
        public int IDAgency { get; set; }

        [Description("ID Cơ quan")]
        public int IDOrgan { get; set; }

        [MaxLength(50)]
        [Description("Tên tài khoản")]
        public string AccountName { get; set; }

        [Required]
        [MaxLength(50)]
        [Description("Tên người dùng")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Description("Mật khẩu")]
        public string Password { get; set; }

        [MaxLength(20)]
        [Description("Số CCCD/CMT")]
        public string IdentityNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [Description("Email")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        [Description("Số điện thoại")]
        public string Phone { get; set; }

        [Description("Ngày sinh")]
        public DateTime? Birthday { get; set; }

        [MaxLength(250)]
        [Description("Nơi sinh")]
        public string Birthplace { get; set; }

        [MaxLength(250)]
        [Description("Địa chỉ")]
        public string Address { get; set; }

        [Description("Giới tính")]
        public int Gender { get; set; } = 0;

        [Description("Ảnh đại diện")]
        public long? Avatar { get; set; }

        [MaxLength(300)]
        [Description("Mô tả")]
        public string Description { get; set; }

        [Description("Ngày bắt đầu")]
        public DateTime? StartDate { get; set; }

        [Description("Ngày kết thúc")]
        public DateTime? EndDate { get; set; }

        [Description("Trạng thái")]
        public int Status { get; set; } = 1;

        [Description("ID nhóm người dùng")]
        public int? IDTeam { get; set; }

        [Description("Số lần đăng nhập thất bại")]
        public int CountLoginFail { get; set; } = 0;

        [Description("Có quyền cơ quan hay không")]
        public bool HasOrganPermission { get; set; }

        [MaxLength(250)]
        public string FileName { get; set; }

        [MaxLength(1000)]
        public string PhysicalPath { get; set; }

        public int? FileType { get; set; }

        [Column("Size", TypeName = "decimal(18,2)")]
        public decimal? Size { get; set; }
    }
}
