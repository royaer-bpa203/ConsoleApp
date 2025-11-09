using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseApp
{     // ==================== COURSE APPLICATION ====================

    public class CourseApp
    {
        private List<Group> groups = new List<Group>();
        private List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            Console.WriteLine("Course Application Started");
        }

        // 1 - Create Group
        public Group CreateGroup(string name, string teacher, string room)
        {
            var group = new Group(name, teacher, room);
            groups.Add(group);
            return group;
        }

        // 2 - Update Group
        public Group UpdateGroup(int groupId, string name = null, string teacher = null, string room = null)
        {
            var group = GetGroupById(groupId);
            if (group == null) return null;

            if (name != null) group.Name = name;
            if (teacher != null) group.Teacher = teacher;
            if (room != null) group.Room = room;

            return group;
        }

        // 3 - Delete Group
        public bool DeleteGroup(int groupId)
        {
            var group = GetGroupById(groupId);
            if (group != null)
            {
                groups.Remove(group);
                students.RemoveAll(s => s.Group.Id == groupId); // Qrup silinirsə, tələbələr də silinir
                return true;
            }
            return false;
        }

        // 4 - Get Group by Id
        public Group GetGroupById(int groupId)
        {
            return groups.FirstOrDefault(g => g.Id == groupId);
        }

        // 5 - Get all groups by teacher
        public List<Group> GetGroupsByTeacher(string teacher)
        {
            return groups.Where(g => g.Teacher.Equals(teacher, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // 6 - Get all groups by room
        public List<Group> GetGroupsByRoom(string room)
        {
            return groups.Where(g => g.Room.Equals(room, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // 7 - Get all groups
        public List<Group> GetAllGroups()
        {
            return groups;
        }

        // 8 - Create Student
        public Student CreateStudent(string name, string surname, int age, int groupId)
        {
            var group = GetGroupById(groupId);
            if (group == null)
                throw new Exception("Group not found!");

            var student = new Student(name, surname, age, group);
            students.Add(student);
            return student;
        }

        // 9 - Update Student
        public Student UpdateStudent(int studentId, string name = null, string surname = null, int? age = null, int? groupId = null)
        {
            var student = GetStudentById(studentId);
            if (student == null) return null;

            if (name != null) student.Name = name;
            if (surname != null) student.Surname = surname;
            if (age != null) student.Age = age.Value;
            if (groupId != null)
            {
                var group = GetGroupById(groupId.Value);
                if (group != null)
                    student.Group = group;
            }

            return student;
        }

        // 10 - Get student by id
        public Student GetStudentById(int studentId)
        {
            return students.FirstOrDefault(s => s.Id == studentId);
        }
        // 11 - Delete student
        public bool DeleteStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student != null)
            {
                students.Remove(student);
                return true;
            }
            return false;
        }

        // 12 - Get students by age
        public List<Student> GetStudentsByAge(int age)
        {
            return students.Where(s => s.Age == age).ToList();
        }

    }
}
