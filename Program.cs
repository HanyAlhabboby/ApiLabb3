
using ApiLabb3.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using ApiLabb3.Models;

namespace ApiLabb3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //Get Persons

            app.MapGet("/persons", async (ApplicationDbContext context) =>
            {
                var persons = await context.Persons.ToListAsync();
                if (persons == null || !persons.Any())
                {
                    return Results.NotFound("Hittade inga personer");
                }
                return Results.Ok(persons);
            });



            // get person by id
            app.MapGet("/person/{PersonId}", async (int personId, ApplicationDbContext context) =>
            {
                var person = await context.Persons.Include(p => p.Interests).FirstOrDefaultAsync(p => p.PersonId == personId);
                if (person == null)
                {
                    return Results.NotFound("person not found");
                }

                var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
                return Results.Json(person, options);
            });



            //get link by interest
            app.MapGet("/InterestLinks/{InterestId}", async (int interestId, ApplicationDbContext context) =>
            {
                var interest = await context.Interests.Include(p => p.Links).FirstOrDefaultAsync(p => p.InterestId == interestId);
                if (interest == null)
                {
                    return Results.NotFound("Interest not found");
                }

                var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
                return Results.Json(interest, options);
            });




            //Skapa ny intresse till personen

            app.MapPost("/person/{personId}/Interests", async (int personId, Interest newInterest, ApplicationDbContext context) =>
            {
                // Hitta personen som ska få ett nytt intresse tillagd

                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Kunde inte hitta personen som vi ska skapa interesse till");
                }

                // Lägg till det nya intresset till personen

                newInterest.FkPersonId = personId;  // Sätt PersonId för det nya intresset
                context.Interests.Add(newInterest);
                await context.SaveChangesAsync();

                var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
                return Results.Json(newInterest, options);
            });




            //Skapa ny länk till personen

            app.MapPost("/person/{personId}/Links", async (int personId, Link newLink, ApplicationDbContext context) =>
            {
                // Hitta personen som ska få en länk till

                var person = await context.Persons.FindAsync(personId);
                if (person == null)
                {
                    return Results.NotFound("Kunde inte hitta personen som vi ska skapa länk till");
                }

                // Lägg till det nya länk till personen

                newLink.FkInterestId = personId;  // Sätt PersonId för den nya länken
                context.Links.Add(newLink);
                await context.SaveChangesAsync();

                var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
                return Results.Json(newLink, options);
            });








            // Get person by id test
            //app.mapget("/persons/{id:int}", async (int id, applicationdbcontext context) =>
            //{
            //    var employee = await context.persons.findasync(id);
            //    if (employee == null)
            //    {
            //        return results.notfound("employee not found");
            //    }
            //    return results.ok(employee);
            //});







            app.Run();
        }
    }
}
