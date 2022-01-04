using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public void CreateProduct(string name, double price, int categoryID);
    }
}
