using System;
using System.Linq;
using PEW.Core.Domain;
using PEW.Core.Exceptions;
using PEW.Core.Interfaces;
using PEW.Core.Interfaces.Data;

namespace PEW.Handlers
{
    public class AddProfile
    {
        private readonly IProfileRepository _repository;
        private readonly IValidator _validator;

        public AddProfile(
            IProfileRepository repository, 
            IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(Profile profile)
        {
            if (profile == null) throw new ArgumentNullException("Profile cannot be null");
            if (_validator.Validate(profile).Any()) throw new ValidationException("Validation failed", _validator.Validate(profile));
            _repository.Add(profile);
        }
    }
}
