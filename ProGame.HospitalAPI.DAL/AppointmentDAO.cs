using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL
{
    public class AppointmentDAO : IAppointmentDAO
    {
        private static string _connectionString;

        public AppointmentDAO()
        {
            _connectionString = Configuration["Connnectionstrings:ConnectionStringHospital"];
        }

        public void Update(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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
                    //ParameterName = "@Status",
                    //Value = appointment.IsCancelled
                };
                command.Parameters.Add(idSpecialityParam);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
