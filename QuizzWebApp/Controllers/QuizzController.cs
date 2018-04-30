using QuizzWebApp.Models;
using QuizzWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizzWebApp.Controllers
{
    public class QuizzController : Controller
    {
        public DbQuizzEntities dbContext = new DbQuizzEntities();

        // GET: Quizz
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult QuizzSettings()
        {
            QuizzModeVM modeList = new QuizzModeVM();
            modeList.Modes = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="Yes or No", Value= "0"},
                new SelectListItem(){ Text="3 Choices", Value= "1"},
            };

            return View(modeList);
        }

        [HttpPost]
        public ActionResult QuizzSettings(QuizzModeVM quizMode)
        {
            Session["SelectedMode"] = quizMode.Mode;

            return RedirectToAction("QuizzView");
        }

        [HttpGet]
        public ActionResult QuizzView()
        {
            int selectedMode = (int)Session["SelectedMode"];

            Random rand = new Random();
            int toSkip = rand.Next(0, dbContext.QuestionTables.Count());
            var tmpQ = dbContext.QuestionTables.OrderBy(x => x.Id).Skip(toSkip).Take(1).First();
            QuestionVM question = new QuestionVM()
            {
                QuestionID = tmpQ.Id,
                QuestionText = tmpQ.QuestionText,
                Anwser = tmpQ.Answer,
                Choices = new List<ChoiceVM>()
            };

            foreach (var c in tmpQ.ChoiceTables)
            {
                question.Choices.Add(new ChoiceVM() { ChoiceID = c.ID, ChoiceText = c.ChoiceText });
            }

            return View(question);
        }
    }
}