
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BengalBooks.DataAccess.Repository.IRepository;
using BengalBooks.Models;
using BengalBooksWeb.Data;

namespace BengalBooks.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CoverTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(CoverType obj)
        {
            _dbContext.CoverTypes.Update(obj);
        }
    }
}
