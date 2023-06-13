using NobelBackEnd.Core;
using NobelBackEnd.Core.Repositories;
using NobelBackEnd.MyDatabase;
using NobelBackEnd.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
            Prizes = new PrizeRepository(context);
            Laureates = new LaureateRepository(context);
        }

        public IPrizeRepository Prizes { get; }

        public ILaureateRepository Laureates { get; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}