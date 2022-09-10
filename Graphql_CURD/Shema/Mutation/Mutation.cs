using Graphql_CURD.Data;
using Graphql_CURD.Validators;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Graphql_CURD.Shema.Mutation
{
    public class Mutation
    {
        protected readonly CakeInputTypeValidator _inputTypeValidator;
        protected readonly BooksService _booksService;



        public Mutation(CakeInputTypeValidator inputTypeValidator, BooksService booksService = null)
        {
            _inputTypeValidator = inputTypeValidator;
            _booksService = booksService;
        }

        //public async Task<IActionResult> Post(Book newBook)
        //{
        //    await _booksService.CreateAsync(newBook);
        //    return newBook;
        //    //return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        //}

        //[Authorize]
        public async Task<Cakes> SaveCakesAsync([Service] MyWorkDbContext myWorkDbContext, Cakes cakes)
        {
            myWorkDbContext.Cakes.Add(cakes);
            await myWorkDbContext.SaveChangesAsync();
            return cakes;
        }
        //[Authorize]
        public async Task<Cakes> UpdateCakesAsync([Service] MyWorkDbContext myWorkDbContext, Cakes ubdateCakes)
        {
            myWorkDbContext.Cakes.Update(ubdateCakes);
            await myWorkDbContext.SaveChangesAsync();
            return ubdateCakes;
        }
        //[Authorize(Policy ="IsAdmin")]
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
