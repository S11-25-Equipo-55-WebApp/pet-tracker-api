using petTrackerApi.Model;
using Microsoft.EntityFrameworkCore;

namespace petTrackerApi.Data
{
    public partial class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }   

        public virtual DbSet<Calendario> Calendarios { get; set; }

        public virtual DbSet<ConsultaClinica> ConsultaClinicas { get; set; }

        public virtual DbSet<ControlPeso> ControlPesos { get; set; }

        public virtual DbSet<Desparacitacion> Desparacitaciones { get; set; }

        public virtual DbSet<Dieta> Dietas { get; set; }

        public virtual DbSet<Especie> Especies { get; set; }

        public virtual DbSet<EstadoRecordatorio> EstadoRecordatorios { get; set; }

        public virtual DbSet<ExamenMedico> ExamenMedicos { get; set; }

        public virtual DbSet<Mascota> Mascota { get; set; }

        public virtual DbSet<Medicacion> Medicaciones { get; set; }

        public virtual DbSet<Raza> Razas { get; set; }

        public virtual DbSet<Recordatorio> Recordatorios { get; set; }

        public virtual DbSet<TipoAlimento> TipoAlimentos { get; set; }

        public virtual DbSet<TipoDesparacitacion> TipoDesparacitaciones { get; set; }

        public virtual DbSet<TipoEvento> TipoEventos { get; set; }

        public virtual DbSet<TipoExamen> TipoExamen { get; set; }

        public virtual DbSet<TipoMedicamento> TipoMedicamentos { get; set; }

        public virtual DbSet<TipoVacuna> TipoVacunas { get; set; }

        public virtual DbSet<TipoVvmd> TipoVvmds { get; set; }

        public virtual DbSet<Tratamiento> Tratamientos { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Vacuna> Vacunas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.ToTable("Calendario");

                entity.Property(e => e.CalendarioId).HasColumnName("calendarioId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.FechaEvento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEvento");
                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");
                entity.Property(e => e.TipoEventoId).HasColumnName("tipoEventoId");
                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.HasOne(d => d.Mascota).WithMany(p => p.Calendarios)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calendario_Mascota");

                entity.HasOne(d => d.TipoEvento).WithMany(p => p.Calendarios)
                    .HasForeignKey(d => d.TipoEventoId)
                    .HasConstraintName("FK_Calendario_TipoEvento");

                entity.HasOne(d => d.Usuario).WithMany(p => p.Calendarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calendario_Usuario");
            });

            modelBuilder.Entity<ConsultaClinica>(entity =>
            {
                entity.ToTable("ConsultaClinica");

                entity.Property(e => e.ConsultaClinicaId).HasColumnName("consultaClinicaId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.Diagnostico)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("diagnostico");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.FechaConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaConsulta");
                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.Motivo)
                    .HasColumnType("text")
                    .HasColumnName("motivo");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");
                entity.Property(e => e.Veterinario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("veterinario");

                entity.HasOne(d => d.Mascota).WithMany(p => p.ConsultaClinicas)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsultaClinica_Mascota");
            });

            modelBuilder.Entity<ControlPeso>(entity =>
            {
                entity.ToTable("ControlPeso");

                entity.Property(e => e.ControlPesoId).HasColumnName("controlPesoId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.UnidadMedidaId).HasColumnName("unidadMedidaId");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");
                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.HasOne(d => d.Mascota).WithMany(p => p.ControlPesos)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ControlPeso_Mascota");

                entity.HasOne(u => u.UnidadMedida).WithMany(c => c.ControlPesos)
                    .HasForeignKey(d => d.UnidadMedidaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ControlPeso_UnidadMedida");
            });

            modelBuilder.Entity<Desparacitacion>(entity =>
            {
                entity.ToTable("Desparacitacion");

                entity.Property(e => e.DesparacitacionId).HasColumnName("desparacitacionId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.FechaAplicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAplicacion");
                entity.Property(e => e.FechaProxima)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaProxima");
                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");
                entity.Property(e => e.TipoDesparacitacionId).HasColumnName("tipoDesparacitacionId");

                entity.HasOne(d => d.Mascota).WithMany(p => p.Desparacitacions)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Desparacitacion_Mascota");

                entity.HasOne(d => d.TipoDesparacitacion).WithMany(p => p.Desparacitacions)
                    .HasForeignKey(d => d.TipoDesparacitacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Desparacitacion_TipoDesparacitacion");
            });

            modelBuilder.Entity<Dieta>(entity =>
            {
                entity.ToTable("Dieta");

                entity.HasKey(e => e.DietaId);
                entity.Property(e => e.DietaId).HasColumnName("dietaId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");
                entity.Property(e => e.PorcionDia).HasColumnName("porcionDia");
                entity.Property(e => e.TipoAlimentoId).HasColumnName("tipoAlimentoId");

                entity.HasOne(d => d.Mascota).WithMany(p => p.Dieta)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dieta_Mascota");

                entity.HasOne(d => d.TipoAlimento).WithMany(p => p.Dieta)
                    .HasForeignKey(d => d.TipoAlimentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dieta_TipoAlimento");

                entity.HasOne(d => d.UnidadMedida).WithMany(p => p.Dieta)
                    .HasForeignKey(d => d.UnidadMedidaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dieta_UnidadMedida");

            });

            modelBuilder.Entity<Especie>(entity =>
            {
                entity.ToTable("Especie");

                entity.Property(e => e.EspecieId).HasColumnName("especieId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<EstadoRecordatorio>(entity =>
            {
                entity.HasKey(e => e.EstadoId);

                entity.ToTable("EstadoRecordatorio");

                entity.Property(e => e.EstadoId).HasColumnName("estadoId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ExamenMedico>(entity =>
            {
                entity.HasKey(e => e.ExamenId);

                entity.ToTable("ExamenMedico");

                entity.Property(e => e.ExamenId).HasColumnName("examenId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.ConsultaId).HasColumnName("consultaId");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.FechaExamen).HasColumnName("fechaExamen");
                entity.Property(e => e.Resultado)
                    .HasColumnType("text")
                    .HasColumnName("resultado");
                entity.Property(e => e.TipoExamenId).HasColumnName("tipoExamenId");

                entity.HasOne(d => d.Consulta).WithMany(p => p.ExamenMedicos)
                    .HasForeignKey(d => d.ConsultaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamenMedico_ConsultaClinica");

                entity.HasOne(d => d.TipoExamen).WithMany(p => p.ExamenMedicos)
                    .HasForeignKey(d => d.TipoExamenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamenMedico_TipoExamen");
            });

            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.HasKey(e => e.MascotaId);

                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.EspecieId).HasColumnName("especieId");
                entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
                entity.Property(e => e.FotoMascota).HasMaxLength(200).HasColumnName("fotoMascota");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.RazaId).HasColumnName("razaId");
                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.HasOne(d => d.Especie).WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.EspecieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mascota_Especie");

                entity.HasOne(d => d.Raza).WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.RazaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mascota_Raza");

                entity.HasOne(d => d.Usuario).WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mascota_Usuario");
            });

            modelBuilder.Entity<Medicacion>(entity =>
            {
                entity.ToTable("Medicacion");

                entity.Property(e => e.MedicacionId).HasColumnName("medicacionId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.ConsultaId).HasColumnName("consultaId");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.Dosis).HasColumnName("dosis");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Frecuencia).HasColumnName("frecuencia");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");
                entity.Property(e => e.TipoMedicacionId).HasColumnName("tipoMedicacionId");

                entity.HasOne(d => d.Consulta).WithMany(p => p.Medicacions)
                    .HasForeignKey(d => d.ConsultaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicacion_ConsultaClinica");

                entity.HasOne(d => d.TipoMedicacion).WithMany(p => p.Medicacions)
                    .HasForeignKey(d => d.TipoMedicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicacion_TipoMedicamento");
            });

            modelBuilder.Entity<Raza>(entity =>
            {
                entity.ToTable("Raza");

                entity.Property(e => e.RazaId).HasColumnName("razaId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Recordatorio>(entity =>
            {
                entity.HasKey(e => e.RecordatorioInt);

                entity.ToTable("Recordatorio");

                entity.Property(e => e.RecordatorioInt).HasColumnName("recordatorioInt");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.EstadoRecordatorioId).HasColumnName("estadoRecordatorioId");
                entity.Property(e => e.FechaRecordatorio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRecordatorio");
                entity.Property(e => e.Intervalo).HasColumnName("intervalo");
                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.TipoVvmdid).HasColumnName("tipoVVMDId");
                entity.Property(e => e.Titulo).HasColumnName("titulo");
                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

                entity.HasOne(d => d.EstadoRecordatorio).WithMany(p => p.Recordatorios)
                    .HasForeignKey(d => d.EstadoRecordatorioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recordatorio_EstadoRecordatorio");

                entity.HasOne(d => d.Mascota).WithMany(p => p.Recordatorios)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recordatorio_Mascota");

                entity.HasOne(d => d.TipoVvmd).WithMany(p => p.Recordatorios)
                    .HasForeignKey(d => d.TipoVvmdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recordatorio_TipoVVMD");

                entity.HasOne(d => d.Usuario).WithMany(p => p.Recordatorios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recordatorio_Usuario");
            });

            modelBuilder.Entity<TipoAlimento>(entity =>
            {
                entity.ToTable("TipoAlimento");

                entity.Property(e => e.TipoAlimentoId).HasColumnName("tipoAlimentoId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoDesparacitacion>(entity =>
            {
                entity.HasKey(e => e.TipoDesparacitacionId).HasName("PK_tipoDesparacitacion");

                entity.ToTable("TipoDesparacitacion");

                entity.Property(e => e.TipoDesparacitacionId).HasColumnName("tipoDesparacitacionId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.TipoEventoId).HasName("PK_tipoEvento");

                entity.ToTable("TipoEvento");

                entity.Property(e => e.TipoEventoId).HasColumnName("tipoEventoId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoExamen>(entity =>
            {
                entity.HasKey(e => e.TipoExamenId);

                entity.Property(e => e.TipoExamenId).HasColumnName("tipoExamenId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.Editado)
                    .HasColumnType("datetime")
                    .HasColumnName("editado");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoMedicamento>(entity =>
            {
                entity.HasKey(e => e.TipoMedId);

                entity.ToTable("TipoMedicamento");

                entity.Property(e => e.TipoMedId).HasColumnName("tipoMedId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoVacuna>(entity =>
            {
                entity.ToTable("TipoVacuna");

                entity.Property(e => e.TipoVacunaId).HasColumnName("tipoVacunaId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoVvmd>(entity =>
            {
                entity.ToTable("TipoVVMD");

                entity.Property(e => e.TipoVvmdid).HasColumnName("tipoVVMDId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tratamiento>(entity =>
            {
                entity.ToTable("Tratamiento");

                entity.Property(e => e.TratamientoId)
                    .ValueGeneratedNever()
                    .HasColumnName("tratamientoId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.ConsultaId).HasColumnName("consultaId");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.Dosis).HasColumnName("dosis");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
                entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
                entity.Property(e => e.Frecuencia).HasColumnName("frecuencia");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");

                entity.HasOne(d => d.Consulta).WithMany(p => p.Tratamientos)
                    .HasForeignKey(d => d.ConsultaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tratamiento_ConsultaClinica");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt")
                    .HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt")
                    .HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.ToTable("Vacuna");

                entity.Property(e => e.VacunaId).HasColumnName("vacunaId");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");
                entity.Property(e => e.CreadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("creadoAt");
                entity.Property(e => e.EditadoAt)
                    .HasColumnType("datetime")
                    .HasColumnName("editadoAt");
                entity.Property(e => e.FechaAplicacion).HasColumnName("fechaAplicacion");
                entity.Property(e => e.FechaProxima).HasColumnName("fechaProxima");
                entity.Property(e => e.MascotaId).HasColumnName("mascotaId");
                entity.Property(e => e.Notas)
                    .HasColumnType("text")
                    .HasColumnName("notas");
                entity.Property(e => e.TipoVacunaId).HasColumnName("tipoVacunaId");

                entity.HasOne(d => d.Mascota).WithMany(p => p.Vacunas)
                    .HasForeignKey(d => d.MascotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacuna_Mascota");

                entity.HasOne(d => d.TipoVacuna).WithMany(p => p.Vacunas)
                    .HasForeignKey(d => d.TipoVacunaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacuna_TipoVacuna");
            });
            modelBuilder.Entity<UnidadMedida>(entity =>
            {
                entity.ToTable("UnidadMedida");

                entity.Property(e => e.UnidadMedidaId).HasColumnName("unidadMedidaId");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Abreviatura)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("abreviatura");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


















}
