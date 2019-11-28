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
    public class RoomsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Room> GetAll([FromServices] IConfiguration configuration)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("Database")))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [Room]", connection);

                var reader = command.ExecuteReader();

                var rooms = new List<Room>();

                while(reader.Read())
                {
                    rooms.Add(new Room(
                        (string)reader["Building"],
                        (int)reader["RoomNo"],
                        (int)reader["Capacity"]
                    ));
                }

                reader.Close();

                return rooms;
            }
        }

        [HttpGet("unused")]
        public IEnumerable<Room> GetUnused([FromServices] IConfiguration configuration)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("Database")))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [Room] R WHERE (SELECT COUNT(*) FROM [Class] C WHERE C.RoomNo = R.RoomNo and C.Building = R.Building) = 0", connection);

                var reader = command.ExecuteReader();

                var rooms = new List<Room>();

                while (reader.Read())
                {
                    rooms.Add(new Room(
                        (string)reader["Building"],
                        (int)reader["RoomNo"],
                        (int)reader["Capacity"]
                    ));
                }

                reader.Close();

                return rooms;
            }
        }
    }
}
