using Infrastructure.Entities;
using Infrastructure.Repository;
using System.Linq;

namespace Infrastructure.Service
{
    public interface IKhachHangService
    {
        IQueryable<KhachHang> GetKhachHang();
        KhachHang GetKhachHang(int id);
        void InsertKhachHang(KhachHang khachhang);
        void UpdateKhachHang(KhachHang khachhang);
        void DeleteKhachHang(KhachHang khachhang);
    }

    public class KhachhangService : IKhachHangService
    {
        private IKhachHangRepository khachhangRepository;

        public KhachhangService(IKhachHangRepository KhachhangRepository)
        {
            this.khachhangRepository = KhachhangRepository;
        }

        public IQueryable<KhachHang> GetKhachHang()
        {
            return khachhangRepository.GetAll();
        }

        public KhachHang GetKhachHang(int id)
        {
            return khachhangRepository.GetById(id);
        }

        public void InsertKhachHang(KhachHang khachhang)
        {
            khachhangRepository.Insert(khachhang);
        }

        public void UpdateKhachHang(KhachHang khachhang)
        {
            khachhangRepository.Update(khachhang);
        }

        public void DeleteKhachHang(KhachHang khachhang)
        {
            khachhangRepository.Delete(khachhang);
        }
    }
}
