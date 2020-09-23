using ClassTimeTable.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClassTimeTable.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public IActionResult Index()
        {
            //var numCon = _scheduleRepository.CalculateFinessAndNumberOfConflicts();
            var fit = _scheduleRepository.GetFitness();
            //var fit2 = _scheduleRepository.GetFitness();

            return View(fit);
        }
    }
}
