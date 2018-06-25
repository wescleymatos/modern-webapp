using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ModernStore.Domain.Commands.Outputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context.Customers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public GetCustomerCommandResult Get(string username)
        {
            //Utilizando EF

            //return _context.Customers
            //    .Include(x => x.User)
            //    .AsNoTracking()
            //    .Select(x => new GetCustomerCommandResult
            //    {
            //        Name = x.Name.ToString(),
            //        Document = x.Document.Number,
            //        Email = x.Email.Address,
            //        Password = x.User.Password,
            //        Username = x.User.UserName
            //    })
            //    .FirstOrDefault(x => x.Username == username);

            var query = "SELECT * FROM [Nome_Tabela] WHERE username = @username";

            using (var conn = new SqlConnection("ModernStoreConnectionString"))
            {
                conn.Open();

                return conn.Query<GetCustomerCommandResult>(query, new { username }).FirstOrDefault();
            }
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
