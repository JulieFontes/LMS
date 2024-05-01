using API.LMS.Database;
using Library.LMS.Models;

namespace API.LMS.EC
{
    public class PersonEC
    {
        public List<Person> People
        {
            get { return Filebase.Current.People; }
        }

        public List<Student> Students
        {
            get { return Filebase.Current.Students; }
        }

        //private EfContext ef = new EfContextFactory().CreateDbContext(new string[0]);
        public Person? AddOrUpdate(Person p)
        {
            Filebase.Current.AddOrUpdate(p);
            return p;
        }

        public Student? GetStudent(string id)
        {
            return Filebase.Current.Students.Where(s => s.Id == id).FirstOrDefault();
        }

        public Person? Delete(string id)
        {
            Person? personToDelete = Filebase.Current.Students.FirstOrDefault(c => c.Id == id);
            if (personToDelete != null)
            {
                Filebase.Current.DeletePerson(personToDelete.Id ?? string.Empty);
            }
            return personToDelete;
        }

    }
}