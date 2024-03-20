namespace Library.LMS.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public Person()
        {
            Name = string.Empty;
            Id = string.Empty;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }

}
