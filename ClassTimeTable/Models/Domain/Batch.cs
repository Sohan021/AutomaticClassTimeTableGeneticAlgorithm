using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassTimeTable.Models.Domain
{
    public class Batch
    {
        //public Batch(int Id, string Name, string BatchCode, List<Course> Courses)
        //{
        //    this.Id = Id;
        //    this.Name = Name;
        //    this.BatchCode = BatchCode;
        //    this.Courses = Courses;


        //}

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string BatchCode { get; set; }

        public virtual IList<Course> Courses { get; set; }

    }
}
