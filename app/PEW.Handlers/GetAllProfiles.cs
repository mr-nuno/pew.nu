using System.Collections.Generic;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;

namespace PEW.Handlers
{
    public class GetAllProfiles
    {
        private readonly IProfileRepository _repository;

        public GetAllProfiles(IProfileRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Profile> Execute()
        {
            return _repository.GetAll();
        }
    }
}
