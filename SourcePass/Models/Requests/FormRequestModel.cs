namespace SourcePass.Models.Requests
{
    public class FormRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
        public List<FormQuestionRequestModel> Questions { get; set; }
    }
}
