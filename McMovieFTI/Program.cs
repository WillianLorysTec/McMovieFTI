var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        builder =>
        {
            builder.WithOrigins("http://example.com",
                                "http://www.contoso.com");
        });

    options.AddPolicy("AnotherPolicy",
        builder =>
        {
            global::Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder corsPolicyBuilder = builder.WithOrigins("http://localhost/4200")
                                .AllowAnyHeader()
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .DisallowCredentials();
                                

        });
});

// Add services to the container.

builder.Services.AddControllers();
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
app.UseCors("AnotherPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
