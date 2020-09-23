using System.ComponentModel.DataAnnotations;

namespace ClassTimeTable.Models.Domain
{
    public class MeetingTime
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Time { get; set; }
    }
}
