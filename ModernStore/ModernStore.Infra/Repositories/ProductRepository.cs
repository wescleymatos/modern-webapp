using Dapper;
using ModernStore.Domain.Commands.Outputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            var query = "SELECT * FROM [Nome_Tabela] WHERE username = @username";

            using (var conn = new SqlConnection("ModernStoreConnectionString"))
            {
                conn.Open();

                return conn.Query<GetProductListCommandResult>(query);
            }
        }
    }
}
