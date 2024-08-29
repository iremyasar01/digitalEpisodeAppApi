 global using Microsoft.EntityFrameworkCore;
 using digitalEpisodeAppApi.Models;
 //using digitalEpisodeAppApi.Services;

 namespace digitalEpisodeAppApi.Data;
//DbContext veri tabanı ile etkilişeme geçmeyi sağlayan sınıf
public class TvSeriesDbContext : DbContext
{
    public DbSet<TvShowsModel> TvShows { get; set; }
    public DbSet<UsersModel> Users { get; set; }
    public DbSet<MoviesModel> Movies { get; set; }
    public DbSet<EpisodeModel> Episodes { get; set; }
    public DbSet<FavMoviesModel> FavMovies{ get; set; }
    public DbSet<FavSeriesModel> FavSeries { get; set; }
    public DbSet<SeriesWatchModel> SeriesWatch { get; set; }
    public DbSet<MovieWatchModel> MoviesWatch { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=DigitalEpisode;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        modelBuilder.Entity<TvShowsModel>().ToTable("tv_shows");
        modelBuilder.Entity<TvShowsModel>().HasKey(a => a.SeriesId);
        modelBuilder.Entity<TvShowsModel>()
            .HasMany(t => t.FavSeries)
            .WithOne(f => f.TvShows)
            .HasForeignKey(f => f.TvShowId);
        
        modelBuilder.Entity<TvShowsModel>()
            .HasMany(t => t.WatchSeries)
            .WithOne(w => w.tvShows)
            .HasForeignKey(w => w.SeriesId);
        
        
        
        
        
        
        
        modelBuilder.Entity<UsersModel>().ToTable("users");
        modelBuilder.Entity<UsersModel>().HasKey(a => a.UserId);
        */
        
        /*
        modelBuilder.Entity<MoviesModel>().ToTable("movies");
        modelBuilder.Entity<MoviesModel>().HasKey(a => a.MovieId);
        modelBuilder.Entity<MoviesModel>()
            .HasMany(t => t.FavMovies)
            .WithOne(f => f.Movies)
            .HasForeignKey(f => f.MoviesId);
        
        modelBuilder.Entity<MoviesModel>()
            .HasMany(t => t.MovieWatch)
            .WithOne(w => w.Movies)
            .HasForeignKey(w => w.MovieId);
            

        modelBuilder.Entity<EpisodeModel>().ToTable("episodes");
        modelBuilder.Entity<EpisodeModel>().HasKey(a => a.EpisodeId);
        
        modelBuilder.Entity<FavMoviesModel>().ToTable("favMovies");
        modelBuilder.Entity<FavMoviesModel>().HasKey(a => a.FavMoviesId);
        
       // modelBuilder.Entity<FavMoviesModel>()
         //   .HasKey(f => new { f.UserId, f.MoviesId });
        modelBuilder.Entity<UsersModel>()
            .HasMany(u => u.FavMovies)
            .WithOne(f => f.Users)
            .HasForeignKey(f => f.UserId);
        modelBuilder.Entity<UsersModel>()
            .HasMany(u => u.FavSeries)
            .WithOne(f => f.Users)
            .HasForeignKey(f => f.UserId);
        
        */
        /*
        modelBuilder.Entity<FavSeriesModel>().ToTable("favSeries");
        modelBuilder.Entity<FavSeriesModel>().HasKey(a => a.FavSeriesId);
        //modelBuilder.Entity<FavSeriesModel>()
          //  .HasKey(f => new { f.UserId, f.FavSeriesId});
        
        modelBuilder.Entity<UsersModel>()
            .HasMany(u => u.MovieWatch)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId);
        modelBuilder.Entity<UsersModel>()
            .HasMany(u => u.SeriesWatch)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId);
        modelBuilder.Entity<MoviesModel>().ToTable("Movies");
*/
// MovieId'nin birincil anahtar olarak tanımlanması
        modelBuilder.Entity<MoviesModel>().HasKey(x => x.MovieId);

// MovieId'nin otomatik artan kimlik sütunu olarak ayarlanması
        modelBuilder.Entity<MoviesModel>()
            .Property(e => e.MovieId)
            .HasColumnName("MovieId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

// MovieName için maksimum uzunluk ve zorunluluk kısıtlamaları
        modelBuilder.Entity<MoviesModel>()
            .Property(e => e.MovieName)
            //.HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

// PosterPath için zorunluluk kısıtlaması
        modelBuilder.Entity<MoviesModel>()
            .Property(e => e.posterPath)
            //.HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

// MovieOverview için zorunluluk kısıtlaması
        modelBuilder.Entity<MoviesModel>()
            .Property(e => e.movieOverview)
            .IsRequired()
            .ValueGeneratedNever();

// MovieCountry için zorunluluk kısıtlaması
        modelBuilder.Entity<MoviesModel>()
            .Property(e => e.movieCountry)
            .IsRequired()
            .ValueGeneratedNever();

// Vote için maksimum uzunluk ve zorunluluk kısıtlamaları
        modelBuilder.Entity<MoviesModel>()
            .Property(e => e.vote)
            //.HasMaxLength(10)
            .IsRequired()
            .ValueGeneratedNever();

// Genre için maksimum uzunluk ve zorunluluk kısıtlamaları
        modelBuilder.Entity<MoviesModel>()
            .Property(e => e.Genre)
           // .HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

// Foreign key ilişkileri tanımlanıyor
        modelBuilder.Entity<MoviesModel>()
            .HasMany(e => e.FavMovies)
            .WithOne(e => e.Movies)
            .HasForeignKey(e => e.MovieId);

        modelBuilder.Entity<MoviesModel>()
            .HasMany(e => e.MovieWatch)
            .WithOne(e => e.Movies)
            .HasForeignKey(e => e.MovieId);
        modelBuilder.Entity<FavMoviesModel>().ToTable("FavMovies");

        modelBuilder.Entity<FavMoviesModel>().HasKey(x => x.FavMoviesId);

        modelBuilder.Entity<FavMoviesModel>()
            .Property(e => e.FavMoviesId)
            .HasColumnName("FavMoviesId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<FavMoviesModel>()
            .Property(e => e.UserId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<FavMoviesModel>()
            .Property(e => e.MovieId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<FavMoviesModel>()
            .HasOne(e => e.Users)
            .WithMany(e => e.FavMovies)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<FavMoviesModel>()
            .HasOne(e => e.Movies)
            .WithMany(e => e.FavMovies)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<EpisodeModel>().ToTable("Episodes");

        modelBuilder.Entity<EpisodeModel>().HasKey(x => x.EpisodeId);

        modelBuilder.Entity<EpisodeModel>()
            .Property(e => e.EpisodeId)
            .HasColumnName("EpisodeId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<EpisodeModel>()
            .Property(e => e.EpisodeName)
            .HasMaxLength(100)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<EpisodeModel>()
            .Property(e => e.EpisodeNumber)
            .HasMaxLength(10)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<EpisodeModel>()
            .Property(e => e.EpisodeOverview)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<EpisodeModel>()
            .Property(e => e.vote)
            .HasMaxLength(10)
            .IsRequired()
            .ValueGeneratedNever();
        
        modelBuilder.Entity<FavSeriesModel>().ToTable("FavSeries");

        modelBuilder.Entity<FavSeriesModel>().HasKey(x => x.FavSeriesId);

        modelBuilder.Entity<FavSeriesModel>()
            .Property(e => e.FavSeriesId)
            .HasColumnName("FavSeriesId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<FavSeriesModel>()
            .Property(e => e.UserId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<FavSeriesModel>()
            .Property(e => e.SeriesId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<FavSeriesModel>()
            .HasOne(e => e.Users)
            .WithMany(e => e.FavSeries)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<FavSeriesModel>()
            .HasOne(e => e.TvShows)
            .WithMany(e => e.FavSeries)
            .HasForeignKey(e => e.SeriesId);
        
        
        modelBuilder.Entity<MovieWatchModel>().ToTable("MovieWatch");

        modelBuilder.Entity<MovieWatchModel>().HasKey(x => x.MovieWatchId);

        modelBuilder.Entity<MovieWatchModel>()
            .Property(e => e.MovieWatchId)
            .HasColumnName("MovieWatchId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<MovieWatchModel>()
            .Property(e => e.UserId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<MovieWatchModel>()
            .Property(e => e.MovieId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<MovieWatchModel>()
            .HasOne(e => e.User)
            .WithMany(e => e.MovieWatch)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<MovieWatchModel>()
            .HasOne(e => e.Movies)
            .WithMany(e => e.MovieWatch)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<SeriesWatchModel>().ToTable("SeriesWatch");

        modelBuilder.Entity<SeriesWatchModel>().HasKey(x => x.SeriesWatchId);

        modelBuilder.Entity<SeriesWatchModel>()
            .Property(e => e.SeriesWatchId)
            .HasColumnName("SeriesWatchId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<SeriesWatchModel>()
            .Property(e => e.UserId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<SeriesWatchModel>()
            .Property(e => e.SeriesId)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<SeriesWatchModel>()
            .HasOne(e => e.User)
            .WithMany(e => e.SeriesWatch)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<SeriesWatchModel>()
            .HasOne(e => e.tvShows)
            .WithMany(e => e.WatchSeries)
            .HasForeignKey(e => e.SeriesId);
        
        modelBuilder.Entity<TvShowsModel>().ToTable("TvShows");

        modelBuilder.Entity<TvShowsModel>().HasKey(x => x.SeriesId);

        modelBuilder.Entity<TvShowsModel>()
            .Property(e => e.SeriesId)
            .HasColumnName("SeriesId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<TvShowsModel>()
            .Property(e => e.SeriesName)
            .HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<TvShowsModel>()
            .Property(e => e.SeriesPosterPath)
            .HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<TvShowsModel>()
            .Property(e => e.SeriesOverview)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<TvShowsModel>()
            .Property(e => e.SeriesCountry)
            .HasMaxLength(50)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<TvShowsModel>()
            .Property(e => e.SeriesVote)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<TvShowsModel>()
            .Property(e => e.Genre)
            .HasMaxLength(50)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<TvShowsModel>()
            .HasMany(e => e.FavSeries)
            .WithOne(e => e.TvShows)
            .HasForeignKey(e => e.SeriesId);

        modelBuilder.Entity<TvShowsModel>()
            .HasMany(e => e.WatchSeries)
            .WithOne(e => e.tvShows)
            .HasForeignKey(e => e.SeriesId);
        modelBuilder.Entity<UsersModel>().ToTable("Users");

        modelBuilder.Entity<UsersModel>().HasKey(x => x.UserId);

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.UserId)
            .HasColumnName("UserId")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.Email)
            .HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.Username)
            .HasMaxLength(50)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.name)
            .HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.surname)
            .HasMaxLength(200)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.phoneNumber)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.password)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<UsersModel>()
            .Property(e => e.passwordAgain)
            .IsRequired()
            .ValueGeneratedNever();

        modelBuilder.Entity<UsersModel>()
            .HasMany(e => e.FavMovies)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<UsersModel>()
            .HasMany(e => e.FavSeries)
            .WithOne(e => e.Users)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<UsersModel>()
            .HasMany(e => e.SeriesWatch)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<UsersModel>()
            .HasMany(e => e.MovieWatch)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);


        



        
      
        

        
        
        
        
        
        
        /*
        modelBuilder.Entity<SeriesWatchModel>().ToTable("watchSeries");
       // modelBuilder.Entity<SeriesWatchModel>().HasKey(a => a.SeriesWatchId);
        modelBuilder.Entity<SeriesWatchModel>()
            .HasKey(w => new { w.UserId, w.SeriesId });
        
        
        modelBuilder.Entity<MovieWatchService>().ToTable("watchMovies");
       modelBuilder.Entity<MovieWatchModel>().HasKey(a => a.MovieWatchId);
       // modelBuilder.Entity<MovieWatchModel>()
         //   .HasKey(w => new { w.UserId, w.MovieId });
         
      */

        base.OnModelCreating(modelBuilder);
        
    }
}
