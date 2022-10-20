using Dapper;
using SourcePass.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcePass.Repositories.Repositories
{
    public class FormQuestionRepository : IFormQuestionRepository
    {
        private readonly DataContext _context;
        public FormQuestionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<FormQuestion> Insert(FormQuestion model)
        {
            var procedureName = "InsertFormQuestion";
            var parameters = new DynamicParameters();
            parameters.Add("Description", model.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("IsRequired", model.IsRequired, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("QuestionID", model.QuestionID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AnswerTypeID", model.AnswerTypeID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AnswerPreview", model.AnswerPreview, DbType.String, ParameterDirection.Input);
            parameters.Add("FormID", model.FormID, DbType.Int32, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var formID = await connection.QueryFirstOrDefaultAsync<int>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                model.ID = formID;

                return model;
            }
        }
    }
}
