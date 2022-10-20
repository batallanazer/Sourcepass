using SourcePass.Repositories.Entities;
using SourcePass.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcePass.Services.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IFormQuestionRepository _formQuestionRepository;
        public FormService(IFormRepository formRepository, IFormQuestionRepository formQuestionRepository)
        {
            _formRepository = formRepository;
            _formQuestionRepository = formQuestionRepository;

        }
        public async Task<int> CreateForm(Form form, List<FormQuestion> questions)
        {
            try
            {
                var formResponse = await _formRepository.Insert(form);
                foreach (var question in questions)
                {
                    question.FormID = formResponse.ID;
                    await _formQuestionRepository.Insert(question);
                }
                return formResponse.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
