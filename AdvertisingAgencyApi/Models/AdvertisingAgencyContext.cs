using Microsoft.EntityFrameworkCore;

namespace AdvertisingAgencyApi.Models;

public partial class AdvertisingAgencyContext : DbContext
{
    public AdvertisingAgencyContext()
    {
    }

    public AdvertisingAgencyContext(DbContextOptions<AdvertisingAgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdsRate> AdsRates { get; set; }
    public virtual DbSet<Advertising> Advertisings { get; set; }
    public virtual DbSet<Campaign> Campaigns { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Contract> Contracts { get; set; }
    public virtual DbSet<Manager> Managers { get; set; }
    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=advertising_agency_api;Username=postgres;Password=06082005");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdsRate>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("AdsRate");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostPerClick).HasColumnName("cost_per_click");
            entity.Property(e => e.ClickThroughRate).HasColumnName("click_through_rate");
            entity.Property(e => e.ConversionRate).HasColumnName("conversion_rate");
            entity.Property(e => e.AvgQualityScore).HasColumnName("avg_quality_score");
            entity.HasOne(d => d.Advertising)
                .WithMany(p => p.AdsRates)
                .HasForeignKey(d => d.AdvertisingId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ads_rate_fk_advertising_id");
        });

        modelBuilder.Entity<Advertising>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Advertising");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StartTime).HasColumnType("date").HasColumnName("start_time");
            entity.Property(e => e.EndTime).HasColumnType("date").HasColumnName("end_time");
            entity.Property(e => e.AdvertisingType).HasColumnName("advertising_type");
            entity.Property(e => e.CampaignCode).HasColumnName("campaign_code");
            entity.HasOne(d => d.Campaign)
                .WithMany(p => p.Advertisings)
                .HasForeignKey(d => d.CampaignCode)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("advertising_fk_campaign_code");
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.ContractCode);
            entity.ToTable("Campaign");
            entity.Property(e => e.ContractCode).HasColumnName("contract_code");
            entity.Property(e => e.CurrentStatus).HasMaxLength(50).HasColumnName("current_status");
            entity.Property(e => e.Description).HasMaxLength(300).HasColumnName("description");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.PersonId);
            entity.ToTable("Client");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.CompanyName).HasMaxLength(50).HasColumnName("company_name");

            entity.HasOne(c => c.Person)
                .WithOne(p => p.Client)
                .HasForeignKey<Client>(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("client_fk_person_id");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractCode);
            entity.ToTable("Contract");
            entity.Property(e => e.ContractCode).HasColumnName("contract_code");
            entity.Property(e => e.DateDesigned).HasColumnType("date").HasColumnName("date_designed");
            entity.Property(e => e.ValidFrom).HasColumnType("date").HasColumnName("valid_from");
            entity.Property(e => e.ValidTo).HasColumnType("date").HasColumnName("valid_to");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("contract_fk_manager_id");
            entity.HasOne(d => d.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("contract_fk_client_id");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.PersonId);
            entity.ToTable("Manager");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.StartedWork).HasColumnType("date").HasColumnName("started_work");

            entity.HasOne(m => m.Person)
                .WithOne(p => p.Manager)
                .HasForeignKey<Manager>(m => m.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("manager_fk_person_id");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName).HasMaxLength(255).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasMaxLength(255).HasColumnName("last_name");
            entity.Property(e => e.Email).HasMaxLength(255).HasColumnName("email").IsRequired();
            entity.Property(e => e.Phone).HasMaxLength(20).HasColumnName("phone").IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
