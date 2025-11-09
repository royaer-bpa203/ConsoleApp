public class Group
{
    private static int _idCounter = 1;
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Teacher { get; set; }
    public string Room { get; set; }

    public Group(string name, string teacher, string room)
    {
        Id = _idCounter++;
        Name = name;
        Teacher = teacher;
        Room = room;
    }

    public override string ToString()
    {
        return $"Group(Id={Id}, Name={Name}, Teacher={Teacher}, Room={Room})";
    }
}