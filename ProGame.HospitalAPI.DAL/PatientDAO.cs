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
            _connectionString = Configuration["Connnectionstrings:ConnectionStringHospital"];
        }

        public int Add(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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

                command.ExecuteNonQuery();

                return (int)command.Parameters["@Id"].Value;
            }
        }

        public void Delete(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeletePatient", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = patient.Id
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetPatients", connection);

                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Patient()
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
        }

        public Patient GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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
                        while (reader.Read())
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

        public void Update(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
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
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
        }
    }
}
