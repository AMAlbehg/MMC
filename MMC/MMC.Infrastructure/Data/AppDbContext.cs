using System;
using System.Collections.Generic;
using MMC.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;

namespace MMC.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evenement> Evenements { get; set; }

    public virtual DbSet<Partenaire> Partenaires { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<ParticipementSession> ParticipementSessions { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Speaker> Speakers { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<Support> Supports { get; set; }

    public virtual DbSet<SupportSession> SupportSessions { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BAJFKVA;Database=GestionEvenementMoroccoMicrosoftCommunity;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evenement>(entity =>
        {
            entity.HasKey(e => e.EvenementId).HasName("PK__Evenemen__327074D053F26538");

            entity.ToTable("Evenement");

            entity.Property(e => e.EvenementId)
                .ValueGeneratedNever()
                .HasColumnName("EvenementID");
            entity.Property(e => e.Adresse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Categorie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateDebut).HasColumnType("datetime");
            entity.Property(e => e.DateFin).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FacebookLink)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InstagramLink)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TypeEvenement)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Partenaire>(entity =>
        {
            entity.HasKey(e => e.PartenaireId).HasName("PK__Partenai__5DCADE5D160A9878");

            entity.ToTable("Partenaire");

            entity.Property(e => e.PartenaireId)
                .ValueGeneratedNever()
                .HasColumnName("PartenaireID");
            entity.Property(e => e.EvenementId).HasColumnName("EvenementID");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Evenement).WithMany(p => p.Partenaires)
                .HasForeignKey(d => d.EvenementId)
                .HasConstraintName("FK__Partenair__Evene__48CFD27E");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("PK__Particip__7227997E63A4B22A");

            entity.ToTable("Participant");

            entity.Property(e => e.ParticipantId)
                .ValueGeneratedNever()
                .HasColumnName("ParticipantID");
            entity.Property(e => e.AdresseMail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GSM");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexe)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Societe)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UtilisateurId).HasColumnName("UtilisateurID");
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Participants)
                .HasForeignKey(d => d.UtilisateurId)
                .HasConstraintName("FK__Participa__Utili__71D1E811");
        });

        modelBuilder.Entity<ParticipementSession>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ParticipementSession");

            entity.Property(e => e.DateParticipation)
                .HasColumnType("datetime")
                .HasColumnName("dateParticipation");
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");

            entity.HasOne(d => d.Participant).WithMany()
                .HasForeignKey(d => d.ParticipantId)
                .HasConstraintName("FK__Participe__Parti__6B24EA82");

            entity.HasOne(d => d.Session).WithMany()
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Participe__Sessi__6C190EBB");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Session__C9F492708276AE6F");

            entity.ToTable("Session");

            entity.Property(e => e.SessionId)
                .ValueGeneratedNever()
                .HasColumnName("SessionID");
            entity.Property(e => e.Adresse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EvenementId).HasColumnName("EvenementID");
            entity.Property(e => e.SpeakerId).HasColumnName("SpeakerID");
            entity.Property(e => e.TitreSession)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TypeSession)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UtilisateurId).HasColumnName("UtilisateurID");
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Evenement).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.EvenementId)
                .HasConstraintName("FK__Session__Eveneme__3F466844");

            entity.HasOne(d => d.Speaker).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.SpeakerId)
                .HasConstraintName("FK__Session__Speaker__3E52440B");

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UtilisateurId)
                .HasConstraintName("FK__Session__Utilisa__403A8C7D");
        });

        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.HasKey(e => e.SpeakerId).HasName("PK__Speakers__79E7573926CE7E56");

            entity.HasIndex(e => e.AdresseMail, "UQ__Speakers__F1D9A53D5E5A8C86").IsUnique();

            entity.Property(e => e.SpeakerId)
                .ValueGeneratedNever()
                .HasColumnName("SpeakerID");
            entity.Property(e => e.AdresseMail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Biography).HasColumnType("text");
            entity.Property(e => e.LienFacebook)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LienInstagram)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LienLinkedin)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LienTwitter)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mct).HasColumnName("MCT");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mvp).HasColumnName("MVP");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SiteWeb)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UtilisateurId).HasColumnName("UtilisateurID");

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Speakers)
                .HasForeignKey(d => d.UtilisateurId)
                .HasConstraintName("FK__Speakers__Utilis__70DDC3D8");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.SponsorId).HasName("PK__Sponsor__3B609EF53ECFAFD6");

            entity.ToTable("Sponsor");

            entity.Property(e => e.SponsorId)
                .ValueGeneratedNever()
                .HasColumnName("SponsorID");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SessionId).HasColumnName("SessionID");

            entity.HasOne(d => d.Session).WithMany(p => p.Sponsors)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Sponsor__Session__4316F928");
        });

        modelBuilder.Entity<Support>(entity =>
        {
            entity.HasKey(e => e.SupportId).HasName("PK__Support__D82DBC6C3657DAAE");

            entity.ToTable("Support");

            entity.Property(e => e.SupportId)
                .ValueGeneratedNever()
                .HasColumnName("SupportID");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Statut)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SupportSession>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SupportSession");

            entity.Property(e => e.DateSupportSession)
                .HasColumnType("datetime")
                .HasColumnName("dateSupportSession");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");

            entity.HasOne(d => d.Session).WithMany()
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__SupportSe__Sessi__6EF57B66");

            entity.HasOne(d => d.Support).WithMany()
                .HasForeignKey(d => d.SupportId)
                .HasConstraintName("FK__SupportSe__Suppo__6E01572D");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.ThemeId).HasName("PK__Theme__FBB3E4B9CDD58677");

            entity.ToTable("Theme");

            entity.Property(e => e.ThemeId)
                .ValueGeneratedNever()
                .HasColumnName("ThemeID");
            entity.Property(e => e.EvenementId).HasColumnName("EvenementID");
            entity.Property(e => e.NomTheme)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Evenement).WithMany(p => p.Themes)
                .HasForeignKey(d => d.EvenementId)
                .HasConstraintName("FK__Theme__Evenement__45F365D3");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.UtilisateurId).HasName("PK__Utilisat__6CB6AE1FC76C4830");

            entity.ToTable("Utilisateur");

            entity.HasIndex(e => e.AdresseMail, "UQ__Utilisat__F1D9A53DA9E27FCC").IsUnique();

            entity.Property(e => e.UtilisateurId)
                .ValueGeneratedNever()
                .HasColumnName("UtilisateurID");
            entity.Property(e => e.AdresseMail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GSM");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexe)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Societe)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
