using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProGame.HospitalAPI.Common.Entities.Options;
using Microsoft.Extensions.Options;

namespace ProGame.HospitalAPI.DAL
{
    public class AppointmentDAO : IAppointmentDAO
    {
        private static string _connectionString;

        public AppointmentDAO(IOptions<OptionsBaseDAO> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_UpdateAppointmentById", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter fullNameParam = new SqlParameter
                {
                    ParameterName = "@Description",
                    Value = appointment.Description
                };
                command.Parameters.Add(fullNameParam);

                SqlParameter idSpecialityParam = new SqlParameter
                {
                    ParameterName = "@IdStatus",
                    Value = (int)appointment.Status
                };
                command.Parameters.Add(idSpecialityParam);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = appointment.Id
                };
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
