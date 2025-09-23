using WebApplication1.Models;

namespace PayTrack.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        public Task<AppUser> GetAddByAsunce(AppUser appUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> GetAllAsynceAllUser(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByDeleteAsynce(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByIdAsynce(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByUpdatedAsynce(AppUser appUser, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
