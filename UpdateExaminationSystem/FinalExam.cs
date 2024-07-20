using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static UpdateExaminationSystem.Mcq;

namespace UpdateExaminationSystem
{
    public class FinalExam : Exam
    {
        public FinalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {

        }
        int choice, correctIndex;
        public override void CreateExam()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Enter Question {i + 1}:");

                Question question = new Question();

                Console.WriteLine("Choose the type of question:");
                Console.WriteLine("1. True or False");
                Console.WriteLine("2. Multiple Choice");

                do { Console.Write("Enter your choice: ");
                   } while (int.TryParse(Console.ReadLine(), out choice) && (choice <1 ||choice >2));
               

                Console.Clear();
           int mark ;
           int correctAnswer;
                switch (choice)
                {
                     
                    case 1:
                        question.Header = "True | False ";
                        Console.WriteLine(question.Header);

                        Console.WriteLine("Enter the body of the question: ");
                        question.Body = Console.ReadLine() ?? "Not valid";

                      
                    do  {   Console.Write("Enter the mark for question: ");
                         } while (int.TryParse(Console.ReadLine(), out mark) && (mark < 1));

                        question.Mark = mark;

                        question = new TFQ(question.Header, question.Body, question.Mark);

                        do
                        {
                            Console.Write("Enter the correct answer (1=true|2=false): ");
                        } while (int.TryParse(Console.ReadLine(), out correctAnswer) && (correctAnswer < 1 || correctAnswer > 2));
                      
                      //  question.AddAnswer(new Answer(1, correctAnswer.ToString()));
                        question.CorrectAnswerIndex = correctAnswer;

                        break;
                    case 2:
                        question.Header = "MCQ Choise One Answer";
                        Console.WriteLine(question.Header);
                        Console.WriteLine("Enter the body of the question: ");
                        question.Body = Console.ReadLine() ?? "Not valid" ;

                        do
                        {
                          Console.Write("Enter the mark for question: ");
                        } while (int.TryParse(Console.ReadLine(), out mark) && (mark < 1));
                        question.Mark =mark;

                        question = new MCQ(question.Header, question.Body, question.Mark);


                        Console.WriteLine("Enter the number of answer choices: ");

                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write($"Enter answer choice {j + 1}: ");
                            string choiceText = Console.ReadLine();
                            question.AddAnswer(new Answer(j + 1, choiceText));
                        }
                        do {
                            Console.Write("Enter the index of the correct answer: ");
                        } while  ( int.TryParse(Console.ReadLine() ,out  correctIndex)  && (correctIndex < 1 || correctIndex >3));
                      
                        question.CorrectAnswerIndex = correctIndex;


                        break;
                    default:
                        Console.WriteLine("Invalid choice. Question creation canceled.");
                        return;
                }
                Console.WriteLine("-----------------------------------");
                Question.Add(question);
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine("Final Exam:");
            int totalMarks = 0;

            foreach (var question in Question)
            {
                question.ShowQuestion();

                Console.WriteLine("------------------------");
                int answer;
                do {
                    Console.Write("Enter your answer :");
                }   while(int.TryParse(Console.ReadLine(),out answer) && (answer <1 && answer >3 ));
                
                Console.WriteLine("---------------------");

                if (question.CorrectAnswerIndex == answer)
                {
                    totalMarks = question.Mark;
                }
                else totalMarks = 0;



            }
            Console.Clear();

            Console.WriteLine("Your Answers :");
            foreach (var question1 in Question)
            {
                Console.Write($"Q{Question.IndexOf(question1) + 1})   {question1.Body} ");

                Console.WriteLine("    :" + question1.AnswerList[question1.CorrectAnswerIndex - 1].AnswerText);

                Console.WriteLine($" your Grade is {totalMarks} from {question1.Mark}");

            }

        }
    }
}