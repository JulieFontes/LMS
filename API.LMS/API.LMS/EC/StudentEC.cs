using API.LMS.Database;
using Library.LMS.Models;

namespace API.LMS.EC
{
    public class StudentEC
    {
        //private EfContext ef = new EfContextFactory().CreateDbContext(new string[0]);
        public List<Student> Students
        {
            get { return FakeDatabase.Current.Students; }
        }

        public Student? AddOrUpdate(Student s)
        {
            Filebase.Current.AddOrUpdate(s);
            return null;
        }

        public Student? Get(string id)
        {
            return Filebase.Current.People.FirstOrDefault(x => x.Id == id) as Student;
        }

        public Student? Delete(string id)
        {
            Student? studentToDelete = Filebase.Current.People.FirstOrDefault(x => x.Id == id) as Student;
            if (studentToDelete != null)
            {
                Filebase.Current.DeletePerson(studentToDelete.Id ?? string.Empty);
            }
            return studentToDelete;
        }

    }
}