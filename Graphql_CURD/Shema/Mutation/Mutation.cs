using Graphql_CURD.Data;
using HotChocolate.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace Graphql_CURD.Shema.Mutation
{
    public class Mutation
    {
        [Authorize]
        public async Task<Cakes> SaveCakesAsync([Service] MyWorkDbContext myWorkDbContext, Cakes cakes)
        {
            myWorkDbContext.Cakes.Add(cakes);
            await myWorkDbContext.SaveChangesAsync();
            return cakes;
        }
        [Authorize]
        public async Task<Cakes> UpdateCakesAsync([Service] MyWorkDbContext myWorkDbContext, Cakes ubdateCakes)
        {
            myWorkDbContext.Cakes.Update(ubdateCakes);
            await myWorkDbContext.SaveChangesAsync();
            return ubdateCakes;
        }
        [Authorize]
        public async Task<string>Delete([Service] MyWorkDbContext myWorkDbContext, int id)
        {
            var cakeToDelete = await myWorkDbContext.Cakes.FindAsync(id);
            if(cakeToDelete is null)
            {
                return "There are not data !";
            }
            myWorkDbContext.Cakes.Remove(cakeToDelete);
            await myWorkDbContext.SaveChangesAsync();
            return "Cake was been deleted";

        }
    }
}
