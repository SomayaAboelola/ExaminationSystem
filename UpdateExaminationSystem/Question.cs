using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateExaminationSystem
{
    public  class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public int CorrectAnswerIndex { get; set; }


        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new List<Answer>();
        }
        public Question() { }
        public virtual void ShowQuestion() { }


        public void AddAnswer(Answer answer)
        {
            AnswerList.Add(answer);
        }


    }
}

