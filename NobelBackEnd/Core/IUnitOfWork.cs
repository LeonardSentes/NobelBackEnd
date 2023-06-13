using NobelBackEnd.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPrizeRepository Prizes { get; }
        ILaureateRepository Laureates { get; }
        int Complete();
    }
}