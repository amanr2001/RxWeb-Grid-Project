using RxWeb.Core.Data;
using EFcoreRxweb.BoundedContext.Main;

namespace EFcoreRxweb.UnitOfWork.Main
{
    public class LoginUow : BaseUow, ILoginUow
    {
        public LoginUow(ILoginContext context, IRepositoryProvider repositoryProvider) : base(context, repositoryProvider) { }
    }

    public interface ILoginUow : ICoreUnitOfWork { }
}


