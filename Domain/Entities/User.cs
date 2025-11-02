namespace SCleanArchitecture.SimpleAPI.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string ?Name { get; set; }
    public string ?Email { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public User() { }

}
