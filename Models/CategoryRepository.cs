using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> Categories => _dbContext.Categories;
    }
}
