namespace SourcePass.Models.Requests
{
    public class FormQuestionRequestModel
    {
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionID { get; set; }
        public int AnswerTypeID { get; set; }
        public string AnswerPreview { get; set; }
    }
}
