using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Chinook_part2.Models;
using System.Linq;
using Dapper;

namespace Chinook_part2.Data
{
    public class ChinookRepository
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True";


        public List<Customer> GetCustomersByCountry(string country)
        {
            var sql = @"select 
                            *
                        from Customer
                        where Customer.Country = @country";

            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Customer>(sql, new { Country = country}).ToList();
            }
        }

        public List<Employee> GetEmployeesByTitle(string title)
        {
            var sql = @"select 
                           *
                        from Employee
                        where Title = @title";

            using(var db = new SqlConnection(ConnectionString))
            {
                return db.Query<Employee>(sql, new { Title = title }).ToList();
            }
        }

        public int GetSalesAgentCustomerCount(int id)
        {
            var sql = @"select count(*) 
                        from Employee as e
                        join Customer as c on e.EmployeeId = c.SupportRepId
                        where e.employeeId = @Id";

            using (var db = new SqlConnection(ConnectionString))
            {
                return db.QueryFirstOrDefault<int>(sql, new { Id = id });
            }
        }

        public IEnumerable<Employee> GetTopSalesAgent()
        {
            var sql = @"select 
                            Top(1) e.EmployeeId, 
                            SUM(i.Total) as TotalSales, 
                            e.LastName, 
                            e.FirstName from Invoice as i
                        left join customer as c on i.CustomerId = c.CustomerId
                        left join Employee as e on c.SupportRepId = e.EmployeeId
                        group by e.EmployeeId, e.LastName, e.FirstName
                        order by SUM(i.Total) desc";
            using (var db = new SqlConnection(ConnectionString))
            {
                var employee = db.Query<Employee>(sql);
                return employee;
            }
        }
    }
}