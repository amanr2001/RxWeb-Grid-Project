using RxWeb.Core.Data;
using EFcoreRxweb.BoundedContext.Main;

namespace EFcoreRxweb.UnitOfWork.Main
{
    public class CandidateLookupUow : BaseUow, ICandidateLookupUow
    {
        public CandidateLookupUow(ICandidateLookupContext context, IRepositoryProvider repositoryProvider) : base(context, repositoryProvider) { }
    }

    public interface ICandidateLookupUow : ICoreUnitOfWork { }
}


