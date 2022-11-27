
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category obj)
        {
            _dbContext.Categories.Update(obj);
        }
    }
}
