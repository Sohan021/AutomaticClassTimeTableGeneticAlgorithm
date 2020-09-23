using ClassTimeTable.Models.Domain;
using System.Collections.Generic;

namespace ClassTimeTable.Services.Interface
{
    public interface IRoomRepository
    {
        ICollection<Room> GetRooms();
        Room GetRoom(int Id);
        bool RoomExist(int Id);

        bool Create(Room room);
        bool Update(Room room);
        bool Delete(Room room);
        bool Save();
    }
}
