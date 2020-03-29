using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitnesCenter.Models
{
    public partial class TrComDBContext : DbContext
    {
        public TrComDBContext()
        {
        }

        public TrComDBContext(DbContextOptions<TrComDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonement> Abonement { get; set; }
        public virtual DbSet<AbonementType> AbonementType { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientTraining> ClientTraining { get; set; }
        public virtual DbSet<DayOff> DayOff { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExerciseCategory> ExerciseCategory { get; set; }
        public virtual DbSet<ExerciseMuscleGroup> ExerciseMuscleGroup { get; set; }
        public virtual DbSet<ExerciseWorkout> ExerciseWorkout { get; set; }
        public virtual DbSet<FoodProduct> FoodProduct { get; set; }
        public virtual DbSet<Ingestion> Ingestion { get; set; }
        public virtual DbSet<MuscleGroup> MuscleGroup { get; set; }
        public virtual DbSet<Ration> Ration { get; set; }
        public virtual DbSet<Respite> Respite { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TimeOff> TimeOff { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingCategory> TrainingCategory { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Workout> Workout { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TrComDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonement>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.AbonementType)
                    .WithMany(p => p.Abonement)
                    .HasForeignKey(d => d.AbonementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Abonement_AbonementType");
            });

            modelBuilder.Entity<AbonementType>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Preferences).HasMaxLength(250);

                entity.HasOne(d => d.Ration)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.RationId)
                    .HasConstraintName("FK_Client_ToRation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_ToUser");
            });

            modelBuilder.Entity<ClientTraining>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TrainingId })
                    .HasName("PK__ClientTr__D8F36BFCE479BE54");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientTraining)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientTraining_ToClient");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.ClientTraining)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientTraining_ToTraining");
            });

            modelBuilder.Entity<DayOff>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.DayOff)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DayOff_ToTrainer");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<ExerciseCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ExerciseId })
                    .HasName("PK__Exercise__F30E70D996F30221");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ExerciseCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseCategory_ToCategory");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExerciseCategory)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseCategory_ToExercise");
            });

            modelBuilder.Entity<ExerciseMuscleGroup>(entity =>
            {
                entity.HasKey(e => new { e.MuscleGroupId, e.ExerciseId })
                    .HasName("PK__tmp_ms_x__E37DA2B4491A706F");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExerciseMuscleGroup)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseMuscleGroup_ToExercise");

                entity.HasOne(d => d.MuscleGroup)
                    .WithMany(p => p.ExerciseMuscleGroup)
                    .HasForeignKey(d => d.MuscleGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseMuscleGroup_ToMuscleGroup");
            });

            modelBuilder.Entity<ExerciseWorkout>(entity =>
            {
                entity.HasKey(e => new { e.ExerciseId, e.WorkoutId })
                    .HasName("PK__Exercise__AE68EF8F5414A2A6");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExerciseWorkout)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseTraining_ToExercise");

                entity.HasOne(d => d.Workout)
                    .WithMany(p => p.ExerciseWorkout)
                    .HasForeignKey(d => d.WorkoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExerciseTraining_ToWorkout");
            });

            modelBuilder.Entity<FoodProduct>(entity =>
            {
                entity.Property(e => e.Kilocalories).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Ingestion)
                    .WithMany(p => p.FoodProduct)
                    .HasForeignKey(d => d.IngestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodProduct_ToIngestion");
            });

            modelBuilder.Entity<Ingestion>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Ration)
                    .WithMany(p => p.Ingestion)
                    .HasForeignKey(d => d.RationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingestion_ToRation");
            });

            modelBuilder.Entity<MuscleGroup>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ration>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Respite>(entity =>
            {
                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Respite)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Respite_ToTraining");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TimeOff>(entity =>
            {
                entity.HasOne(d => d.DayOff)
                    .WithMany(p => p.TimeOff)
                    .HasForeignKey(d => d.DayOffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeOff_ToDayOff");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trainer_ToUser");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Training_ToTrainer");
            });

            modelBuilder.Entity<TrainingCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.TrainingId })
                    .HasName("PK__tmp_ms_x__27844BD349E28613");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TrainingCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainingCategory_ToCategory");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrainingCategory)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainingCategory_ToTraining");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AboutMe).HasMaxLength(250);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.Property(e => e.ThirdName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ToRole");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.Property(e => e.Distance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Duration).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.Workout)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workout_ToTraining");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
