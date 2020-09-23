using ClassTimeTable.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassTimeTable.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Batch> Batches { get; set; }

        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<MeetingTime> MeetingTimes { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }



        //public virtual DbSet<Schedule> Schedules { get; set; }

        //public virtual DbSet<ScheduleClass> ScheduleClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Instructor>()
           .Property(p => p.Id)
           .ValueGeneratedOnAdd();

            //modelBuilder.Entity<ScheduleClass>()
            //    .HasKey(s => new { s.ClassId, s.ScheduleId });

            //modelBuilder.Entity<ScheduleClass>()
            //    .HasOne(s => s.Schedule)
            //    .WithMany(c => c.ScheduleClasses)
            //    .HasForeignKey(f => f.ScheduleId);


            //modelBuilder.Entity<ScheduleClass>()
            //    .HasOne(c => c.Class)
            //    .WithMany(c => c.ScheduleClasses)
            //    .HasForeignKey(f => f.ClassId);


        }
    }
}
