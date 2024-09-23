namespace MovieReservation.CORE.Entities;

public class Movie:BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public int Duration { get; set; }
    public double? Rating { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<ShowTime>? ShowTimes { get; set; }

}
