using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Computer> GetAll([FromServices] IConfiguration configuration)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("Database")))
            {
                connection.Open();

                var command = new SqlCommand($"SELECT * FROM [Computer]", connection);

                var reader = command.ExecuteReader();

                var computers = new List<Computer>();

                while(reader.Read())
                {
                    computers.Add(new Computer(
                        (int)reader["Number"],
                        (int)reader["AssembledYear"],
                        (string)reader["Building"],
                        (int)reader["RoomNo"]
                    ));
                }

                reader.Close();

                return computers;
            }
        }
    }
}
