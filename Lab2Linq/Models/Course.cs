using System.ComponentModel.DataAnnotations;

namespace Lab2Linq.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public List<Class> Classes { get; set; }
    }
}