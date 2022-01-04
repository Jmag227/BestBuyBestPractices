using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var depRepo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Add a new Department");
            var newDepartment = Console.ReadLine();
            depRepo.InsertDepartment(newDepartment);
            var allDepartments = depRepo.GetAllDepartments();
            foreach (var dep in allDepartments)
            {
                Console.WriteLine(dep.Name);
                Console.WriteLine();
            }


            Console.WriteLine();
            var proRepo = new DapperProductRepo(conn);
            Console.WriteLine("Add a new Product! We need three things. A name, a price, and a number ID for it!");
            Console.WriteLine("Input a name for your product!");           
            string name = Console.ReadLine();
            Console.WriteLine("Input a price for your Product");
            double price;
            double.TryParse(Console.ReadLine(), out price);
            Console.WriteLine("Now pick a number between 1-10 for the Category ID");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            proRepo.CreateProduct(name, price, id);
            Console.WriteLine();
            var allPro = proRepo.GetAll();
            foreach (var product in allPro)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine();
            }




        }
    }
}
