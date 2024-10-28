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
using CakeDeliveryDTO.CakeDTOs;

namespace DataAccessLayer
{
    public class DataAccessHelper
    {
        // Create an instance of clsErrorLogger
        private static ErrorLogger _logger = new ErrorLogger(ErrorLogger.LogToEventViewer);

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
                Console.WriteLine("the error in the data access function" + ex);
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

        // Retrieve a single record by any parameter (ID, string, etc.)
        public static T? GetByParameter<T>(string storedProcedureName, string parameterName, object? value, Func<IDataReader, T> mapFunction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameter with dynamic type
                        command.Parameters.AddWithValue($"@{parameterName}", value ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Pass the reader to your mapping function
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

            return default; // Return default value if no result found
        }

        // Retrieve all records with a parameter
        public static List<T> GetAll<T>(string storedProcedureName, string parameterName, object? value, Func<IDataReader, T> mapFunction)
        {
            var list = new List<T>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameter with dynamic type
                        command.Parameters.AddWithValue($"@{parameterName}", value ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Pass the reader to your mapping function
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

        // Retrieve all records without any parameter
        public static List<T> GetAll<T>(string storedProcedureName, Func<IDataReader, T> mapFunction)
        {
            var list = new List<T>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                // Pass the reader to your mapping function
                                var item = mapFunction(reader);
                                list.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("the error here "+ex.Message);
                HandleException(ex);
            }
            return list;
        }

        // Delete a record
        public static bool Delete(string storedProcedureName, string parameterName, object? value)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
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

            return (rowsAffected > 0);
        }

        public static List<T> All<T, T1, T2>(string storedProcedureName, string parameterName1, T1 value1, string parameterName2, T2 value2) where T : class
        {
            List<T> results = new List<T>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@{parameterName1}", (object)value1 ?? DBNull.Value);
                        command.Parameters.AddWithValue($"@{parameterName2}", (object)value2 ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Instead of using Activator, we directly construct the CakeDTO (or any other DTO)
                                if (typeof(T) == typeof(CakeDTO))
                                {
                                    var cakeDto = new CakeDTO(
                                        reader["CakeID"] as int?,
                                        reader["CakeName"].ToString(),
                                        reader["Description"].ToString(),
                                        (decimal)reader["Price"],
                                        (int)reader["StockQuantity"],
                                        (int)reader["CategoryID"],
                                        reader["ImageUrl"].ToString()
                                    );
                                    results.Add(cakeDto as T);
                                }
                                // Add similar blocks for other DTOs if needed
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                HandleException(ex);
            }

            return results;
        }

        public static void GetTotalPagesAndRows(int categoryId, int pageSize, out int totalRows, out int totalPages)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetTotalPagesAndRows", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    SqlParameter totalRowsParam = new SqlParameter("@TotalRows", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(totalRowsParam);


                    SqlParameter totalPagesParam = new SqlParameter("@TotalPages", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(totalPagesParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    totalRows = (int)totalRowsParam.Value;
                    totalPages = (int)totalPagesParam.Value;
                }
            }
        }

        public static bool Exists<T1, T2>(string storedProcedureName, string parameterName1, T1 value1, string parameterName2, T2 value2)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@{parameterName1}", (object)value1 ?? DBNull.Value);
                        command.Parameters.AddWithValue($"@{parameterName2}", (object)value2 ?? DBNull.Value);

                        SqlParameter returnParameter = new SqlParameter("@ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();

                        isFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                HandleException(ex);
            }

            return isFound;
        }

        // Add parameters from a DTO object to a SqlCommand
        /// <summary>
        /// A helper method that dynamically adds parameters to a SqlCommand based on the properties of
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
