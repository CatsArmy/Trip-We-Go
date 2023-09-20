using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Trip_We_Go
{
    internal class Tour
    {
        public string name;
        private Point[] places;
        private int index;
        public Tour(string name)
        {
            this.name = name;
            this.places = new Point[20];
            this.index = 0;
        }
        public Tour(Tour tour)
        {
            this.name = tour.name;
            this.places = new Point[tour.places.Length];
            for (int i = 0; i < tour.index; i++)
            {
                this.places[i] = new Point(tour.places[i]);
            }
            this.index = tour.index;
        }
        public bool AddPoint(Point p)
        {
            if (this.index >= this.places.Length || this.index < 0) return false;
            this.places[this.index] = new Point(p);
            index++;
            return true;
        }
        public Point[] GetPlaces()
        {
            Point[] arr = new Point[this.places.Length];
            for (int i = 0; i < this.index; i++)
            {
                arr[i] = new Point(this.places[i]);
            }
            return arr;
        }

        public double TourLength()
        {
            double length = 0;
            for (int i = 0; i < this.index - 1; i++)
            {
                length += this.places[i].Distance(this.places[i + 1]);
            }
            return length;
        }
        public Point HighestPoint()
        {
            int index = 0;
            for (int i = 1; i < this.index; i++)
            {
                if (this.places[i].IsAbove(this.places[index]))
                {
                    index = i;
                }
            }
            return this.places[index];
        }
        public double LongestDistance()
        {
            double distance = -1;
            for (int i = 0; i < this.index - 1; i++)
            {
                double value = this.places[i].Distance(this.places[i + 1]);
                if (distance < value)
                {
                    distance = value;
                }
            }
            return distance;
        }
        public int DifficultyLevel()
        {
            int countRises = 0;
            int countDescents = 0;
            for (int i = 0; i < this.index - 1; i++)
            {
                if (this.places[i].IsAbove(this.places[i + 1]))
                {
                    countDescents++;
                }
                else if (this.places[i].IsBelow(this.places[i + 1]))
                {
                    countRises++;
                }
            }
            if (countRises > countDescents)
            {
                return 3;
            }
            if (countRises < countDescents)
            {
                return 2;
            }
            return 1;
        }
        public bool Exist(Point p)
        {
            for (int i = 0; i < index; i++)
            {
                if (this.places[i].Equals(p))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            string s = "length of the tour " + TourLength() + "\n";
            s += "all of the points: " + "\n";
            for (int i = 0; i < this.index; i++)
            {
                s += this.places[i] + "\n";
            }
            s += "the highest point: " + HighestPoint() + "\n";
            s += "longest part: " + LongestDistance() + "\n";
            s += "difficulty level: " + DifficultyLevel();
            return s;
        }


    }
}
