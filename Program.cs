global using FunL_backend.Models;
global using FunL_backend.Services.PlatformService;
global using FunL_backend.Services.UserService;
global using FunL_backend.Services.SubscriptionService;
global using FunL_backend.Dtos.Title;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using FunL_backend.Data;
using System.Text.Json.Serialization;
using FunL_backend.Dtos.User;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtSettings>(jwtSettings);

var jwtKey = jwtSettings["Key"];

if (string.IsNullOrEmpty(jwtKey))
{
    throw new ArgumentException("JWT Key is missing or empty in configuration");
}

var key = Encoding.ASCII.GetBytes(jwtKey);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;  // In production, you might want to set this to true
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = false  // Usually set to true if you are specifying an audience
    };
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<AddTitleDto, Title>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Cast, opt => opt.MapFrom(src => src.Cast))
        .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries))
        .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors))
        .ForMember(dest => dest.PosterURLs, opt => opt.MapFrom(src => src.PosterURLs))
        .ForMember(dest => dest.BackdropURLs, opt => opt.MapFrom(src => src.BackdropURLs))
        .ForMember(dest => dest.StreamingServices, opt => opt.MapFrom(src => src.StreamingInfo));

    cfg.CreateMap<AddStreamingServiceInfoDto, StreamingServiceInfo>()
        .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
        .ForMember(dest => dest.Audios, opt => opt.MapFrom(src => src.Audios))
        .ForMember(dest => dest.Subtitles, opt => opt.MapFrom(src => src.Subtitles))
        .ForMember(dest => dest.StreamingPlatformId, opt => opt.Ignore());

    cfg.CreateMap<Title, GetTitleDto>()
    .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.TitleGenres.Select(tg => tg.Genre.Name).ToList()))
    .ForMember(dest => dest.StreamingServices, opt => opt.MapFrom(src => src.StreamingServices));

    cfg.CreateMap<StreamingServiceInfo, GetStreamingServiceInfoDto>()
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceJson))
        .ForMember(dest => dest.Platform, opt => opt.MapFrom(src => src.StreamingPlatform.Name));

    cfg.CreateMap<RegisterUserDto, User>();
    cfg.CreateMap<LoginUserDto, User>();
});
builder.Services.AddSingleton(config.CreateMapper());
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
