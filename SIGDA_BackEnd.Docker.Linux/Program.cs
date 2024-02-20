using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options =>
    {
        options.AllowAnyOrigin()
        .SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddCors(o => o.AddPolicy("fotocopiado_cors", builder =>
{
    builder.WithOrigins("http://localhost:4200/")
    .SetIsOriginAllowed(origin => true).AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       //ValidIssuer = configuration["JWT:ISSUER_TOKEN"],
                       //ValidAudience = configuration["JWT:AUDIENCE_TOKEN"],
                       //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SECRET_KEY"]))
                       ValidIssuer = "https://plataformacore.poderjudicial-gto.gob.mx",
                       ValidAudience = "https://plataformacore.poderjudicial-gto.gob.mx",
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("s1f04v3rs10n2021dtiyt"))
                   };
               });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("fotocopiado_cors");
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
