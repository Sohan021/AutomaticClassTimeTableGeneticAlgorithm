using ClassTimeTable.Models.Domain;

namespace ClassTimeTable.Services.Interface
{
    public interface IPopulationRepository
    {
        bool CreateClasses(Class cls);

        bool Save();
    }
}
