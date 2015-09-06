using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {            
            string enteredName;
            string enteredPosition;
            int enteredYear;

            Worker[] workers = new Worker[5];

            int count = 0;
            while (count < 5)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Enter worker's name -> ");
                enteredName = Console.ReadLine();

                Console.WriteLine("Enter worker's position -> ");
                enteredPosition = Console.ReadLine();

                Console.WriteLine("Enter worker's year of applying for a job -> ");
                
                if(!Int32.TryParse(Console.ReadLine(), out enteredYear))
                {
                    Console.WriteLine("Year must be a number");
                    continue;
                }

                Worker worker;

                try
                {
                    worker = new Worker(enteredName, enteredPosition, enteredYear);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch(YearFormatExeption e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                workers[count] = worker;
                Console.WriteLine("Worker was added.");
                count++;
            }

            Array.Sort(workers);
            int enteredExp;
            while (true)
            {
                Console.WriteLine("\nEnter the number of years and you'll receive all workers who has an experience greater than the entered number");
                if (Int32.TryParse(Console.ReadLine(), out enteredExp))
                {
                    Console.WriteLine("\nAll workers with experience greater than {0} years", enteredExp);
                    foreach (var item in workers.GetWorkersWithGreaterExp(enteredExp))
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }

            Console.ReadKey();
        }
    }

    static class SetExt
    {
        public static Worker[] GetWorkersWithGreaterExp(this Worker[] workerArr, int experience)
        {
            var list = new List<Worker>();
            foreach (var item in workerArr)
            {
                if(DateTime.Now.Year - item.ApplyingJobYear > experience)
                {
                    list.Add(item);
                }
            }

            return list.ToArray();
        }
    }
}
