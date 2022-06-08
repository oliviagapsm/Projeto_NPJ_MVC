using Microsoft.EntityFrameworkCore;

namespace NPJ_MVC.Data
{
    public partial class AgendaNPJContext : DbContext
    {
        public AgendaNPJContext()
        {
        }

        public AgendaNPJContext(DbContextOptions<AgendaNPJContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamento { get; set; } = null!;
        public virtual DbSet<Agenda> Agenda { get; set; } = null!;
        public virtual DbSet<AgendaVW> AgendaVW { get; set; } = null!;
        public virtual DbSet<AreaJuridica> AreaJuridica { get; set; } = null!;
        public virtual DbSet<AreaJuridicaNucleoJuridico> AreaJuridicaNucleoJuridico { get; set; } = null!;
        public virtual DbSet<Assistido> Assistido { get; set; } = null!;
        public virtual DbSet<AssistidoVW> AssistidoVW { get; set; } = null!;
        public virtual DbSet<DisponibilidadeHorario> DisponibilidadeHorario { get; set; } = null!;
        public virtual DbSet<ExcelArea> ExcelArea { get; set; } = null!;
        public virtual DbSet<ExcelNajHorario> ExcelNajHorario { get; set; } = null!;
        public virtual DbSet<Horario> Horario { get; set; } = null!;
        public virtual DbSet<LocalAtendimento> LocalAtendimento { get; set; } = null!;
        public virtual DbSet<NucleoJuridico> NucleoJuridico { get; set; } = null!;
        public virtual DbSet<Usuario> Usuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=OLIVIA_MACEDO\\SQLEXPRESS;Initial Catalog=AgendaNPJ;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => e.IdAgendamento)
                    .HasName("PK_NPJTB_Agendamento");

                entity.ToTable("Agendamento", "NPJTB");

                entity.HasIndex(e => e.IdAgenda, "IX_NPJTB_Agendamento_NPJTB_Agenda");

                entity.HasIndex(e => e.IdAssitido, "IX_NPJTB_Agendamento_NPJTB_Assistido");

                entity.HasIndex(e => new { e.IdAssitido, e.IdAgenda, e.DtAgendamento }, "UQ_NPJTB_Agendamento_idAgenda_idAssistido_dtAgendamento")
                    .IsUnique();

                entity.Property(e => e.IdAgendamento).HasColumnName("idAgendamento");

                entity.Property(e => e.DtAgendamento)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dtAgendamento");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IdAgenda).HasColumnName("idAgenda");

                entity.Property(e => e.IdAssitido).HasColumnName("idAssitido");

                entity.HasOne(d => d.IdAgendaNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdAgenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_Agendamento_NPJTB_Agenda");

                entity.HasOne(d => d.IdAssitidoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdAssitido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_Agendamento_NPJTB_Assistido");
            });

            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasKey(e => e.IdAgenda)
                    .HasName("PK_NPJTB__Agenda");

                entity.ToTable("Agenda", "NPJTB");

                entity.HasIndex(e => e.IdDisponibilidadeHorario, "IX_NPJTB_Agenda_NPJTB_DisponibilidadeHorario");

                entity.HasIndex(e => new { e.DtAgenda, e.IdDisponibilidadeHorario }, "UQ_NPJTB_Agenda_dtAgenda_idDisponibilidadeHorario")
                    .IsUnique();

                entity.Property(e => e.IdAgenda).HasColumnName("idAgenda");

                entity.Property(e => e.DtAgenda)
                    .HasColumnType("datetime")
                    .HasColumnName("dtAgenda");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IdDisponibilidadeHorario).HasColumnName("idDisponibilidadeHorario");

                entity.HasOne(d => d.IdDisponibilidadeHorarioNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.IdDisponibilidadeHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_Agenda_NPJTB_DisponibilidadeHorario");
            });

            modelBuilder.Entity<AgendaVW>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Agenda", "NPJVW");

                entity.Property(e => e.DeEndereco)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("deEndereco");

                entity.Property(e => e.DtAgenda)
                    .HasColumnType("datetime")
                    .HasColumnName("dtAgenda");

                entity.Property(e => e.EdEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("edEmail");

                entity.Property(e => e.HrFim)
                    .HasColumnType("time(0)")
                    .HasColumnName("hrFim");

                entity.Property(e => e.HrInicio)
                    .HasColumnType("time(0)")
                    .HasColumnName("hrInicio");

                entity.Property(e => e.IcAtivoAgenda).HasColumnName("icAtivo_Agenda");

                entity.Property(e => e.IcAtivoAreaJuridica).HasColumnName("icAtivo_AreaJuridica");

                entity.Property(e => e.IcAtivoAreaJuridicaNucleoJuridico).HasColumnName("icAtivo_AreaJuridicaNucleoJuridico");

                entity.Property(e => e.IcAtivoDisponibilidadeHorario).HasColumnName("icAtivo_DisponibilidadeHorario");

                entity.Property(e => e.IcAtivoHorario).HasColumnName("icAtivo_Horario");

                entity.Property(e => e.IcAtivoLocalAtendimento).HasColumnName("icAtivo_LocalAtendimento");

                entity.Property(e => e.IcAtivoNucleoJuridico).HasColumnName("icAtivo_NucleoJuridico");

                entity.Property(e => e.IdAgenda).HasColumnName("idAgenda");

                entity.Property(e => e.IdAreaJuridica).HasColumnName("idAreaJuridica");

                entity.Property(e => e.IdAreaJuridicaNucleoJuridico).HasColumnName("idAreaJuridicaNucleoJuridico");

                entity.Property(e => e.IdDisponibilidadeHorario).HasColumnName("idDisponibilidadeHorario");

                entity.Property(e => e.IdHorario).HasColumnName("idHorario");

                entity.Property(e => e.IdLocalAtendimento).HasColumnName("idLocalAtendimento");

                entity.Property(e => e.IdNucleoJuridico).HasColumnName("idNucleoJuridico");

                entity.Property(e => e.IdNucleoJuridicoHorario).HasColumnName("idNucleoJuridico_Horario");

                entity.Property(e => e.NmAreaJuridica)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nmAreaJuridica");

                entity.Property(e => e.NmLocalAtendimento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nmLocalAtendimento");

                entity.Property(e => e.NmNucleoJuridico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nmNucleoJuridico");

                entity.Property(e => e.NuQtdeAgendamento).HasColumnName("nuQtdeAgendamento");

                entity.Property(e => e.NuQtdeVagas).HasColumnName("nuQtdeVagas");

                entity.Property(e => e.NuTelefone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nuTelefone");
            });

            modelBuilder.Entity<AreaJuridica>(entity =>
            {
                entity.HasKey(e => e.IdAreaJuridica)
                    .HasName("PK_NPJTB_AreaJuridica");

                entity.ToTable("AreaJuridica", "NPJTB");

                entity.HasIndex(e => e.NmAreaJuridica, "UQ_NPJTB_AreaJuridica_nmAreaJuridica")
                    .IsUnique();

                entity.Property(e => e.IdAreaJuridica)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idAreaJuridica");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.NmAreaJuridica)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nmAreaJuridica");
            });

            modelBuilder.Entity<AreaJuridicaNucleoJuridico>(entity =>
            {
                entity.HasKey(e => e.IdAreaJuridicaNucleoJuridico)
                    .HasName("PK_NPJTB_AreaJuridicaNucleoJuridico");

                entity.ToTable("AreaJuridicaNucleoJuridico", "NPJTB");

                entity.HasIndex(e => e.IdNucleoJuridico, "IX_NPJTB_AreaJuridicaNucleoJuridico_NPJTB_NucleoJuridico");

                entity.HasIndex(e => e.IdAreaJuridica, "IX_NPJTB_AreaJuridicaNucleoJuridico_idAreaJuridica");

                entity.HasIndex(e => new { e.IdAreaJuridica, e.IdNucleoJuridico }, "UQ_NPJTB_AreaJuridicaNucleoJuridico_idAreaJuridica_idNucleoJuridico")
                    .IsUnique();

                entity.Property(e => e.IdAreaJuridicaNucleoJuridico).HasColumnName("idAreaJuridicaNucleoJuridico");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IdAreaJuridica).HasColumnName("idAreaJuridica");

                entity.Property(e => e.IdNucleoJuridico).HasColumnName("idNucleoJuridico");

                entity.HasOne(d => d.IdAreaJuridicaNavigation)
                    .WithMany(p => p.AreaJuridicaNucleoJuridicos)
                    .HasForeignKey(d => d.IdAreaJuridica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_AreaJuridicaNucleoJuridico_idAreaJuridica");

                entity.HasOne(d => d.IdNucleoJuridicoNavigation)
                    .WithMany(p => p.AreaJuridicaNucleoJuridicos)
                    .HasForeignKey(d => d.IdNucleoJuridico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_AreaJuridicaNucleoJuridico_NPJTB_NucleoJuridico");
            });

            modelBuilder.Entity<Assistido>(entity =>
            {
                entity.HasKey(e => e.IdAssitido)
                    .HasName("PK_NPJTB_Assistido");

                entity.ToTable("Assistido", "NPJTB");

                entity.HasIndex(e => e.IdUsuario, "IX_NPJTB_Assistido_NPJTB_Usuario");

                entity.Property(e => e.IdAssitido).HasColumnName("idAssitido");

                entity.Property(e => e.DtAceiteTermo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dtAceiteTermo");

                entity.Property(e => e.DtCadastro)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dtCadastro");

                entity.Property(e => e.EdIpassistido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("edIPAssistido");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Assistidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_Assistido_NPJTB_Usuario");
            });

            modelBuilder.Entity<AssistidoVW>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Assistido", "NPJVW");

                entity.Property(e => e.CoSenha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coSenha");

                entity.Property(e => e.DeLocalResidencia)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("deLocalResidencia");

                entity.Property(e => e.DtAceiteTermo)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dtAceiteTermo");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dtAlteracao");

                entity.Property(e => e.DtCadastro)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dtCadastro");

                entity.Property(e => e.EdIpassistido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("edIPAssistido");

                entity.Property(e => e.IcAdministrador).HasColumnName("icAdministrador");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IcColaborador).HasColumnName("icColaborador");

                entity.Property(e => e.IdAssitido).HasColumnName("idAssitido");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NmUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nmUsuario");

                entity.Property(e => e.NuCpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("nuCPF");

                entity.Property(e => e.NuIdentidade)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nuIdentidade");
            });

            modelBuilder.Entity<DisponibilidadeHorario>(entity =>
            {
                entity.HasKey(e => e.IdDisponibilidadeHorario)
                    .HasName("PK_NPJTB_DisponibilidadeHorario");

                entity.ToTable("DisponibilidadeHorario", "NPJTB");

                entity.HasIndex(e => e.IdAreaJuridicaNucleoJuridico, "IX_NPJTB_DisponibilidadeHorario_NPJTB_AreaJuridicaLocalAtendimento");

                entity.HasIndex(e => e.IdHorario, "IX_NPJTB_DisponibilidadeHorario_NPJTB_Horario");

                entity.HasIndex(e => new { e.IdAreaJuridicaNucleoJuridico, e.IdHorario }, "UQ_NPJTB_DisponibilidadeHorario_idAreaJuridicaNucleoJuridico_idHorario")
                    .IsUnique();

                entity.Property(e => e.IdDisponibilidadeHorario).HasColumnName("idDisponibilidadeHorario");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IdAreaJuridicaNucleoJuridico).HasColumnName("idAreaJuridicaNucleoJuridico");

                entity.Property(e => e.IdHorario).HasColumnName("idHorario");

                entity.HasOne(d => d.IdAreaJuridicaNucleoJuridicoNavigation)
                    .WithMany(p => p.DisponibilidadeHorarios)
                    .HasForeignKey(d => d.IdAreaJuridicaNucleoJuridico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_DisponibilidadeHorario_NPJTB_AreaJuridicaLocalAtendimento");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.DisponibilidadeHorarios)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_DisponibilidadeHorario_NPJTB_Horario");
            });

            modelBuilder.Entity<ExcelArea>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Excel_Area");

                entity.Property(e => e.ÁreasDeAtuação)
                    .HasMaxLength(255)
                    .HasColumnName("Áreas de Atuação");
            });

            modelBuilder.Entity<ExcelNajHorario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Excel_NAJ_Horario");

                entity.Property(e => e.EMail)
                    .HasMaxLength(255)
                    .HasColumnName("E-mail");

                entity.Property(e => e.Endereço).HasMaxLength(255);

                entity.Property(e => e.HorárioDeAtendimentoPresencial)
                    .HasMaxLength(255)
                    .HasColumnName("Horário de atendimento presencial");

                entity.Property(e => e.HorárioDeFuncionamentoAtendimentoTelefônico)
                    .HasMaxLength(255)
                    .HasColumnName("Horário de funcionamento (atendimento telefônico)");

                entity.Property(e => e.Naj)
                    .HasMaxLength(255)
                    .HasColumnName("NAJ");

                entity.Property(e => e.Telefones).HasMaxLength(255);

                entity.Property(e => e.Turno).HasMaxLength(255);

                entity.Property(e => e.ÁreasDeAtuação)
                    .HasMaxLength(255)
                    .HasColumnName("Áreas de Atuação");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PK_NPJTB_Horario");

                entity.ToTable("Horario", "NPJTB");

                entity.HasIndex(e => e.IdNucleoJuridico, "IX_NPJTB_Horario_NucleoJuridico");

                entity.HasIndex(e => new { e.IdNucleoJuridico, e.HrInicio }, "UQ_NPJTB_Horario_idNucleoJuridico_hrInicio")
                    .IsUnique();

                entity.Property(e => e.IdHorario).HasColumnName("idHorario");

                entity.Property(e => e.HrFim)
                    .HasColumnType("time(0)")
                    .HasColumnName("hrFim");

                entity.Property(e => e.HrInicio)
                    .HasColumnType("time(0)")
                    .HasColumnName("hrInicio");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IdNucleoJuridico).HasColumnName("idNucleoJuridico");

                entity.Property(e => e.NuQtdeVagas).HasColumnName("nuQtdeVagas");

                entity.HasOne(d => d.IdNucleoJuridicoNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.IdNucleoJuridico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_Horario_NucleoJuridico");
            });

            modelBuilder.Entity<LocalAtendimento>(entity =>
            {
                entity.HasKey(e => e.IdLocalAtendimento)
                    .HasName("PK_NPJTB_LocalAtendimento");

                entity.ToTable("LocalAtendimento", "NPJTB");

                entity.HasIndex(e => e.DeEndereco, "UQ_NPJTB_LocalAtendimento_deEndereco")
                    .IsUnique();

                entity.HasIndex(e => e.NmLocalAtendimento, "UQ_NPJTB_LocalAtendimento_nmLocalAtendimento")
                    .IsUnique();

                entity.Property(e => e.IdLocalAtendimento).HasColumnName("idLocalAtendimento");

                entity.Property(e => e.DeEndereco)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("deEndereco");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.NmLocalAtendimento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nmLocalAtendimento");
            });

            modelBuilder.Entity<NucleoJuridico>(entity =>
            {
                entity.HasKey(e => e.IdNucleoJuridico)
                    .HasName("PK_NPJTB_NucleoJuridico");

                entity.ToTable("NucleoJuridico", "NPJTB");

                entity.HasIndex(e => e.IdLocalAtendimento, "IX_NPJTB_NucleoJuridico_NPJTB_LocalAtendimento");

                entity.HasIndex(e => e.NmNucleoJuridico, "UQ_NPJTB_NucleoJuridico_nmNucleoJuridico")
                    .IsUnique();

                entity.Property(e => e.IdNucleoJuridico).HasColumnName("idNucleoJuridico");

                entity.Property(e => e.EdEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("edEmail");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IdLocalAtendimento).HasColumnName("idLocalAtendimento");

                entity.Property(e => e.NmNucleoJuridico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nmNucleoJuridico");

                entity.Property(e => e.NuTelefone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nuTelefone");

                entity.HasOne(d => d.IdLocalAtendimentoNavigation)
                    .WithMany(p => p.NucleoJuridicos)
                    .HasForeignKey(d => d.IdLocalAtendimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NPJTB_NucleoJuridico_NPJTB_LocalAtendimento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_NPJTB_Usuario");

                entity.ToTable("Usuario", "NPJTB");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.CoSenha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coSenha");

                entity.Property(e => e.DeLocalResidencia)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("deLocalResidencia");

                entity.Property(e => e.DtAlteracao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dtAlteracao");

                entity.Property(e => e.IcAdministrador).HasColumnName("icAdministrador");

                entity.Property(e => e.IcAtivo).HasColumnName("icAtivo");

                entity.Property(e => e.IcColaborador).HasColumnName("icColaborador");

                entity.Property(e => e.NmUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nmUsuario");

                entity.Property(e => e.NuCpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("nuCPF");

                entity.Property(e => e.NuIdentidade)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nuIdentidade");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
