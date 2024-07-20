using System.Diagnostics;

namespace UpdateExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C#");
            subject.CreateExam();

            Console.Clear();
            char input;
            do
            {
                Console.Write("Do you want to start exam (Y|N ) :");
            } while (!char.TryParse(Console.ReadLine(), out input));
            Console.Clear();
            if (input =='Y')
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                subject.ShowExam();

                Console.WriteLine($"The Elapsed :{stopwatch.Elapsed}");
            }
            else if (input=='N')
                Console.WriteLine("GoodLuck");
            else
                Console.WriteLine("not Valid");

            Console.ReadLine();
        }
    }

  }

