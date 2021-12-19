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
    public class PatientDAO : IPatientDAO
    {
        private static string _connectionString;

        public PatientDAO()
        {
            _connectionString = "Data Source=DESKTOP-ATJ1BBO;Initial Catalog=HospitalDB;Integrated Security=True";
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_AddPatient", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter fullNameParam = new SqlParameter
                {
                    ParameterName = "@FullName",
                    Value = patient.FullName
                };
                command.Parameters.Add(fullNameParam);

                SqlParameter phoneNumberParam = new SqlParameter
                {
                    ParameterName = "@PhoneNumber",
                    Value = patient.PhoneNumber
                };
                command.Parameters.Add(phoneNumberParam);

                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = patient.Email
                };
                command.Parameters.Add(emailParam);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();

                return (int)command.Parameters["@Id"].Value;
            }
        }

        public async Task DeletePatientByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_DeletePatientById", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_GetPatients", connection);

                command.CommandType = CommandType.StoredProcedure;

                var result = new List<Patient>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new Patient()
                            {
                                Id = (int)reader["Id"],
                                FullName = reader["FullName"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                Email = reader["Email"] as string
                            });
                        }
                    }
                }
                return result;
            }
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_GetPatientById", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            return new Patient()
                            {
                                Id = (int)reader["Id"],
                                FullName = reader["FullName"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                Email = reader["Email"] as string
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_UpdatePatientById", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter fullNameParam = new SqlParameter
                {
                    ParameterName = "@FullName",
                    Value = patient.FullName
                };
                command.Parameters.Add(fullNameParam);

                SqlParameter phoneNumberParam = new SqlParameter
                {
                    ParameterName = "@PhoneNumber",
                    Value = patient.PhoneNumber
                };
                command.Parameters.Add(phoneNumberParam);

                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = patient.Email
                };
                command.Parameters.Add(emailParam);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = patient.Id
                };
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
