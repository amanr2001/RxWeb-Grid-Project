using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestProject.UnitOfWork.Main;
using TestProject.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;

namespace TestProject.Api.Controllers.MasterModule
{
    [ApiController]
    [Route("api/[controller]")]
	
	public class TestsController : BaseController<Test,vTest,Test>

    {
        public TestsController(IMasterUow uow):base(uow) {}

    }
}
