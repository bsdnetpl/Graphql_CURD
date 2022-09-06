
using Graphql_CURD.Data;
using Graphql_CURD.Shema.Sorting;
using Microsoft.EntityFrameworkCore;

namespace Graphql_CURD.Shema.Query
{
    public class Query
    {
        //[UseDbContext(typeof(MyWorkDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 5)]
        [UseFiltering]
        [UseSorting(typeof(SortingTypes))]
        public async Task<List<Cakes>> AllCakesAsync([Service] MyWorkDbContext myWorkDbContext)
        {
            var result = await myWorkDbContext.Cakes.ToListAsync();
            return result;
        }
        
    }
}
