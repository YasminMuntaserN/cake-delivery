using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Configuration;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class DataAccessHelper
    {
        // Create an instance of clsErrorLogger
        private static  clsErrorLogger _logger = new clsErrorLogger(clsErrorLogger.LogToEventViewer);

        // Method to handle exceptions and log them
        private static void HandleException(Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                _logger.LogError("Database Exception", ex);
            }
            else
            {
                _logger.LogError("General Exception", ex);
            }
        }

        // Insert a new record and return the new ID
        public static int? Add<T>(string storedProcedureName, string outputParameterName, T entity)
        {
            int? newId = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
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

        // Retrieve a All records
        public static List<T> GetAll<T>(string storedProcedureName, Func<IDataRecord, T> mapFunction)
        {
            var list = new List<T>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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

        // Delete record 
        public static bool Delete(string storedProcedureName, string parameterName, object? value)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameter for the ID or value used to identify the record to delete
                        command.Parameters.AddWithValue($"@{parameterName}", value ?? DBNull.Value);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            // If rowsAffected > 0, it means the record was successfully deleted
            return (rowsAffected > 0);
        }


        // Add parameters from a DTO object to a SqlCommand
        /// <summary>
        /// a helper method that dynamically adds parameters to a SqlCommand based on the properties of
        /// a given object (dto). This method uses reflection to inspect the properties of the object and 
        /// automatically create SQL parameters for each property. The parameters are then added to the
        /// SqlCommand, which is used in database operations like inserts, updates, etc.
        /// </summary>
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
