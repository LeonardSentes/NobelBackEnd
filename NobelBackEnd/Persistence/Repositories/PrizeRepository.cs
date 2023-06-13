using NobelBackEnd.Core.Repositories;
using NobelBackEnd.Models;
using NobelBackEnd.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Persistence.Repositories
{
    public class PrizeRepository : GenericRepository<Prize>, IPrizeRepository
    {
     
        public PrizeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        
    }
}