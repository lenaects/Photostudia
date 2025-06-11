using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhotoStudia_1.Models;

public partial class PhotostudiaContext : DbContext
{
    public PhotostudiaContext()
    {
    }

    public PhotostudiaContext(DbContextOptions<PhotostudiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Completedphoto> Completedphotos { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<MobileService> MobileServices { get; set; }

    public virtual DbSet<Mobileorder> Mobileorders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Photographer> Photographers { get; set; }

    public virtual DbSet<Photographerschedule> Photographerschedules { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<ProfilServiceType> ProfilServiceTypes { get; set; }

    public virtual DbSet<Profilphotographer> Profilphotographers { get; set; }

    public virtual DbSet<Profiltypeshooting> Profiltypeshootings { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Studio> Studios { get; set; }

    public virtual DbSet<StudioImage> StudioImages { get; set; }

    public virtual DbSet<StudioService> StudioServices { get; set; }

    public virtual DbSet<Typeshooting> Typeshootings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=195.19.93.77;Port=5432;Database=Photostudia;Username=postgres;Password=DuB20dub05");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Completedphoto>(entity =>
        {
            entity.HasKey(e => e.Completedphotoid).HasName("completedphotos_pkey");

            entity.ToTable("completedphotos");

            entity.Property(e => e.Completedphotoid).HasColumnName("completedphotoid");
            entity.Property(e => e.Completiondate).HasColumnName("completiondate");
            entity.Property(e => e.Filepath).HasColumnName("filepath");
            entity.Property(e => e.Finalprice)
                .HasPrecision(19, 4)
                .HasColumnName("finalprice");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.Order).WithMany(p => p.Completedphotos)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("completedphotos_orderid_fkey");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("feedback_pkey");

            entity.ToTable("feedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Feedback1).HasColumnName("feedback");
            entity.Property(e => e.Nameclient).HasColumnName("nameclient");
            entity.Property(e => e.Profilphotographerid).HasColumnName("profilphotographerid");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Profilphotographer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Profilphotographerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_feedback_profil");
        });

        modelBuilder.Entity<MobileService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mobile_services_pkey");

            entity.ToTable("mobile_services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.RadiusFromKm)
                .HasPrecision(4, 1)
                .HasColumnName("radius_from_km");
            entity.Property(e => e.RadiusToKm)
                .HasPrecision(4, 1)
                .HasDefaultValueSql("2.0")
                .HasColumnName("radius_to_km");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Service).WithMany(p => p.MobileServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("mobile_services_service_id_fkey");
        });

        modelBuilder.Entity<Mobileorder>(entity =>
        {
            entity.HasKey(e => e.Mobileorderid).HasName("mobileorder_pkey");

            entity.ToTable("mobileorder");

            entity.Property(e => e.Mobileorderid).HasColumnName("mobileorderid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Eventaddress).HasColumnName("eventaddress");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.Order).WithMany(p => p.Mobileorders)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mobileorder_orderid_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Appointmentdate).HasColumnName("appointmentdate");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.Photographerid).HasColumnName("photographerid");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
            entity.Property(e => e.Typeshootingid).HasColumnName("typeshootingid");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_clientid_fkey");

            entity.HasOne(d => d.Photographer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Photographerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_photographerid_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_service");

            entity.HasOne(d => d.Typeshooting).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Typeshootingid)
                .HasConstraintName("fk_orders_typeshootingid");
        });

        modelBuilder.Entity<Photographer>(entity =>
        {
            entity.HasKey(e => e.Photographerid).HasName("photographers_pkey");

            entity.ToTable("photographers");

            entity.Property(e => e.Photographerid).HasColumnName("photographerid");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Salt).HasColumnName("salt");
        });

        modelBuilder.Entity<Photographerschedule>(entity =>
        {
            entity.HasKey(e => e.Scheduleid).HasName("photographerschedules_pkey");

            entity.ToTable("photographerschedules");

            entity.Property(e => e.Scheduleid).HasColumnName("scheduleid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Photographerid).HasColumnName("photographerid");
            entity.Property(e => e.Starttime).HasColumnName("starttime");

            entity.HasOne(d => d.Photographer).WithMany(p => p.Photographerschedules)
                .HasForeignKey(d => d.Photographerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("photographerschedules_photographerid_fkey");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("portfolio_pkey");

            entity.ToTable("portfolio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Profilphotographerid).HasColumnName("profilphotographerid");

            entity.HasOne(d => d.Profilphotographer).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.Profilphotographerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_portfolio_profil");
        });

        modelBuilder.Entity<ProfilServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profil_service_type_pkey");

            entity.ToTable("profil_service_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProfilphotographerId).HasColumnName("profilphotographer_id");
            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");

            entity.HasOne(d => d.Profilphotographer).WithMany(p => p.ProfilServiceTypes)
                .HasForeignKey(d => d.ProfilphotographerId)
                .HasConstraintName("profil_service_type_profilphotographer_id_fkey");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.ProfilServiceTypes)
                .HasForeignKey(d => d.ServiceTypeId)
                .HasConstraintName("profil_service_type_service_type_id_fkey");
        });

        modelBuilder.Entity<Profilphotographer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profilphotographers_pkey");

            entity.ToTable("profilphotographers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Pfotographerid).HasColumnName("pfotographerid");

            entity.HasOne(d => d.Pfotographer).WithMany(p => p.Profilphotographers)
                .HasForeignKey(d => d.Pfotographerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_profil_photographer");
        });

        modelBuilder.Entity<Profiltypeshooting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profiltypeshooting_pkey");

            entity.ToTable("profiltypeshooting");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Profilphotographerid).HasColumnName("profilphotographerid");
            entity.Property(e => e.Typeshootingid).HasColumnName("typeshootingid");

            entity.HasOne(d => d.Profilphotographer).WithMany(p => p.Profiltypeshootings)
                .HasForeignKey(d => d.Profilphotographerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_profilphotographer");

            entity.HasOne(d => d.Typeshooting).WithMany(p => p.Profiltypeshootings)
                .HasForeignKey(d => d.Typeshootingid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profiltypeshooting_typeshootingid_fkey");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("requests_pkey");

            entity.ToTable("requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientEmail).HasColumnName("client_email");
            entity.Property(e => e.ClientName).HasColumnName("client_name");
            entity.Property(e => e.ClientPhone).HasColumnName("client_phone");
            entity.Property(e => e.PhotographerId).HasColumnName("photographer_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
            entity.Property(e => e.ShootingDate).HasColumnName("shooting_date");
            entity.Property(e => e.ShootingTypeId).HasColumnName("shooting_type_id");

            entity.HasOne(d => d.Photographer).WithMany(p => p.Requests)
                .HasForeignKey(d => d.PhotographerId)
                .HasConstraintName("requests_photographer_id_fkey");

            entity.HasOne(d => d.Service).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("requests_service_id_fkey");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ServiceTypeId)
                .HasConstraintName("requests_service_type_id_fkey");

            entity.HasOne(d => d.ShootingType).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ShootingTypeId)
                .HasConstraintName("requests_shooting_type_id_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
            entity.Property(e => e.Unit).HasColumnName("unit");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceTypeId)
                .HasConstraintName("services_service_type_id_fkey");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.ServiceTypeId).HasName("service_types_pkey");

            entity.ToTable("service_types");

            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Studio>(entity =>
        {
            entity.HasKey(e => e.StudioId).HasName("studios_pkey");

            entity.ToTable("studios");

            entity.Property(e => e.StudioId).HasColumnName("studio_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.PricePerHour)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_hour");
        });

        modelBuilder.Entity<StudioImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("studio_images_pkey");

            entity.ToTable("studio_images");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.StudioId).HasColumnName("studio_id");

            entity.HasOne(d => d.Studio).WithMany(p => p.StudioImages)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("studio_images_studio_id_fkey");
        });

        modelBuilder.Entity<StudioService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("studio_services_pkey");

            entity.ToTable("studio_services");

            entity.HasIndex(e => e.ServiceId, "studio_services_service_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StudioId).HasColumnName("studio_id");

            entity.HasOne(d => d.Service).WithOne(p => p.StudioService)
                .HasForeignKey<StudioService>(d => d.ServiceId)
                .HasConstraintName("studio_services_service_id_fkey");

            entity.HasOne(d => d.Studio).WithMany(p => p.StudioServices)
                .HasForeignKey(d => d.StudioId)
                .HasConstraintName("studio_services_studio_id_fkey");
        });

        modelBuilder.Entity<Typeshooting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("typeshooting_pkey");

            entity.ToTable("typeshooting");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Typeshooting1).HasColumnName("typeshooting");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
