using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Entities
{
    public class stackoverflow
    {
        public Survey SurveyDetails { get; set; }

        public List<QuestionSet> SurveyQuestions { get; set; }
    }

    public class Survey
    {
        public int Id { get; set; } = 0;
        public string SurveyName { get; set; } = "a";
        public int IntroId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public string IntroName { get; set; }
        public string Intro { get; set; }
        public string Conclusion { get; set; }
    }

    public class QuestionSet
    {
        public int? SubQuestionOf { get; set; } = 1;
        public int Order { get; set; }
        public bool RepeatPerUser { get; set; }
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Q_Text { get; set; }
        public string SubText { get; set; }
        public string TableTitle { get; set; }
        public string Format { get; set; }
        public string OptionsGroup { get; set; }
        public string DBViewName { get; set; }
        public string Header { get; set; }
        public int? Minimum { get; set; }
        public int? Maximum { get; set; }
        public int? Interval { get; set; }
        public int SelectedOption { get; set; }
        public bool Selected { get; set; }
    }


}