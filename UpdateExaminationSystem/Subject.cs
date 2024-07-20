using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateExaminationSystem
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        int input, time  ,numofque;
        public void CreateExam()
        {


            do
            {
              Console.Write($"Enter The Type Of Exam You Want to Create (1 for Final || 2 for Practical ): ");
            } while (int.TryParse(Console.ReadLine(), out input) && (input < 1 || input >= 2));
            
            do {
                 Console.Write("Enter Time of Exam : ");
               } while ( int.TryParse(Console.ReadLine() ,out time) && (time <1 ));

            do
            {
                Console.Write("Enter The number of Question : ");
            } while (int.TryParse(Console.ReadLine(), out numofque) && (numofque <1));
    
            Console.Clear();
            switch (input)
            {
                case 1:
                    Exam = new FinalExam(time, numofque);
                    break;
                case 2:
                    Exam = new PracticalExam(time, numofque);
                    break;
                default:
                    Console.WriteLine("Not Valid");
                    return;
            }

            Exam.CreateExam();
        }
        public void ShowExam()
        {
            Console.WriteLine($"Subject: {SubjectName}");
            Exam.ShowExam();
        }
    }
}

