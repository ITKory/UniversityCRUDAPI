using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using System.Collections.Immutable;
using University;
using University.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MykbecgkContext>();
builder.Services.AddTransient<IGenericRepository<FullTimeStudent>, EFGenericRepository<FullTimeStudent>>() ;
builder.Services.AddTransient<IGenericRepository<DistanceLearning>, EFGenericRepository<DistanceLearning>>() ;
builder.Services.AddTransient<IGenericRepository<Person>, EFGenericRepository<Person>>() ;
builder.Services.AddTransient<IGenericRepository<CompetitionType>, EFGenericRepository< CompetitionType>>() ;
 
 
var app = builder.Build();

app.MapGet("/", async (context) => { await context.Response.WriteAsync("Hello World!"); });

 


app.MapGet("/person", async (HttpContext context, MykbecgkContext db, IGenericRepository<Person> people) =>
{
    return await people.GetListAsync();
});
app.MapPost("/person/add", async (HttpContext context,  IGenericRepository<Person> repository, Person person) => {

    var result = await repository.CreateAsync(person);
    if (result is null)
        return new  ();
    return result;
});
app.MapPost("/person/update", (HttpContext context, IGenericRepository<Person> repository,  Person person) =>
{
    repository.Update(person );
     
    var student = repository.FindById((int)person.Id);
    return student;

});
app.MapDelete("/person/del/{id}", (HttpContext context, int id, IGenericRepository<Person> repository) =>
{
    var student = repository.FindById(id);
    if (student is not null)
        repository.Remove(student);

});

app.MapGet("/competitors/distance", async (HttpContext context, IGenericRepository<DistanceLearning> people) =>
{
    return await people.GetListAsync();
});


app.MapGet("/competitors/fulltime", async (HttpContext context, IGenericRepository<FullTimeStudent> people) =>
{
    return await people.GetListAsync();
});
app.MapPost("/competitors/fulltime/add", async (HttpContext context, IGenericRepository<FullTimeStudent> repository, FullTimeStudent   fullTimeStudent) =>
{
    var result = await   repository.CreateAsync(fullTimeStudent);
    if (result is null)
        return new    ();
    return result;

});
app.MapPost("/competitors/distance/add", async (HttpContext context, IGenericRepository<DistanceLearning> repository, DistanceLearning distanceStudent) => 
{
   var result = await   repository.CreateAsync(distanceStudent);
    if (result is null)
        return new   ();
    return result;

});

app.MapPost("/competitors/distance/update", (HttpContext context, IGenericRepository<DistanceLearning> repository, DistanceLearning distanceStudent) =>
{
    repository.Update(distanceStudent);
    
    var student = repository.FindById(distanceStudent.Id);
    return student;

});
app.MapPost("/competitors/fulltime/update", (HttpContext context, IGenericRepository<FullTimeStudent> repository, FullTimeStudent fullTimeStudent) =>
{
    repository.Update(fullTimeStudent);
    var student = repository.FindById(fullTimeStudent.Id);
    return student;

});

app.MapDelete("/competitors/distance/del/{id}", (HttpContext context, IGenericRepository<FullTimeStudent> repository, int id) =>
{
    var student = repository.FindById(id);
    if (student is not null)
        repository.Remove(student);
});
app.MapDelete("/competitors/fulltime/del/{id}", (HttpContext context, IGenericRepository<FullTimeStudent> repository, int id) =>
{
    var student = repository.FindById(id);
    if (student is not null)
        repository.Remove(student);
});

app.MapGet("/competitors/type", async (HttpContext context, IGenericRepository<CompetitionType> type) =>
{
    return await type.GetListAsync();
});
app.MapPost("/type/add", async (HttpContext context, IGenericRepository<CompetitionType> repository, CompetitionType type) => {

    var result = await repository.CreateAsync(type);
    if (result is null)
        return new();
    return result;
});
app.MapPost("/type/update", (HttpContext context, IGenericRepository<CompetitionType> repository, CompetitionType competitionType) =>
{
    repository.Update(competitionType);
    var student = repository.FindById(competitionType.Id);
    return student;

});
app.MapDelete("/type/del/{id}", (HttpContext context, int id, IGenericRepository<CompetitionType> repository) =>
{
    var student = repository.FindById(id);
    if (student is not null)
        repository.Remove(student);

});

 
 
 

 
 
app.Run();
 