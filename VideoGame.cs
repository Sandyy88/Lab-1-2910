using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_2910
{
    public class VideoGame : IComparable<VideoGame>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; } 
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NASales { get; set; }
        public double EUSales { get; set; }
        public double JPSales { get; set; }
        public double OtherSales { get; set; }
        public double GlobalSales { get; set; }

        public VideoGame(string Name, string Platform, int Year, string Genre, string Publisher, double NASales, double EUSales, double JPSales, double OtherSales, double GlobalSales)
        {
            this.Name = Name;
            this.Platform = Platform;
            this.Year = Year;
            this.Genre = Genre;
            this.Publisher = Publisher;
            this.NASales = NASales;
            this.EUSales = EUSales;
            this.JPSales = JPSales;
            this.OtherSales = OtherSales;
            this.GlobalSales = GlobalSales;
        }

        public int CompareTo(VideoGame other)
            => string.Compare(Name, other.Name);

        public override string ToString()
        {
            string str = $"\nName: {Name}";
                   str += $"\nPlatform: {Platform}";
                   str += $"\nYear: {Year}";
                   str += $"\nGenre: {Genre}";
                   str += $"\nPublisher: {Publisher}";
                   str += $"\nNASales: {NASales}";
                   str += $"\nEUSales: {EUSales}";
                   str += $"\nJPSales: {JPSales}";
                   str += $"\nOtherSales: {OtherSales}";
                   str += $"\nGlobalSales: {GlobalSales}";

            return str;
        }
    }
}