using ClassTimeTable.Models.Domain;
using ClassTimeTable.Services.Interface;
using ClassTimeTable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTimeTable.Controllers
{
    public class GeneticController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;

        private readonly IClassRepository _classRepository;

        public GeneticController(IScheduleRepository scheduleRepository, IClassRepository classRepository)
        {
            _scheduleRepository = scheduleRepository;
            _classRepository = classRepository;

        }

        public async Task<IActionResult> Index()
        {
            //var numCon = _scheduleRepository.CalculateFinessAndNumberOfConflicts();
            //var fit = _scheduleRepository.GetFitness();
            //var fit2 = _scheduleRepository.GetFitness();

            //#region Mutate Population

            //mutate schedule first
            //first get all schedule list
            var scheduleList = _classRepository.Create();

            scheduleList = scheduleList.OrderByDescending(x => x.Fitness).ToList();
            //NOW MAKE  a while loop for new new mutations
            while (scheduleList[0].ClassFits[0].Fitness != 1.0)
            {
                var unordered = MutateList(CrossoverPopulation(scheduleList));
                scheduleList = unordered.OrderByDescending(x => x.Fitness).ToList();
            }
            //var final = MutateList(CrossoverPopulation(scheduleList));

            //#endregion

            //printable classes

            var @class = scheduleList.FirstOrDefault();
            if (@class != null)
            {
                var classes = @class.ClassFits.Select(x => x.Class).ToList();
                classes.OrderBy(_ => _.Batch.Name);
                return View(classes);
            }

            return View(default(List<Class>));
        }


        List<ScheduleViewModel> MutateList(List<ScheduleViewModel> scheduleList)
        {
            //select elite point
            //then iterate to that index from zero
            var eliteIndex = 1;
            //generate new mutate schedule
            var mutateScheduleList = _classRepository.Create();

            for (int i = 0; i < scheduleList.Count; i++)
            {
                if (i <= eliteIndex)
                {
                    //untill it is elite index do not change anything
                    mutateScheduleList[i] = scheduleList[i];
                }
                else
                {
                    //mutate classes inside of then schedules
                    mutateScheduleList[i] = GetClassAlterMutation(scheduleList[i], i);
                }
            }

            return mutateScheduleList;
        }


        ScheduleViewModel GetClassAlterMutation(ScheduleViewModel schedule, int index)
        {
            var r = new Random();
            var newSchedules = _classRepository.Create();
            var newClasses = newSchedules[index].ClassFits;
            for (int i = 0; i < schedule.ClassFits.Count; i++)
            {
                if (0.1 > r.NextDouble())
                {
                    schedule.ClassFits[i] = newClasses[i];
                }
            }

            return schedule;
        }

        List<ScheduleViewModel> SelectTournamentPopulation(List<ScheduleViewModel> population)
        {
            var TOURNAMENT_SELECTION_SIZE = 3;
            var list = _classRepository.Create(TOURNAMENT_SELECTION_SIZE);


            for (int i = 0; i < TOURNAMENT_SELECTION_SIZE; i++)
            {
                var index = Convert.ToInt32(new Random().NextDouble() * (population.Count - 1));
                list[i] = population[index];
            }
            return list;
        }

        List<ScheduleViewModel> CrossoverPopulation(List<ScheduleViewModel> population)
        {
            //then iterate to that index from zero
            var eliteIndex = 1;
            var CROSSOVER_RATE = 0.9;

            var crossOverList = _classRepository.Create();

            for (int i = 0; i < population.Count; i++)
            {
                if (i <= eliteIndex)
                {
                    //untill it is elite index do not change anything
                    crossOverList[i] = population[i];
                }
                else
                {
                    //if greater than elite then mutate
                    if (CROSSOVER_RATE > new Random().NextDouble())
                    {
                        var sch1 = (SelectTournamentPopulation(population))[0];

                        var sch2 = (SelectTournamentPopulation(population))[0];

                        crossOverList[i] = CrossoverSchedule(sch1, sch2);

                    }
                    //mutate classes inside of then schedules
                    crossOverList[i] = population[i];
                }
            }
            return crossOverList;

        }


        ScheduleViewModel CrossoverSchedule(ScheduleViewModel schedule1, ScheduleViewModel schedule2)
        {
            var crossSchedule = _classRepository.Create()[0];

            for (int i = 0; i < crossSchedule.ClassFits.Count; i++)
            {
                if (new Random().NextDouble() > 0.5)
                {
                    crossSchedule.ClassFits[i] = schedule1.ClassFits[i];
                }
                else
                {
                    crossSchedule.ClassFits[i] = schedule2.ClassFits[i];
                }
            }
            return crossSchedule;
        }



    }
}
