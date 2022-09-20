using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using MinimalAPI;

// Minimal APIs at a glance:
// https://gist.github.com/davidfowl/ff1addd02d239d2d26f4648a06158727

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PersonsDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/person/cnt", (PersonsDbContext db) =>
{
    return db.Persons.Count();
});

app.MapGet("/person/detail/{id:int}", (PersonsDbContext db, int id) =>
{
    return db.Persons.Include(x => x.Address).Include(x => x.Contracts)
                .FirstOrDefault(x => x.Id == id);

});

app.MapPost("/person/add", (PersonsDbContext db, Persons person)
    => PersonActions.AddPerson(db, person));

app.Run();

