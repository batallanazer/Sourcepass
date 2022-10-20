using SourcePass.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcePass.Services.Services
{
    public interface IFormService
    {
        Task<int> CreateForm(Form form, List<FormQuestion> question);
    }
}
