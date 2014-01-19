using System;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;

namespace PEW.Handlers
{
    public class DeleteProfile
    {
        private readonly IProfileRepository _repository;

        public DeleteProfile(IProfileRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Profile profile)
        {
            if (profile == null) throw new ArgumentNullException("Profile cannot be null");
            _repository.Delete(profile);
        }

        public void Execute(string gamerTag)
        {
            Execute(_repository.GetByGamerTag(gamerTag));
        }
    }
}
