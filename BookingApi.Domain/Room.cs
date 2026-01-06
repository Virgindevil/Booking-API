namespace BookingApi.Domain;

public class Room
{
    public int Id { get; set; }
    public string Class { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}