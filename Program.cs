using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace Lab_1_2910
{
    public class Program
    {
        private static List<VideoGame> list = new List<VideoGame>();
        //So I had to take screenshots in sections by commenting some of the sections below in order to see it, for it surpassed the console limit

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            var ProjectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            string FilePath = @$"{ProjectFolder}{Path.DirectorySeparatorChar}videogames.csv";
            Console.WriteLine(FilePath);

            // INPUTING FILE AND PASSING THE OBJECTS ///////////////////////////////////////////////////////////////////////

            try
            {
                using (var sr = new StreamReader($@"{FilePath}"))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] inputs = line.Split(',');

                        list.Add(new VideoGame(inputs[0], inputs[1], int.Parse(inputs[2]), inputs[3], inputs[4], double.Parse(inputs[5]), double.Parse(inputs[6]), double.Parse(inputs[7]), double.Parse(inputs[8]), double.Parse(inputs[9])));
                    }
                }
            }
            catch
            {
                Console.WriteLine("ERROR OPENING FILE.");
            }

            // SORT FOR #2 //////////////////////////////////////////////////////////////////////////////////////////////

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\n--------------------------------------VIDEO GAMES--------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            list.Sort();
            list.ForEach(VideoGame => Console.WriteLine(VideoGame.Name));

            // LINQ FOR #3 /////////////////////////////////////////////////////////////////////////////////////////////// 

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\n--------------------------------------Publisher Section--------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            var pickedPublisher = list.Where(VideoGame => VideoGame.Publisher == "Nintendo");
            foreach (var VideoGame in pickedPublisher)
            {
                Console.WriteLine(VideoGame);
            }

            // FOR #4 /////////////////////////////////////////////////////////////////////////////////////////////// 

            float selectedpublisher = pickedPublisher.Count();
            float total = list.Count;
            var percentage = (selectedpublisher / total) * 100;
            Console.WriteLine($"\nOut of {total} games, {selectedpublisher} are developed by Nintendo, which is {percentage:0.##}%");

            // FOR #5 /////////////////////////////////////////////////////////////////////////////////////////////// 

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\n--------------------------------------Genre Section--------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            var pickedGenre = list.Where(VideoGame => VideoGame.Genre == "Shooter");
            foreach (var VideoGame in pickedGenre)
            {
                Console.WriteLine(VideoGame);
            }

            // FOR #6 /////////////////////////////////////////////////////////////////////////////////////////////// 

            float selectedGenre = pickedGenre.Count();
            var percent = (selectedGenre / total) * 100;
            Console.WriteLine($"\nOut of {total} games, {selectedGenre} are Shooter games, which is {percent:0.##}%");

            // FOR #7 /////////////////////////////////////////////////////////////////////////////////////////////// 
            
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\n--------------------------------------Publisher User Input Section--------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            PublisherData();

            // FOR #8 /////////////////////////////////////////////////////////////////////////////////////////////// 

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\n--------------------------------------Genre User Input Section--------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            GenreData();
          
        }

        // FOR #7 ///////////////////////////////////////////////////////////////////////////////////////////////

        private static void PublisherData()
        {
            Console.Write("\nWhat Publisher do you want to look up? ");
            string publisherLookup = Console.ReadLine();
            
            var publisherLookup2 = list.Where(VideoGame => VideoGame.Publisher == $"{publisherLookup}");
            foreach (var VideoGame in publisherLookup2)
            {
                Console.WriteLine(VideoGame);
            }
            
            //Percentage
            float total = list.Count;
            float selectedPublisher = publisherLookup2.Count();

            var percentage = (selectedPublisher / total) * 100;
            Console.WriteLine($"\nOut of {total} games, {selectedPublisher} are developed by {publisherLookup}, which is {percentage:0.##}%");

        }

        // FOR #8 ///////////////////////////////////////////////////////////////////////////////////////////////

        private static void GenreData()
        {
            Console.Write("\nWhat Genre do you want to look up? ");
            string genreLookup = Console.ReadLine();

            var genreLookup2 = list.Where(VideoGame => VideoGame.Genre == $"{genreLookup}");
            foreach(var VideoGame in genreLookup2)
            {
                Console.WriteLine(VideoGame);
            }

            //Percentage
            float total = list.Count;
            float selectedGenre = genreLookup2.Count();

            var percentage = (selectedGenre / total) * 100;
            Console.WriteLine($"\nOut of {total} games, {selectedGenre} are {genreLookup} games, which is {percentage:0.##}%");
        }
    }
}
