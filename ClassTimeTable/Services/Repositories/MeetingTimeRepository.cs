using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ClassTimeTable.Services.Repositories
{
    public class MeetingTimeRepository : IMeetingTimeRepository
    {

        private readonly AppDbContext _context;

        public MeetingTimeRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(MeetingTime meetingTime)
        {
            _context.Add(meetingTime);
            return Save();
        }

        public bool Delete(MeetingTime meetingTime)
        {
            _context.Remove(meetingTime);
            return Save();
        }

        public MeetingTime GetMeetingTime(int Id)
        {

            var meetingTime = _context.MeetingTimes.Find(Id);
            return meetingTime;
        }

        public ICollection<MeetingTime> GetMeetingTimes()
        {
            return _context.MeetingTimes.ToList();
        }

        public bool MeetingTimesExist(int Id)
        {
            return _context.MeetingTimes.Any(m => m.Id == Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(MeetingTime meetingTime)
        {
            _context.Update(meetingTime);
            return Save();
        }
    }
}
