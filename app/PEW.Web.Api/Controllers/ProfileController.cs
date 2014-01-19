using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PEW.Core;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;
using PEW.Handlers;

namespace PEW.Web.Api.Controllers
{
    public class ProfileController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Profile> Get()
        {
            return Utilities.Use<GetAllProfiles>().Execute();
        }

        public Profile Get(string gamerTag) 
        {
            return Utilities.Use<GetProfileByGamerTag>().Execute(gamerTag);
        }

        public Profile Put(Profile profile)
        {
            Utilities.Use<UpdateProfile>().Execute(profile);
            _unitOfWork.Commit();
            return profile;
        }

        public Profile Post(Profile profile)
        {
            Utilities.Use<AddProfile>().Execute(profile);
            _unitOfWork.Commit();
            return profile;
        }

        public void Delete(string gamerTag)
        {
            Utilities.Use<DeleteProfile>().Execute(gamerTag);
        }
    }
}
