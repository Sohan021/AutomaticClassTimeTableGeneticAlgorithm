using System.ComponentModel.DataAnnotations;

namespace ClassTimeTable.Models.Domain
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        public int BatchId { get; set; }

        public Batch Batch { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int MeetingTimeId { get; set; }

        public MeetingTime MeetingTime { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }


        public int ScheduleId { get; set; }

        //public IList<ScheduleClass> ScheduleClasses { get; set; }
    }
}
