public class Movie : Media
{
    public int Duration { get; set; }
    public string Director { get; set; }

    public Movie(string title, string author, int yearPublished, int duration, string director)
        : base(title, author, yearPublished)
    {
        Duration = duration;
        Director = director;
    }

    public override string ToString()
    {
        return base.ToString() + $", Длительность: {Duration} мин., Режиссер: {Director}";
    }
}