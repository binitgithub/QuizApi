using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Data;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuizController(QuizDbContext context)
        {
            _context = context;
        }

    // GET: api/Quiz
    [HttpGet]
    public IActionResult GetQuestions()
    {
        var questions = _context.Questions
            .Include(q => q.Options)
            .ToList();
        return Ok(questions);
    }
    // POST: api/Quiz/Submit
    [HttpPost("submit")]
    public IActionResult SubmitQuiz([FromBody] List<QuizSubmission> submissions)
    {
        int score = 0;

        foreach (var submission in submissions)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == submission.QuestionId);
            if (question != null && question.CorrectOptionId == submission.SelectedOptionId)
            {
                score++;
            }
        }

        return Ok(new { Score = score });
    }
    
    }
}