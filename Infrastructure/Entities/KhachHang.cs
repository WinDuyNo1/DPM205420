using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    [Table("Khachhang")]
    public class KhachHang
    {
        [Key]
        public int Makh { get; set; }
        public string Ten { get; set; }
        public int SDT { get; set; }
        
    }
}
