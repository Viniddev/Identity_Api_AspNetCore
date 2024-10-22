using IdentityApi.Controllers;
using IdentityApi.Data;
using IdentityApi.Models;
using IdentityApi.Properties;


var builder = WebApplication.CreateBuilder(args);

#region adicionado
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddInfrastructure();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddControllers();
    builder.Services.AddDbContext<AppDbContext>();

    Settings settings = new Settings();

    builder.Services.AddIdentityApiEndpoints<User>()
        .AddEntityFrameworkStores<AppDbContext>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add
app.MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
