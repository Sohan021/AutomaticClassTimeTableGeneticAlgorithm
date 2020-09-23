using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;

namespace ClassTimeTable.Services.Repositories
{
    public class PopulationRepository : IPopulationRepository
    {
        private readonly AppDbContext _context;
        private readonly IClassRepository _classRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public PopulationRepository(AppDbContext context,
                                    IClassRepository classRepository,
                                    IScheduleRepository scheduleRepository)
        {
            _context = context;
            _classRepository = classRepository;
            _scheduleRepository = scheduleRepository;
        }

        public bool CreateClasses(Class cls)
        {
            for (int i = 0; i <= 9; i++)
            {
                //_classRepository.Create(cls);
                //_scheduleRepository.CalculateFinessAndNumberOfConflicts();
            }

            return Save();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
