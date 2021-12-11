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
            _connectionString = "Data Source=DESKTOP-ATJ1BBO;Initial Catalog=HospitalDB;Integrated Security=True";
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
                    Value = record.Patient.Id
                };
                command.Parameters.Add(idPatientParam);

                SqlParameter idDoctorParam = new SqlParameter
                {
                    ParameterName = "@IdDoctor",
                    Value = record.Doctor.Id
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
                SqlCommand command = new SqlCommand("sp_DeleteRecordById", connection);

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

                var recordsToReturn = new List<Record>();
                var records = new Dictionary<int, Record>();
                var appointments = new Dictionary<int, Appointment>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            records.Add((int)reader["Id"], new Record()
                            {
                                Id = (int)reader["Id"],
                                Date = (DateTime)reader["Date"]
                            });
                        }
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            appointments.Add((int)reader["IdRecord"], new Appointment()
                            {
                                Description = reader["Description"] as string,
                                Status = (Status)Enum.Parse(typeof(Status), reader["Name"] as string),
                                Record = new Record()
                        });
                        }
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            records.Where(r => r.Value.Id == (int)reader["Id"]).FirstOrDefault().Value.Patient = new Patient()
                            {
                                Id = (int)(reader["IdPatient"]),
                                Email = reader["Email"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                FullName = reader["FullName"] as string,
                                Appointments = new List<Appointment>()
                            };
                        }                    
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            records.Where(r => r.Value.Id == (int)reader["Id"]).FirstOrDefault().Value.Doctor = new Doctor()
                            {
                                Id = (int)(reader["IdDoctor"]),
                                Email = reader["Email"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                FullName = reader["FullName"] as string,
                                Appointments = new List<Appointment>()
                            };
                        }
                    }
                }

                foreach (var record in records)
                {
                    foreach (var appointment in appointments)
                    {
                        record.Value.Appointment = appointments[record.Key];
                        appointment.Value.Record = records[appointment.Key];
                    }
                    recordsToReturn.Add(record.Value);
                }
                return recordsToReturn;
            }
        }

        public Record GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetRecordById", connection);

                command.CommandType = CommandType.StoredProcedure;

                var record = new Record();
                var appointment = new Appointment();

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
                            record.Id = (int)reader["Id"];
                            record.Date = (DateTime)reader["Date"];
                        }
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            appointment.Id = id;
                            appointment.Description = reader["Description"] as string;
                            appointment.Status = (Status)Enum.Parse(typeof(Status), reader["Name"] as string);
                        }
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            record.Patient = new Patient()
                            {
                                Id = (int)(reader["IdPatient"]),
                                Email = reader["Email"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                FullName = reader["FullName"] as string,
                                Appointments = new List<Appointment>()
                            };
                        }
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            record.Doctor = new Doctor()
                            {
                                Id = (int)(reader["IdDoctor"]),
                                Email = reader["Email"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                FullName = reader["FullName"] as string,
                                Appointments = new List<Appointment>()
                            };
                        }
                    }
                }

                record.Appointment = appointment;
                appointment.Record = record;

                return record;
            }
        }
    }
}
