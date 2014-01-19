using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEW.Core.Domain;
using PEW.Core.Exceptions;
using PEW.Core.Interfaces;
using PEW.Core.Interfaces.Data;

namespace PEW.Handlers
{
    public class UpdateProfile
    {
        private readonly IProfileRepository _repository;
        private readonly IValidator _validator;

        public UpdateProfile(
            IProfileRepository repository, 
            IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(Profile profile)
        {
            if(profile == null) throw new ArgumentNullException("Profile cannot be null");
            var fromDb = _repository.GetByGamerTag(profile.GamerTag);

            fromDb.Game = profile.Game;
            fromDb.Console = profile.Console;
            fromDb.Friends = profile.Friends;
            fromDb.FirstName = profile.FirstName;
            fromDb.LastName = profile.LastName;
            fromDb.Gravatar = profile.Gravatar;
            fromDb.HistoryCount = profile.HistoryCount;
            fromDb.Email = profile.Email;
            fromDb.Theme = profile.Theme;

            if (_validator.Validate(fromDb).Any()) throw new ValidationException("Validation failed", _validator.Validate(fromDb));
        }
    }
}
