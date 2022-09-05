using Graphql_CURD.Data;
using System.Runtime.CompilerServices;

namespace Graphql_CURD.Shema.Mutation
{
    public class Mutation
    {
        public async Task<Cakes> SaveCakesAsync([Service] MyWorkDbContext myWorkDbContext, Cakes cakes)
        {
            myWorkDbContext.Cakes.Add(cakes);
            await myWorkDbContext.SaveChangesAsync();
            return cakes;
        }
        public async Task<Cakes> UpdateCakesAsync([Service] MyWorkDbContext myWorkDbContext, Cakes ubdateCakes)
        {
            myWorkDbContext.Cakes.Update(ubdateCakes);
            await myWorkDbContext.SaveChangesAsync();
            return ubdateCakes;
        }

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
