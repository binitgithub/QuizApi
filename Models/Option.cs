using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; } // Foreign key to Question
    }
}