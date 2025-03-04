using System;

class FilmReviewSystem
{
    static int[][] Ratings;

    static void Main()
    {
        Console.Write("Enter the number of films to review: ");
        int filmCount = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the number of users providing ratings: ");
        int reviewerCount = Convert.ToInt32(Console.ReadLine());

        Initialize(filmCount, reviewerCount);

        int menuSelection;
        do
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Submit Film Ratings");
            Console.WriteLine("2. Show All Ratings");
            Console.WriteLine("3. Calculate Average Ratings");
            Console.WriteLine("4. Identify Best Rated Film");
            Console.WriteLine("5. Identify Worst Rated Film");
            Console.WriteLine("6. Exit");
            Console.Write("Selection: ");
            menuSelection = Convert.ToInt32(Console.ReadLine());

            switch (menuSelection)
            {
                case 1:
                    EnterRatings(filmCount, reviewerCount);
                    break;
                case 2:
                    ShowRatings(filmCount);
                    break;
                case 3:
                    ComputeAverages(filmCount, reviewerCount);
                    break;
                case 4:
                    IdentifyBestFilm(filmCount, reviewerCount);
                    break;
                case 5:
                    IdentifyWorstFilm(filmCount, reviewerCount);
                    break;
                case 6:
                    Console.WriteLine("Exiting program. Have a great day!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        } while (menuSelection != 6);
    }

    static void Initialize(int filmCount, int reviewerCount)
    {
        Ratings = new int[filmCount][];
        for (int i = 0; i < filmCount; i++)
        {
            Ratings[i] = new int[reviewerCount];
        }
    }

    static void EnterRatings(int filmCount, int reviewerCount)
    {
        for (int i = 0; i < filmCount; i++)
        {
            Console.WriteLine($"\nProvide ratings for Film {i + 1}:");
            for (int j = 0; j < reviewerCount; j++)
            {
                Console.Write($"Reviewer {j + 1}, rate this film (1-5): ");
                Ratings[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }

    static void ShowRatings(int filmCount)
    {
        Console.WriteLine("\nCurrent Ratings:");
        for (int i = 0; i < filmCount; i++)
        {
            Console.WriteLine($"Film {i + 1}: {string.Join(", ", Ratings[i])}");
        }
    }

    static void ComputeAverages(int filmCount, int reviewerCount)
    {
        Console.WriteLine("\nAverage Ratings:");
        for (int i = 0; i < filmCount; i++)
        {
            double total = 0;
            for (int j = 0; j < reviewerCount; j++)
            {
                total += Ratings[i][j];
            }
            double avg = total / reviewerCount;
            Console.WriteLine($"Film {i + 1} - Avg Rating: {avg:F2}");
        }
    }

    static void IdentifyBestFilm(int filmCount, int reviewerCount)
    {
        double highestAvg = 0;
        int bestFilmIndex = -1;
        for (int i = 0; i < filmCount; i++)
        {
            double total = 0;
            for (int j = 0; j < reviewerCount; j++)
            {
                total += Ratings[i][j];
            }
            double avg = total / reviewerCount;
            if (avg > highestAvg)
            {
                highestAvg = avg;
                bestFilmIndex = i;
            }
        }
        Console.WriteLine($"\nTop-rated film: Film {bestFilmIndex + 1} with an average rating of {highestAvg:F2}");
    }

    static void IdentifyWorstFilm(int filmCount, int reviewerCount)
    {
        double lowestAvg = double.MaxValue;
        int worstFilmIndex = -1;
        for (int i = 0; i < filmCount; i++)
        {
            double total = 0;
            for (int j = 0; j < reviewerCount; j++)
            {
                total += Ratings[i][j];
            }
            double avg = total / reviewerCount;
            if (avg < lowestAvg)
            {
                lowestAvg = avg;
                worstFilmIndex = i;
            }
        }
        Console.WriteLine($"\nLowest-rated film: Film {worstFilmIndex + 1} with an average rating of {lowestAvg:F2}");
    }
}