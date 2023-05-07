using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace learnX.Models
{
    public class KhachHangViewModel
    {
        public KhachHangViewModel()
        {
        }

        [DisplayName("Ma khach hang")]
        public int Makh { get; set; }

        [DisplayName("Họ và tên")]
        [MaxLength(125, ErrorMessage = "Họ và tên không quá 125 ký tự.")]
        public string ten { get; set; }

        [DisplayName("So dien thoai")]
        public bool SDT { get; set; }

       
    }

}
