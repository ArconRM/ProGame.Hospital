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
    public class DoctorDAO : IDoctorDAO
    {
        private static string _connectionString;

        public DoctorDAO()
        {
            _connectionString = "Data Source=DESKTOP-ATJ1BBO;Initial Catalog=HospitalDB;Integrated Security=True";
        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_AddDoctor", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter fullNameParam = new SqlParameter
                {
                    ParameterName = "@FullName",
                    Value = doctor.FullName
                };
                command.Parameters.Add(fullNameParam);

                SqlParameter phoneNumberParam = new SqlParameter
                {
                    ParameterName = "@PhoneNumber",
                    Value = doctor.PhoneNumber
                };
                command.Parameters.Add(phoneNumberParam);

                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = doctor.Email
                };
                command.Parameters.Add(emailParam);

                SqlParameter idSpecialityParam = new SqlParameter
                {
                    ParameterName = "@IdSpeciality",
                    Value = (int)doctor.Speciality
                };
                command.Parameters.Add(idSpecialityParam);

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

        public async Task DeleteDoctorAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_DeleteDoctorById", connection);

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

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_GetDoctors", connection);

                command.CommandType = CommandType.StoredProcedure;

                var result = new List<Doctor>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(await reader.ReadAsync())
                        {
                            result.Add(new Doctor()
                            {
                                Id = (int)reader["Id"],
                                FullName = reader["FullName"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                Email = reader["Email"] as string,
                                Speciality = (Specialities)Enum.Parse(typeof(Specialities), reader["Speciality"] as string)
                            });
                        }
                    }
                }
                return result;
            }
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_GetDoctorById", connection);

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
                            return new Doctor()
                            {
                                Id = (int)reader["Id"],
                                FullName = reader["FullName"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                Email = reader["Email"] as string,
                                Speciality = (Specialities)Enum.Parse(typeof(Specialities), reader["Speciality"] as string)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("sp_UpdateDoctorById", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter fullNameParam = new SqlParameter
                {
                    ParameterName = "@FullName",
                    Value = doctor.FullName
                };
                command.Parameters.Add(fullNameParam);

                SqlParameter phoneNumberParam = new SqlParameter
                {
                    ParameterName = "@PhoneNumber",
                    Value = doctor.PhoneNumber
                };
                command.Parameters.Add(phoneNumberParam);

                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = doctor.Email
                };
                command.Parameters.Add(emailParam);

                SqlParameter idSpecialityParam = new SqlParameter
                {
                    ParameterName = "@IdSpeciality",
                    Value = (int)doctor.Speciality
                };
                command.Parameters.Add(idSpecialityParam);

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = doctor.Id
                };
                command.Parameters.Add(idParam);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
