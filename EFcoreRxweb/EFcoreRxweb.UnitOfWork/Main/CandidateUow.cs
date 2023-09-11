using RxWeb.Core.Data;
using EFcoreRxweb.BoundedContext.Main;

namespace EFcoreRxweb.UnitOfWork.Main
{
    public class CandidateUow : BaseUow, ICandidateUow
    {
        public CandidateUow(ICandidateContext context, IRepositoryProvider repositoryProvider) : base(context, repositoryProvider) { }
    }

    public interface ICandidateUow : ICoreUnitOfWork { }
}


