using FK3_skilaverkefni_EF_Core.Models;
using FK3_skilaverkefni_EF_Core.Models.DTO;

namespace FK3_Skilaverkefni_WebApi.Data.Interfaces
{
    public interface IRepository
    {
        Task<Group> AddGroupAsync(Group group);
        Task<Mark> AddMarkAsync(Mark mark);
        Task<Student> AddStudentAsync(Student student);
        Task<Subject> AddSubjectAsync(Subject subject);
        Task<Teacher> AddTeacherAsync(Teacher teacher);
        Task<bool> DeleteGroupAsync(int id);
        Task<bool> DeleteMarkAsync(int id);
        Task<bool> DeleteStudentAsync(int id);
        Task<bool> DeleteSubjectAsync(int id);
        Task<bool> DeleteTeacherAsync(int id);
        Task<List<Group>> GetAllGroupsAsync();
        Task<List<Mark>> GetAllMarksAsync();
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<List<Subject>> GetAllSubjectsAsync();
        Task<List<TeacherDTO>> GetAllTeachersAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task<Mark> GetMarkByIdAsync(int id);
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<TeacherDTO> GetTeacherByIdAsync(int id);
        Task<Group> UpdateGroupAsync(int id, Group group);
        Task<Mark> UpdateMarkAsync(int id, Mark mark);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task<Subject> UpdateSubjectAsync(int id, Subject subject);
        Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher);

    }
}
