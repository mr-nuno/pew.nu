using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;

namespace PEW.Repository
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(IRavenDbDataContext ravenDbContext)
            : base(ravenDbContext)
        {

        }

        public Profile GetByGamerTag(string gamerTag)
        {
            return First(p => p.GamerTag.Equals(gamerTag));
        }
    }
}
