using FK3_skilaverkefni_EF_Core.Data;
using FK3_skilaverkefni_EF_Core.Models;
using FK3_skilaverkefni_EF_Core.Models.DTO;
using FK3_Skilaverkefni_WebApi.Data.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FK3_Skilaverkefni_WebApi.Data
{
    public class SchoolRepository : IRepository
    {
        private readonly SchoolDBContext _dbContext;

        public SchoolRepository()
        {
            _dbContext = new SchoolDBContext();
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            using (var db = _dbContext)
            {
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();
            }
            return student;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            List<Student> students;

            using (var db = _dbContext)
            {
                students = await db.Students.ToListAsync();
            }

            List<StudentDTO> listToReturn = new List<StudentDTO>();

            foreach (Student stud in students)
            {
                StudentDTO studTAdd = new StudentDTO
                {
                    StudentId = stud.StudentId,
                    First_Name = stud.First_Name,
                    Last_Name = stud.Last_Name,

                };
                listToReturn.Add(studTAdd);

            }
            return listToReturn;
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            Student s;

            using (var db = _dbContext)
            {
                s = await db.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            }

            if (s == null)
            {
                return null;
            }

            StudentDTO studentToReturn = new StudentDTO
            {
                StudentId = s.StudentId,
                First_Name = s.First_Name,
                Last_Name = s.Last_Name,
            };
            return studentToReturn;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            Student studentToUpdate;

            using (var db = _dbContext)
            {
                studentToUpdate = await db.Students.FirstOrDefaultAsync(c => c.StudentId == id)!;

                if (studentToUpdate == null)
                {
                    return null;
                }

                studentToUpdate.First_Name = student.First_Name;
                studentToUpdate.Last_Name = student.Last_Name;
                studentToUpdate.SSID = student.SSID;



                await db.SaveChangesAsync();

                return studentToUpdate;
            }
        }

        public async Task<List<TeacherDTO>> GetAllTeachersAsync()
        {
            List<Teacher> teachers;

            using (var db = _dbContext)
            {
                teachers = await db.Teachers.ToListAsync();
            }

            List<TeacherDTO> listToReturn = new List<TeacherDTO>();

            foreach (Teacher teach in teachers)
            {
                TeacherDTO teachToAdd = new TeacherDTO
                {
                    TeacherId = teach.TeacherId,
                    First_Name = teach.First_Name,
                    Last_Name = teach.Last_Name,
                };
                listToReturn.Add(teachToAdd);
            }
            return listToReturn;
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            using (var db = _dbContext)
            {
                await db.Teachers.AddAsync(teacher);
                await db.SaveChangesAsync();
            }
            return teacher;
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            Teacher teacherToDelete;

            using (var db = _dbContext)
            {
                teacherToDelete = await db.Teachers.FirstOrDefaultAsync(t => t.TeacherId == id);
                if (teacherToDelete == null)
                {
                    return false;
                }

                db.Teachers.Remove(teacherToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<TeacherDTO> GetTeacherByIdAsync(int id)
        {
            Teacher t;

            using (var db = _dbContext)
            {
                t = await db.Teachers.FirstOrDefaultAsync(t => t.TeacherId == id);
            }

            if (t == null)
            {
                return null;
            }

            TeacherDTO teacherToReturn = new TeacherDTO
            {
                TeacherId = t.TeacherId,
                First_Name = t.First_Name,
                Last_Name = t.Last_Name,
            };
            return teacherToReturn;
        }

        public async Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher)
        {
            Teacher teacherToUpdate;
            using (var db = _dbContext)
            {
                teacherToUpdate = await db.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacher.TeacherId);
                if (teacherToUpdate == null)
                {
                    return null;
                }

                teacherToUpdate.First_Name = teacher.First_Name;
                teacherToUpdate.Last_Name = teacher.Last_Name;
                teacherToUpdate.SSID = teacher.SSID;

                await db.SaveChangesAsync();
                return teacherToUpdate;
            }
        }

        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            using (var db = _dbContext)
            {
                await db.Subjects.AddAsync(subject);
                await db.SaveChangesAsync();
            }
            return subject;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            Subject subjectToDelete;

            using (var db = _dbContext)
            {
                subjectToDelete = await db.Subjects.FirstOrDefaultAsync(s => s.SubjectId == id);
                if (subjectToDelete == null)
                {
                    return false;
                }

                db.Subjects.Remove(subjectToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            List<Subject> subjects;

            using (var db = _dbContext)
            {
                subjects = await db.Subjects.ToListAsync();
            }

            List<Subject> listToReturn = new List<Subject>();

            foreach (Subject sub in subjects)
            {
                Subject subToAdd = new Subject
                {
                    SubjectId = sub.SubjectId,
                    Title = sub.Title
                };
                listToReturn.Add(subToAdd);
            }
            return listToReturn;
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            Subject s;
            using (var db = _dbContext)
            {
                s = await db.Subjects.FirstOrDefaultAsync(s => s.SubjectId == id);
            }

            if (s == null)
            {
                return null;
            }

            Subject subjectToReturn = new Subject
            {
                SubjectId = s.SubjectId,
                Title = s.Title
            };
            return subjectToReturn;

        }

        public async Task<Subject> UpdateSubjectAsync(int id, Subject subject)
        {
            Subject subjectToUpdate;

            using (var db = _dbContext)
            {
                subjectToUpdate = await db.Subjects.FirstOrDefaultAsync(s => s.SubjectId == id);
                if (subjectToUpdate == null)
                {
                    return null;
                }

                subjectToUpdate.Title = subject.Title;

                await db.SaveChangesAsync();
                return subjectToUpdate;
            }

        }

        public async Task<Group> AddGroupAsync(Group group)
        {
            using (var db = _dbContext)
            {
                await db.Groups.AddAsync(group);
                await db.SaveChangesAsync();
            }
            return group;
        }

        public async Task<bool> DeleteGroupAsync(int id)
        {
            Group groupToDelete;

            using (var db = _dbContext)
            {
                groupToDelete = await db.Groups.FirstOrDefaultAsync(g => g.GroupId == id);
                if (groupToDelete == null)
                {
                    return false;
                }

                db.Groups.Remove(groupToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            List<Group> groups;

            using (var db = _dbContext)
            {
                groups = await db.Groups.ToListAsync();
            }
            List<Group> result = new List<Group>();
            foreach (Group g in groups)
            {
                Group groupToAdd = new Group
                {
                    GroupId = g.GroupId,
                    Name = g.Name
                };
                result.Add(groupToAdd);
            }
            return result;
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            Group group;
            using (var db = _dbContext)
            {
                group = await db.Groups.FirstOrDefaultAsync(g => g.GroupId == id);
            }

            if (group == null)
            {
                return null;
            }

            Group groupToReturn = new Group
            {
                GroupId = group.GroupId,
                Name = group.Name
            };
            return groupToReturn;
        }

        public async Task<Group> UpdateGroupAsync(int id, Group group)
        {
            Group groupToUpdate;
            using (var db = _dbContext)
            {
                groupToUpdate = await db.Groups.FirstOrDefaultAsync(g => g.GroupId == id);
                if (groupToUpdate == null)
                {
                    return null;
                }

                groupToUpdate.Name = group.Name;

                await db.SaveChangesAsync();
                return groupToUpdate;
            }
        }

        public async Task<Mark> AddMarkAsync(Mark mark)
        {
            using (var db = _dbContext)
            {
                await db.Marks.AddAsync(mark);
                await db.SaveChangesAsync();
            }
            return mark;
        }

        public async Task<bool> DeleteMarkAsync(int id)
        {
            Mark markToDelete;
            using (var db = _dbContext) {
                markToDelete = await db.Marks.FirstOrDefaultAsync(m => m.MarkId == id);
                if (markToDelete == null)
                {
                    return false;
                }

                db.Marks.Remove(markToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Mark>> GetAllMarksAsync()
        {
            List<Mark> marks;

            using (var db = _dbContext)
            {
                marks = await db.Marks.ToListAsync();
            }
            List<Mark> result = new List<Mark>();

            foreach (var mark in marks) {
                Mark markToAdd = new Mark
                {
                    MarkId = mark.MarkId,
                    StudentId = mark.StudentId,
                    Subject_id = mark.Subject_id,
                    Date = mark.Date,
                    Grade = mark.Grade
                };
                result.Add(markToAdd);
            }
            return result;
        }


        public async Task<Mark> GetMarkByIdAsync(int id)
        {
            Mark mark;
            using (var db = _dbContext)
            {
                mark = await db.Marks.FirstOrDefaultAsync(m => m.MarkId == id);
            }

            if (mark == null)
            {
                return null;
            }
            Mark mark1 = new Mark
            {
                MarkId = mark.MarkId,
                StudentId = mark.StudentId,
                Subject_id = mark.Subject_id,
                Date = mark.Date,
                Grade = mark.Grade
            };
            return mark1;


        }

        public async Task<Mark> UpdateMarkAsync(int id, Mark mark)
        {
            Mark markToUpdate;
            using (var db = _dbContext) {
                markToUpdate = await db.Marks.FirstOrDefaultAsync(m => m.MarkId == id);
                if (markToUpdate == null)
                {
                    return null;
                }

                markToUpdate.StudentId = mark.StudentId;
                markToUpdate.Subject_id = mark.Subject_id;
                markToUpdate.Date = mark.Date;
                markToUpdate.Grade = mark.Grade;

                await db.SaveChangesAsync();
                return markToUpdate;
            }
    }
    }
}









