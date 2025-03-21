public class Book : Media
{
    public int PageCount { get; set; }
    public string Genre { get; set; }

    public Book(string title, string author, int yearPublished, int pageCount, string genre)
        : base(title, author, yearPublished)
    {
        PageCount = pageCount;
        Genre = genre;
    }

    public override string ToString()
    {
        return base.ToString() + $", Страниц: {PageCount}, Жанр: {Genre}";
    }
}