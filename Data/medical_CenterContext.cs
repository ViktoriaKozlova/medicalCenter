
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using medical_Center.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace medical_Center.Data;
public partial class  medical_CenterContext : DbContext
{
    public medical_CenterContext(DbContextOptions<medical_CenterContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Conslusion> Conslusions { get; set; }
    public virtual DbSet<ConclusionMedicine> ConclusionMedicines { get; set; }
    public virtual DbSet<DiseaseHistory> DiseaseHistorys { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Education> Educations { get; set; }
    public virtual DbSet<Medicine> Medicines { get; set; }
    public virtual DbSet<Reception> Receptions { get; set; }
    public virtual DbSet<Response> Responses { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<ServiceDoctor> ServiceDoctors { get; set; }
    public virtual DbSet<Test> Tests { get; set; }
    public virtual DbSet<TypeMedicine> TypeMedicines { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }
    public DbSet<ViewInformation> ViewInformations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<ViewInformation>(entity =>
        {
            entity.HasNoKey(); // Поскольку представление не имеет явного ключа

            entity.ToView("view_informaition"); // Указываем имя представления

            entity.Property(e => e.IdConslusion).HasColumnName("idconslusion");
            entity.Property(e => e.Information).HasColumnName("information");
            entity.Property(e => e.FullNameDoctor).HasColumnName("full_name_doctor");
            entity.Property(e => e.FullNameUser).HasColumnName("full_name_user");
            entity.Property(e => e.DateReception).HasColumnName("date_reseption");
            entity.Property(e => e.TimeReception).HasColumnName("time_reseption");
        });
    
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PRIMARY");

            entity.ToTable("doctor");

            entity.Property(e => e.IdDoctor)
                .ValueGeneratedNever()
                .HasColumnName("iddoctor");

            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");

            entity.Property(e => e.Birthday)
                .HasColumnName("bithday");

            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");

            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");

            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");

            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");

            entity.Property(e => e.WorkSchedule)
                .HasColumnName("work_scheudle_idwork_scheudle");

          
        });
         modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("idrole");

            entity.Property(e => e.NameRole)
                .HasMaxLength(45)
                .HasColumnName("name_role");
        });

        // Опис моделі для таблиці `user`
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("iduser");

            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");

            entity.Property(e => e.Birthday)
                .HasColumnName("bithday");

            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");

            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");

            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");

            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");

            entity.Property(e => e.role_idrole)
                .HasColumnName("role_idrole");

           
        });

        // Опис моделі для таблиці `type_medicines`
        modelBuilder.Entity<TypeMedicine>(entity =>
        {
            entity.HasKey(e => e.IdTypeMedicines).HasName("PRIMARY");

            entity.ToTable("type_medicines");

            entity.Property(e => e.IdTypeMedicines)
                .ValueGeneratedNever()
                .HasColumnName("idtype_medicines");

            entity.Property(e => e.NameMedicines)
                .HasMaxLength(45)
                .HasColumnName("name_medicines");
        });
           modelBuilder.Entity<DiseaseHistory>(entity =>
        {
            entity.HasKey(e => e.IdDiseaseHistory).HasName("PRIMARY");

            entity.ToTable("desienes_history");

            entity.Property(e => e.IdDiseaseHistory)
                .ValueGeneratedNever()
                .HasColumnName("iddesienes_history");

            entity.Property(e => e.Diagnosis)
                .HasMaxLength(45)
                .HasColumnName("diagnisis");

            entity.Property(e => e.HealthHistory)
                .HasMaxLength(45)
                .HasColumnName("health_history");
        });

        // Опис моделі для таблиці `medicines`
        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.IdMedicines).HasName("PRIMARY");

            entity.ToTable("medicines");

            entity.Property(e => e.IdMedicines)
                .ValueGeneratedNever()
                .HasColumnName("idmedicines");

            entity.Property(e => e.NameMedicines)
                .HasMaxLength(45)
                .HasColumnName("name_medicines");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.TypeMedicines)
                .HasColumnName("type_medicines_idtype_medicines");

            entity.Property(e => e.DiseaseHistory)
                .HasColumnName("desienes_history_iddesienes_history");

        });

        // Опис моделі для таблиці `test`
        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.IdTest).HasName("PRIMARY");

            entity.ToTable("test");

            entity.Property(e => e.IdTest)
                .ValueGeneratedNever()
                .HasColumnName("idtest");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");

            entity.Property(e => e.Information)
                .HasMaxLength(45)
                .HasColumnName("infornation");

            entity.Property(e => e.DiseaseHistoryId)
                .HasColumnName("desienes_history_iddesienes_history");

           
        });
         modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("PRIMARY");

            entity.ToTable("service");

            entity.Property(e => e.IdService)
                .ValueGeneratedNever()
                .HasColumnName("idservice");

            entity.Property(e => e.NameService)
                .HasMaxLength(45)
                .HasColumnName("name_service");

            entity.Property(e => e.Price)
                .HasColumnName("price");
        });

        // Опис моделі для таблиці `work_scheudle`
        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.IdWorkSchedule).HasName("PRIMARY");

            entity.ToTable("work_scheudle");

            entity.Property(e => e.IdWorkSchedule)
                .ValueGeneratedNever()
                .HasColumnName("idwork_scheudle");

            entity.Property(e => e.Day)
                .HasMaxLength(45)
                .HasColumnName("day");

            entity.Property(e => e.Time)
                .HasMaxLength(45)
                .HasColumnName("time");
        });

    

        // Опис моделі для таблиці `service_has_doctor`
        modelBuilder.Entity<ServiceDoctor>(entity =>
        {
            entity.HasKey(e => new { e.ServiceId, e.DoctorId }).HasName("PRIMARY");

            entity.ToTable("service_has_doctor");

            entity.Property(e => e.ServiceId)
                .HasColumnName("service_idservice");

            entity.Property(e => e.DoctorId)
                .HasColumnName("doctor_iddoctor");

         
        });
        modelBuilder.Entity<Reception>(entity =>
        {
            entity.HasKey(e => e.IdReception).HasName("PRIMARY");

            entity.ToTable("reception");

            entity.Property(e => e.IdReception)
                .ValueGeneratedNever()
                .HasColumnName("idreception");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Time)
                .HasColumnName("time");

            entity.Property(e => e.Visit)
                .HasColumnName("visit");

            entity.Property(e => e.User)
                .HasColumnName("user_iduser");

            entity.Property(e => e.ServiceId)
                .HasColumnName("service_has_doctor_service_idservice");

            entity.Property(e => e.DoctorId)
                .HasColumnName("service_has_doctor_doctor_iddoctor");

          
        });

        // Опис моделі для таблиці `response`
        modelBuilder.Entity<Response>(entity =>
        {
            entity.HasKey(e => e.IdResponse).HasName("PRIMARY");

            entity.ToTable("response");

            entity.Property(e => e.IdResponse)
                .ValueGeneratedNever()
                .HasColumnName("idresponse");

            entity.Property(e => e.Text)
                .HasColumnType("text")
                .HasColumnName("text");

            entity.Property(e => e.Doctor)
                .HasColumnName("doctor_iddoctor");

          
        });

        // Опис моделі для таблиці `education`
        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.IdEducation).HasName("PRIMARY");

            entity.ToTable("education");

            entity.Property(e => e.IdEducation)
                .ValueGeneratedNever()
                .HasColumnName("ideducation");

            entity.Property(e => e.University)
                .HasMaxLength(45)
                .HasColumnName("university");

            entity.Property(e => e.Year)
                .HasColumnName("year");

            entity.Property(e => e.Qualification)
                .HasMaxLength(45)
                .HasColumnName("qualification");

            entity.Property(e => e.Doctor)
                .HasColumnName("doctor_iddoctor");

         
        });
        
         modelBuilder.Entity<Conslusion>(entity =>
        {
            entity.HasKey(e => e.IdConclusion).HasName("PRIMARY");

            entity.ToTable("conslusion");

            entity.Property(e => e.IdConclusion)
                .ValueGeneratedNever()
                .HasColumnName("idconslusion");

            entity.Property(e => e.Date)
                .HasColumnName("date");

            entity.Property(e => e.Information)
                .HasMaxLength(45)
                .HasColumnName("information");

          entity.Property(e => e.Reception)
               .HasColumnName("reception_idreception");

            entity.Property(e => e.DiseaseHistory)
                .HasColumnName("desienes_history_iddesienes_history");
        });

        // Опис моделі для таблиці `conslusion_has_medicines`
        modelBuilder.Entity<ConclusionMedicine>(entity =>
        {
            entity.HasKey(e => new { e.ConclusionId, e.MedicineId  }).HasName("PRIMARY");

            entity.ToTable("conslusion_has_medicines");

            entity.Property(e => e.ConclusionId)
                .HasColumnName("conslusion_idconslusion");

            entity.Property(e => e.MedicineId )
                .HasColumnName("medicines_idmedicines");

           
        });
    }
    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}