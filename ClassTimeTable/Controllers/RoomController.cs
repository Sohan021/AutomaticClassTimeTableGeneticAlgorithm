using ClassTimeTable.Models.Domain;
using ClassTimeTable.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassTimeTable.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IActionResult Index()
        {
            return View(_roomRepository.GetRooms());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Create(room);
                return RedirectToAction(nameof(Index));
            }

            return View(room);
        }

        public IActionResult Update(int id)
        {
            var room = _roomRepository.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Update(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            var room = _roomRepository.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Delete(room);
                return RedirectToAction(nameof(Index));
            }

            return View(room);
        }

    }
}
