
using Graphql_CURD.Data;
using Microsoft.EntityFrameworkCore;

namespace Graphql_CURD.Shema.Query
{
    public class Query
    {
        [UseFiltering]
        
        public async Task<List<Cakes>> AllCakesAsync([Service] MyWorkDbContext myWorkDbContext)
        {
            var result = await myWorkDbContext.Cakes.ToListAsync();
            return result;
        }
        
    }
}
