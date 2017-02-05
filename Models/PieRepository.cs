using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private AppDbContext _dbContext;

        public PieRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Pie> PieOfTheWeek
        {
            get
            {
                return _dbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
            
        }
         

        public IEnumerable<Pie> Pies
        {
            get
            {
                return _dbContext.Pies.Include(c => c.Category);
            }
        }

        public Pie GetPieById(int pieId) => _dbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        
    }
}
