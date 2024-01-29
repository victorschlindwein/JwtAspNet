using JwtAspNet.Models;
using JwtAspNet.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", (TokenService service) =>
{
    var user = new User(
        1,
        "vitao",
        "vitao@vitao.com",
        "https://avatars.githubusercontent.com/u/35261245?v=4",
        "rova10",
        ["student", "premium"]
    );
    
    return service.Create(user);
});

app.Run();
