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
    public class RecordDAO : IRecordDAO
    {
        private static string _connectionString;

        public RecordDAO()
        {
            _connectionString = Configuration["Connnectionstrings:ConnectionStringHospital"];
        }

        public int Add(Record record)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_AddRecord", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter dateParam = new SqlParameter
                {
                    ParameterName = "@Date",
                    Value = record.Date
                };
                command.Parameters.Add(dateParam);

                SqlParameter idPatientParam = new SqlParameter
                {
                    ParameterName = "@IdPatient",
                    Value = 
                };
                command.Parameters.Add(idPatientParam);

                SqlParameter idDoctorParam = new SqlParameter
                {
                    ParameterName = "@IdDoctor",
                    Value = 
                };
                command.Parameters.Add(idDoctorParam);

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

        public void Delete(Record record)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteRecord", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = record.Id
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Record> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetRecords", connection);

                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return new Record()
                            {
                                Id = (int)reader["Id"],
                                Date = (Datetime)reader["Date"],
                                Patient = 
                                Doctor = 
                            };
                        }
                    }
                }
            }
        }

        public Record GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetRecordById", connection);

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
                            return new Record()
                            {
                                Id = (int)reader["Id"],
                                Date = (Datetime)reader["Date"],
                                Patient =
                                Doctor =
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
