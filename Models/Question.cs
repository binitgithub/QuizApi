using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Option> Options { get; set; }
        public int CorrectOptionId { get; set; } // References the correct option
    }
}