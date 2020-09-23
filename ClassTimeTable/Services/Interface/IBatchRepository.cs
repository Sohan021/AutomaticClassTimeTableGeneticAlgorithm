using ClassTimeTable.Models.Domain;
using System.Collections.Generic;

namespace ClassTimeTable.Services.Interface
{
    public interface IBatchRepository
    {
        ICollection<Batch> GetBatches();
        Batch GetBatch(int Id);
        bool BatchExist(int Id);
        ICollection<Course> GetCoursesOfThisBatch(int batchId);

        bool Create(Batch batch);
        bool Update(Batch batch);
        bool Delete(Batch batch);
        bool Save();
    }
}
