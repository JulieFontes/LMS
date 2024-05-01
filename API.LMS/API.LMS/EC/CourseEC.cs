using API.LMS.Database;
using Library.LMS.Models;

namespace API.LMS.EC
{
    public class CourseEC
    {
        public List<Course> Courses
        {
            get { return Filebase.Current.Courses; }
        }

        //private EfContext ef = new EfContextFactory().CreateDbContext(new string[0]);
        public Course? AddOrUpdate(Course c)
        {
            Filebase.Current.AddOrUpdate(c);
            return null;
        }

        public Course? Get(string id)
        {
            return Filebase.Current.Courses.FirstOrDefault(c => c.Code == id);
        }

        public Course? Delete(string code)
        {
            Course? courseToDelete = Filebase.Current.Courses.FirstOrDefault(c => c.Code == code);
            if (courseToDelete != null)
            {
               Filebase.Current.DeleteCourse(courseToDelete.Code);
            }
            return courseToDelete;
        }

    }
}