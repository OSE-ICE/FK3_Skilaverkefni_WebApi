using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FK3_skilaverkefni_EF_Core.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public required List<Student> StudentId { get; set; }
        public required List<Subject> Subject_id { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
    }
}
