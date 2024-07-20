using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static UpdateExaminationSystem.Mcq;

namespace UpdateExaminationSystem
{
    public class PracticalExam : Exam
    {   


        Question question =new Question ();

        public PracticalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public override void CreateExam()
        {
           for (int i = 0; i < NumberOfQuestions; i++) { 
           question.Header = "MCQ  ";
            Console.WriteLine(question.Header);
            Console.Write("Enter the body of the question: ");
           question.Body = Console.ReadLine();

            Console.Write("Enter the mark for question: ");
            question.Mark = int.Parse(Console.ReadLine());

            question = new MCQ(question.Header, question.Body, question.Mark);


            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Enter answer choice {j + 1}: ");
                string choic = Console.ReadLine();
                question.AddAnswer(new Answer(j + 1, choic));
            }

            Console.Write("Enter the index of the correct answer: ");
            int correctIndex = int.Parse(Console.ReadLine());
            question.CorrectAnswerIndex = correctIndex;


            Console.WriteLine("-----------------------------------");
                Question.Add(question);

            }
    }

        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam:");
            foreach (var question in Question)
            {
                question.ShowQuestion();
                Console.WriteLine("------------------------");
                Console.Write("Enter your answer :");
                int answer = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------");
                Console.Clear();
            }
            foreach (var question in Question)

                Console.WriteLine("Correct Answer: " + question.AnswerList[question.CorrectAnswerIndex - 1].AnswerText);

        }
    }
}