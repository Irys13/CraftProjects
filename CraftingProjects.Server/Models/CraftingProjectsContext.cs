using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CraftingProjects.Server.Models;

public partial class CraftingProjectsContext : DbContext
{
    public CraftingProjectsContext()
    {
    }

    public CraftingProjectsContext(DbContextOptions<CraftingProjectsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fabric> Fabrics { get; set; }

    public virtual DbSet<FabricCost> FabricCosts { get; set; }

    public virtual DbSet<FiberBlend> FiberBlends { get; set; }

    public virtual DbSet<Pattern> Patterns { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Yarn> Yarns { get; set; }

    public virtual DbSet<YarnCost> YarnCosts { get; set; }

    public virtual DbSet<YarnStash> YarnStashes { get; set; }

    public virtual DbSet<YarnWeight> YarnWeights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-CC808CD\\SQLEXPRESS01;initial catalog=CraftingProjects;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fabric>(entity =>
        {
            entity.HasKey(e => e.FabricId).HasName("PK__fabric__F53E9CD161167AD1");

            entity.ToTable("fabric");

            entity.Property(e => e.FabricId).HasColumnName("fabricID");
            entity.Property(e => e.Colour)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("colour");
            entity.Property(e => e.ColourDescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("colourDescription");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("height");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");
            entity.Property(e => e.Width)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("width");
        });

        modelBuilder.Entity<FabricCost>(entity =>
        {
            entity.HasKey(e => e.FabricCostId).HasName("PK__fabricCo__F6ACB6B37DBAB4D9");

            entity.ToTable("fabricCost");

            entity.Property(e => e.FabricCostId).HasColumnName("fabricCostID");
            entity.Property(e => e.FabricId).HasColumnName("fabricID");
            entity.Property(e => e.FabricTotalCost)
                .HasComputedColumnSql("([width]*[price])", true)
                .HasColumnType("decimal(13, 4)")
                .HasColumnName("fabricTotalCost");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("height");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchaseDate");
            entity.Property(e => e.Shop)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("shop");
            entity.Property(e => e.Width)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("width");

            entity.HasOne(d => d.Fabric).WithMany(p => p.FabricCosts)
                .HasForeignKey(d => d.FabricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fabricCos__fabri__619B8048");
        });

        modelBuilder.Entity<FiberBlend>(entity =>
        {
            entity.HasKey(e => e.BlendId).HasName("PK__fiber_bl__D6660D7BE7A9A234");

            entity.ToTable("fiberBlends");

            entity.Property(e => e.BlendId).HasColumnName("blendID");
            entity.Property(e => e.FiberType)
                .HasMaxLength(50)
                .HasColumnName("fiberType");
            entity.Property(e => e.Percentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("percentage");
            entity.Property(e => e.YarnId).HasColumnName("yarnID");

            entity.HasOne(d => d.Yarn).WithMany(p => p.FiberBlends)
                .HasForeignKey(d => d.YarnId)
                .HasConstraintName("FK__fiber_ble__yarn___4BAC3F29");
        });

        modelBuilder.Entity<Pattern>(entity =>
        {
            entity.HasKey(e => e.PatternsId).HasName("PK__patterns__3213E83F81562A2F");

            entity.ToTable("patterns");

            entity.Property(e => e.PatternsId).HasColumnName("patternsID");
            entity.Property(e => e.Category)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category");
            entity.Property(e => e.Cost)
                .HasColumnType("money")
                .HasColumnName("cost");
            entity.Property(e => e.Craft)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("craft");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectsId).HasName("PK__projects__3213E83F676EFF4B");

            entity.ToTable("projects");

            entity.Property(e => e.ProjectsId).HasColumnName("projectsID");
            entity.Property(e => e.Craft)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("craft");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Pattern).HasColumnName("pattern");
            entity.Property(e => e.Receiver)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Me")
                .IsFixedLength()
                .HasColumnName("receiver");
            entity.Property(e => e.Resources).HasColumnName("resources");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Backlog")
                .IsFixedLength()
                .HasColumnName("status");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__resource__3213E83F310C8F9C");

            entity.ToTable("resource");

            entity.Property(e => e.ResourceId).HasColumnName("resourceID");
            entity.Property(e => e.ProjectId).HasColumnName("projectID");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.ResourceReferenceId).HasColumnName("resourceReferenceID");
            entity.Property(e => e.ResourceType)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("resourceType");

            entity.HasOne(d => d.Project).WithMany(p => p.ResourcesNavigation)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__resource__projec__5165187F");
        });

        modelBuilder.Entity<Yarn>(entity =>
        {
            entity.HasKey(e => e.YarnId).HasName("PK__yarn__3213E83F637B3A6B");

            entity.ToTable("yarn");

            entity.Property(e => e.YarnId).HasColumnName("yarnID");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("brand");
            entity.Property(e => e.Colour)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("colour");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Metrage).HasColumnName("metrage");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.ThreadWeight).HasColumnName("threadWeight");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<YarnCost>(entity =>
        {
            entity.HasKey(e => e.YarnCostId).HasName("PK__yarnCost__533FE537530235B7");

            entity.ToTable("yarnCost");

            entity.Property(e => e.YarnCostId).HasColumnName("yarnCostID");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchaseDate");
            entity.Property(e => e.Shop)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("shop");
            entity.Property(e => e.Skeins).HasColumnName("skeins");
            entity.Property(e => e.YarnId).HasColumnName("yarnID");
            entity.Property(e => e.YarnTotalCost)
                .HasComputedColumnSql("([skeins]*[price])", true)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("yarnTotalCost");

            entity.HasOne(d => d.Yarn).WithMany(p => p.YarnCosts)
                .HasForeignKey(d => d.YarnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__yarnCost__yarnID__5EBF139D");
        });

        modelBuilder.Entity<YarnStash>(entity =>
        {
            entity.HasKey(e => e.YarnStashId).HasName("PK__yarnStas__3213E83FEB520D25");

            entity.ToTable("yarnStash");

            entity.Property(e => e.YarnStashId).HasColumnName("yarnStashID");
            entity.Property(e => e.Metrage).HasColumnName("metrage");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.YarnId).HasColumnName("yarnID");
        });

        modelBuilder.Entity<YarnWeight>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("yarnWeights");

            entity.Property(e => e.YarnWeightId).HasColumnName("yarnWeightID");
            entity.Property(e => e.YarnWeightName)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("yarnWeightName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
