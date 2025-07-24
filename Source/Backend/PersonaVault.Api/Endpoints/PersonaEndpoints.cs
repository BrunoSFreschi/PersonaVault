using PersonaVault.Domain.Entities;

namespace PersonaVault.Api.Endpoints;

public static class PersonaEndpoints
{
    public static List<Persona> PersonaList = []; // VAI VIRAR BANCO DE DADOS NO FUTURO
    public static IEndpointRouteBuilder MapPersonaEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/personas").WithTags("Persona");

        group.MapGet("/", () => Results.Ok(PersonaList.AsEnumerable())).WithName("GetAllPersonas")
        .WithOpenApi();

        group.MapGet("/{guid:guid}", (Guid id) =>
        {
            Persona? persona = PersonaList.FirstOrDefault(p => p.Id == id);
            return persona is not null ? Results.Ok(persona) : Results.NotFound();
        }).WithOpenApi();

        group.MapGet("/PersonaName", (string Name) =>
        {
            Persona? persona = PersonaList.FirstOrDefault(p => p.Name == Name);
            return persona is not null ? Results.Ok(persona) : Results.NotFound();
        }).WithOpenApi();

        group.MapPost("/Persona", (Persona Persona) =>
        {
            Persona.Id = Guid.NewGuid();

            PersonaList.Add(Persona);
            return Results.Created($"/pessoas/{Persona.Id}", Persona);
        }).WithOpenApi();

        group.MapDelete("/{guid:guid}", (Guid id) =>
        {
            Persona? persona = PersonaList.FirstOrDefault(p => p.Id == id);
            if (persona is null) return Results.NotFound();

            PersonaList.Remove(persona);
            return Results.NoContent();
        }).WithOpenApi();

        return app;
    }
}
