WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

List<Persona> personaGroup = [];

app.MapGet("/getPersonaAll", () => Results.Ok(personaGroup.AsEnumerable())).WithName("PersonaVault")
.WithOpenApi();

app.MapGet("/getPersonaId", (long id) =>
{
    Persona? persona = personaGroup.FirstOrDefault(p => p.Id == id);
    return persona is not null ? Results.Ok(persona) : Results.NotFound();
}).WithOpenApi();

app.MapGet("/getPersonaName", (string Name) =>
{
    Persona? persona = personaGroup.FirstOrDefault(p => p.Name == Name);
    return persona is not null ? Results.Ok(persona) : Results.NotFound();
}).WithOpenApi();

app.MapPost("/postPersona", (Persona Persona) =>
{
    Persona.Guid = Guid.NewGuid();
    Persona.Id = personaGroup.Count != 0 ? personaGroup.Max(p => p.Id) + 1 : 1;

    personaGroup.Add(Persona);
    return Results.Created($"/pessoas/{Persona.Id}", Persona);
}).WithOpenApi();

app.MapDelete("/deletePersonaId", (long id) =>
{
    Persona? persona = personaGroup.FirstOrDefault(p => p.Id == id);
    if (persona is null) return Results.NotFound();

    personaGroup.Remove(persona);
    return Results.NoContent();
}).WithOpenApi();

app.MapDelete("/deletePersonaGuid", (Guid id) =>
{
    Persona? persona = personaGroup.FirstOrDefault(p => p.Guid == id);
    if (persona is null) return Results.NotFound();

    personaGroup.Remove(persona);
    return Results.NoContent();
}).WithOpenApi();

app.Run();

public class Persona
{
    public Guid Guid { get; set; }
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
}