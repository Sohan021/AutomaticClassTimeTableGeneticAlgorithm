using ClassTimeTable.Models.Domain;
using ClassTimeTable.Persistence;
using ClassTimeTable.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ClassTimeTable.Services.Repositories
{
    public class BatchRepository : IBatchRepository
    {

        private readonly AppDbContext _context;

        public BatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool BatchExist(int Id)
        {
            return _context.Batches.Any(b => b.Id == Id);
        }

        public bool Create(Batch batch)
        {
            _context.Batches.Add(batch);
            return Save();
        }

        public bool Delete(Batch batch)
        {
            _context.Remove(batch);
            return Save();
        }

        public Batch GetBatch(int Id)
        {
            Batch batch = new Batch();
            batch = _context.Batches.Where(b => b.Id == Id).FirstOrDefault(b => b.Id == Id);

            return batch;
        }

        public ICollection<Batch> GetBatches()
        {

            var batches = _context.Batches.Include(c => c.Courses).ToList();
            return batches;
        }

        public ICollection<Course> GetCoursesOfThisBatch(int batchId)
        {
            return _context.Courses.Where(c => c.Batch.Id == batchId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(Batch batch)
        {
            _context.Update(batch);
            return Save();
        }
    }
}
