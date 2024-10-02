using AggregatorAPI.Services;  

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ICryptoService, CryptoService>();  
builder.Services.AddControllers();  

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();  
app.UseAuthorization();

app.MapControllers();  

app.Run();
