using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateExaminationSystem
{
    public class Mcq
    {
        public class MCQ : Question

        {
            public MCQ(string header, string body, int mark) : base(header, body, mark)
            {
                AnswerList = new List<Answer>();

            }

            public override void ShowQuestion()
            {
                Console.WriteLine($"MCQ Choose one Question \t \t  ({Mark})");
                Console.WriteLine($"Question: {Body}");
                Console.WriteLine("Option Answers:");
                for (int i = 0; i < AnswerList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {AnswerList[i].AnswerText}");
                }
            }

        }
    }
}
