using Animals.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var animals = new List<Animal>
{
    new Animal { ID = 1, Name = "Brian", Type = "Dog", Weight = 70, Color = "Brown" },
    new Animal { ID = 2, Name = "Kit", Type = "Cat", Weight = 10, Color = "White"}, 
    new Animal { ID = 3, Name = "Goldy", Type = "Fish", Weight = 1, Color = "Gold"}
};

var visits = new List<Visit>
{
    new Visit { DateOfVisit = DateTime.Now, Animal = animals[0], Description = "Annual checkup", Price = 50 },
    new Visit { DateOfVisit = DateTime.Now, Animal = animals[1], Description = "Vaccination", Price = 30 },
    new Visit { DateOfVisit = DateTime.Now, Animal = animals[2], Description = "Anti drowning vaccination", Price = 10 }
};

app.MapGet("api/animals", () => Results.Ok(animals));

app.MapGet("api/animals/{id}", (int id) => 
{
    var animal = animals.FirstOrDefault(a => a.ID == id);
    return Results.Ok(animal);
});

app.MapPost("api/animals", (Animal newAnimal) => 
{
    animals.Add(newAnimal);
    return Results.Created($"/api/animals/{newAnimal.ID}", newAnimal);
});

app.MapPut("api/animals/{id}", (int id, Animal updatedAnimal) => 
{
    var index = animals.FindIndex(a => a.ID == id);
    animals[index] = updatedAnimal;
    return Results.Ok(updatedAnimal);
});

app.MapDelete("api/animals/{id}", (int id) => 
{
    var animal = animals.FirstOrDefault(a => a.ID == id);
    animals.Remove(animal);
    return Results.Ok(animal);
});

app.MapGet("api/animals/{id}/visits", (int id) => 
{
    var animalVisits = visits.Where(v => v.Animal.ID == id).ToList();
    return Results.Ok(animalVisits);
});

app.MapPost("api/animals/{id}/visits", (int id, Visit newVisit) => 
{
    var animal = animals.FirstOrDefault(a => a.ID == id);
    newVisit.Animal = animal;
    visits.Add(newVisit);
    return Results.Created($"/api/animals/{id}/visits/{visits.Count}", newVisit);
});

app.Run();

