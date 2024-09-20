using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DataAccessHelper
    {
        private static readonly ErrorLogger _logger = new ErrorLogger(LogHandler.LogToEventViewer);

        // Method to handle exceptions and log them
        private static void HandleException(Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                _logger.LogError("Database Exception", sqlEx);
            }
            else
            {
                _logger.LogError("General Exception", ex);
            }
        }

        // Insert a new record and return the new ID
        public static int? Add<T>(string storedProcedureName, string outputParameterName, T entity, Func<IDataRecord, T> mapFunction)
        {
            int? newId = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters from the DTO
                        AddParametersFromDto(command, entity);

                        // Add output parameter to get the new ID
                        SqlParameter outputIdParam = new SqlParameter($"@{outputParameterName}", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newId = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return newId;
        }

        // Update an existing record
        public static bool Update<T>(string storedProcedureName, T entity)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters from the DTO
                        AddParametersFromDto(command, entity);

                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (rowAffected > 0);
        }

        // Retrieve a single record by ID
        public static T? GetById<T>(string storedProcedureName, string parameterName, object? value, Func<IDataRecord, T> mapFunction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue($"@{parameterName}", value ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return mapFunction(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return default;
        }

        // Retrieve all records with optional parameters
        public static List<T> GetAll<T>(string storedProcedureName, Func<IDataRecord, T> mapFunction, params (string name, object? value)[] parameters)
        {
            var list = new List<T>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add optional parameters to the command
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue($"@{parameter.name}", parameter.value ?? DBNull.Value);
                        }

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = mapFunction(reader);
                                list.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        // Add parameters from a DTO object to a SqlCommand
        private static void AddParametersFromDto<T>(SqlCommand command, T dto)
        {
            // Use reflection to add parameters dynamically
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(dto);
                var parameter = new SqlParameter($"@{property.Name}", value ?? DBNull.Value);
                command.Parameters.Add(parameter);
            }
        }
    }
}
}
