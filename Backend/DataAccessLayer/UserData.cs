
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CakeDeliveryDTO.UserDtos;

namespace DataAccessLayer
{
    public class UserData
    {
        /// <summary>
        /// Adds a new User to the database.
        /// </summary>
        /// <param name="User">UserCreateDto with User data.</param>
        /// <returns>The new UserID if successful, otherwise null.</returns>
        public static int? Add(UserCreateDTO User)
        {
            return DataAccessHelper.Add(
                "sp_AddNewUser",
                "NewUserID",
                User
            );
        }


        /// <summary>
        /// Retrieves a User by its ID.
        /// </summary>
        /// <param name="UserId">The ID of the User to find.</param>
        /// <returns>UserDTO if found, otherwise null.</returns>
        public static UserDTO? GetUserById(int? UserId)
        {
            return DataAccessHelper.GetByParameter<UserDTO>(
                "sp_GetUserById",
                "UserID",
                UserId,
                Mappings.MapUserDTOFromReader
            );
        }

        /// <summary>
        /// Updates an existing User in the database.
        /// </summary>
        /// <param name="UserToUpdate">UserDTO with updated User data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateUser(UserDTO UserToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateUser",
                UserToUpdate
            );
        }


        /// <summary>
        /// Retrieves all Users from the database.
        /// </summary>
        /// <returns>A list of UserDTO objects.</returns>
        public static List<UserDTO> GetAllUsers()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllUsers",
                Mappings.MapUserDTOFromReader
            );
        }


        public static bool ExsistByPasswordAndEmail(string Email , string Password)
        {
            return DataAccessHelper.Exists(
                "sp_ExsistByEamilAndPassword",
                "Email",
                Email,
                "Password",
                Password
            );
        }
    
    }
}
