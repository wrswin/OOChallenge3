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
    public class ClassController : ControllerBase
    {
        [HttpGet("{classCode}")]
        public ActionResult<Class> Get([FromServices] IConfiguration configuration, string classCode)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("Database")))
            {
                connection.Open();

                var command = new SqlCommand($"SELECT * FROM [Class] C where C.ClassCode = '{classCode}'", connection);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var class_ = new Class(
                        (string)reader["ClassCode"],
                        (string)reader["Name"],
                        (string)reader["Building"],
                        (int)reader["RoomNo"]
                    );

                    reader.Close();

                    return class_;
                }
                else
                {
                    reader.Close();

                    return NotFound();
                }
            }
        }
    }
}
