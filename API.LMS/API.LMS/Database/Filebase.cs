using Newtonsoft.Json;
using Library.LMS.Models;

namespace API.LMS.Database
{
    public class Filebase
    {
        private string _root;
        private string _personRoot;
        private string _courseRoot;
        private string _studentRoot;
        private static Filebase? _instance;

        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = "C:\\temp";
            _personRoot = $"{_root}\\People";
            _studentRoot = $"{_personRoot}\\Students";
            _courseRoot = $"{_root}\\Courses";

            if (!Directory.Exists(_studentRoot))
                Directory.CreateDirectory(_studentRoot);

            if (!Directory.Exists(_courseRoot))
                Directory.CreateDirectory(_courseRoot);

        }

        public List<Student> Students
        {
            get
            {
                var root = new DirectoryInfo(_studentRoot);
                var students = new List<Student>();
                foreach (var todoFile in root.GetFiles())
                {
                    var todo = JsonConvert.DeserializeObject<Student>(File.ReadAllText(todoFile.FullName));
                    if (todo != null )
                        students.Add(todo);
                }
                return students;
            }
        }

        public List<Person> People  //All people 
        {
            get
            {
                DirectoryInfo root = new DirectoryInfo(_personRoot);
                var people = new List<Person>();
                foreach (var todoFile in root.GetFiles())
                {
                    var todo = JsonConvert.DeserializeObject<Person>(File.ReadAllText(todoFile.FullName));
                    if (todo != null)
                        people.Add(todo);
                }
                root = new DirectoryInfo(_studentRoot);
                foreach (var todoFile in root.GetFiles())
                {
                    var todo = JsonConvert.DeserializeObject<Person>(File.ReadAllText(todoFile.FullName));
                    if (todo != null)
                        people.Add(todo);
                }
                return people;
            }
        }

        public List<Course> Courses
        {
            get 
            {
                DirectoryInfo root = new DirectoryInfo(_courseRoot);
                var courses = new List<Course>();
                foreach (var todoFile in root.GetFiles())
                {
                    var todo = JsonConvert.DeserializeObject<Course>(File.ReadAllText(todoFile.FullName));
                    if (todo != null)
                        courses.Add(todo);
                }
                return courses;
            }
        }

        public Person AddOrUpdate(Person p)
        {
            if (p.Id == null || p.Id == "")
                p.Id = newId(p.Name);

            string root;
            if (p is Student)
            {
                root = _studentRoot;
                p = p as Student;
            }
            else root = _personRoot;

            string path = $"{root}\\{p.Id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                File.Delete(path);      //blow it up
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(p));

            return p;
        }

        public bool DeletePerson(string id)
        {
            string path = $"{_personRoot}\\{id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
                return true;
            }
            path = $"{_studentRoot}\\{id}.json";
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }

        public Course AddOrUpdate(Course c)
        {

            string path = $"{_courseRoot}\\{c.Code}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                File.Delete(path);      //blow it up
            }
            else
            {
                path = $"{_courseRoot}\\{c.Code}.json";
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(c));

            return c;
        }

        public bool DeleteCourse(string code)
        {
            string path = $"{_courseRoot}\\{code}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
                return true;
            }

            return false;
        }

        private string newId(string _name)
        {
            _name = _name.ToLower();
            string id = string.Empty;

            if (char.IsLetter(_name[0]))
                id += _name[0];

            for (int i = 1; i < _name.Length; ++i)
            {
                if (_name[i] == ' ' && i != _name.Length-1)
                {
                    id += _name[++i];
                }
            }

            int currentYear = DateTime.Now.Year;
            id += currentYear.ToString().Substring(2);

            id = lastValidId(id);

            return id;
        }

        private string lastValidId(string id)
        {
            foreach (Person s in Current.People)
            {
                if (s.Id == id)
                {
                    id += 'a';
                }
            }

            return id;
        }
    }

}