namespace csharp_practice23;

public class Film: IDisposable
{
    private string _title;
    private string _studio;
    private string _genre;
    private int _duration;
    private int _year;
    private bool _disposed = false;

    public string Title
    {
        get => _title;
        set => _title = value;
    }
    public string Studio
    {
        get => _studio;
        set => _studio = value;
    }
    public string Genre
    {
        get => _genre;
        set => _genre = value;
    }
    public int Duration
    {
        get => _duration;
        set => _duration = value > 0 ? value : 0;
    }

    public int Year
    {
        get => _year;
        set => _year = value > 1888 ? value : 1800;
    }
    

    public Film(string title, string studio, string genre, int duration, int year)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty");
        if (string.IsNullOrWhiteSpace(studio))
            throw new ArgumentException("Studio cannot be null or empty");
        if (string.IsNullOrWhiteSpace(genre))
            throw new ArgumentException("Genre cannot be null or empty");
        if (duration < 0)
            throw new ArgumentException("Duration cannot be negative");
        if (year < 1888)
            throw new ArgumentException("Year cannot be less than 1888");
        
        _title = title;
        _studio = studio;
        _genre = genre;
        _duration = duration;
        _year = year;
    }

    public void Print()
    {
        Console.WriteLine($"Title: {Title} ({Year})");
        Console.WriteLine($"Studio: {Studio}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Duration: {Duration} minutes\n");
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Console.WriteLine($"[DISPOSE]: Film \"{Title}\" ({Year}) is deleted through the Dispose method");
            _disposed = true;
        }
    }
    // ~Film() => Console.WriteLine($"[FINALIZATION]: Film \"{Title}\" is deleted");
}

class Program
{
    static void Main(string[] args)
    {
        // Film f1 = new Film("Spider-Man: Brand New Day", "Columbia Picture / Marvel Studios", "Action / Sci-Fi", 145,
        //     2026);
        // f1.Print();
        // GcTest();
        // GC.Collect();
        // GC.WaitForPendingFinalizers();
        
        
        using (Film f1 = new Film("Spider-Man: Brand New Day", "Columbia Picture / Marvel Studios", "Action / Sci-Fi", 145, 2026))
        {
            f1.Print();
            Console.WriteLine("Using block...");
        }
        Console.WriteLine("THE END");
    }

    // static void GcTest()
    // {
    //     Film f2 = new Film("GC Test", "GC Test", "GC Test", 228, 2022);
    //     Console.WriteLine($"Temporary file \"{f2.Title}\"");
    // }
}