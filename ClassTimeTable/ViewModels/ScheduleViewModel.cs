using System.Collections.Generic;

namespace ClassTimeTable.ViewModels
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public double Fitness { get; set; }
        public List<ClassFitnessViewModel> ClassFits { get; set; }
    }
}
