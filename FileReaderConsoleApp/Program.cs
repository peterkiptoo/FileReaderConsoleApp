using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileReaderConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double sum = 0;
                double average = 0;
                var usersFile = File.ReadAllLines("userDetails.txt");
                List<string> AverageList = new List<string>(usersFile);
                var query = AverageList.Select(s => s.Split(';'))
                    .GroupBy(sp => sp[0])
                    .Select(grp =>
                    new
                    {
                        Name = grp.Key,
                        Avg = grp.Average(t => int.Parse(t[1])),

                    });
                foreach( var item in query)
                {
                    Console.WriteLine("Name:{0}| Salary: {1}", item.Name, item.Avg);
                    sum += item.Avg;
                    average = sum / AverageList.Count;

                }
                Console.WriteLine("Average Salary: " + average);
                Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
