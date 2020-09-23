using ClassTimeTable.Models.Domain;
using System.Collections.Generic;

namespace ClassTimeTable.Services.Interface
{
    public interface IMeetingTimeRepository
    {
        ICollection<MeetingTime> GetMeetingTimes();
        MeetingTime GetMeetingTime(int Id);
        bool MeetingTimesExist(int Id);

        bool Create(MeetingTime meetingTime);
        bool Update(MeetingTime meetingTime);
        bool Delete(MeetingTime meetingTime);
        bool Save();
    }
}
