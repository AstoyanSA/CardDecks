var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<CardDecksDbContext>(options =>
    options.UseInMemoryDatabase("DeckStorage"));
builder.Services.AddRepositories();
builder.Services.AddFacades();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
