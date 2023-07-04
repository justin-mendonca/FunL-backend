global using FunL_backend.Models;
global using FunL_backend.Services.PlatformService;
global using FunL_backend.Dtos.Title;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using FunL_backend.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using FunL_backend.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
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
});
builder.Services.AddSingleton(config.CreateMapper());

builder.Services.AddScoped<IPlatformService, PlatformService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
