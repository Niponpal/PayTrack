using WebApplication1.Models;

namespace PayTrack.Repository
{
    public interface IAppUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllAsynceAllUser(CancellationToken cancellationToken);
        Task<AppUser> GetByIdAsynce(int  id, CancellationToken cancellationToken);
        Task<AppUser> GetAddByAsunce(AppUser appUser, CancellationToken cancellationToken);
        Task<AppUser> GetByDeleteAsynce(int id, CancellationToken cancellationToken);
        Task<AppUser> GetByUpdatedAsynce(AppUser appUser, CancellationToken cancellationToken);
    }
}
