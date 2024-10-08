﻿namespace MovieReservation.CORE.Entities;

public class ShowTime:BaseEntity
{
    public int MovieId { get; set; }
    public int TheaterId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Movie Movie { get; set; }
    public Theater Theater { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
}
