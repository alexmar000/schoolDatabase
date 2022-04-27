using System.ComponentModel.DataAnnotations;

namespace Lab2Linq.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
    }
}