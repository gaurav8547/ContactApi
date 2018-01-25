namespace ContactApi.Models
{
    public interface IPerson
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
