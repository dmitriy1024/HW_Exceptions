using System;

namespace Task1
{
    struct Worker : IComparable<Worker>
    {
        public string NameAndInitials;

        public readonly string Position;

        public readonly int ApplyingJobYear;

        public Worker(string nameAndInitials, string position, int applyingJobYear)
        {
            if(nameAndInitials == null || position == null || nameAndInitials.Length == 0 || position.Length == 0)
            {
                throw new ArgumentException("Name and position cannot be null or empty!");
            }
            else if(applyingJobYear < 1900 || applyingJobYear > DateTime.Now.Year)
            {
                throw new YearFormatExeption("Year has an incorrect format!");
            }
            else
            {
                NameAndInitials = nameAndInitials;
                Position = position;
                ApplyingJobYear = applyingJobYear;
            }
        }

        public int CompareTo(Worker other)
        {   
            return String.Compare(NameAndInitials, other.NameAndInitials, true);
        }

        public override string ToString()
        {
            return String.Format("Name: {0,-12} Position: {1,-12} Year of applying for a job: {2,-12}", NameAndInitials, Position, ApplyingJobYear);
        }
    }
}
