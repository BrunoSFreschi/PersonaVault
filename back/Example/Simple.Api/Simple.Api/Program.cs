var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<Pessoa> pessoas = [];

app.MapGet("/", () =>
{
    return Results.Ok(pessoas.AsEnumerable());
});


app.MapPost("/", (Pessoa pessoa) =>
{
    pessoa.Guid = Guid.NewGuid();

    pessoa.Id = pessoas.Count != 0 ? pessoas.Max(p => p.Id) + 1 : 1;

    pessoas.Add(pessoa);

    return Results.Created($"/pessoas/{pessoa.Id}", pessoa);
});

app.Run();


public class Pessoa
{
    public Guid Guid { get; set; }
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
}