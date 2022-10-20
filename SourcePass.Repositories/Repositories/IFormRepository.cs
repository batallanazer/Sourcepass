using SourcePass.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcePass.Repositories.Repositories
{
    public interface IFormRepository
    {
        Task<Form> Insert(Form model);
    }
}
