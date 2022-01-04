using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BestBuyBestPractices
{
    internal class DapperProductRepo : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }
            
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("Insert Into Products " +
            "(Name, Price, CategoryID) Values (@name, @price, @categoryID);",
            new { name, price, categoryID });
        }

        public IEnumerable<Product> GetAll()
        {
            return _connection.Query<Product>("Select * From Products;");
        }
    }
}
