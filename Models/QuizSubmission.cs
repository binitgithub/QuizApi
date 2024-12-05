using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Models
{
    public class QuizSubmission
    {
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
    }
}