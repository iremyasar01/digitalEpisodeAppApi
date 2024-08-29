using digitalEpisodeAppApi.Data;
using digitalEpisodeAppApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TvSeriesDbContext>();
builder.Services.AddScoped<ITvShowsService, TvShowsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IFavMoviesService, FavMoviesService>();
builder.Services.AddScoped<IFavService, FavSeriesService>();
builder.Services.AddScoped<ISeriesWatchService, SeriesWatchService>();
builder.Services.AddScoped<IMovieWatchService, MovieWatchService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();