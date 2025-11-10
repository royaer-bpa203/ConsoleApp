public class Student
{
    private static int _idCounter = 1;
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }

    public Student(string name, string surname, int age, Group group)
    {
        Id = _idCounter++;
        Name = name;
        Surname = surname;
        Age = age;
        Group = group;
    }
    public override string ToString()
    {
        return $"Student(Id={Id}, Name={Name}, Surname={Surname}, Age={Age}, GroupId={Group?.Id})";
    }
}