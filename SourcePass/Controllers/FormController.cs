using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SourcePass.Models.Requests;
using SourcePass.Repositories.Entities;
using SourcePass.Services.Services;

namespace SourcePass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _service;
        public FormController(IFormService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FormRequestModel model)
        {
            try
            {
                var form = new Form { 
                    Description = model.Description,
                    CategoryID = model.CategoryID,
                    Title = model.Title
                };
                var questions = model.Questions.Select(i => new FormQuestion
                {
                    AnswerPreview = i.AnswerPreview,
                    AnswerTypeID = i.AnswerTypeID,
                    Description = i.Description,
                    IsRequired = i.IsRequired,
                    QuestionID = i.QuestionID,
                }).ToList();

                var response = await _service.CreateForm(form, questions);
                return Ok(response);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
