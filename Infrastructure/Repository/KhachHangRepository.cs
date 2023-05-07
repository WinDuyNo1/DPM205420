using Infrastructure.EF;
using Infrastructure.Entities;
using Infrastructure.Generic;

namespace Infrastructure.Repository
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
    }

    public class KhachhangRepository : Repository<KhachHang>, IKhachHangRepository
    {
        public KhachhangRepository(EXDbContext context) : base(context)
        {
        }
    }
}
