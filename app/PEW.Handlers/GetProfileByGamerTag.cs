using System;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;

namespace PEW.Handlers
{
    public class GetProfileByGamerTag
    {
        private readonly IProfileRepository _repository;

        public GetProfileByGamerTag(IProfileRepository repository)
        {
            _repository = repository;
        }

        public Profile Execute(string gamerTag)
        {
            if(string.IsNullOrEmpty(gamerTag)) throw new ArgumentNullException("GamerTag cannot be empty");
            return _repository.GetByGamerTag(gamerTag);
        }
    }
}
