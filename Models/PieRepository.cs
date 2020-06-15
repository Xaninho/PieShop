using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class PieRepository :IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // Method to return all the pies in the database
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return appDbContext.Pies.Include(c => c.Category);
            }
        }

        // Returns all pies which 'IsPieOfTheWeek' attribute = true
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        // Returns a pie given its Id
        public Pie GetPieById(int pieId)
        {
            return appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
