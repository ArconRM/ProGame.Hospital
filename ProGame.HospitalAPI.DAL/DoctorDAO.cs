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

        public int Add(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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

                command.ExecuteNonQuery();

                return (int)command.Parameters["@Id"].Value;
            }
        }

        public void Delete(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteDoctorById", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = doctor.Id
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetDoctors", connection);

                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            yield return new Doctor()
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
        }

        public Doctor GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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
                        while (reader.Read())
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

        public void Update(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
