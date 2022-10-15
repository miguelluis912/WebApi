using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class chinookContext : DbContext
    {
        public chinookContext()
        {
        }

        public chinookContext(DbContextOptions<chinookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Invoiceline> Invoicelines { get; set; } = null!;
        public virtual DbSet<Mediatype> Mediatypes { get; set; } = null!;
        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<Track> Tracks { get; set; } = null!;

        // No es recomendable tener la codaena de conexiona la base de datos, 
        //SearchOption cambio al archivo appsetting, Se deja de referencia
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;database=chinook;uid=luis;pwd=luis", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.2-mariadb"));
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album");

                entity.HasIndex(e => e.ArtistId, "IFK_AlbumArtistId");

                entity.Property(e => e.AlbumId).HasColumnType("int(11)");

                entity.Property(e => e.ArtistId).HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasMaxLength(160)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtistId");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.ArtistId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.SupportRepId, "IFK_CustomerSupportRepId");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasMaxLength(70)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.City)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Company)
                    .HasMaxLength(80)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Country)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.State)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SupportRepId).HasColumnType("int(11)");

                entity.HasOne(d => d.SupportRep)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SupportRepId)
                    .HasConstraintName("FK_CustomerSupportRepId");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.ReportsTo, "IFK_EmployeeReportsTo");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasMaxLength(70)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Country)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ReportsTo).HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_EmployeeReportsTo");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.HasIndex(e => e.CustomerId, "IFK_InvoiceCustomerId");

                entity.Property(e => e.InvoiceId).HasColumnType("int(11)");

                entity.Property(e => e.BillingAddress)
                    .HasMaxLength(70)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.BillingCity)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.BillingCountry)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.BillingPostalCode)
                    .HasMaxLength(10)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.BillingState)
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasPrecision(10, 2);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceCustomerId");
            });

            modelBuilder.Entity<Invoiceline>(entity =>
            {
                entity.ToTable("invoiceline");

                entity.HasIndex(e => e.InvoiceId, "IFK_InvoiceLineInvoiceId");

                entity.HasIndex(e => e.TrackId, "IFK_InvoiceLineTrackId");

                entity.Property(e => e.InvoiceLineId).HasColumnType("int(11)");

                entity.Property(e => e.InvoiceId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.TrackId).HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice).HasPrecision(10, 2);

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Invoicelines)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLineInvoiceId");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Invoicelines)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceLineTrackId");
            });

            modelBuilder.Entity<Mediatype>(entity =>
            {
                entity.ToTable("mediatype");

                entity.Property(e => e.MediaTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("playlist");

                entity.Property(e => e.PlaylistId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasMaxLength(120)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasMany(d => d.Tracks)
                    .WithMany(p => p.Playlists)
                    .UsingEntity<Dictionary<string, object>>(
                        "Playlisttrack",
                        l => l.HasOne<Track>().WithMany().HasForeignKey("TrackId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PlaylistTrackTrackId"),
                        r => r.HasOne<Playlist>().WithMany().HasForeignKey("PlaylistId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PlaylistTrackPlaylistId"),
                        j =>
                        {
                            j.HasKey("PlaylistId", "TrackId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("playlisttrack");

                            j.HasIndex(new[] { "TrackId" }, "IFK_PlaylistTrackTrackId");

                            j.IndexerProperty<int>("PlaylistId").HasColumnType("int(11)");

                            j.IndexerProperty<int>("TrackId").HasColumnType("int(11)");
                        });
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("track");

                entity.HasIndex(e => e.AlbumId, "IFK_TrackAlbumId");

                entity.HasIndex(e => e.GenreId, "IFK_TrackGenreId");

                entity.HasIndex(e => e.MediaTypeId, "IFK_TrackMediaTypeId");

                entity.Property(e => e.TrackId).HasColumnType("int(11)");

                entity.Property(e => e.AlbumId).HasColumnType("int(11)");

                entity.Property(e => e.Bytes).HasColumnType("int(11)");

                entity.Property(e => e.Composer)
                    .HasMaxLength(220)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.GenreId).HasColumnType("int(11)");

                entity.Property(e => e.MediaTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Milliseconds).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UnitPrice).HasPrecision(10, 2);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_TrackAlbumId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_TrackGenreId");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackMediaTypeId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
