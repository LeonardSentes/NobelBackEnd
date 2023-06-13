using NobelBackEnd.Core.Repositories;
using NobelBackEnd.Models;
using NobelBackEnd.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Persistence.Repositories
{
    public class LaureateRepository : GenericRepository<Laureate>, ILaureateRepository
    {

        public LaureateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}