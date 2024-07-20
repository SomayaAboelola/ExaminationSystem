using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateExaminationSystem
{
    public class TFQ :Question
    {
        public TFQ(string header, string body, int mark) : base(header, body, mark)
        {
            AnswerList = new List<Answer>();
            AnswerList.Add(new Answer(1, "True"));
            AnswerList.Add(new Answer(2, "False"));


        }
        public override void ShowQuestion()
        {
            Console.WriteLine($"True | False Question  \t \t  ({Mark})");
            Console.WriteLine($"Question: {Body}");

            foreach (var answer in AnswerList)
            {

                Console.Write($"{answer.AnswerId}-{answer.AnswerText} \t \t ");

            }
            Console.WriteLine();
        }
    }
}
