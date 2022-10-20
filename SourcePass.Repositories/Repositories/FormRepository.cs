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
    public class FormRepository : IFormRepository
    {
        private readonly DataContext _context;
        public FormRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Form> Insert(Form model)
        {
            var procedureName = "InsertForm";
            var parameters = new DynamicParameters();
            parameters.Add("Title", model.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("Description", model.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("CategoryID", model.CategoryID, DbType.Int32, ParameterDirection.Input);
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
