using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

public class Program
{
    private static List<CustomAlbum> albums = new List<CustomAlbum>();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1 - Dodawanie płyty do bazy danych");
            Console.WriteLine("2 - Wszystkie płyty");
            Console.WriteLine("3 - Szczegółowe informacje o płycie");
            Console.WriteLine("4 - Wykonawcy na danej płycie");
            Console.WriteLine("5 - Szczegółowe informacje o utworze");
            Console.WriteLine("6 - Zapis bazy do pliku");
            Console.WriteLine("7 - Odczyt bazy z pliku");
            Console.WriteLine("8 - Wyjście");

            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCustomAlbum();
                    break;
                case "2":
                    DisplayAllCustomAlbums();
                    break;
                case "3":
                    DisplayCustomAlbumDetails();
                    break;
                case "4":
                    DisplayPerformersOnCustomAlbum();
                    break;
                case "5":
                    DisplayTrackDetails();
                    break;
                case "6":
                    SaveDatabaseToFile();
                    break;
                case "7":
                    LoadDatabaseFromFile();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void AddCustomAlbum()
    {
        Console.WriteLine("Dodawanie nowej płyty:\n");

        Console.Write("Tytuł płyty: ");
        string title = Console.ReadLine();
    XD2:
        Console.Write("Typ płyty (CD/DVD): ");
        string type1 = Console.ReadLine();
        string type;
        if (type1 == "CD" || type1 == "dvd" || type1 == "cd" || type1 == "DVD")
        {
            type = type1;
        }
        else
        {

            Console.WriteLine("Wpisano zły typ płyty");
            goto XD2;
        }

        Console.Write("Wykonawca: ");
        string author = Console.ReadLine();

        double duration;
        Console.Write("Czas trwania (minuty): ");

        while (!double.TryParse(Console.ReadLine(), out duration))
        {
            Console.WriteLine("Proszę wprowadzić prawidłową liczbę.");
            Console.Write("Czas trwania (minuty): ");
        }

        int albumNumber;
        Console.Write("Numer płyty: ");

        while (!int.TryParse(Console.ReadLine(), out albumNumber))
        {
            Console.WriteLine("Proszę wprowadzić prawidłową liczbę.");
            Console.Write("Numer płyty: ");
        }

        CustomAlbum album = new CustomAlbum(title, type, duration, albumNumber);
        albums.Add(album);

        while (true)
        {
        XD:
            Console.Write("Podaj tytuł utworu: ");
            string songName = Console.ReadLine();

            double songDuration;
            Console.Write("Podaj czas trwania utworu: ");

            while (!double.TryParse(Console.ReadLine(), out songDuration))
            {
                Console.WriteLine("Proszę wprowadzić prawidłową liczbę.");
                Console.Write("Podaj czas trwania utworu: ");
            }

            Console.Write("Podaj wykonawców utworu (po przecinku): ");
            string songArtists = Console.ReadLine();

            Console.Write("Podaj kompozytora utworu: ");
            string songComposer = Console.ReadLine();

            int songNumber;
            Console.Write("Podaj numer utworu: ");

            while (!int.TryParse(Console.ReadLine(), out songNumber))
            {
                Console.WriteLine("Proszę wprowadzić prawidłową liczbę.");
                Console.Write("Numer utworu: ");
            }

            CustomTrack track = new CustomTrack(songName, songDuration, songComposer, songNumber);
            foreach (var artist in songArtists.Split(','))
            {
                track.Performers.Add(artist.Trim());
            }

            album.AddTrack(track);

            Console.Write("Czy na płycie jest więcej utworów? T/N");
            string songCheck = Console.ReadLine();

            if (songCheck == "T" || songCheck == "t")
                goto XD;
        }

        Console.WriteLine("Płyta dodana do bazy danych.");
    }

    private static void DisplayAllCustomAlbums()
    {
        Console.WriteLine("Lista wszystkich płyt:");

        foreach (var album in albums)
        {
            Console.WriteLine(album.GetTitle());
        }
    }

    private static void DisplayCustomAlbumDetails()
    {
        Console.Write("Podaj numer płyty: ");
        if (int.TryParse(Console.ReadLine(), out int albumNumber))
        {
            var album = FindCustomAlbumByNumber(albumNumber);

            if (album != null)
            {
                album.DisplayCustomAlbum();
            }
            else
            {
                Console.WriteLine("Płyta o podanym numerze nie istnieje.");
            }
        }
        else
        {
            Console.WriteLine("Proszę wprowadzić prawidłowy numer.");
        }
    }

    private static void DisplayPerformersOnCustomAlbum()
    {
        Console.Write("Podaj numer płyty: ");
        if (int.TryParse(Console.ReadLine(), out int albumNumber))
        {
            var album = FindCustomAlbumByNumber(albumNumber);

            if (album != null)
            {
                Console.WriteLine($"Wykonawcy na płycie {album.GetTitle()}:");
                foreach (var performer in album.GetPerformers())
                {
                    Console.WriteLine(performer);
                }
            }
            else
            {
                Console.WriteLine("Płyta o podanym numerze nie istnieje.");
            }
        }
        else
        {
            Console.WriteLine("Proszę wprowadzić prawidłowy numer.");
        }
    }

    private static void DisplayTrackDetails()
    {
        Console.Write("Podaj numer płyty: ");
        if (int.TryParse(Console.ReadLine(), out int albumNumber))
        {
            var album = FindCustomAlbumByNumber(albumNumber);

            if (album != null)
            {
                Console.Write("Podaj numer utworu: ");
                if (int.TryParse(Console.ReadLine(), out int trackNumber))
                {
                    album.DisplayCustomTrack(trackNumber);
                }
                else
                {
                    Console.WriteLine("Proszę wprowadzić prawidłowy numer utworu.");
                }
            }
            else
            {
                Console.WriteLine("Płyta o podanym numerze nie istnieje.");
            }
        }
        else
        {
            Console.WriteLine("Proszę wprowadzić prawidłowy numer.");
        }
    }

    private static CustomAlbum FindCustomAlbumByNumber(int albumNumber)
    {
        foreach (var album in albums)
        {
            if (album.GetAlbumNumber() == albumNumber)
            {
                return album;
            }
        }
        return null;
    }

    private static void SaveDatabaseToFile()
    {
        using (StreamWriter file = File.CreateText("custom_albums.txt"))
        {
            foreach (var album in albums)
            {
                file.WriteLine($"Tytuł płyty:{album.GetTitle()}\nTyp płyty:{album.GetType()}\nCzas trwania:{album.GetDuration()}\nNumer płyty:{album.GetAlbumNumber()}");

                foreach (var track in album.GetTracks())
                {
                    file.WriteLine($"Track:{track.Title},{track.Duration},{track.Composer},{track.TrackNumber}");
                    file.WriteLine($"Performers:{string.Join(",", track.Performers)}");
                }

                file.WriteLine("---");
            }
        }

        Console.WriteLine("Baza danych została zapisana do pliku custom_albums.txt.\n");
        Console.WriteLine("Plik znajduje się w C:\\Users\\[user]\\source\\repos\\kolegaMuzykant\\bin\\Debug\\net8.0");
    }

    private static void LoadDatabaseFromFile()
    {
        if (File.Exists("custom_albums.txt"))
        {
            albums.Clear();
            using (StreamReader file = File.OpenText("custom_albums.txt"))
            {
                CustomAlbum currentAlbum = null;
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("Tytuł utworu:"))
                    {
                        string[] albumInfo = line.Split('\n');
                        string title = albumInfo[0].Split(':')[1];
                        string type = albumInfo[1].Split(':')[1];
                        double duration = double.Parse(albumInfo[2].Split(':')[1]);
                        int albumNumber = int.Parse(albumInfo[3].Split(':')[1]);

                        currentAlbum = new CustomAlbum(title, type, duration, albumNumber);
                        albums.Add(currentAlbum);
                    }
                    else if (line.StartsWith("Tytuł utworu:"))
                    {
                        string[] trackInfo = line.Split(',');
                        string title = trackInfo[0].Split(':')[1];
                        double duration = double.Parse(trackInfo[1]);
                        string composer = trackInfo[2];
                        int trackNumber = int.Parse(trackInfo[3]);

                        CustomTrack track = new CustomTrack(title, duration, composer, trackNumber);
                        currentAlbum.AddTrack(track);
                    }
                    else if (line.StartsWith("Wykonawcy:"))
                    {
                        string[] performers = line.Split(':')[1].Split(',');
                        foreach (var performer in performers)
                        {
                            currentAlbum.GetTracks().Last().Performers.Add(performer.Trim());
                        }
                    }
                    else if (line == "---")
                    {
                        currentAlbum = null;
                    }
                }
            }

            Console.WriteLine("Baza danych została wczytana z pliku.");
        }
        else
        {
            Console.WriteLine("Plik z bazą danych nie istnieje.");
        }
    }
}

public class CustomAlbum
{
    private string title;
    private string type;
    private double duration;
    private List<CustomTrack> trackList;
    private List<string> performers;
    private int albumNumber;

    public CustomAlbum(string title, string type, double duration, int albumNumber)
    {
        this.title = title;
        this.type = type;
        this.duration = duration;
        this.trackList = new List<CustomTrack>();
        this.performers = new List<string>();
        this.albumNumber = albumNumber;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetType()
    {
        return type;
    }

    public int GetAlbumNumber()
    {
        return albumNumber;
    }

    public double GetDuration()
    {
        return duration;
    }

    public List<CustomTrack> GetTracks()
    {
        return trackList;
    }

    public List<string> GetPerformers()
    {
        return performers;
    }

    public void AddTrack(CustomTrack track)
    {
        trackList.Add(track);
    }

    public void AddPerformer(string performer)
    {
        performers.Add(performer);
    }

    public void DisplayCustomAlbum()
    {
        Console.WriteLine($"Tytuł płyty: {title}");
        Console.WriteLine($"Typ płyty: {type}");
        Console.WriteLine($"Czas trwania: {duration} minutes");
        Console.WriteLine($"Numer płyty: {albumNumber}");
        Console.WriteLine("Lista utworów:");
        foreach (var track in trackList)
        {
            Console.WriteLine($"- {track.Title}");
        }
    }

    public void DisplayCustomTrack(int trackNumber)
    {
        var track = trackList.FirstOrDefault(t => t.TrackNumber == trackNumber);
        if (track != null)
        {
            Console.WriteLine($"Tytuł utworu: {track.Title}");
            Console.WriteLine($"Czas trwania utworu: {track.Duration} minutes");
            Console.WriteLine("Wykonawcy:");
            foreach (var performer in track.Performers)
            {
                Console.WriteLine($"- {performer}");
            }
            Console.WriteLine($"Kompozytor: {track.Composer}");
            Console.WriteLine($"Numer utworu: {track.TrackNumber}");
        }
        else
        {
            Console.WriteLine("Nie ma utworu o takim numerze.");
        }
    }
}

public class CustomTrack
{
    private string title;
    private double duration;
    private List<string> performers;
    private string composer;
    private int trackNumber;

    public CustomTrack(string title, double duration, string composer, int trackNumber)
    {
        this.title = title;
        this.duration = duration;
        this.performers = new List<string>();
        this.composer = composer;
        this.trackNumber = trackNumber;
    }

    public string Title
    {
        get { return title; }
    }

    public double Duration
    {
        get { return duration; }
    }

    public List<string> Performers
    {
        get { return performers; }
    }

    public string Composer
    {
        get { return composer; }
    }

    public int TrackNumber
    {
        get { return trackNumber; }
    }
}
