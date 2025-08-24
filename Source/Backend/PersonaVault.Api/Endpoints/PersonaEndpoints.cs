using PersonaVault.Api.Request;
using PersonaVault.Api.Response;
using PersonaVault.Domain.Entities;
using PersonaVault.Domain.ValueObjects;

namespace PersonaVault.Api.Endpoints;

public static class PersonaEndpoints
{
    public static List<Persona> PersonaList = []; // VAI VIRAR BANCO DE DADOS NO FUTURO
    public static IEndpointRouteBuilder MapPersonaEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/personas").WithTags("Persona");

        group.MapGet("/", () =>
        {
            return Results.Ok(PersonaList.Where(x => x.Active));
        }
        ).WithName("GetAllActivatedPerson").WithOpenApi();

        group.MapGet("/{id:guid}", (Guid id) =>
        {
            Persona? persona = PersonaList.FirstOrDefault(p => p.Id == id);
            return persona is not null ? Results.Ok(persona) : Results.NotFound();
        }).WithOpenApi();

        group.MapGet("/PersonaName", (string Name) =>
        {
            Persona? persona = PersonaList.FirstOrDefault(p => p.Name == Name);
            return persona is not null ? Results.Ok(persona) : Results.NotFound();
        }).WithOpenApi();

        group.MapPost("/Persona", (RequestPersona request) =>
        {
            try
            {
                Name nameVO = new Name(request.Name);
                Email emailVO = new Email(request.Mail);
                Persona persona = new(nameVO, emailVO);

                ResponsePersona response = new(persona.Id, persona.Name);
                PersonaList.Add(persona);
                return Results.Created($"/pessoas/{response.Id}", response);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }

        }).WithOpenApi();

        group.MapPut("/{id:guid}", (Guid id, RequestPersona request) =>
        {
            Persona? persona = PersonaList.FirstOrDefault(x => x.Id == id);
            if (persona is null)
                return Results.NotFound($"{id} don`t exist");

            try
            {
                Name nameVO = new Name(request.Name);
                Email emailVO = new Email(request.Mail);

                persona.Update(nameVO, emailVO);
                return Results.NoContent();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }

        }).WithOpenApi().WithOrder(1);

        group.MapDelete("/{id:guid}", (Guid id) =>
        {
            Persona? persona = PersonaList.FirstOrDefault(p => p.Id == id);
            if (persona is null) return Results.NotFound();
            persona.Deactivate();
            return Results.NoContent();
        }).WithOpenApi();

        return app;
    }
}
