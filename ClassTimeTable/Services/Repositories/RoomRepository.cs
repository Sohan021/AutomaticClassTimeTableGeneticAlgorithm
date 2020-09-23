using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ClassTimeTable.Services.Repositories
{
    public class RoomRepository : IRoomRepository
    {

        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Room room)
        {
            _context.Add(room);
            return Save();
        }

        public bool Delete(Room room)
        {
            _context.Remove(room);
            return Save();
        }

        public Room GetRoom(int Id)
        {
            Room room = new Room();
            room = _context.Rooms.FirstOrDefault(r => r.Id == Id);
            return room;
        }

        public ICollection<Room> GetRooms()
        {
            return _context.Rooms.OrderBy(r => r.Name).ToList();
        }

        public bool RoomExist(int Id)
        {
            return _context.Rooms.Any(r => r.Id == Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(Room room)
        {
            _context.Update(room);
            return Save();
        }
    }
}
