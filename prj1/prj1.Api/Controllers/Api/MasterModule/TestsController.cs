using Microsoft.AspNetCore.Mvc;
using System.Linq;
using prj1.UnitOfWork.Main;
using prj1.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;

namespace prj1.Api.Controllers.MasterModule
{
    [ApiController]
    [Route("api/[controller]")]
	
	public class TestsController : BaseController<Test,vTest,Test>

    {
        public TestsController(IMasterUow uow):base(uow) {}

    }
}
