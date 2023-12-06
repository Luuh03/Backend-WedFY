using System;
using System.Collections.Generic;
using APIWedfy.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWedfy.Data;

public partial class WedfyContext : DbContext
{
    public WedfyContext(DbContextOptions<WedfyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Habilidade> Habilidades { get; set; }

    public virtual DbSet<HabilidadeNoticia> HabilidadeNoticia { get; set; }

    public virtual DbSet<HabilidadeProgramador> HabilidadeProgramadors { get; set; }

    public virtual DbSet<HabilidadeProjeto> HabilidadeProjetos { get; set; }

    public virtual DbSet<Noticia> Noticia { get; set; }

    public virtual DbSet<Projeto> Projetos { get; set; }

    public virtual DbSet<ProjetoPortfolio> ProjetoPortfolios { get; set; }

    public virtual DbSet<Solicitacao> Solicitacaos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("feedback");

            entity.HasIndex(e => e.IdRemetente, "fk_feedback_programador_usuario1_idx");

            entity.HasIndex(e => e.IdDestinatario, "fk_feedback_programador_usuario2_idx");

            entity.HasIndex(e => e.IdProjeto, "fk_feedback_projeto1_idx");

            entity.Property(e => e.DataPublicacao)
                .HasColumnType("datetime")
                .HasColumnName("data_publicacao");
            entity.Property(e => e.IdDestinatario).HasColumnName("id_destinatario");
            entity.Property(e => e.IdProjeto).HasColumnName("id_projeto");
            entity.Property(e => e.IdRemetente).HasColumnName("id_remetente");
            entity.Property(e => e.Nota).HasColumnName("nota");
            entity.Property(e => e.Texto)
                .HasMaxLength(2000)
                .HasColumnName("texto");

            entity.HasOne(d => d.IdDestinatarioNavigation).WithMany()
                .HasForeignKey(d => d.IdDestinatario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_feedback_programador_usuario2");

            entity.HasOne(d => d.IdProjetoNavigation).WithMany()
                .HasForeignKey(d => d.IdProjeto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_feedback_projeto1");

            entity.HasOne(d => d.IdRemetenteNavigation).WithMany()
                .HasForeignKey(d => d.IdRemetente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_feedback_programador_usuario1");
        });

        modelBuilder.Entity<Habilidade>(entity =>
        {
            entity.HasKey(e => e.IdHabilidade).HasName("PRIMARY");

            entity.ToTable("habilidade");

            entity.Property(e => e.IdHabilidade).HasColumnName("id_habilidade");
            entity.Property(e => e.NomeHabilidade)
                .HasMaxLength(50)
                .HasColumnName("nome_habilidade");
        });

        modelBuilder.Entity<HabilidadeNoticia>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("habilidade_noticia");

            entity.HasIndex(e => e.IdHabilidade, "fk_habilidade_noticia_habilidade1_idx");

            entity.HasIndex(e => e.IdNoticia, "fk_habilidade_noticia_noticia1_idx");

            entity.Property(e => e.IdHabilidade).HasColumnName("id_habilidade");
            entity.Property(e => e.IdNoticia).HasColumnName("id_noticia");

            entity.HasOne(d => d.IdHabilidadeNavigation).WithMany()
                .HasForeignKey(d => d.IdHabilidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_habilidade_noticia_habilidade1");

            entity.HasOne(d => d.IdNoticiaNavigation).WithMany()
                .HasForeignKey(d => d.IdNoticia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_habilidade_noticia_noticia1");
        });

        modelBuilder.Entity<HabilidadeProgramador>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("habilidade_programador");

            entity.HasIndex(e => e.IdHabilidade, "fk_habilidade_programador_habilidade1_idx");

            entity.HasIndex(e => e.IdProgramador, "fk_habilidade_programador_usuario1_idx");

            entity.Property(e => e.IdHabilidade).HasColumnName("id_habilidade");
            entity.Property(e => e.IdProgramador).HasColumnName("id_programador");

            entity.HasOne(d => d.IdHabilidadeNavigation).WithMany()
                .HasForeignKey(d => d.IdHabilidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_habilidade_programador_habilidade1");

            entity.HasOne(d => d.IdProgramadorNavigation).WithMany()
                .HasForeignKey(d => d.IdProgramador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_habilidade_programador_usuario1");
        });

        modelBuilder.Entity<HabilidadeProjeto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("habilidade_projeto");

            entity.HasIndex(e => e.IdHabilidade, "fk_habilidade_projeto_habilidade1_idx");

            entity.HasIndex(e => e.IdProjeto, "fk_habilidade_projeto_projeto1_idx");

            entity.Property(e => e.IdHabilidade).HasColumnName("id_habilidade");
            entity.Property(e => e.IdProjeto).HasColumnName("id_projeto");

            entity.HasOne(d => d.IdHabilidadeNavigation).WithMany()
                .HasForeignKey(d => d.IdHabilidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_habilidade_projeto_habilidade1");

            entity.HasOne(d => d.IdProjetoNavigation).WithMany()
                .HasForeignKey(d => d.IdProjeto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_habilidade_projeto_projeto1");
        });

        modelBuilder.Entity<Noticia>(entity =>
        {
            entity.HasKey(e => e.IdNoticia).HasName("PRIMARY");

            entity.ToTable("noticia");

            entity.HasIndex(e => e.IdAdministrador, "fk_noticia_usuario1_idx");

            entity.Property(e => e.IdNoticia).HasColumnName("id_noticia");
            entity.Property(e => e.Acessos).HasColumnName("acessos");
            entity.Property(e => e.DataPublicacao)
                .HasColumnType("datetime")
                .HasColumnName("data_publicacao");
            entity.Property(e => e.IdAdministrador).HasColumnName("id_administrador");
            entity.Property(e => e.LinkNoticia)
                .HasMaxLength(200)
                .HasColumnName("link_noticia");
            entity.Property(e => e.Texto)
                .HasMaxLength(2000)
                .HasColumnName("texto");

            entity.HasOne(d => d.IdAdministradorNavigation).WithMany(p => p.Noticia)
                .HasForeignKey(d => d.IdAdministrador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_noticia_usuario1");
        });

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.HasKey(e => e.IdProjeto).HasName("PRIMARY");

            entity.ToTable("projeto");

            entity.HasIndex(e => e.IdCliente, "fk_projeto_usuario1_idx");

            entity.HasIndex(e => e.IdProgramador, "fk_projeto_usuario2_idx");

            entity.Property(e => e.IdProjeto).HasColumnName("id_projeto");
            entity.Property(e => e.DataFinalizacao)
                .HasColumnType("datetime")
                .HasColumnName("data_finalizacao");
            entity.Property(e => e.DataPublicacao)
                .HasColumnType("datetime")
                .HasColumnName("data_publicacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(400)
                .HasColumnName("descricao");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdProgramador).HasColumnName("id_programador");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Titulo)
                .HasMaxLength(45)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ProjetoIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_projeto_usuario1");

            entity.HasOne(d => d.IdProgramadorNavigation).WithMany(p => p.ProjetoIdProgramadorNavigations)
                .HasForeignKey(d => d.IdProgramador)
                .HasConstraintName("fk_projeto_usuario2");
        });

        modelBuilder.Entity<ProjetoPortfolio>(entity =>
        {
            entity.HasKey(e => e.IdProjetoPortfolio).HasName("PRIMARY");

            entity.ToTable("projeto_portfolio");

            entity.HasIndex(e => e.IdProgramador, "fk_portifolio_usuario1_idx");

            entity.Property(e => e.IdProjetoPortfolio).HasColumnName("id_projeto_portfolio");
            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .HasColumnName("descricao");
            entity.Property(e => e.IdProgramador).HasColumnName("id_programador");
            entity.Property(e => e.Link)
                .HasMaxLength(200)
                .HasColumnName("link");
            entity.Property(e => e.NomeProjeto)
                .HasMaxLength(45)
                .HasColumnName("nome_projeto");

            entity.HasOne(d => d.IdProgramadorNavigation).WithMany(p => p.ProjetoPortfolios)
                .HasForeignKey(d => d.IdProgramador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_portifolio_usuario1");
        });

        modelBuilder.Entity<Solicitacao>(entity =>
        {
            entity.HasKey(e => e.IdSolicitacao).HasName("PRIMARY");

            entity.ToTable("solicitacao");

            entity.HasIndex(e => e.IdProjeto, "fk_solicitacao_projeto1_idx");

            entity.HasIndex(e => e.IdProgramador, "fk_solicitacao_usuario1_idx");

            entity.Property(e => e.IdSolicitacao).HasColumnName("id_solicitacao");
            entity.Property(e => e.DataFim)
                .HasColumnType("datetime")
                .HasColumnName("data_fim");
            entity.Property(e => e.DataInicio)
                .HasColumnType("datetime")
                .HasColumnName("data_inicio");
            entity.Property(e => e.IdProgramador).HasColumnName("id_programador");
            entity.Property(e => e.IdProjeto).HasColumnName("id_projeto");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("status");

            entity.HasOne(d => d.IdProgramadorNavigation).WithMany(p => p.Solicitacoes)
                .HasForeignKey(d => d.IdProgramador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_solicitacao_usuario1");

            entity.HasOne(d => d.IdProjetoNavigation).WithMany(p => p.Solicitacaos)
                .HasForeignKey(d => d.IdProjeto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_solicitacao_projeto1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("celular");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Nome)
                .HasMaxLength(25)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(40)
                .HasColumnName("senha");
            entity.Property(e => e.Sobrenome)
                .HasMaxLength(45)
                .HasColumnName("sobrenome");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
