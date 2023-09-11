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
	[Access(1)]
	public class StudentsController : BaseController<Student,vStudent,vStudentRecord>

    {
        public StudentsController(IMasterUow uow):base(uow) {}

    }
}
