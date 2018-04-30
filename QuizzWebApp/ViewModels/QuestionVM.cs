using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizzWebApp.ViewModels
{
    public class QuestionVM
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string Anwser { get; set; }
        public string UserAnswer { get; set; }
        public ICollection<ChoiceVM> Choices { get; set; }
    }
}