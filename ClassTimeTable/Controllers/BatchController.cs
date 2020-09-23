using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassTimeTable.Controllers
{
    public class BatchController : Controller
    {
        private readonly IBatchRepository _batchRepository;
        private readonly AppDbContext _context;

        public BatchController(IBatchRepository batchRepository,
                               AppDbContext context)
        {
            _batchRepository = batchRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_batchRepository.GetBatches());
        }

        public IActionResult GetCourseOfThisBatch(int id)
        {
            return View(_batchRepository.GetCoursesOfThisBatch(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                _batchRepository.Create(batch);
                return RedirectToAction(nameof(Index));
            }
            return View(batch);
        }

        public IActionResult Update(int id)
        {
            var batch = _batchRepository.GetBatch(id);

            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Batch batch)
        {
            if (ModelState.IsValid)
            {
                _batchRepository.Update(batch);
                return RedirectToAction(nameof(Index));
            }

            return View(batch);
        }

        public IActionResult Delete(int id)
        {
            var batch = _batchRepository.GetBatch(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Batch batch)
        {
            if (ModelState.IsValid)
            {
                _batchRepository.Delete(batch);
                return RedirectToAction(nameof(Index));
            }

            return View(batch);
        }
    }
}
