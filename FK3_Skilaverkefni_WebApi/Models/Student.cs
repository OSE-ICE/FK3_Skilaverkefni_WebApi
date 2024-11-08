using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FK3_skilaverkefni_EF_Core.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? SSID { get; set; }
        public List<Group> Group_Id { get; set; } = new List<Group>();

        public static implicit operator bool(Student v)
        {
            throw new NotImplementedException();
        }
    }
}
