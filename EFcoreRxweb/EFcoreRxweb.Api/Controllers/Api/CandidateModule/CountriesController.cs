using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EFcoreRxweb.UnitOfWork.Main;
using EFcoreRxweb.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;

namespace EFcoreRxweb.Api.Controllers.CandidateModule
{
    [ApiController]
    [Route("api/[controller]")]
	
	public class CountriesController : BaseController<Country,Country,Country>

    {
        public CountriesController(ICandidateUow uow):base(uow) {}

    }
}
