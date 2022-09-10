
using Graphql_CURD.Data;
using Graphql_CURD.Shema.Sorting;
using Microsoft.EntityFrameworkCore;
using Graphql_CURD.Data;

namespace Graphql_CURD.Shema.Query
{
   
    public class Query
    {
        private readonly BooksService _booksService;

        public Query(BooksService booksService)
        {
            _booksService = booksService;
        }
        [UseFiltering]
        public async Task<List<Book>> Get() =>
       await _booksService.GetAsync();

  
        //[UseDbContext(typeof(MyWorkDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 15)]
        [UseProjection]
        [UseFiltering]
        [UseSorting(typeof(SortingTypes))]
        public async Task<List<Cakes>> AllCakesAsync([Service] MyWorkDbContext myWorkDbContext)
        {
            var result = await myWorkDbContext.Cakes.ToListAsync();
            return result;
        }
        
    }
}
