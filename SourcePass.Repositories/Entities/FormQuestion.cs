using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcePass.Repositories.Entities
{
    public class FormQuestion
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionID { get; set; }
        public int AnswerTypeID { get; set; }
        public string AnswerPreview { get; set; }
        public int FormID { get; set; }
    }
}
